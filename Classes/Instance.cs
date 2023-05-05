using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Girvi.Classes
{
    class Instance
    {
        public static clsUser user = null;
        public static TabControl documentTabStrip = null;
        public static Hashtable tabPagesTable = new Hashtable();
        public static Hashtable instanceVars = new Hashtable();
        public static String pgsql_host = "localhost";
        public static String pgsql_port = "3612";
        public static String pgsql_database = "girvi";
        public static String companyName = "tunch";
        public static String pgsql_user = "postgres";
        public static String pgsql_password = "mathura";
        public static int Number_Of_Zeroes_in_bill = 6;
        public static string Data_Directory = Path.GetFullPath(".\\") + "data";
        public static string instance_Directory = "data//global//instanceVars.dat";
        public static String ItemMasterAccountSelectedIndex = "";
        public static string loggedinRole = "";
        public static string loggedInUser = "";
        public static string loggedInPass = "";
        public static bool isDemoVersion = false;
        public static int EntriesLimit = 100;
        public static string Backup_Directory = "";


        public static void initializeMap()
        {
            try
            {
                Stream stream = File.Open(instance_Directory, FileMode.Open);
                BinaryFormatter bFormate = new BinaryFormatter();
                instanceVars = (Hashtable)bFormate.Deserialize(stream);
                stream.Close();

                if (!(instanceVars.ContainsKey("EntriesLimit")))
                {
                    instanceVars["EntriesLimit"] = EntriesLimit;
                    stream = File.Open(instance_Directory, FileMode.Create);
                    bFormate = new BinaryFormatter();
                    bFormate.Serialize(stream, instanceVars);
                    stream.Close();
                }

                EntriesLimit = Helper.MycInt(instanceVars["EntriesLimit"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }


    }
}
