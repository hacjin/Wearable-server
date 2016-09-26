using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BluetoothServer
{
    public partial class IconSlideForm : Form
    {
        Dictionary<int, string> controlprocesslist = new Dictionary<int, string>();
        PictureBox[] pictureBox;
        int pindex = 0;
        int previousindex = 0;
        int nCount = 0;
        int indexPositionY = 100;
        float OpacityImage = 1;

        public IconSlideForm(Dictionary<int, string> clist)
        {
            
            controlprocesslist = clist;
            nCount = controlprocesslist.Count;
            this.TopMost = true;
            InitializeComponent();
        }

        private void IconSlideForm_Load(object sender, EventArgs e)
        {

            if (nCount > 10)
            {
                pindex = 5;
            }
            else {
                pindex = nCount / 2;
            }
            paintIcon();
        }

        #region Icon control

        // icon setting
        private void paintIcon()
        {
            
           processnamelist pl = new processnamelist();
           Bitmap myBitmap;
           int positionX = 30;
           int positionY = 220;
           int i = 0;
           pictureBox = new PictureBox[nCount];

           foreach (KeyValuePair<int, string> kvp in controlprocesslist)
           {
               myBitmap = new Bitmap((Image)BluetoothServer.Properties.Resources.ResourceManager.GetObject(pl.isProcess(kvp.Value)));
               //myBitmap = new Bitmap((Image)BluetoothServer.Properties.Resources.kakaotalk);
              // myBitmap.MakeTransparent(Color.Magenta);
               pictureBox[i] = new PictureBox();
               pictureBox[i].Name = Convert.ToString(kvp.Key);
               pictureBox[i].Tag = kvp.Value;

               pictureBox[i].Size = new Size(100, 100);
               //first index = total /2, if total > 10 then index 5
               if (pindex == i)
               {
                   selectindex();
                  pictureBox[i].Location = new Point(positionX, positionY - indexPositionY);
               }
               else {
                   pictureBox[i].Location = new Point(positionX, positionY);
               }
               pictureBox[i].TabIndex = 10;
               pictureBox[i].TabStop = false;
               pictureBox[i].Visible = true;
               pictureBox[i].Parent = this;
               pictureBox[i].BorderStyle = BorderStyle.None;
               pictureBox[i].Image = myBitmap;
               pictureBox[i].Paint += new PaintEventHandler(Form1_Paint);
               pictureBox[i].Padding = new Padding(4, 0, 4, 0);




               positionX += 100;

               i++;
           }
           
        }
        //선택된 아이콘 up animation
        private void selectImage()
        {
            Point c = pictureBox[pindex].Location;
            Point c1 = pictureBox[previousindex].Location;
            pictureBox[pindex].Location = new Point(c.X, c.Y - indexPositionY);
        }
        //아이콘 삭제
        private void clearIcon()
        {
            for (int i = 0; i < nCount; i++)
            {

                if (pictureBox[i].Image != null)
                {
                    pictureBox[i].Image.Dispose();
                    pictureBox[i].Image = null;
                    pictureBox[i].Dispose();
                }
            }

        }

        #endregion

        #region image animation controls
        private void deleteAnimation()
        {
            OpacityImage = 1;
            removeAnimation();

        }
        private void removeAnimation()
        {
            
            //animation image
            pictureBox[pindex].Location = new Point(pictureBox[pindex].Location.X, pictureBox[pindex].Location.Y - 25);

            //Opacity image
            pictureBox[pindex].Image = ChangeOpacity(pictureBox[pindex].Image, OpacityImage);
            OpacityImage = OpacityImage - 0.05f;

            Invalidate();


            relocateImage();
            removeImage();
            selectImage();
            selectindex();
        }
        private void removeProcess(int pid)
        {
            ProcessStartInfo cmd = new ProcessStartInfo();
            Process process = new Process();
            cmd.FileName = @"cmd";
            cmd.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.CreateNoWindow = true;
            cmd.UseShellExecute = false;
            cmd.RedirectStandardOutput = true;
            cmd.RedirectStandardInput = true;
            cmd.RedirectStandardError = true;

            process.EnableRaisingEvents = false;
            process.StartInfo = cmd;
            process.Start();
            process.StandardInput.Write("@taskkill -f /PID " + pid + Environment.NewLine);
            process.StandardInput.Close();


            process.WaitForExit();
            process.Close();

        }
        //image delete
        private void removeImage()
        {

            int loop;

            removeProcessName("["+pictureBox[pindex].Tag + " 종료]");
            pictureBox[pindex].Image.Dispose();
            pictureBox[pindex].Image = null;
            pictureBox[pindex].Dispose();

            if (pindex != nCount)
            {
                for (loop = pindex; loop < nCount - 1; loop++)
                {
                    pictureBox[loop] = pictureBox[loop + 1];
                }
            }

            nCount--;

        }
        private void selectindex()
        {
            //글자
            indexName.Text = Convert.ToString(pictureBox[pindex].Tag);
        }
        private void removeProcessName(string pro)
        {
            deleteName.Text = pro;
        }
        //투명도 변환
        public Bitmap ChangeOpacity(Image img, float opacityvalue)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            Graphics graphics = Graphics.FromImage(bmp);
            ColorMatrix colormatrix = new ColorMatrix();
            colormatrix.Matrix33 = opacityvalue;
            ImageAttributes imgAttribute = new ImageAttributes();
            imgAttribute.SetColorMatrix(colormatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            graphics.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imgAttribute);
            graphics.Dispose();
            return bmp;
        }
        #endregion

        public void leftMove()
        {
            if (pindex > 0)
            {
                previousindex = pindex;
                pindex--;

                Point c = pictureBox[pindex].Location;
                Point c1 = pictureBox[previousindex].Location;

                pictureBox[pindex].Location = new Point(c.X, c.Y - indexPositionY);
                pictureBox[previousindex].Location = new Point(c1.X, c1.Y + indexPositionY);


                selectindex();
                iconMove();
            }
        }
        
        public void rightMove()
        {
            if (pindex < nCount - 1)
            {
                previousindex = pindex;
                pindex++;

                Point c = pictureBox[pindex].Location;
                Point c1 = pictureBox[previousindex].Location;

                pictureBox[pindex].Location = new Point(c.X, c.Y - indexPositionY);
                pictureBox[previousindex].Location = new Point(c1.X, c1.Y + indexPositionY);

                selectindex();
                iconMove();
            }
        }

        public void removeMove()
        {
            
            if (pindex != nCount)
            {
                removeProcess(Convert.ToInt16(pictureBox[pindex].Name));
                deleteAnimation();
            }
            else if (pindex > 0)
            {
                pindex--;
                removeProcess(Convert.ToInt16(pictureBox[pindex].Name));
                deleteAnimation();
            }
            else
            {
                MessageBox.Show("삭제시킬 것이 없습니다.");
            }
        }

        
        private void relocateImage()
        {
            int rightindex = 0;
            int leftindex = nCount;

            //오른쪽으로 땡기기
            if (pindex != 0)
            {
                for (rightindex = 0; rightindex < pindex; rightindex++)
                {
                    pictureBox[rightindex].Location = new Point(Convert.ToInt16(pictureBox[rightindex].Location.X + 100), pictureBox[rightindex].Location.Y);

                }
            }
        }

        public void iconMove()
        {
            int loop, moving = 80;


            if (pictureBox[pindex].Location.X >= 490)
            {
                for (loop = 0; loop < nCount; loop++)
                {

                    pictureBox[loop].Location = new Point(Convert.ToInt16(pictureBox[loop].Location.X - moving), pictureBox[loop].Location.Y);


                }
            }
            else if (pictureBox[pindex].Location.X <= 510)
            {
                for (loop = 0; loop < nCount; loop++)
                {

                    pictureBox[loop].Location = new Point(Convert.ToInt16(pictureBox[loop].Location.X + moving), pictureBox[loop].Location.Y);

                }
            }


        }
        

       
    
        void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            PictureBox pic = (PictureBox)sender;
            Pen pen = new Pen(Color.Red);
            string str = pic.Tag.ToString();
            //투명
          //  pic.BackColor = System.Drawing.Color.Transparent;

            g.DrawString(str, this.Font, new SolidBrush(Color.Black), new PointF(3f, 3f));


        }

    }
}

