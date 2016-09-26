using System;

using System.Drawing;
using System.Runtime.InteropServices;

using System.Windows.Forms;

namespace BluetoothServer
{

    class MouseControl
    {
        static int[] prex = new int[3];
        static int[] prey = new int[3];
        int cnt = 0;
        [DllImport("user32.dll")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern int SendMessage(int hwnd, int wMsg, int wParam, int lParam);


        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, uint dwExtraInfo);
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        private const int WM_LBUTTONDOWN = 0x0202;
        private const int WM_LBUTTONUP = 0x0201;
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);



        public string Mouseclick(int e)
        {
            int hWnd = FindWindow(null, "VirtuaCop 2");
            switch (e)
            {
                case 0:
                    break;
                case 1:
                    //MClick(System.Windows.Forms.Cursor.Position);
                    mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)prex[0], (uint)prey[0], 0, 0);
                    //SendMessage(hWnd, WM_LBUTTONDOWN | WM_LBUTTONUP, 0, 1);
                    break;
                case 2:
                    mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, (uint)prex[0], (uint)prey[0], 0, 0);
                    break;

            }
            return "mouseclick";

        }

        private void MClick(Point pos)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }

        public string Mousemove(double oriZ, double oriY)
        {
            string x = Cursor.Position.X.ToString();
            string y = Cursor.Position.Y.ToString();
            double mX = Convert.ToDouble(x);
            double mY = Convert.ToDouble(y);

            int posX = Convert.ToInt16(mX + oriZ * 2);
            int posY = Convert.ToInt16(mY + oriY * 2);

            if (prex[0] == 0 && prey[0] == 0)
            {
                prex[0] = Cursor.Position.X;
                prey[0] = Cursor.Position.Y;
            }else if (prex[1] == 0 && prey[1] == 0)
            {
                prex[1] = Cursor.Position.X;
                prey[1] = Cursor.Position.Y;
            }
            else if(prex[2] == 0 && prey[2] == 0)
            {
                prex[2] = Cursor.Position.X;
                prey[2] = Cursor.Position.Y;
            }
            else
            {
                prex[0] = prex[1];
                prey[0] = prey[1];
                prex[1] = prex[2];
                prey[1] = prey[2];
                prex[2] = Cursor.Position.X;
                prey[2] = Cursor.Position.Y;
            }

            System.Windows.Forms.Cursor.Position = new Point(posX, posY);

            return "Mouse Move";
        }

    }
}