using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BluetoothServer
{
    class Processcheck
    {
        //이소스에서는 사용안하지만 할수도 있기 때문에 냄겨두자
        Thread processCheckThread;
        IconSlideForm isf;
        IconMarkForm imf;
        //시작하자마자 저장하는 프로세스
        Dictionary <int, string> processlist = new Dictionary<int, string>();

        //프로그램 실행중에 실행된 프로그램 목록
        Dictionary<int, string> checkprocesslist = new Dictionary<int, string>();

        //사용자가 제어할 프로세스 목록(현제 이것만 사용중)
        Dictionary<int, string> controlprocesslist;
        //화면에 보여줄 필요 없는 프로세스
        List<string> basicprocesslist = new List<string>();

        public Processcheck()
        {
            
        }
        #region process start(Mark control)
        public void prcoessStartForm()
        {
            
            imf = new IconMarkForm();
            imf.Show();
        }

        public void processCloseForm()
        {
            imf.Close();
        }
        public void startProcess()
        {
            imf.startProcess();
        }
        public void markleftMove()
        {
            imf.leftMove();

        }
        public void markrightMove()
        {
            imf.rightMove();

        }
        #endregion
        #region process exit(process control)
        public void initform()
        {
            cmdStart();
            isf = new IconSlideForm(controlprocesslist);
            isf.Show();
        }
       
        public void closeform()
        {
            isf.Close();
        }
        public void leftMove()
        {
            isf.leftMove();
        
        }
        public void rightMove()
        {
            isf.rightMove();
            
        }
        public void killProcess()
        {
            isf.removeMove();
        }
        private void currentProcess()
        {
            Process[] prolist = Process.GetProcesses();

            foreach (Process p in prolist)
            {

                if (!basicprocesslist.Contains(p.ProcessName))
                {
                    controlprocesslist.Add(p.Id, p.ProcessName);
                   
                }

            }
        }


        private void basicProcess()
        {
            basicprocesslist.Add("services");
            basicprocesslist.Add("igfxtray");
            basicprocesslist.Add("ImageSAFERStart_X64");
            basicprocesslist.Add("svchost");
            basicprocesslist.Add("devenv");
            basicprocesslist.Add("IAStorDataMgrSvc");
            basicprocesslist.Add("hkcmd");
            basicprocesslist.Add("nvtray");
            basicprocesslist.Add("smss");
            basicprocesslist.Add("SearchIndexer");
            basicprocesslist.Add("csrss");
            basicprocesslist.Add("conhost");
            basicprocesslist.Add("unsecapp");
            basicprocesslist.Add("igfxtray");
            basicprocesslist.Add("RAVCpl64");
            basicprocesslist.Add("StandardCollector.Service");
            basicprocesslist.Add("armsvc");
            basicprocesslist.Add("BTServer");
            basicprocesslist.Add("wininit");
            basicprocesslist.Add("taskhost");
            basicprocesslist.Add("wlanext");
            basicprocesslist.Add("splwow64");
            basicprocesslist.Add("POWERPNT");
            basicprocesslist.Add("winlogon");
            basicprocesslist.Add("NvBackend");
            basicprocesslist.Add("VBCSCompiler");
            basicprocesslist.Add("ImageSAFERSvc");
            basicprocesslist.Add("System");
            basicprocesslist.Add("httpd");
            basicprocesslist.Add("Idle");
            basicprocesslist.Add("dwm");
            basicprocesslist.Add("LMS");
            basicprocesslist.Add("WIIADAP");
            basicprocesslist.Add("vcpkgsrv");
            basicprocesslist.Add("ss_conn_service");
            basicprocesslist.Add("lsass");
            basicprocesslist.Add("node");
            basicprocesslist.Add("wmpnetwk");
            basicprocesslist.Add("VPWalletService");
            basicprocesslist.Add("wpmsvc");
            basicprocesslist.Add("explorer");
            basicprocesslist.Add("SearchFilterHost");
            basicprocesslist.Add("AvrcpService");
            basicprocesslist.Add("VsHub");
            basicprocesslist.Add("nvxdsync");
            basicprocesslist.Add("RtkBleServ");
            basicprocesslist.Add("iusb3mon");
            basicprocesslist.Add("daemonu");
            basicprocesslist.Add("nvvsvc");
            basicprocesslist.Add("BluetoothServer.vshos");
            basicprocesslist.Add("veraport");
            basicprocesslist.Add("igfxsrvc");
            basicprocesslist.Add("SearchProtocolHost");
            basicprocesslist.Add("ImageSAFERStart_X86");
            basicprocesslist.Add("audiodg");
            basicprocesslist.Add("mysqld");
            basicprocesslist.Add("HeciServer");
            basicprocesslist.Add("BTDevMgr");
            basicprocesslist.Add("ISignPlusWebCrypto");
            basicprocesslist.Add("igfxpers");
            basicprocesslist.Add("MSBuild");
            basicprocesslist.Add("Microsoft.VsHub.Server.HttpHost");
            basicprocesslist.Add("spoolsv");
            basicprocesslist.Add("BluetoothServer.vshost");
            basicprocesslist.Add("lsm");
            basicprocesslist.Add("sppsvc");
            basicprocesslist.Add("AAM Updates Notifier");
            basicprocesslist.Add("natsvc");
            basicprocesslist.Add("RIconMan");
            basicprocesslist.Add("Eap3Host");
            basicprocesslist.Add("taskeng");
            basicprocesslist.Add("Jhi_service");
            basicprocesslist.Add("RocketDock");
            basicprocesslist.Add("TrustedInstaller");
            basicprocesslist.Add("sfvsfserver");
            basicprocesslist.Add("AquaPreLoader");
            basicprocesslist.Add("WmiPrvSE");
            basicprocesslist.Add("bdcam64.bin");
        }

        private void cmdStart()
        {
            controlprocesslist = new Dictionary<int, string>();
            //curent process
            basicProcess();
            currentProcess();
        }
        #endregion
        #region 여기서는 사용 안함
        private void outputLog()
        {
            foreach (KeyValuePair<int, string> kvp in processlist)
            {
                //logbox(kvp.Key + "," + kvp.Value);
            }
        }

        //실행된 프로세스 체크
        private void checkprocess()
        {
            while (true)
            {

                Thread.Sleep(500);

                Process[] prolist = Process.GetProcesses();



                foreach (Process p in prolist)
                {

                    if (!processlist.ContainsKey(p.Id) && !checkprocesslist.ContainsKey(p.Id))
                    {
                        checkprocesslist.Add(p.Id, p.ProcessName);
                        
                    }

                }


            }

        }
        private void threadexit()
        {
            /*실행되는 프로세스 체크 하는 함수 사용할때
           if(processCheckThread.IsAlive)
           processCheckThread.Abort();
           */
        }
        //최초 저장 프로세스
        private void saveprocess(Process[] prolist)
        {
            foreach (Process p in prolist)
            {
                processlist.Add(p.Id, p.ProcessName);
            }
        }
        #endregion
    }
    
}
