using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace BluetoothServer.Classes
{
    class AudioControl
    {
        public AudioControl()
        {
            SelectDevice(1);
        }
        #region EndPointController.exe interaction
        public void defaultSound()
        {
            SelectDevice(1);
        }
        public void speakerSound()
        {
            SelectDevice(2);
        }
        private static IEnumerable<Tuple<int, string, bool>> GetDevices()
        {
            var p = new Process
            {
                StartInfo =
                                {
                                    UseShellExecute = false,
                                    RedirectStandardOutput = true,
                                    CreateNoWindow = true,
                                    FileName = AppDomain.CurrentDomain.BaseDirectory+"../../EndPointController.exe",
                                    Arguments = "-f \"%d|%ws|%d|%d\""
                                }
            };


            p.Start();
            p.WaitForExit();
            var stdout = p.StandardOutput.ReadToEnd().Trim();

            var devices = new List<Tuple<int, string, bool>>();

            foreach (var line in stdout.Split('\n'))
            {
                var elems = line.Trim().Split('|');
                var deviceInfo = new Tuple<int, string, bool>(int.Parse(elems[0]), elems[1], elems[3].Equals("1"));
                devices.Add(deviceInfo);
            }

            return devices;
        }

        private static void SelectDevice(int id)
        {
            var p = new Process
            {
                StartInfo =
                                {
                                    UseShellExecute = false,
                                    RedirectStandardOutput = true,
                                    CreateNoWindow = true,
                                    FileName = AppDomain.CurrentDomain.BaseDirectory+"../../EndPointController.exe",
                                    Arguments = id.ToString(CultureInfo.InvariantCulture)
                                }
            };
            p.Start();
            p.WaitForExit();
        }

        #endregion
    }
}
