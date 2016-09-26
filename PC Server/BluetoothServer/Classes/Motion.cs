using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluetoothServer
{
    /**
     * 모션제어
     */
    class Motion
    {
        MotionFuc mf = MotionFuc.getInstance();
    
        const int size = 3;
        int cnt = 0,cntO=0,cntM=0;
        static double[] cccX = new double[size];
        static double[] cccY = new double[size];
        static double[] cccZ = new double[size];

        static double[] oooX = new double[size + 2];
        static double[] oooY = new double[size + 2];
        static double[] oooZ = new double[size + 2];

        static double[] mmmX = new double[size + 2];
        static double[] mmmY = new double[size + 2];
        static double[] mmmZ = new double[size + 2];

        static double gravity_x = 0;
        static double gravity_y = 0;
        static double gravity_z = 0;

        static int notcnt = 0;

        String tmpArray = "";

        #region smoothings

        private double[] smoothing(double accX, double accY, double accZ)
        {
            double[] results = new double[3];
            double needX = 0;
            double needY = 0;
            double needZ = 0;

            cccX[cnt] = accX;
            cccY[cnt] = accY;
            cccZ[cnt] = accZ;
            for (int i = 0; i < size; i++)
            {
                needX += cccX[i];
                needY += cccY[i];
                needZ += cccZ[i];
            }
            needX = needX / size;
            needY = needY / size;
            needZ = needZ / size;
            needX = Convert.ToInt32(needX);
            needY = Convert.ToInt32(needY);
            needZ = Convert.ToInt32(needZ);

            results[0] = needX;
            results[1] = needY;
            results[2] = needZ;


            cnt++;
            if (cnt == size)
                cnt = 0;

            return results;
        }

        private double[] smoothing_O(double accX, double accY, double accZ)
        {
            double[] results = new double[3];
            double needX = 0;
            double needY = 0;
            double needZ = 0;

            oooX[cntO] = accX;
            oooY[cntO] = accY;
            oooZ[cntO] = accZ;
            for (int i = 0; i < size; i++)
            {
                needX += oooX[i];
                needY += oooY[i];
                needZ += oooZ[i];
            }
            needX = needX / size;
            needY = needY / size;
            needZ = needZ / size;
            needX = Convert.ToInt32(needX);
            needY = Convert.ToInt32(needY);
            needZ = Convert.ToInt32(needZ);

            results[0] = needX;
            results[1] = needY;
            results[2] = needZ;


            cntO++;
            if (cntO == size)
                cntO = 0;

            return results;
        }

        private double[] smoothing_M(double maX, double maY, double maZ)
        {
            double[] results = new double[3];
            double needX = 0;
            double needY = 0;
            double needZ = 0;

            mmmX[cntM] = maX;
            mmmY[cntM] = maY;
            mmmZ[cntM] = maZ;
            for (int i = 0; i < size; i++)
            {
                needX += mmmX[i];
                needY += mmmY[i];
                needZ += mmmZ[i];
            }
            needX = needX / size;
            needY = needY / size;
            needZ = needZ / size;
            needX = Convert.ToInt32(needX);
            needY = Convert.ToInt32(needY);
            needZ = Convert.ToInt32(needZ);

            results[0] = needX;
            results[1] = needY;
            results[2] = needZ;


            cntM++;
            if (cntM == size)
                cntM = 0;

            return results;
        }
        #endregion

        private void initArr()
        {
            cccX = new double[size];
            cccY = new double[size];
            cccZ = new double[size];
        }

        public String checkMotion(double accX, double accY, double accZ, double oriX, double oriY, double oriZ,double maX,double maY, double maZ,String mode)
        {
            String flag = "not";
            double[] resultH = new double[3];
            double[] resultO = new double[3];
            double[] resultM = new double[3];
            double accHX, accHY, accHZ;
            double oriOX, oriOY, oriOZ;
            double maMX, maMY, maMZ;

            gravity_x = 0.7 * gravity_x + (1 - 0.7) * accX;
            gravity_y = 0.7 * gravity_y + (1 - 0.7) * accY;
            gravity_z = 0.7 * gravity_z + (1 - 0.7) * accZ;

            accX = accX - gravity_x;
            accY = accY - gravity_y;
            accZ = accZ - gravity_z;

            resultH = smoothing(accX, accY, accZ);
            accHX = resultH[0];
            accHY = resultH[1];
            accHZ = resultH[2];


            resultO = smoothing_O(oriX, oriY, oriZ);
            oriOX = resultO[0];
            oriOY = resultO[1];
            oriOZ = resultO[2];

            resultM = smoothing_M(maX, maY, maZ);
            maMX = resultM[0];
            maMY = resultM[1];
            maMZ = resultM[2];


            if (oriZ != -720 && oriZ != 720)
            {
                if (accHY < -5 && oriOZ < -500)
                {
                    flag = "right";
                }
                if (accHY > 5 && oriOZ > 500)
                {
                    flag = "left";
                }
            }

            if (oriY != 720 && oriY != -720)
            {
                if (accHZ < -7 && oriOY > 250)
                {
                    flag = "up";
                }
                if (accHZ > 7 && oriOY < -200)
                {
                    flag = "down";
                }
            }


            //left rotation
            if (oriOX >= 400 && accHY >= 5 && accHZ <= -3)
                flag = "leftrotation";

            //right rotation
            if (oriOX <= -400 && accHY <= -5 && accHZ <= -2)
                flag = "rightrotation";


            switch (flag)
            {   
                case "left":
                    {
                            initArr();
                            tmpArray = tmpArray + "l";
                            notcnt = 0;
                            return ("////////////////// LEFT //////////////////");
    
                    }
                case "right":
                    {

                        {
                            initArr();
                            tmpArray = tmpArray + "r";
                            notcnt = 0;
                            return ("////////////////// RIGHT //////////////////");
                        }
 
                    }
                case "down":
                    {

                        {
                            initArr();
                            tmpArray = tmpArray + "d";
                            notcnt = 0;
                            return ("////////////////// DOWN //////////////////");
                        }
                    }
                case "up":
                    {
                        {
                            initArr();
                            tmpArray = tmpArray + "u";
                            notcnt = 0;

                            return ("////////////////// UP //////////////////");
                        }
                    }
                case "leftrotation":
                    {
                        {
                            initArr();
                            tmpArray = tmpArray + "o";
                            notcnt = 0;

                            return ("////////////////// LEFT RO //////////////////");
                        }
                    }
                case "rightrotation":
                    {
                        {
                            initArr();
                            tmpArray = tmpArray + "n";
                            notcnt = 0;

                            return ("////////////////// RIGHT RO //////////////////");
                        }
                    }
                default:
                    break;
            }
            if (flag == "not")
            {
                notcnt++;
                if (notcnt > 10 && mode != "4")
                {
                    mf.motioncheck2(tmpArray);
                    tmpArray = "";
                    notcnt = 0;
                }
            }
            return "";
        }
    }
}
