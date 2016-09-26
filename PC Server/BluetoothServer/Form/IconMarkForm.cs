using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BluetoothServer.IconHelper;
using System.Diagnostics;

namespace BluetoothServer
{
    public partial class IconMarkForm : Form
    {
        ProgramMark pm = new ProgramMark();
        PictureBox[] pictureBox;
        int pindex = 0;
        int previousindex = 0;
        int nCount = 0;
        int indexPositionY = 100;
     
        public IconMarkForm()
        {
           
            this.TopMost = true;
            InitializeComponent();
        }

        private void IconMarkForm_Load(object sender, EventArgs e)
        {
            paintIcon();

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            PictureBox pic = (PictureBox)sender;
            string str = pic.Tag.ToString();
            g.DrawString(str, this.Font, new SolidBrush(Color.Black), new PointF(3f, 3f));


        }

        public void startProcess()
        {
            Process.Start(pictureBox[pindex].Name);
        }

        private static Bitmap ResizeBitmap(Bitmap sourceBMP, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
                g.DrawImage(sourceBMP, 0, 0, width, height);
           
            return result;
        }
        private void CenterPictureBox(PictureBox picBox, Bitmap picImage)
        {
            picBox.Image = picImage;
            picBox.Location = new Point((picBox.Parent.ClientSize.Width / 2) - (picImage.Width / 2),
                                        (picBox.Parent.ClientSize.Height / 2) - (picImage.Height / 2));
            picBox.Refresh();
        }
        private void paintIcon()
        {
            Dictionary<string, string> programlist = pm.returnProgramlist();
            Bitmap myBitmap;
            int positionX = 30;
            int positionY = 220;
            int i = 0;
            pictureBox = new PictureBox[programlist.Count];


            nCount = programlist.Count;
            if (nCount > 10)
            {
                pindex = 5;
            }
            else {
                pindex = nCount / 2;
            }

            foreach (KeyValuePair<string, string> kvp in programlist)
            {

                Icon icn = IconReader.GetFileIcon(kvp.Value, IconReader.IconSize.Large, false);
                

                myBitmap = icn.ToBitmap();
                myBitmap = ResizeBitmap(myBitmap, 50, 50);
              //  CenterPictureBox(pictureBox[i], myBitmap);
                pictureBox[i] = new PictureBox();
                pictureBox[i].Name = kvp.Value;
                pictureBox[i].Tag = kvp.Key;

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
                pictureBox[i].BackColor = Color.Aqua;
                pictureBox[i].SizeMode = PictureBoxSizeMode.CenterImage;

                positionX += 100;

                i++;


            }
        }
        private void selectindex()
        {
            //글자
            indexName.Text = Convert.ToString(pictureBox[pindex].Tag);
        }
        //선택된 아이콘 up animation
        private void selectImage()
        {
            Point c = pictureBox[pindex].Location;
            Point c1 = pictureBox[previousindex].Location;
            pictureBox[pindex].Location = new Point(c.X, c.Y - indexPositionY);
        }

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
    }
}
