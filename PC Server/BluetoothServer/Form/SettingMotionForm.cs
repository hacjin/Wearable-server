using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BluetoothServer.IconHelper;
using System.Runtime.InteropServices;
namespace BluetoothServer
{
    public partial class SettingMotionForm : UserControl
    {
        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern int SendMessage(int hwnd, int wMsg, int wParam, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, uint dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern int FindWindowEx(int hWnd1, int hWnd2, string lpsz1, string lpsz2);

        MotionFuc mf = MotionFuc.getInstance();
        Dictionary<string, string> motionlist = new Dictionary<string, string>();
        char[] tempsave = new char[17];

        //프로그램 즐겨찾기를 위함
        ProgramMark pm = new ProgramMark();

        private static SettingMotionForm one;

        public static SettingMotionForm getInstance()
        {
            if (one == null)
            {
                one = new SettingMotionForm();
            }
            return one;
        }

        //R,L,U,D 갯수
        int nCount = 0;
        PictureBox[] pictureBox = new PictureBox[17];
        public SettingMotionForm()
        {

            InitializeComponent();
            programMark();
        }

        #region Icon control
        private void paintIcon(string direction)
        {

            Bitmap myBitmap;
            int positionX = 10;
            int positionY = 108;

            positionX = (nCount - 1) * 40 + 10;
            myBitmap = new Bitmap((Image)BluetoothServer.Properties.Resources.ResourceManager.GetObject(direction));
            pictureBox[nCount - 1] = new PictureBox();
            pictureBox[nCount - 1].Name = direction;
            pictureBox[nCount - 1].Size = new Size(36, 36);
            pictureBox[nCount - 1].Location = new Point(positionX, positionY);
            pictureBox[nCount - 1].TabIndex = 10;
            pictureBox[nCount - 1].TabStop = false;
            pictureBox[nCount - 1].Visible = true;
            pictureBox[nCount - 1].Parent = this;
            pictureBox[nCount - 1].BorderStyle = BorderStyle.None;
            pictureBox[nCount - 1].Image = myBitmap;
            pictureBox[nCount - 1].Paint += new PaintEventHandler(Form1_Paint);
            pictureBox[nCount - 1].Padding = new Padding(0, 0, 0, 0);
            pictureBox[nCount - 1].Tag = " ";

        }
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
        void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            PictureBox pic = (PictureBox)sender;
            Pen pen = new Pen(Color.Red);
            string str = pic.Tag.ToString();

            g.DrawString(str, this.Font, new SolidBrush(Color.Black), new PointF(3f, 3f));


        }
        #endregion

        private void checkcount()
        {
            if (nCount > 17)
            {
                MessageBox.Show("모션은 최대 17까지 정의할 수 있습니다.");
                nCount--;
            }
            else
            {
                nCount++;
            }
        }
        private void saveToarray(char ch)
        {
            if (nCount < 17)
                tempsave[nCount] = ch;
        }
        private void rightbtn_Click(object sender, EventArgs e)
        {
            saveToarray('r');
            checkcount();
            paintIcon("right");
        }

        private void upbtn_Click(object sender, EventArgs e)
        {
            saveToarray('u');
            checkcount();
            paintIcon("up");
        }

        private void leftbtn_Click(object sender, EventArgs e)
        {
            saveToarray('l');
            checkcount();
            paintIcon("left");
        }

        private void downbtn_Click(object sender, EventArgs e)
        {
            saveToarray('d');
            checkcount();
            paintIcon("down");
        }
        private void leftRbtn_Click(object sender, EventArgs e)
        {
            saveToarray('o');
            checkcount();
            paintIcon("leftrotation");

        }

        private void rightRbtn_Click(object sender, EventArgs e)
        {
            saveToarray('n');
            checkcount();
            paintIcon("rightrotation");
        }

        private void savebtn_Click(object sender, EventArgs e)
        {
            string dirkey = "";
            for (int i = 0; i < nCount; i++)
            {
                dirkey += tempsave[i];
            }
            if (dirkey != "")
            {

                mf.setDic(dirkey, fucbox.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("모션을 정의해라");
            }
            clearIcon();
            motionoutput();
            nCount = 0;
        }

        private void motionoutput()
        {
            textBox1.Clear();
            motionlist = mf.getDic();
            foreach (KeyValuePair<string, string> kvp in motionlist)
            {
                motionbox(kvp.Key + " : " + kvp.Value);
            }
        }
        public void bmo(int check)
        {
            if (check == 1)
            {
                mf.setDic("l", "LEFT");
                mf.setDic("r", "RIGHT");
                mf.setDic("u", "NONE");
                mf.setDic("d", "NONE");
                mf.setDic("o", "NONE");//왼쪽회전
                mf.setDic("n", "NONE");//오른쪽회전
                mf.setDic("ud", "NONE");
            }
            else if (check == 0)
            {
                mf.setDic("l", "LEFT");
                mf.setDic("r", "RIGHT");
                mf.setDic("u", "UP");
                mf.setDic("d", "DOWN");
                mf.setDic("o", "NONE");//왼쪽회전
                mf.setDic("n", "NONE");//오른쪽회전
                mf.setDic("ud", "Alt + ENTER");
            }

            motionoutput();
        }
        public void motionbox(string message)
        {

            Func<int> del = delegate()
            {
                textBox1.AppendText(message + System.Environment.NewLine);
                return 0;
            };
            Invoke(del);

        }
        private void SettingMotionForm_Load(object sender, EventArgs e)
        {

            Queue<string> q = new Queue<string>();
            q = mf.getFunc();

            foreach (string value in q)
            {
                fucbox.Items.Add(value);
            }


            fucbox.SelectedIndex = 0;
            motionoutput();
        }

        private void pptbtn_Click(object sender, EventArgs e)
        {
            mf.setDic("l", "LEFT");
            mf.setDic("r", "RIGHT");
            mf.setDic("u", "NONE");
            mf.setDic("d", "NONE");
            mf.setDic("o", "NONE");//왼쪽회전
            mf.setDic("n", "NONE");//오른쪽회전
            mf.setDic("ud", "NONE");
            motionoutput();
        }

        private void gombtn_Click(object sender, EventArgs e)
        {
            mf.setDic("l", "LEFT");
            mf.setDic("r", "RIGHT");
            mf.setDic("u", "UP");
            mf.setDic("d", "DOWN");
            mf.setDic("o", "NONE");//왼쪽회전
            mf.setDic("n", "NONE");//오른쪽회전
            mf.setDic("ud", "Alt + ENTER");
            motionoutput();
        }

        private void mariobtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Chrome.exe", "http://slither.io");
            mf.setDic("l", "LEFT");
            mf.setDic("r", "RIGHT");
            mf.setDic("u", "x");
            mf.setDic("d", "NONE");
            mf.setDic("o", "LeftMouse");//왼쪽회전
            mf.setDic("n", "RightMouse");//오른쪽회전
            mf.setDic("ud", "Alt + ENTER");
            motionoutput();
            int hWnd = FindWindow("Chrome_WidgetWin_1", "slither.io - Chrome");
            int hw = FindWindowEx(hWnd, 0, "Chrome_RenderWidgetHostHWND", "Chrome Legacy Window");
            Delay(1100);
            SendMessage(hw, 0x0021, 0, 1);
            SendMessage(hw, 0x0202, 0, 1);
            SendMessage(hw, 0x201, 0, 1);
            SendMessage(hWnd, 0x0021, 0, 1);
            SendMessage(hWnd, 0x0202, 0, 1);
            SendMessage(hWnd, 0x0201, 0, 1);
            SendMessage(hWnd, 0x0200, 0, 1);
            System.Windows.Forms.Cursor.Position = new Point(970, 525);
            mouse_event(0x02 | 0x04, 0, 0, 0, 0);
            mouse_event(0x02 | 0x04, 0, 0, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog pFileDlg = new OpenFileDialog();
            pFileDlg.Filter = "All Files(*.*)|*.*";
            pFileDlg.Title = "편집할 파일을 선택하여 주세요.";

            if (pFileDlg.ShowDialog() == DialogResult.OK)
            {
                string strFullPathFile = pFileDlg.FileName;
                string Filename = pFileDlg.SafeFileName;

                if (pm.containProgram(Filename))
                {
                    MessageBox.Show("이미 저장한 프로그램입니다.");
                }
                else
                {
                    //MessageBox.Show(strFullPathFile);
                    Icon icn = IconReader.GetFileIcon(strFullPathFile, IconReader.IconSize.Large, false);
                    iconView.Images.Add(icn);
                    iconList.Items.Add(Filename, iconList.Items.Count);

                    pm.saveProgram(Filename, strFullPathFile);
                }


            }
        }

        private void programMark()
        {
            Dictionary<string, string> programlist = pm.returnProgramlist();


            //key : file name, Value : path
            foreach (KeyValuePair<string, string> kvp in programlist)
            {

                Icon icn = IconReader.GetFileIcon(kvp.Value, IconReader.IconSize.Large, false);

                iconView.Images.Add(icn);
                iconList.Items.Add(kvp.Key, iconList.Items.Count);
            }
        }

        /*
        private void iconList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string filename = iconList.FocusedItem.Text;
            int fileindex = iconList.FocusedItem.Index;
            iconList.Items.RemoveAt(fileindex);
            pm.deleteProgram(filename);
        }
        */

        private void iconList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Dictionary<string, string> programlist = pm.returnProgramlist();

            string filename = iconList.FocusedItem.Text;
            int fileindex = iconList.FocusedItem.Index;

            pm.deleteProgram(filename);

            iconView.Images.Clear();
            iconList.Items.Clear();

            foreach (KeyValuePair<string, string> kvp in programlist)
            {
                Icon icn = IconReader.GetFileIcon(kvp.Value, IconReader.IconSize.Large, false);

                iconView.Images.Add(icn);
                iconList.Items.Add(kvp.Key, iconList.Items.Count);
            }

        }

        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);
            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }
            return DateTime.Now;
        }
    }
}