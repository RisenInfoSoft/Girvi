using System;
using Girvi.Classes;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using Girvi.Forms.Pop_Up_Form;
using Npgsql;

namespace Girvi.Forms.View
{
    public partial class frmPartyList : Form
    {
        string imgPath = null;
        string companyName = Helper.MyCStr(Instance.companyName).ToLower();
        public frmPartyList()
        {
            InitializeComponent();
            Common.getAllType(cmbo_type);
            Common.getRelationship(cmbNamePrefix);
            Common.getAllStateWithCode(cmbo_state);
            Common.getBalanceFormate(cmbBalFormate);
            bind_Data();
        }

        public void bind_Data()
        {
            string get_Data = "SELECT CODE AS CODE, NAME AS NAME, TYPE AS TYPE FROM party";
            DataTable dt = Helper.getTable(get_Data);
            if(dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                string code = Helper.MyCStr(dt.Rows[0]["CODE"]);
                string get_data = "select * from party where code = '"+ code +"'";
                DataTable dt0 = Helper.getTable(get_data);
                if(dt0.Rows.Count > 0)
                {
                    txt_code.Text = Helper.MyCStr(dt0.Rows[0]["code"]);
                    txt_name.Text = Helper.MyCStr(dt0.Rows[0]["name"]);
                    txt_address.Text = Helper.MyCStr(dt0.Rows[0]["address"]);
                    txt_remark.Text = Helper.MyCStr(dt0.Rows[0]["remark"]);
                    txt_phone.Text = Helper.MyCStr(dt0.Rows[0]["mobile"]);
                    txt_email.Text = Helper.MyCStr(dt0.Rows[0]["email"]);
                    cmbo_city.Text = Helper.MyCStr(dt0.Rows[0]["city"]);
                    cmbo_state.Text = Helper.MyCStr(dt0.Rows[0]["state"]);
                    ddl_date.Value = Helper.MyCDate(dt0.Rows[0]["date"]);
                    cmbo_type.Text = Helper.MyCStr(dt0.Rows[0]["type"]);
                    pictureBox1.ImageLocation = Common.bind_Img(code:txt_code.Text, form: "Party");
                }
                
            }
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            frmClsMsgBox frm = new frmClsMsgBox();
            frm.ShowDialog();
            if(frm.DialogResult == DialogResult.Yes)
                this.Close();
        }

        private void txt_search_KeyUp(object sender, KeyEventArgs e)
        {
            string keywords = txt_search.Text;
            DataTable dt = (DataTable)dataGridView1.DataSource;
            if (dt != null)
                dt.DefaultView.RowFilter = string.Format("code LIKE '%{0}%' OR name LIKE '%{0}%' OR type LIKE '%{0}%'", keywords);
            resizeGridView();
        }

        private void resizeGridView()
        {
            this.dataGridView1.Width = this.Width - 20;
            this.dataGridView1.Height = this.dataGridView1.Rows.Count * 22 + 21;
            if (this.dataGridView1.Height > this.Height - this.dataGridView1.Location.Y)
            {
                this.dataGridView1.Height = this.Height - this.dataGridView1.Location.Y;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!validate())
                return;

            NpgsqlConnection con = Helper.getConnection();
            NpgsqlTransaction trans = con.BeginTransaction();
            try
            {
                string Type = Helper.MyCStr(cmbo_type.Text);
                string Id = Helper.MyCStr(txt_code.Text);
                string Name = Helper.MyCStr(txt_name.Text);
                string Address = Helper.MyCStr(txt_address.Text);
                string Remark = Helper.MyCStr(txt_remark.Text);
                string Mobile = Helper.MyCStr(txt_phone.Text);
                string Date = Common.getVoucherMysqlDate(ddl_date.Value);
                string Email = Helper.MyCStr(txt_email.Text);
                string City = Helper.MyCStr(cmbo_city.Text);
                string State = Helper.MyCStr(cmbo_state.Text);
                string image = imgPath;
                Common.sav_Img(imgPath:imgPath, code:Id, form:"Party");
                
                ColumnDataCollection coll = new ColumnDataCollection();

                coll.Add("name", Name);
                coll.Add("address", Address);
                coll.Add("remark", Remark);
                coll.Add("mobile", Mobile);
                coll.Add("date", Date);
                coll.Add("type", Type);
                coll.Add("email", Email);
                coll.Add("city", City);
                coll.Add("state", State);
                coll.Add("image", image);
                Helper.UpdateTable(TableNames.Party, coll, RSAUpdateTableType.Update, "code = '"+ Id +"'", con, trans);
                MessageBox.Show("Saved successfully");

                trans.Commit();
                Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-US"));
                bind_Data();
                //setEditable(false);
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show(ex.Message);
            }
        }

        public bool validate()
        {
            string type = cmbo_type.Text.Trim();
            string state = cmbo_state.Text.Trim();
            if (type == "" || type == "-------Type-------")
            {
                MessageBox.Show("Please select account type.");
                cmbo_type.Focus();
                return false;
            }
            if (state == "" || state == "-----Select-----")
            {
                MessageBox.Show("Please select state.");
                cmbo_state.Focus();
                return false;
            }
            if (type == "Supplier" || type == "Customer" || type == "Other" || type == "Karigar" || type == "Tunch" || type == "Parcel" || type == "MCX" || type == "Interest")
            {
                if (txt_name.Text.Trim() == "")
                {
                    MessageBox.Show("Please fill the account name.");
                    txt_name.Focus();
                    return false;
                }

            }


            return true;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            pictureBox1.ImageLocation = null;
            int ind = e.RowIndex;
            DataGridViewRow selectedRows = dataGridView1.CurrentRow;
            if (selectedRows == null)
                return;

            string code = selectedRows.Cells[0].Value.ToString();
            string party = selectedRows.Cells[1].Value.ToString();
            string get_data = "SELECT CODE, NAME, nameprefix, relationalname, printname, address, remark, mobile, email, DATE(date) AS date, city, state, TYPE, cashbalance, interestrate, mininterestper FROM party WHERE CODE = '" + code + "' AND NAME = '"+ party + "'";
            DataTable dt = Helper.getTable(get_data);
            if(dt.Rows.Count > 0)
            {
                txt_code.Text = Helper.MyCStr(dt.Rows[0]["CODE"]);
                cmbo_type.Text = Helper.MyCStr(dt.Rows[0]["TYPE"]);
                txt_name.Text = Helper.MyCStr(dt.Rows[0]["NAME"]);
                cmbNamePrefix.SelectedValue = Helper.MyCStr(dt.Rows[0]["nameprefix"]);
                txtRelation.Text = Helper.MyCStr(dt.Rows[0]["relationalname"]);
                txtPrintName.Text = Helper.MyCStr(dt.Rows[0]["printname"]);
                txt_address.Text = Helper.MyCStr(dt.Rows[0]["address"]);
                txt_remark.Text = Helper.MyCStr(dt.Rows[0]["remark"]);
                txt_phone.Text = Helper.MyCStr(dt.Rows[0]["mobile"]);
                txt_email.Text = Helper.MyCStr(dt.Rows[0]["email"]);
                cmbo_city.Text = Helper.MyCStr(dt.Rows[0]["city"]);
                cmbo_state.Text = Helper.MyCStr(dt.Rows[0]["state"]);
                ddl_date.Value = Helper.MyCDate(dt.Rows[0]["date"]);
                txtOpeningCash.Text = Helper.MyCStr(dt.Rows[0]["cashbalance"]);
                txtIntRate.Text = Helper.MyCStr(dt.Rows[0]["interestrate"]);
                cmbMinIntPer.SelectedValue = Helper.MyCStr(dt.Rows[0]["mininterestper"]);

                pictureBox1.ImageLocation = Common.bind_Img(code: txt_code.Text, form: "Party");
                if (pictureBox1.ImageLocation == null || pictureBox1.ImageLocation == "")
                    pictureBox1.Image = pictureBox1.BackgroundImage;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Select Image";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr.ToString() == "OK")
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName.Replace("\\", "\\\\");
                this.imgPath = pictureBox1.ImageLocation;
            }
        }

        private void ddl_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbo_type.Focus();
        }

        private void cmbo_type_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txt_name.Focus();
        }

        private void txt_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txt_phone.Focus();
        }

        private void txt_phone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbo_state.Focus();
        }

        private void cmbo_state_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbo_city.Focus();
        }

        private void cmbo_city_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txt_remark.Focus();
        }

        private void txt_remark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txt_address.Focus();
        }

        private void txt_address_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txt_email.Focus();
        }

        private void txt_email_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_save.Focus();
        }


        private void frmPartyList_KeyDown(object sender, KeyEventArgs e)
        {
            try 
            {
                string value = Helper.MyCStr(txt_search.Text);

                if (value == "")
                    lblSearch.Visible = true;
                else
                    lblSearch.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}
