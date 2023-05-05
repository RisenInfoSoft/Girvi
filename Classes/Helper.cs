using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Girvi.Classes
{
    public enum RSAUpdateTableType
    {
        Insert,
        Update
    }

    public static class Helper
    {
        static NpgsqlConnection con;

        public static NpgsqlConnection getConnection(Boolean isReset = false)
        {
            if (con != null && !isReset && con.State == ConnectionState.Open)
            {
                //if (con.Ping())
                if (con.State.ToString() == "Start")
                    return con;
                else
                    con.Close();
            }
            try
            {
                String connectionString = "Server = " + Instance.pgsql_host + "; Port = " + Instance.pgsql_port + "; Database = " + Instance.pgsql_database + "; User Id = " + Instance.pgsql_user + "; Password = " + Instance.pgsql_password + "; Integrated Security = true;";
                con = new NpgsqlConnection(connectionString);
                con.Open();

                if (con.State.ToString() == "Close")
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (con.State.ToString() == "Start")
                            return con;
                        else
                            Timer(1000);
                    }
                }

                return con;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }

        private static void Timer(int v)
        {
            throw new NotImplementedException();
        }

        public static int MycInt(object obj)
        {
            try
            {
                int i = Convert.ToInt32(obj);
                return i;
            }
            catch
            {
                return 0;
            }
        }

        public static string MyCStr(object obj)
        {
            try
            {
                string str = Convert.ToString(obj);
                if (str == null)
                {
                    str = "";
                }
                return str;

            }
            catch
            {
                return "";
            }
        }

        public static double MyCDbl(object obj)
        {
            try
            {
                double dbl = Convert.ToDouble(obj);
                if (double.IsInfinity(dbl) || double.IsNaN(dbl) || double.IsNegativeInfinity(dbl) || double.IsPositiveInfinity(dbl))
                {
                    dbl = 0;
                }
                return dbl;
            }
            catch
            {
                return 0;
            }
        }

        public static DateTime MyCDate(object obj)
        {
            try
            {
                DateTime date = Convert.ToDateTime(obj);
                return date;
            }
            catch
            {
                return Convert.ToDateTime("01/Jan/1900");
            }
        }

        public static double MyCMySqll(object obj)
        {
            try
            {
                double MySqll = Convert.ToDouble(obj);
                if (double.IsInfinity(MySqll) || double.IsNaN(MySqll) || double.IsNegativeInfinity(MySqll) || double.IsPositiveInfinity(MySqll))
                {
                    MySqll = 0;
                }
                return MySqll;
            }
            catch
            {
                return 0;
            }
        }

        public static DataTable getTable(string query, NpgsqlConnection cn = null, NpgsqlTransaction trans = null, Boolean isDate = true)
        {
            NpgsqlConnection con = null;
            try
            {
                if (cn != null)
                {
                    con = cn;
                }
                else
                {
                    con = getConnection();
                }
                NpgsqlCommand cmd = con.CreateCommand();
                cmd.CommandText = query;
                cmd.CommandTimeout = 600;

                NpgsqlDataReader reader = cmd.ExecuteReader();
                DataTable returnData = new DataTable();
                DataTable dtSchema = reader.GetSchemaTable();
                List<DataColumn> listCols = new List<DataColumn>();

                if (dtSchema != null)
                {
                    foreach (DataRow drow in dtSchema.Rows)
                    {
                        string columnName = System.Convert.ToString(drow["ColumnName"]);
                        DataColumn column;
                        if ((Type)(drow["DataType"]) == typeof(DateTime) && isDate)
                            column = new DataColumn(columnName, typeof(DateTime));
                        else
                            column = new DataColumn(columnName, typeof(string));
                        //DataColumn column = new DataColumn(columnName, (Type)(drow["DataType"]));
                        //DataColumn column = new DataColumn(columnName, typeof(string));
                        //column.Unique = (bool)drow["IsUnique"];
                        //column.AllowDBNull = (bool)drow["AllowDBNull"];
                        //column.AutoIncrement = (bool)drow["IsAutoIncrement"];
                        listCols.Add(column);
                        returnData.Columns.Add(column);
                    }
                }

                while (reader.Read())
                {
                    DataRow dataRow = returnData.NewRow();
                    for (int i = 0; i < listCols.Count; i++)
                    {
                        dataRow[((DataColumn)listCols[i])] = reader[i];
                    }
                    returnData.Rows.Add(dataRow);
                }
                reader.Close();
                return returnData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                //con.Close();
            }

        }

        public static string getID(string prefix, int num, int N = 8, Boolean ismanualCode = false)
        {
            N = Instance.Number_Of_Zeroes_in_bill + prefix.Length + 1;
            string id = prefix;
            int len = prefix.Length + Helper.MyCStr(num).Length;

            for (int i = 0; i < N - len; i++)
                id += "0";
            id += Helper.MyCStr(num);
            return id;
        }

        public static bool UpdateTable(string tableName, ColumnDataCollection objColumnDataCollection, RSAUpdateTableType updateTableType, string whereClause, NpgsqlConnection conn = null, NpgsqlTransaction trans = null)
        {
            bool localConnection = false, localTransaction = false;
            NpgsqlConnection cn = null;
            string data = "";
            try
            {
                if (conn != null)
                {
                    cn = conn;

                }
                else
                {
                    cn = getConnection();
                    localConnection = true;
                }
                if (trans == null)
                {
                    trans = cn.BeginTransaction();
                    localTransaction = true;

                }
                DataTable tb = getTable("select * from " + tableName + " where 1=2", cn, trans);
                if (updateTableType == RSAUpdateTableType.Insert)
                {
                    string fields = "";
                    string values = "";
                    foreach (clsColumnData objColumnData in objColumnDataCollection)
                    {
                        if (tb.Columns.Contains(objColumnData.FieldName))
                        {
                            DataColumn dc = tb.Columns[objColumnData.FieldName];
                            if (MyLen(fields) > 0)
                            {
                                fields += ", ";
                            }
                            fields += "" + objColumnData.FieldName.ToUpper() + "";
                            if (MyLen(values) > 0)
                            {
                                values += ", ";
                            }
                            string str = "";
                            Type type = dc.DataType;
                            if (objColumnData.Value == null)
                            {
                                str = "Null";
                            }
                            else
                            {
                                if ((type.Name == "DateTime"))
                                {
                                    string tmpDatetime = MyCStr(objColumnData.Value);
                                    str = "'" + tmpDatetime + "'";
                                    // str = "'" + GetPrintDate_forQuery(tmpDatetime) + "'";
                                    //if (tmpDatetime.Year < 1900)
                                    //{
                                    //    str = " null ";
                                    //}
                                }
                                else if ((type.Name == "Double") || (type.Name == "Int32") || (type.Name == "Byte") || (type.Name == "Float") || (type.Name == "Decimal"))
                                {
                                    str = MyCStr(MyCMySqll(objColumnData.Value));
                                }
                                else
                                {
                                    string stval;
                                    stval = MyCStr(objColumnData.Value);

                                    stval = stval.Replace("'", "''");
                                    str = "'" + stval + "'";

                                    if (objColumnData.isUnicode)
                                    {
                                        str = "N" + str;
                                    }
                                    if (MyLen(MyCStr(objColumnData.Value)) == 0)
                                    {
                                        if (objColumnData.nullifBlank)
                                        {
                                            str = "Null";
                                        }

                                    }
                                }
                            }
                            values += str;

                        } ///// column not prsent in the table
                        else
                        {
                            throw new Exception("Column " + objColumnData.FieldName + " is not present in table " + tableName);
                        }
                    }
                    values = " values (" + values + ")";
                    fields = " (" + fields + ") ";
                    data = "Insert into " + tableName + fields + values;
                }
                else
                {
                    string fields = " ";
                    int icnt = 0;
                    foreach (clsColumnData objColumnData in objColumnDataCollection)
                    {
                        if (tb.Columns.Contains(objColumnData.FieldName))
                        {

                            DataColumn dc = tb.Columns[objColumnData.FieldName];
                            if (icnt != 0)
                            {
                                if (MyLen(fields) > 0)
                                {
                                    fields += ", ";
                                }
                            }
                            icnt++;

                            fields += "\"" + objColumnData.FieldName.ToUpper() + "\"";

                            string str = "";

                            if (objColumnData.Value == null)
                            {
                                str = "Null";
                            }
                            else
                            {
                                Type type = dc.DataType;
                                if ((type.Name == "DateTime"))
                                {

                                    string tmpDatetime = MyCStr(objColumnData.Value);
                                    str = "'" + tmpDatetime + "'";
                                    //if (tmpDatetime.Year < 1900)
                                    //{
                                    //    str = " null ";
                                    //}


                                }
                                else if ((type.Name == "Double") || (type.Name == "Int32") || (type.Name == "Byte") || (type.Name == "Float") || (type.Name == "Decimal"))
                                {
                                    str = MyCStr(MyCMySqll(objColumnData.Value));
                                }
                                else
                                {
                                    string stval;
                                    stval = MyCStr(objColumnData.Value);
                                    stval = stval.Replace("'", "''");

                                    str = "'" + stval + "'";

                                    if (objColumnData.isUnicode)
                                    {
                                        str = "N" + str;
                                    }

                                    if (MyLen(MyCStr(objColumnData.Value)) == 0)
                                    {
                                        if (objColumnData.nullifBlank)
                                        {
                                            str = "Null";
                                        }

                                    }
                                }
                            }
                            fields += "=" + str;

                        } ////// column for update not in list of columns for table
                        else
                        {
                            throw new Exception("Column " + objColumnData.FieldName + " is not present in table " + tableName);
                        }
                    }

                    data = "update " + tableName + " SET " + fields + " where " + whereClause;
                    data = data.Replace('"', ' ');
                }
                //data = "insert into itemmaster (code,name,company,category) values(\"test\",\"test\",\"test\",\"test\")";
                NpgsqlCommand cmd = new NpgsqlCommand(data, cn);
                //   cn.Open();
                //cmd.Connection = cn;
                //cmd.Transaction = trans;
                //cmd.CommandText = data;
                cmd.ExecuteNonQuery();
                if (localTransaction)
                    trans.Commit();


                return true;
            }
            catch (Exception ex)
            {
                if (localConnection)
                {
                    trans.Rollback();
                }
                throw ex;
            }
            finally
            {
                if (localConnection)
                {
                    //trans.Commit();
                    cn.Close();
                }
            }
        }

        public static int MyLen(object obj)
        {
            return MyCStr(obj).Length;
        }

        public static string getNextID(string tablename, String subType = null, String whereClause = null, string mode = null, Boolean ismanual = false)
        {
            try
            {
                string id = "", prefix = "";
                if (!ismanual)
                {
                    if (subType != null)
                        prefix = Prefixes.getPrefix(subType);

                    else
                        prefix = Prefixes.getPrefix(tablename);

                    if (mode == "online")
                    {
                        prefix = "CT";
                    }
                }
                else
                {
                    prefix = "";
                }

                string count_query = "";
                //if(ismanual)
                //     count_query = "select count(copy_manualItemCode) from " + tablename + whereClause;
                //else
                count_query = "select count(code) from " + tablename + whereClause;

                DataTable dt = Helper.getTable(count_query);
                int count = Convert.ToInt32(dt.Rows[0][0]);
                if (count == 0)
                {
                    if (!ismanual)
                        id = getID(prefix, 1);
                    else
                        id = getID(prefix, 1001, ismanualCode: true);
                }
                else
                {
                    int len = prefix.Length;
                    //string query = "select max(code) from " + tablename + whereClause;
                    //DataTable dt1 = Utilities.getTable(query, con, trans);
                    //string maxid = Utilities.MyCStr(dt1.Rows[0][0]);
                    //id = getID(prefix, (Convert.ToInt32(maxid.Substring(Utilities.MyLen(prefix))) + 1));
                    if (!ismanual)
                    {
                        //string query = "select max(convert(substr(code, " + (len + 1) + ", length(code)- " + len + "),signed integer)) from " + tablename + whereClause;
                        string query = "select max(substr(code, " + (len + 1) + ", length(code)- " + len + ") :: integer) from " + tablename + whereClause; // 05-02-2023 converted mysql to pgsql by ak47....
                        DataTable dt1 = Helper.getTable(query);
                        //int maxcode = Utilities.MycInt(dt1.Rows[0][0]);
                        string maxcode = Helper.MyCStr(dt1.Rows[0][0]);
                        //maxcode += 1;

                        id = getID(prefix, (Convert.ToInt32(maxcode) + 1));
                    }
                    else
                    {
                        string query = "select max(copy_manualItemCode) from " + tablename + whereClause;
                        DataTable dt1 = Helper.getTable(query);
                        //int maxcode = Utilities.MycInt(dt1.Rows[0][0]);
                        string maxcode = Helper.MyCStr(dt1.Rows[0][0]);
                        id = getID(prefix, (Convert.ToInt32(maxcode) + 1), ismanualCode: ismanual);
                    }
                    //id = prefix + Utilities.MyCStr(maxcode);
                }
                return id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static bool RSAExecuteQuery(string Query, NpgsqlConnection Conn)
        {
            return RSAExecuteQuery(Query, Conn, null);
        }

        public static bool RSAExecuteQuery(string Query, NpgsqlConnection Cn, NpgsqlTransaction Trans)
        {

            bool isExecutedQuery = false;
            bool localconn = false;
            NpgsqlConnection tmpConn = null;

            try
            {
                //DbConnection tmpConn = null;
                if (Cn != null)
                {
                    tmpConn = Cn;
                }
                else
                {
                    tmpConn = getConnection();

                    localconn = true;
                }


                if (tmpConn.State != ConnectionState.Open)
                {
                    tmpConn.Open();
                }




                NpgsqlCommand cmd = new NpgsqlCommand(Query, tmpConn, Trans);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (NpgsqlException e)
                {
                    Thread.Sleep(500);
                    cmd.ExecuteNonQuery();

                }

                isExecutedQuery = true;
            }
            catch (Exception ex)
            {
                isExecutedQuery = false;
                //Trans.Rollback();
                throw ex;
            }
            finally
            {
                if (localconn)
                {
                    //tmpConn.Close();
                    //Trans.Commit();
                    //Cn.Close();
                }
            }
            return isExecutedQuery;
        }
    }
}
