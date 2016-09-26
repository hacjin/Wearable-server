using System;
using System.Collections.Generic;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;
namespace BluetoothServer
{
    /**
     * 모션으로 행해질 기능들
     */
    class MotionFuc
    {
        //SettingSave sv = new SettingSave();
        [DllImport("user32.dll")]
        public static extern void keybd_event(uint vk, uint scan, uint flags, uint extraInfo);
        [DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtaInfo);
        [DllImport("user32.dll")]
        private static extern uint MapVirtualKey(int wCode, int wMapType);
        const byte AltKey = 18;
        const int KEYUP = 0x0002;

        private static MotionFuc one;

        private MotionFuc() { initdic(); }

        public static MotionFuc getInstance()
        {
            if (one == null)
            {
                one = new MotionFuc();
            }
            return one;
        }

        public static Dictionary<String, String> test_dic = new Dictionary<String, String>();


        public void initdic()
        {
            test_dic.Add("l", "NONE");
            test_dic.Add("r", "NONE");
            test_dic.Add("u", "NONE");
            test_dic.Add("d", "NONE");
            test_dic.Add("o", "NONE");
            test_dic.Add("n", "NONE");
        }

        public void motioncheck2(String motion)
        {
            if (motion != "")
            {
                try
                {
                    motionFunc(test_dic[motion]);
                }
                catch (Exception)
                { }
            }
        }

        public void setDic(String index, String data)
        {
            try
            {
                test_dic.Add(index, data);
            }
            catch (Exception)
            {
                test_dic[index] = data;
            }
        }
        public Dictionary<String, String> getDic()
        {

            return test_dic;
        }
        public Queue<string> getFunc()
        {
            Queue<string> q = new Queue<string>();
            q.Enqueue("NONE");
            q.Enqueue("SOUND");
            q.Enqueue("Alt + F4");
            q.Enqueue("Alt + ENTER");
            q.Enqueue("ESC");
            q.Enqueue("SPACE");
            q.Enqueue("ENTER");
            q.Enqueue("UP");
            q.Enqueue("LEFT");
            q.Enqueue("DOWN");
            q.Enqueue("RIGHT");
            q.Enqueue("BACKSPACE");
            q.Enqueue("F5");
            q.Enqueue("SHIFT + F5");
            q.Enqueue("LeftMouse");
            q.Enqueue("RightMouse");
            q.Enqueue("A");
            q.Enqueue("B");
            q.Enqueue("C");
            q.Enqueue("D");
            q.Enqueue("E");
            q.Enqueue("F");
            q.Enqueue("G");
            q.Enqueue("H");
            q.Enqueue("I");
            q.Enqueue("J");
            q.Enqueue("K");
            q.Enqueue("L");
            q.Enqueue("M");
            q.Enqueue("N");
            q.Enqueue("O");
            q.Enqueue("P");
            q.Enqueue("Q");
            q.Enqueue("R");
            q.Enqueue("S");
            q.Enqueue("T");
            q.Enqueue("U");
            q.Enqueue("V");
            q.Enqueue("W");
            q.Enqueue("X");
            q.Enqueue("Y");
            q.Enqueue("Z");
            return q;
        }
        private void motionFunc(String func)
        {

            switch (func)
            {
                case "NONE":
                    break;
                case "SOUND":
                    soundFunc();
                    break;
                case "Alt + F4":
                    AltF4();
                    break;
                case "Alt + ENTER":
                    AltEnter();
                    break;
                case "ENTER":
                    Enter();
                    break;
                case "SPACE":
                    Space();
                    break;
                case "ESC":
                    Esc();
                    break;
                case "RIGHT":
                    Right();
                    break;
                case "LEFT":
                    Left();
                    break;
                case "DOWN":
                    Down();
                    break;
                case "UP":
                    Up();
                    break;
                case "BACKSPACE":
                    Backspace();
                    break;
                case "F5":
                    F5();
                    break;
                case "SHIFT + F5":
                    Shift_F5();
                    break;
                case "LeftMouse":
                    LeftMouse();
                    break;
                case "RightMouse":
                    RightMouse();
                    break;
                case "A":
                    A();
                    break;
                case "B":
                    B();
                    break;
                case "C":
                    C();
                    break;
                case "D":
                    D();
                    break;
                case "E":
                    E();
                    break;
                case "F":
                    F();
                    break;
                case "G":
                    G();
                    break;
                case "H":
                    H();
                    break;
                case "I":
                    I();
                    break;
                case "J":
                    J();
                    break;
                case "K":
                    K();
                    break;
                case "L":
                    L();
                    break;
                case "M":
                    M();
                    break;
                case "N":
                    N();
                    break;
                case "O":
                    O();
                    break;
                case "P":
                    P();
                    break;
                case "Q":
                    Q();
                    break;
                case "R":
                    R();
                    break;
                case "S":
                    S();
                    break;
                case "T":
                    T();
                    break;
                case "U":
                    U();
                    break;
                case "V":
                    V();
                    break;
                case "W":
                    W();
                    break;
                case "X":
                    X();
                    break;
                case "Y":
                    Y();
                    break;
                case "Z":
                    Z();
                    break;
                default:
                    AltTap();
                    break;
            }
        }

        private void soundFunc()
        {
            SoundPlayer player1 = new SoundPlayer("test.wav");
            player1.Load();
            player1.Play();
        }
        private void Backspace()
        {
            //back
            keybd_event(0x08, 0, 0, 0);
            //back release
            keybd_event(0x08, 0, KEYUP, 0);
        }
        private void F5()
        {
            //F5
            keybd_event(0x74, 0, 0, 0);
            //F5 release
            keybd_event(0x74, 0, KEYUP, 0);
        }
        private void Shift_F5()
        {
            //shift
            keybd_event(0x10, 0, 0, 0);
            //F5
            keybd_event(0x74, 0, 0, 0);
            //shift release
            keybd_event(0x10, 0, KEYUP, 0);
            //F5 release
            keybd_event(0x74, 0, KEYUP, 0);
        }
        private void AltTap()
        {
            //alt
            keybd_event(0xA4, 0, 0, 0);
            //tab
            keybd_event(0x09, 0, 0, 0);
            //tab release
            keybd_event(0xA4, 0, KEYUP, 0);
            //alt release
            keybd_event(0x73, 0, KEYUP, 0);
        }
        private void AltF4()
        {
            //alt 
            keybd_event(0xA4, 0, 0, 0);
            //f4
            keybd_event(0x73, 0, 0, 0);
            //f4 release
            keybd_event(0x73, 0, KEYUP, 0);
            //alt release
            keybd_event(0xA4, 0, KEYUP, 0);
        }
        private void AltEnter()
        {
            //alt 
            keybd_event(0xA4, 0, 0, 0);
            //enter
            keybd_event(0x0D, 0, 0, 0);
            //enter
            keybd_event(0x0D, 0, KEYUP, 0);
            //alt release
            keybd_event(0xA4, 0, KEYUP, 0);
        }
        private void Esc()
        {
            keybd_event(0x1B, 0, 0, 0);
            //release
            keybd_event(0x1B, 0, KEYUP, 0);
        }
        private void Space()
        {
            keybd_event(0x20, 0, 0, 0);
            //release
            keybd_event(0x20, 0, KEYUP, 0);
        }

        private void Up()
        {
            keybd_event(0x26, 0, 0, 0);
            //release
            keybd_event(0x26, 0, KEYUP, 0);
        }

        private void Down()
        {
            keybd_event(0x28, 0, 0, 0);
            //release
            keybd_event(0x28, 0, KEYUP, 0);
        }

        private void Left()
        {
            keybd_event(0x25, 0, 0, 0);
            //release
            keybd_event(0x25, 0, KEYUP, 0);
        }

        private void Right()
        {
            keybd_event(0x27, 0, 0, 0);
            //release
            keybd_event(0x27, 0, KEYUP, 0);
        }

        private void LeftMouse()
        {
            int x = Cursor.Position.X;
            int y = Cursor.Position.Y;
            mouse_event(0x00000002, x, y, 0, 0);
            //release
            mouse_event(0x00000004, x, y, 0, 0);
        }

        private void RightMouse()
        {
            keybd_event(0x02, 0, 0, 0);
            //release
            keybd_event(0x02, 0, KEYUP, 0);
        }
        private void Enter()
        {

            keybd_event(0x0D, 0, 0, 0);
            //release
            keybd_event(0x0D, 0, KEYUP, 0);
        }
        private void A() // 41 : A ~ 5A : Z
        {

            keybd_event(0x41, 0, 0, 0);
            //release
            keybd_event(0x41, 0, KEYUP, 0);
        }
        private void B() // 41 : A ~ 5A : Z
        {

            keybd_event(0x42, 0, 0, 0);
            //release
            keybd_event(0x42, 0, KEYUP, 0);
        }
        private void C() // 41 : A ~ 5A : Z
        {

            keybd_event(0x43, 0, 0, 0);
            //release
            keybd_event(0x43, 0, KEYUP, 0);
        }
        private void D() // 41 : A ~ 5A : Z
        {

            keybd_event(0x44, 0, 0, 0);
            //release
            keybd_event(0x44, 0, KEYUP, 0);
        }
        private void E() // 41 : A ~ 5A : Z
        {

            keybd_event(0x45, 0, 0, 0);
            //release
            keybd_event(0x45, 0, KEYUP, 0);
        }
        private void F() // 41 : A ~ 5A : Z
        {

            keybd_event(0x46, 0, 0, 0);
            //release
            keybd_event(0x46, 0, KEYUP, 0);
        }
        private void G() // 41 : A ~ 5A : Z
        {

            keybd_event(0x47, 0, 0, 0);
            //release
            keybd_event(0x47, 0, KEYUP, 0);
        }
        private void H() // 41 : A ~ 5A : Z
        {

            keybd_event(0x48, 0, 0, 0);
            //release
            keybd_event(0x48, 0, KEYUP, 0);
        }
        private void I() // 41 : A ~ 5A : Z
        {

            keybd_event(0x49, 0, 0, 0);
            //release
            keybd_event(0x49, 0, KEYUP, 0);
        }
        private void J() // 41 : A ~ 5A : Z
        {

            keybd_event(0x4A, 0, 0, 0);
            //release
            keybd_event(0x4A, 0, KEYUP, 0);
        }
        private void K() // 41 : A ~ 5A : Z
        {

            keybd_event(0x4B, 0, 0, 0);
            //release
            keybd_event(0x4B, 0, KEYUP, 0);
        }
        private void L() // 41 : A ~ 5A : Z
        {

            keybd_event(0x4C, 0, 0, 0);
            //release
            keybd_event(0x4C, 0, KEYUP, 0);
        }
        private void M() // 41 : A ~ 5A : Z
        {

            keybd_event(0x4D, 0, 0, 0);
            //release
            keybd_event(0x4D, 0, KEYUP, 0);
        }
        private void N() // 41 : A ~ 5A : Z
        {

            keybd_event(0x4E, 0, 0, 0);
            //release
            keybd_event(0x4E, 0, KEYUP, 0);
        }
        private void O() // 41 : A ~ 5A : Z
        {

            keybd_event(0x4F, 0, 0, 0);
            //release
            keybd_event(0x4F, 0, KEYUP, 0);
        }
        private void P() // 41 : A ~ 5A : Z
        {

            keybd_event(0x50, 0, 0, 0);
            //release
            keybd_event(0x50, 0, KEYUP, 0);
        }
        private void Q() // 41 : A ~ 5A : Z
        {

            keybd_event(0x51, 0, 0, 0);
            //release
            keybd_event(0x51, 0, KEYUP, 0);
        }
        private void R() // 41 : A ~ 5A : Z
        {

            keybd_event(0x52, 0, 0, 0);
            //release
            keybd_event(0x52, 0, KEYUP, 0);
        }
        private void S() // 41 : A ~ 5A : Z
        {

            keybd_event(0x53, 0, 0, 0);
            //release
            keybd_event(0x53, 0, KEYUP, 0);
        }
        private void T() // 41 : A ~ 5A : Z
        {

            keybd_event(0x54, 0, 0, 0);
            //release
            keybd_event(0x54, 0, KEYUP, 0);
        }
        private void U() // 41 : A ~ 5A : Z
        {

            keybd_event(0x55, 0, 0, 0);
            //release
            keybd_event(0x55, 0, KEYUP, 0);
        }
        private void V() // 41 : A ~ 5A : Z
        {

            keybd_event(0x56, 0, 0, 0);
            //release
            keybd_event(0x56, 0, KEYUP, 0);
        }
        private void W() // 41 : A ~ 5A : Z
        {

            keybd_event(0x57, 0, 0, 0);
            //release
            keybd_event(0x57, 0, KEYUP, 0);
        }
        private void X() // 41 : A ~ 5A : Z
        {

            keybd_event(0x58, 0, 0, 0);
            //release
            keybd_event(0x58, 0, KEYUP, 0);
        }
        private void Y() // 41 : A ~ 5A : Z
        {

            keybd_event(0x59, 0, 0, 0);
            //release
            keybd_event(0x59, 0, KEYUP, 0);
        }
        private void Z() // 41 : A ~ 5A : Z
        {

            keybd_event(0x5A, 0, 0, 0);
            //release
            keybd_event(0x5A, 0, KEYUP, 0);
        }


    }

}


/*
정수명   값   
의미

VK_LBUTTON   01   마우스왼쪽 버튼
VK_RBUTTON   02   마우스 오른쪽 버튼
VK_CANCEL   03   [Cancel]
VK_MBUTTON   04   마우스 중앙 버튼
VK_XBUTTON1   05   Windows 2000/XP： 마우스 X1 버튼
VK_XBUTTON2   06   Windows 2000/XP： 마우스 X2 버튼
-   07   미정도리
VK_BACK   08   [Back space]
VK_TAB   09   [Tab]
-   0A ~ 0B   예약
VK_CLEAR   0C   [Clear]
VK_RETURN   0D   [Enter]
-   0E ~ 0F   미정도리
VK_SHIFT   10   [Shift]
VK_CONTROL   11   [Ctrl]
VK_MENU   12   [Alt]
VK_PAUSE   13   [Pause]
VK_CAPITAL   14   [Caps Lock]
VK_KANA   15   IME 가나 모드
VK_HANGUEL, VK_HANGUL   15   IME 한글 모드
-   16   미정도리
VK_JUNJA   17
VK_FINAL   18
VK_HANJA   19
VK_KANJI   19   IME 한자 모드
-   1A   미정도리
VK_ESCAPE   1B   [Esc]
VK_CONVERT   1C   IME 변환
VK_NONCONVERT   1D   IME 무변환
VK_ACCEPT   1E
VK_MODECHANGE   1F   IME 모드 변경
VK_SPACE   20   스페이스 키
VK_PRIOR   21   [Page Up]
VK_NEXT   22   [Page Down]
VK_END   23   [End]
VK_HOME   24   [Home]
VK_LEFT   25   [←]
VK_UP   26   [↑]
VK_RIGHT   27   [→]
VK_DOWN   28   [↓]
VK_SELECT   29   [Select]
VK_PRINT   2A   [Print]
VK_EXECUTE   2B   [Execute]
VK_SNAPSHOT   2C   [Print Screen]
VK_INSERT   2D   [Insert]
VK_DELETE   2E   [Delete]
VK_HELP   2F   [Help]
(ASCII 코드 '0' ~ '9' (와)과 같다)   30 ~ 39   [0] ~ [9]
3A ~ 40   미정도리
(ASCII 코드 'A' ~ 'Z' (와)과 같다)   41 ~ 5A   [A] ~ [Z]
VK_LWIN   5B   왼쪽의 Windows 키
VK_RWIN   5C   오른쪽의 Windows 키
VK_APPS   5D   어플리케이션 키
-   5E   예약
VK_SLEEP   5F   컴퓨터 sleeve 키
VK_NUMPAD0 ~ VK_NUMPAD9   60 ~ 69   숫자 패드의 [0] ~ [9]
VK_MULTIPLY   6A   숫자 패드의 [ * ]
VK_ADD   6B   숫자 패드의 [ + ]
VK_SEPARATOR   6C   숫자 패드의 [Enter]
VK_SUBTRACT   6D   숫자 패드의 [ - ]
VK_DECIMAL   6E   숫자 패드의 [ . ]
VK_DIVIDE   6F   숫자 패드의 [ / ]
VK_F1   70   [F1]
VK_F2   71   [F2]
VK_F3   72   [F3]
VK_F4   73   [F4]
VK_F5   74   [F5]
VK_F6   75   [F6]
VK_F7   76   [F7]
VK_F8   77   [F8]
VK_F9   78   [F9]
VK_F10   79   [F10]
VK_F11   7A   [F11]
VK_F12   7B   [F12]
VK_F13   7C   [F13]
VK_F14   7D   [F14]
VK_F15   7E   [F15]
VK_F16   7F   [F16]
VK_F17   80   [F17]
VK_F18   81   [F18]
VK_F19   82   [F19]
VK_F20   83   [F20]
VK_F21   84   [F21]
VK_F22   85   [F22]
VK_F23   86   [F23]
VK_F24   87   [F24]
-   88 ~ 8F   할당해 없음
VK_NUMLOCK   90   [Num Lock]
VK_SCROLL   91   [Scroll Lock]
92 ~ 96   OEM 고유
97 ~ 9F   할당 없음
VK_LSHIFT   A0   왼쪽의 [Shift]
VK_RSHIFT   A1   오른쪽의 [Shift]
VK_LCONTROL   A2   왼쪽의 [Ctrl]
VK_RCONTROL   A3   오른쪽의 [Ctrl]
VK_LMENU   A4   왼쪽의 [Alt]
VK_RMENU   A5   오른쪽의 [Alt]
VK_BROWSER_BACK   A6   Windows 2000/XP： 브라우저의 「돌아온다」키
VK_BROWSER_FORWARD   A7   Windows 2000/XP： 브라우저의 「다음에」키
VK_BROWSER_REFRESH   A8   Windows 2000/XP： 브라우저의 「갱신」키
VK_BROWSER_STOP   A9   Windows 2000/XP： 브라우저의 「중지」키
VK_BROWSER_SEARCH   AA   Windows 2000/XP： 브라우저의 「검색」키
VK_BROWSER_FAVORITES   AB   Windows 2000/XP： 브라우저의 「마음에 드는 것」키
VK_BROWSER_HOME   AC   Windows 2000/XP： 브라우저의 「홈」키
VK_VOLUME_MUTE   AD   Windows 2000/XP： 볼륨의 뮤트 키
VK_VOLUME_DOWN   AE   Windows 2000/XP： 볼륨 다운 키
VK_VOLUME_UP   AF   Windows 2000/XP： 볼륨 업 키
VK_MEDIA_NEXT_TRACK   B0   Windows 2000/XP： 「다음의 트럭」키
VK_MEDIA_PREV_TRACK   B1   Windows 2000/XP： 「전의 트럭」키
VK_MEDIA_STOP   B2   Windows 2000/XP： 「미디어 정지」키
VK_MEDIA_PLAY_PAUSE   B3   Windows 2000/XP： 「미디어 Start / Stop 」키
VK_LAUNCH_MAIL   B4   Windows 2000/XP： 「메일 개시」키
VK_LAUNCH_MEDIA_SELECT   B5   Windows 2000/XP： 「미디어 선택」키
VK_LAUNCH_APP1   B6   Windows 2000/XP： 「어플리케이션 1 기동」키
VK_LAUNCH_APP2   B7   Windows 2000/XP： 「어플리케이션 2 기동」키
B8 ~ B9   예약
VK_OEM_1   BA   
다양한 문자를 위해서 사용할 수 있습니다.

Windows 2000/XP： U.S. 표준 키보드에서는 [ :; ]

VK_OEM_PLUS   BB   Windows 2000/XP： [ + ]
VK_OEM_COMMA   BC   Windows 2000/XP： [ , ]
VK_OEM_MINUS   BD   Windows 2000/XP： [ - ]
VK_OEM_PERIOD   BE   Windows 2000/XP： [ . ]
VK_OEM_2   BF   
다양한 문자를 위해서 사용할 수 있습니다.

Windows 2000/XP： U.S. 표준 키보드에서는 [ /? ]

VK_OEM_3   C0   
다양한 문자를 위해서 사용할 수 있습니다.

Windows 2000/XP： U.S. 표준 키보드에서는 [ `~ ]

C1 ~ D7   예약
D8 ~ DA   할당 없음
VK_OEM_4   DB   
다양한 문자를 위해서 사용할 수 있습니다.

Windows 2000/XP： U.S. 표준 키보드에서는 [ [{ ]

VK_OEM_5   DC   
다양한 문자를 위해서 사용할 수 있습니다.

Windows 2000/XP： U.S. 표준 키보드에서는 [ \| ]

VK_OEM_6   DD   
다양한 문자를 위해서 사용할 수 있습니다.

Windows 2000/XP： U.S. 표준 키보드에서는 [ ]} ]

VK_OEM_7   DE   
다양한 문자를 위해서 사용할 수 있습니다.

Windows 2000/XP： U.S. 표준 키보드에서는 [ '" ]

VK_OEM_8   DF   
다양한 문자를 위해서 사용할 수 있습니다.

-   E0   예약
E1   OEM 고유
VK_OEM_102   E2   Windows 2000/XP： RT 102-key 키보드의 모퉁이 외모 또는 backslash
E3 ~ E4   OEM 고유
VK_PROCESSKEY   E5   Windows 95/98/Me/NT 4.0/2000/XP： IME Process
E6   OEM 고유
VK_PACKET   E7   
Windows 2000/XP： Unicode 문자가 키스트로크(keystroke)인 것 같이 통하기 위해서 사용됩니다.

-   E8   할당해 없음
E9 ~ F5   OEM 고유
VK_ATTN   F6   Attn
VK_CRSEL   F7   CrSel
VK_EXSEL   F8   ExSel
VK_EREOF   F9   Erase EOF
VK_PLAY   FA   Play
VK_ZOOM   FB   Zoom
VK_NONAME   FC   예약
VK_PA1   FD   PA1
VK_OEM_CLEAR   FE   Clear

*/
