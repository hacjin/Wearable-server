using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace BluetoothServer
{
    public partial class MainForm : Form
    {

        BoardForm us1 = null;
        SettingMotionForm us3 = null;
        public MainForm()
        {
            FormInit();
            InitializeComponent();
            
        }
        private void FormInit()
        {
            //항상 위
            this.TopMost = true;
            SetCtlsArgb();
            Thread t = new Thread(new ThreadStart(SplashScreen));
            t.Start();
            Thread.Sleep(3000);
            t.Abort();
            
        }

        /// <summary>
        /// 배경이 있는 컨트롤 투명처리
        /// </summary>
        private void SetCtlsArgb()
        {
            Control.ControlCollection coll = this.Controls;
            foreach (Control c in coll)
            {
                if (c != null)
                {
                    // CheckBox , Lable인 컨트롤의 경우 투명하게 처리합니다.
                    if (c.GetType() == typeof(CheckBox) || c.GetType() == typeof(Label))
                    {
                        c.BackColor = Color.FromArgb(0, 0, 0, 0);
                    }

                }

            }
        }

        public void SplashScreen()
        {
            Application.Run(new SplashScreenForm());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            us1 = new BoardForm();
            us3 = SettingMotionForm.getInstance();
            this.panel1.Controls.Add(us1);
        }

        private void boardbtn_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(us1);
        }

         private void motionsetbtn_Click(object sender, EventArgs e)
        {
            this.panel1.Controls.Clear();
            this.panel1.Controls.Add(us3);
        }
    }
}