using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using BluetoothServer.Classes;

namespace BluetoothServer
{
    public partial class BoardForm : UserControl
    {
        MotionFuc mf = MotionFuc.getInstance();
        Motion mo = new Motion();
        MouseControl mc = new MouseControl();
        Processcheck ps = new Processcheck();//process control form
        AudioControl ac = new AudioControl();
        SettingMotionForm sf = SettingMotionForm.getInstance();
        Dictionary<string, string> b_motionlist = new Dictionary<string, string>();
        BluetoothDeviceInfo[] devices;
       
        string pdirection = "down";
        //device list items
        List<string> items;
        bool started = false;
        bool processform = false, markformchk=false;
        bool alPPT = false;
        bool alGOM = false;

        
        public BoardForm()
        {         
            items = new List<string>();            
            InitializeComponent();
        }


        Guid mUUID = new Guid("00001101-0000-1000-8000-00805F9B34FB");

        #region bluetooth connection
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            startScan();

        }


        private void startScan()
        {
            deviceList.DataSource = null;
            deviceList.Items.Clear();
            items.Clear();
            Thread bluetoothScanThread = new Thread(new ThreadStart(scan));
            bluetoothScanThread.Start();
        }

        private void scan()
        {
            motionbox("Starting Scan..");
            BluetoothClient client = new BluetoothClient();

            devices = client.DiscoverDevices(20, true, true, true, false);
            motionbox("Scan complete");
            motionbox(devices.Length.ToString() + " devices discovered");
            foreach (BluetoothDeviceInfo d in devices)
            {
                items.Add(d.DeviceName + " - " + d.DeviceAddress.ToString());
            }

            updateDeviceList();
        }
        private void updateDeviceList()
        {
            Func<int> del = delegate ()
            {
                deviceList.DataSource = items;
                return 0;
            };
            Invoke(del);
        }


        private void ClientConnectThread()
        {
            BluetoothClient client = new BluetoothClient();
            motionbox("attempting connect");
            client.BeginConnect(deviceInfo.DeviceAddress, mUUID, this.BluetoothClientConnectCallback, client);
        }

        string myPin = "1234";
        private bool pairDevice()
        {
            if (!deviceInfo.Authenticated)
            {
                if (!BluetoothSecurity.PairRequest(deviceInfo.DeviceAddress, myPin))
                {
                    return false;
                }
            }
            return true;
        }

        void BluetoothClientConnectCallback(IAsyncResult result)
        {
            try
            {
                BluetoothClient client = (BluetoothClient)result.AsyncState;
                client.EndConnect(result);//여기서 error : 블루투스 불이 들어와있는지 확인해야함

                Stream stream = client.GetStream();
                stream.ReadTimeout = 1000;
                int readmes = 0;
                string read;

                String packets = "";
                String[] st_S;
                while (stream.CanRead)
                {
                    try
                    {
                        byte[] message = new byte[1024];
                        readmes = stream.Read(message, 0, message.Length);
                        read = Encoding.ASCII.GetString(message, 0, readmes);

                        if (read.Contains('S'))
                        {
                            st_S = read.Split('S');
                            packets += st_S[0];
                            wrongpacket(packets);
                            
                            if (started)
                            {
                               // packetbox(packets);
                                splitdata(packets);
                            }
                            packets = st_S[1];
                            started = true;
                        }
                        else
                        {
                            packets = packets + read;
                        }
                    }
                    catch (Exception ex)
                    {
                        motionbox("0000error:" + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                motionbox("Where is your device?(I think your bluetooth device is turned off)");
            }
        }

        void wrongpacket(String data)
        {
            int cnt = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (data.Substring(i, 1).Equals("/"))
                    cnt++;
            }
            if (cnt != 9)
                started = false;
        }



        #endregion

        #region motion part
        public void splitdata(String data)
        {
            String result;
            String mode="0";
            String[] strsplit = data.Split('/');
            double accX, accY, accZ, oriX, oriY, oriZ, maX, maY, maZ;

            mode = strsplit[0];
            //oriX : [0], oriY : [1] : oriZ : [2] , accX : [3], accY :[4], accZ[5]
            oriX = Convert.ToDouble(strsplit[1]);
            oriY = Convert.ToDouble(strsplit[2]);
            oriZ = Convert.ToDouble(strsplit[3]);

            maX = Convert.ToDouble(strsplit[7]);
            maY = Convert.ToDouble(strsplit[8]);
            maZ = Convert.ToDouble(strsplit[9]);

            accX = Convert.ToDouble(strsplit[4]);
            accY = Convert.ToDouble(strsplit[5]);
            accZ = Convert.ToDouble(strsplit[6]);

  
            result = mo.checkMotion(accX / 10, accY / 10, accZ / 10, oriX, oriY, oriZ, maX, maY, maZ,mode);

            switch (mode)
            {
                case "1": //mouse Mode
                    closeProcessForm();
                   
                    //mouse controller  oriZ 증가 left, oriZ 감소 right, oriY 증가 down, oriY 감소가 up
                    if (oriX < 100 && oriX > -100)
                    {
                        mc.Mousemove((-1) * oriZ / 4.5, (-1) * oriY / 4);
                    }
                    else
                    {
                        if (result == "////////////////// LEFT RO //////////////////")
                            mc.Mouseclick(1);
                        if (result == "////////////////// RIGHT RO //////////////////")
                            mc.Mouseclick(2);
                    }
                    break;

                case "2":   //process Mode
                    closeMarkForm();
                    if (processform == false) {
                        processform = true;
                         startform();
                    }
                    else { 
                        processdirection((-1) * oriZ / 10, accZ);

                    }
                    break;
                case "3":   // programMark Mode
                    closeProcessForm();
                    if (markformchk == false)
                    {
                        markformchk = true;
                        markform();
                    }
                    else {
                        markprocessdirection((-1) * oriZ / 10, accZ);
                    }
                    break;
                case "4":   // Audio Mode
                    closeMarkForm();
                    if(result == "////////////////// RIGHT //////////////////") { 
                        ac.speakerSound();
                    }
                    else if(result == "////////////////// LEFT //////////////////")
                    {
                        ac.defaultSound();
                    }
                    alPPT = false;
                    break;
                case "5":   // PPT Mode
                    ppt_mode();

                    alGOM = false;
                    break;
                case "6":   // GomPlayer Mode
                    gomple_mode();
                    alPPT = false;
                    break;
            }
            
           
                packetbox(result);

        }
        #endregion

        #region when mode is changed, init
        public delegate void event_form();
        public void markform()
        {
            this.Invoke(new event_form(ps.prcoessStartForm));
        }
        //모드가 변경될때마다 꺼야 할 것들 넣으면 된다.
        void closeMarkForm()
        {
            //프로세스창 켜져있으면
            if (markformchk == true)
            {
                
                ps.processCloseForm();
                markformchk = false;
            }

        }        
        private void markprocessdirection(double oriZ, double accZ)
        {
            double dirtest = oriZ; /// 10;

            
            if (accZ > 140 && pdirection == "down")
            {
               
                pdirection = "up";
            }
            else if (accZ < -110 && pdirection == "up")
            {
                ps.startProcess();
                pdirection = "down";
            }
            else if (dirtest < -9 && (accZ > 70 && accZ < 100)) //&& accY > 20)
            {
                ps.markleftMove();

            }
            else if (dirtest > 9 && (accZ > 70 && accZ < 100))// && accY < -20)
            {
                ps.markrightMove();

            }

        }
        #endregion
        
        #region Mode ppt&Gomplayer
        private void gomple_mode()
        {
            if (!alGOM)
            {
                alGOM = true;
                sf.bmo(0);
            }

        }
        private void ppt_mode()
        {
            if (!alPPT)
            {
                alPPT = true;
                sf.bmo(1);
            }
        }
        
        #endregion

        #region process control


        public void startform()
        {
            this.Invoke(new event_form(ps.initform));
        }
        void closeProcessForm()
        {
            //프로세스창 켜져있으면
            if (processform == true)
            {
                ps.closeform();
                processform = false;
            }

        }
        private void processdirection(double oriZ,double accZ)
        {
            double dirtest = oriZ; /// 10;

  
            if (accZ > 140 && pdirection == "down")
            {  
                pdirection = "up";
            }else if (accZ < -110)
            {
                ps.killProcess();
                pdirection = "down";
            }else if (dirtest< -9 && (accZ > 70 && accZ < 100))
            {
                ps.leftMove();        
            }
            else if(dirtest > 9 && (accZ > 70 && accZ < 100))
            {
                ps.rightMove();
            }

        }
        #endregion

        #region output
        public void motionbox(string message)
        {


            Func<int> del = delegate ()
            {
                textBox1.AppendText(message + System.Environment.NewLine);
                return 0;
            };
            Invoke(del);

        }


        public void packetbox(string message)
        {
            Func<int> del = delegate ()
            {
                textBox2.AppendText(message + System.Environment.NewLine);
                return 0;
            };
            Invoke(del);

        }
        #endregion
       

        BluetoothDeviceInfo deviceInfo;
        private void deviceList_DoubleClick(object sender, EventArgs e)
        {
            deviceInfo = devices.ElementAt(deviceList.SelectedIndex);
            motionbox(deviceInfo.DeviceName + " was selected, attempting connect");
            if (pairDevice())
            {
                motionbox("device paired..");
                motionbox("starting connect thread");
                Thread bluetoothClientThread = new Thread(new ThreadStart(ClientConnectThread));
                bluetoothClientThread.Start();
                
            }
            else
            {
                motionbox("Pair failed");
            }
        }
    }

    public partial class CustomTextBox : TextBox
    {
        public CustomTextBox()
        {

            SetStyle(ControlStyles.SupportsTransparentBackColor |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.UserPaint, true);
            BackColor = Color.Transparent;
        }
    }
}
