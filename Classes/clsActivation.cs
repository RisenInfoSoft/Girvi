using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Girvi.Classes
{
    class clsActivation
    {
        public static string datadir = Path.GetFullPath(".\\") + "data";
        public class HardDrive
        {
            public string Model { get; set; }
            public string InterfaceType { get; set; }
            public string SerialNo { get; set; }
            public string Type { get; set; }
        }

        public static void startSqlService()
        {
            String path = Path.GetFullPath(".\\") + "pgsql\\bin\\pg_ctl.exe";
            if (!File.Exists(path)) return;
            Process p = new Process();
            ProcessStartInfo pInfo = new ProcessStartInfo(path);
            pInfo.WorkingDirectory = Path.GetFullPath(".\\") + "data";
            string directory = " -D ";
            string process = " start";
            String arguementString = directory + '"' + datadir + '"' + process;
            pInfo.Arguments = arguementString;
            pInfo.UseShellExecute = false;
            pInfo.CreateNoWindow = true;
            p.StartInfo = pInfo;
            p.Start();
        }

        public static void stopSqlService()
        {
            String path = Path.GetFullPath(".\\") + "pgsql\\bin\\pg_ctl.exe";
            if (!File.Exists(path)) return;
            ProcessStartInfo pInfo = new ProcessStartInfo(path);
            pInfo.WorkingDirectory = Path.GetFullPath(".\\") + "data";
            string directory = " -D ";
            string process = " stop";
            String arguementString = directory + '"' + datadir + '"' + " -m fast " + process;
            pInfo.Arguments = arguementString;
            pInfo.CreateNoWindow = true;
            pInfo.UseShellExecute = false;
            Process p = Process.Start(pInfo);
            p.WaitForExit();

        }

        public static void checkSqlServer()
        {
            String path = Path.GetFullPath(".\\") + "pgsql\\bin\\pg_ctl.exe";
            if (!File.Exists(path)) return;
            Process p = new Process();
            ProcessStartInfo pInfo = new ProcessStartInfo(path);
            pInfo.WorkingDirectory = Path.GetFullPath(".\\") + "data";
            string directory = " -D ";
            string process = " status";
            String arguementString = directory + '"' + datadir + '"' + process;
            pInfo.Arguments = arguementString;
            pInfo.UseShellExecute = false;
            pInfo.CreateNoWindow = true;
            p.StartInfo = pInfo;
            p.Start();
        }

        private string getMode(string mode)
        {
            switch (mode)
            {
                case "s":
                    mode = " -m smart ";
                    break;
                case "i":
                    mode = " -m imedate ";
                    break;
                case "f":
                    mode = " -m fast ";
                    break;
            }
            return mode;
        }
    }
}

