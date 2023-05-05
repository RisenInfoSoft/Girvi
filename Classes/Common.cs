using Girvi.Forms.Pop_Up_Form;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Girvi.Classes
{
    public static class Common
    {
        static string companyName = Helper.MyCStr(Instance.companyName).ToLower();

        public static string getVoucherMysqlDate(DateTime dt)
        {
            string dateFormat = "yyyy-MM-dd HH:mm:ss";
            try
            {
                return dt.ToString(dateFormat);
            }
            catch (Exception e)
            {
                return DateTime.MinValue.ToString(dateFormat);
            }
        }

        public static string getVoucherMysqlDateWOt(DateTime dt, Boolean frmt1 = false, Boolean frmt2 = false)
        {
            string dateFormat = "";
            if (frmt1)
                dateFormat = "yyyy-MM-dd";
            else
                dateFormat = "dd-MM-yyyy";
            try
            {
                return dt.ToString(dateFormat);
            }
            catch (Exception e)
            {
                return DateTime.MinValue.ToString(dateFormat);
            }
        }

        // Grid Functions......
        #region

        //public static DataGridViewCell GetNextCell(DataGridView gridView)
        //{
            //int i = 0;
            //DataGridViewCell nextCell = gridView.CurrentCell;
            //do
            //{
                //int nextCellIndex = (nextCell.ColumnIndex + 1) % gridView.ColumnCount;
                //int nextRowIndex = nextCellIndex == 0 ? (nextCell.RowIndex + 1) % gridView.RowCount : nextCell.RowIndex;
                //nextCell = gridView.Rows[nextRowIndex].Cells[nextCellIndex];
               // i++;
            //}
            //while (i < gridView.RowCount * gridView.ColumnCount && nextCell.ReadOnly && nextCell.OwningColumn.Name != HeaderName.Name && nextCell.OwningColumn.Name != HeaderName.Item);

           // return nextCell;
        //}

        #endregion

        // Bind Function.....................................................
        #region

        public static void getMinimumInterestPer(ComboBox cmb)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("code", typeof(string));
            dt.Columns.Add("name", typeof(string));
            dt.Rows.Add("Days", "Days");
            dt.Rows.Add("Months", "Months");

            cmb.DataSource = dt;
            cmb.DisplayMember = "name";
            cmb.ValueMember = "code";
            cmb.SelectedIndex = 0;
        }

        public static void getBalanceFormate(ComboBox cmb)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("code", typeof(string));
            dt.Columns.Add("formate", typeof(int));
            dt.Rows.Add("Jama", "-", "1");
            dt.Rows.Add("Naam", "+", "1");

            cmb.DataSource = dt;
            cmb.DisplayMember = "name";
            cmb.ValueMember = "code";
            cmb.SelectedIndex = 0;
        }

        public static void getRelationship(ComboBox CoBox)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("code");
            dt.Columns.Add("name");
            dt.Rows.Add("S/O", "S/O");
            dt.Rows.Add("W/O", "W/O");
            dt.Rows.Add("H/O", "H/O");

            CoBox.DataSource = dt;
            CoBox.DisplayMember = "name";
            CoBox.ValueMember = "code";
            CoBox.SelectedIndex = 0;
        }

        public static void getAllStateWithCode(ComboBox CoBox)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("code");
            dt.Rows.Add("-----Select-----", "0");
            dt.Rows.Add("Jammu & Kashmir", "01");
            dt.Rows.Add("Himachal Pradesh", "02");
            dt.Rows.Add("Punjab", "03");
            dt.Rows.Add("Chandigarh", "04");
            dt.Rows.Add("Uttarakhand", "05");
            dt.Rows.Add("Haryana", "06");
            dt.Rows.Add("Delhi", "07");
            dt.Rows.Add("Rajasthan", "08");
            dt.Rows.Add("Uttar Pradesh", "09");
            dt.Rows.Add("Bihar", "10");
            dt.Rows.Add("Sikkim", "11");
            dt.Rows.Add("Arunachal Pradesh", "12");
            dt.Rows.Add("Nagaland", "13");
            dt.Rows.Add("Manipur", "14");
            dt.Rows.Add("Mizoram", "15");
            dt.Rows.Add("Tripura", "16");
            dt.Rows.Add("Meghalaya", "17");
            dt.Rows.Add("Assam", "18");
            dt.Rows.Add("West Bengal", "19");
            dt.Rows.Add("Jharkhand", "20");
            dt.Rows.Add("Odisha", "21");
            dt.Rows.Add("Chhattisgarh", "22");
            dt.Rows.Add("Madhya Pradesh", "23");
            dt.Rows.Add("Gujarat", "24");
            dt.Rows.Add("Daman & Diu", "25");
            dt.Rows.Add("Dadra & Nagar Haveli", "26");
            dt.Rows.Add("Maharashtra", "27");
            dt.Rows.Add("Andhra Pradesh", "28");
            dt.Rows.Add("Karnataka", "29");
            dt.Rows.Add("Goa", "30");
            dt.Rows.Add("Lakshdweep", "31");
            dt.Rows.Add("Kerala", "32");
            dt.Rows.Add("Tamil Nadu", "33");
            dt.Rows.Add("Pondicherry", "34");
            dt.Rows.Add("Andaman & Nicobar Islands", "35");
            dt.Rows.Add("Telangana", "36");
            dt.Rows.Add("Andhra Pradesh (New)", "37");

            CoBox.DataSource = dt;
            CoBox.DisplayMember = "name";
            CoBox.ValueMember = "code";
            CoBox.SelectedIndex = 0;
        }

        public static void getAllType(ComboBox CoBox)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("name");
                dt.Columns.Add("code");
                dt.Rows.Add("-------Type-------", "-------Type-------");
                dt.Rows.Add("Supplier", "Supplier");
                dt.Rows.Add("Customer", "Customer");
                dt.Rows.Add("Bank", "Bank");
                dt.Rows.Add("Capital", "Capital");
                dt.Rows.Add("Expense", "Expense");
                dt.Rows.Add("Parcel", "Parcel");
                dt.Rows.Add("Other", "Other");
                dt.Rows.Add("MCX", "MCX");
                dt.Rows.Add("Interest", "Interest");

                CoBox.DataSource = dt;
                CoBox.DisplayMember = "name";
                CoBox.ValueMember = "code";
                CoBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void getMetal(ComboBox CoMetal)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("code");
            dt.Rows.Add("SILVER", "SILVER");
            dt.Rows.Add("GOLD", "GOLD");
            dt.Rows.Add("OTHER", "OTHER");

            CoMetal.DataSource = dt;
            CoMetal.DisplayMember = "name";
            CoMetal.ValueMember = "code";
            CoMetal.SelectedIndex = 0;
        }

        public static DataTable bindItems(string query = null)
        {
            if (query == null)
                query = "Select code, name from " + TableNames.Item;
            DataTable dt = Helper.getTable(query);
            if (dt != null && dt.Rows.Count > 0)
                return dt;

            return null;
        }

        public static DataTable bindParty(string query = null)
        {
            if(query == null)
                query = "Select code, name from " + TableNames.Party;
            DataTable dt = Helper.getTable(query);
            if(dt != null && dt.Rows.Count > 0)
                return dt;

            return null; 
        }

        public static String callList(string listName)
        {
            string QueryString = " ";
            if (listName.ToLower() == "party")
                QueryString = "SELECT `code`, `name` FROM " + TableNames.Party;
            else if (listName.ToLower() == "subparty")
                QueryString = "SELECT '' AS code, '' AS name UNION SELECT code, name FROM " + TableNames.Party;
            else if (listName.ToLower() == "item")
                QueryString = "SELECT code , name FROM " + TableNames.Item;
            else if (listName.ToLower() == "prename")
                QueryString = "";

            ListPopup frm = new ListPopup(QueryString: QueryString);
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                switch (listName.ToLower())
                {
                    case "party":
                        return frm.CodeColumn;
                    case "subparty":
                        return frm.CodeColumn;
                    case "item":
                        return frm.CodeColumn;
                    case "prename":
                        return frm.CodeColumn;
                }
            }
            return null;
        }

        #endregion


        // Image Functions...............................................................
        #region

        public static string bind_Img(string code, string form)
        {
            string fileName = "", folderName = "";
            folderName = form + "_Image";
            fileName = code + "." + "jpg";
            string imgPath = (Application.StartupPath + "\\" + folderName + "\\" + companyName + "\\" + fileName + "");
            try
            {
                if (File.Exists(imgPath))
                    return imgPath;
            }
            catch (Exception ex) { }
            return "";
        }

        public static void sav_Img(string imgPath, string code, string form)
        {
            try
            {
                //imgPath = imgPath.Replace("\\", "\\\\");
                string folderName = Helper.MyCStr(form);
                folderName = Helper.MyCStr(form) + "_Image";
                try
                {
                    if (!Directory.Exists(Application.StartupPath + "\\" + folderName + "\\" + companyName + "\\"))
                        Directory.CreateDirectory(Application.StartupPath + "\\" + folderName + "\\" + companyName + "\\");
                }
                catch (Exception ex) { }

                //string imgPath = pictureBox1.ImageLocation;
                if (imgPath == null || imgPath == "")
                {
                    //imgPath = images_path.ToString();
                    return;
                }
                else
                {
                    string fileName = Helper.MyCStr(code);
                    fileName = Helper.MyCStr(code) + "." + "jpg";
                    try
                    {
                        if (File.Exists(Application.StartupPath + "\\" + folderName + "\\" + companyName + "\\" + fileName))
                            File.Delete(Application.StartupPath + "\\" + folderName + "\\" + companyName + "\\" + fileName);
                    }
                    catch (Exception ex) { }
                    PictureBox pic = new PictureBox();
                    if (imgPath != "" && imgPath != null)
                    {
                        pic.Image = Image.FromFile(imgPath);
                        pic.Image.Save(Application.StartupPath + "\\" + folderName + "\\" + companyName + "\\" + fileName + "");
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); }
        }

        #endregion



        // Function for Getting data..................................................................
        #region

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
                    if (!ismanual)
                    {
                        //string query = "select max(convert(substr(code, " + (len + 1) + ", length(code)- " + len + "),signed integer)) from " + tablename + whereClause;
                        string query = "select max(substr(code, " + (len + 1) + ", length(code)- " + len + "):: integer) from " + tablename + whereClause;
                        DataTable dt1 = Helper.getTable(query);
                        string maxcode = Helper.MyCStr(dt1.Rows[0][0]);

                        id = getID(prefix, (Convert.ToInt32(maxcode) + 1));
                    }
                    else
                    {
                        string query = "select max(copy_manualItemCode) from " + tablename + whereClause;
                        DataTable dt1 = Helper.getTable(query);
                        string maxcode = Helper.MyCStr(dt1.Rows[0][0]);
                        id = getID(prefix, (Convert.ToInt32(maxcode) + 1), ismanualCode: ismanual);
                    }
                }
                return id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
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


        public static Boolean getPresentID(string fieldName, string tableName, string Id = "")
        {
            string getCode = "SELECT " + fieldName + " FROM " + tableName + " WHERE code = '" + Id + "'";
            DataTable dt = Helper.getTable(getCode);
            if (dt.Rows.Count > 0 && dt.Rows != null)
                return true;

            return false;
        }

        public static String getMaxPresentID(string fieldName, string tableName, string date = "")
        {
            string billNo = null;
            double val = 0;
            string getCode = "SELECT MAX(" + fieldName + ") FROM " + tableName + " WHERE DATE(bill_date) = '" + date + "'";
            DataTable dt = Helper.getTable(getCode);
            if (dt != null && dt.Rows.Count > 0 && Helper.MyCStr(dt.Rows[0][0]) != "")
            {
                val = Helper.MyCDbl(dt.Rows[0][0]);
                billNo = Helper.MyCStr(val + 1);
                return billNo;
            }
            else
                billNo = "1";

            return billNo;
        }

        public static String getNameByCode(String Code, String TableName)
        {
            string name = "";
            string getData = "Select name from " + TableName + " where code = '" + Code + "'";
            DataTable dt = Helper.getTable(getData);
            if (dt != null && dt.Rows.Count > 0)
            {
                name = Helper.MyCStr(dt.Rows[0][0]);
                return name;
            }

            return null;
        }

        #endregion



        // Forms Attaching Points :- Show, Demo, EntryLimits.......
        #region

        public static void ShowForm(Form frm)
        {
            if (Instance.isDemoVersion)
            {
                if (entriesLimit())
                    frm.Show();
                else
                {
                    MessageBox.Show("Demo Entries Limit has been Full. Please Contact : 8439770023");
                    return;
                }
            }
            else
                frm.Show();
        }

        // check entries limits......
        public static Boolean entriesLimit()
        {
            string getEntries = "SELECT COUNT(*) FROM " + TableNames.Party;
            DataTable dt = Helper.getTable(getEntries);
            if (dt != null && dt.Rows.Count > 0)
            {
                if (Instance.EntriesLimit >= Helper.MycInt(dt.Rows[0][0]))
                    return true;
            }
            return false;
        }

        #endregion



        // Ruff Functions.......................................................................
        #region

        public static void StartProcess(string formName)
        {

            if (formName != "" && formName != null)
            {
                int wait = 0;
                while (true)
                {
                    string str = "select distinct username from tbl_activform";
                    DataTable dt = Helper.getTable(str);
                    if (dt.Rows.Count == 0)
                    {
                        NpgsqlConnection c = new NpgsqlConnection();
                        c = Helper.getConnection();
                        NpgsqlTransaction trans = c.BeginTransaction();
                        string str1 = "insert into tbl_activform(name) values('" + formName + "')";
                        NpgsqlCommand cmd = new NpgsqlCommand(str1, c);
                        cmd.ExecuteNonQuery();
                        trans.Commit();
                        break;
                    }
                    else
                    {
                        Thread.Sleep(1000);
                        wait++;
                    }
                    if (wait >= 10)
                    {
                        NpgsqlConnection c = new NpgsqlConnection();
                        c = Helper.getConnection();
                        NpgsqlTransaction trans = c.BeginTransaction();
                        string str1 = "delete from tbl_activform";
                        NpgsqlCommand cmd = new NpgsqlCommand(str1, c);
                        cmd.ExecuteNonQuery();
                        trans.Commit();
                    }
                }
            }
        }

        public static void StopProcess()
        {
            NpgsqlConnection c = new NpgsqlConnection();
            c = Helper.getConnection();
            //MySqlTransaction trans = c.BeginTransaction();
            string str1 = "delete from  tbl_activform ";
            NpgsqlCommand cmd = new NpgsqlCommand(str1, c);
            //trans.Commit();
            cmd.ExecuteNonQuery();
        }

        #endregion

    }
}
