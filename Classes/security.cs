using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Girvi.Classes
{
    public class security
    {
        public static string getSecureText()
        {
            string text = "";
            try
            {

                String path = Path.GetFullPath(".\\") + "client.txt";
                var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    text = streamReader.ReadToEnd();
                }
                //return text;
            }
            catch (Exception ex)
            {
                text = "";
            }
            return text;
        }

        public static string getUniqueID(string drive)
        {
            if (drive == string.Empty)
            {
                foreach (DriveInfo compDrive in DriveInfo.GetDrives())
                {
                    if (compDrive.IsReady)
                    {
                        drive = compDrive.RootDirectory.ToString();
                        break;
                    }
                }
            }

            if (drive.EndsWith(":\\"))
            {
                drive = drive.Substring(0, drive.Length - 2);
            }
            string volumeSerial = getVolumeSerial(drive);
            string cpuID = getCPUID();
            return cpuID.Substring(13) + cpuID.Substring(1, 4) + volumeSerial + cpuID.Substring(4, 4);
        }

        private static string getVolumeSerial(string drive)
        {
            ManagementObject disk = new ManagementObject(@"win32_logicaldisk.deviceid=""" + drive + @":""");
            disk.Get();
            string volumeSerial = disk["VolumeSerialNumber"].ToString();
            disk.Dispose();
            return volumeSerial;

        }
        public class HardDrive
        {
            public string Model { get; set; }
            public string InterfaceType { get; set; }
            public string SerialNo { get; set; }
            public string Type { get; set; }
        }
        private static string getCPUID()
        {
            string cpuInfo = "";
            ManagementClass managClass = new ManagementClass("win32_processor");
            ManagementObjectCollection managCollec = managClass.GetInstances();
            foreach (ManagementObject managObj in managCollec)
            {
                if (cpuInfo == "")
                {
                    cpuInfo = managObj.Properties["processorID"].Value.ToString();
                    break;
                }
            }
            return cpuInfo;
        }
        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "abc123";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "abc123";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        public static bool generateSecureKey()
        {
            bool flage = false;
            try
            {
                String path = Path.GetFullPath(".\\") + "amd.txt";
                FileInfo fi = new FileInfo(path);
                using (FileStream fs = File.Create(path))
                {

                }
                string serial_number = security.getUniqueID("c");
                serial_number = serial_number + "@Girvi";
                string enc = security.Encrypt(serial_number);
                using (StreamWriter sw = fi.CreateText())
                {
                    sw.WriteLine(enc);
                }
                flage = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                flage = false;
            }
            return flage;
        }
        public static bool verifySecureKey()
        {
            bool flage = false;
            String path = Path.GetFullPath(".\\") + "amd.txt";
            FileInfo fi = new FileInfo(path);
            if (!File.Exists(path))
            {
                flage = false;
            }
            else
            {
                string text = "";
                var fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    text = streamReader.ReadToEnd();
                }

                if (Helper.MyCStr(text) == "")
                    return false;

                string serial_number = security.getUniqueID("c");
                string decrpt = security.Decrypt(text);
                if (Helper.MyCStr(decrpt) != "")
                {
                    decrpt = decrpt.Replace("@Girvi", "").Trim();
                    if (decrpt == serial_number)
                        flage = true;
                    else
                        flage = false;
                }
                else
                    flage = false;
            }

            return flage;
        }

    }
}
