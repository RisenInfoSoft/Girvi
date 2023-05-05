using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Girvi.Classes
{
    class clsConnection : ISerializable
    {
        public String userName;
        public String password;
        public String port;
        public String database;
        public String host;

        public clsConnection()
        {
        }

        public clsConnection(SerializationInfo info, StreamingContext ctxt)
        {
            userName = (String)info.GetValue("userName", typeof(String));
            password = (String)info.GetValue("userName", typeof(String));
            port = (String)info.GetValue("userName", typeof(String));
            database = (String)info.GetValue("userName", typeof(String));
            host = (String)info.GetValue("host", typeof(String));

            Instance.pgsql_database = database;
            Instance.pgsql_password = password;
            Instance.pgsql_user = userName;
            Instance.pgsql_port = port;
            Instance.pgsql_host = host;
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("userName", userName);
            info.AddValue("password", password);
            info.AddValue("port", port);
            info.AddValue("database", database);
            info.AddValue("host", host);
        }

        public Boolean saveIntoFile(String file = "config.osl")
        {
            try
            {
                this.userName = Instance.pgsql_user;
                this.password = Instance.pgsql_password;
                this.port = Instance.pgsql_port;
                this.database = Instance.pgsql_database;
                this.host = Instance.pgsql_host;
                Stream stream = File.Open(file, FileMode.Create);
                BinaryFormatter bformatter = new BinaryFormatter();
                bformatter.Serialize(stream, this);
                stream.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void getFromFile(String file = "config.osl")
        {
            try
            {
                Stream stream = File.Open(file, FileMode.Open);
                BinaryFormatter bformatter = new BinaryFormatter();
                bformatter.Deserialize(stream);
                stream.Close();
            }
            catch (Exception e)
            {

            }
        }
    }
}
