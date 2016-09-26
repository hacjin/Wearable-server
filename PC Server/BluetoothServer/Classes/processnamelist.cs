using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluetoothServer
{
    class processnamelist
    {
        public processnamelist()
        {

        }

        public string isProcess(string pName)
        {
            string result = "not";
            switch (pName)
            {
                case "chrome":
                    result = "chrome";
                    break;
                case "Photoshop":
                    result = "photoshop";
                    break;
                case "Rainmeter":
                    result = "rainmeter";
                    break;
                case "KakaoTalk":
                    result = "kakaotalk";
                    break;
                case "CS5ServiceManager":
                    result = "cs5";
                    break;
                case "AvastUI":
                case "AvastSvc":
                case "AvastVBoxSVC":
                    result = "avast";
                    break;
                case "Tomcat8w":
                    result = "tomcat";
                    break;
                case "SkypePlugin":
                    result = "skype";
                    break;
                case "processLog.vshost":
                case "processLog":
                case "BluetoothServer":
                case "BluetoothServer.vshost":
                    result = "server";
                    break;
                case "eclipse":
                    result = "eclipse";
                    break;
                case "Notepad":
                case "notepad":
                    result = "notepad";
                    break;
                case "GOM":
                case "gom":
                    result = "GOM";
                    break;



            }
            return result;
        }
    }
}
