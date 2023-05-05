using Girvi.Classes;
using Girvi.Forms.Pop_Up_Form;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Girvi.Forms.Master_Form
{
    public partial class frmAccountMaster : Form
    {
        string imgPath = null;
        public frmAccountMaster()
        {
            InitializeComponent();
            txtPartyCode.Text = Common.getNextID(TableNames.Party);
            Common.getAllType(cmbType);
            Common.getRelationship(cmbNamePrefix);
            Common.getAllStateWithCode(cmbo_state);
            Common.getBalanceFormate(cmbBalFormate);
            Common.getMinimumInterestPer(cmbMinIntPer);
            dtp1.Focus();
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            frmClsMsgBox frm = new frmClsMsgBox();
            frm.ShowDialog();
            if(frm.DialogResult == DialogResult.Yes)
                this.Close();
        }

        public void Reset()
        {
            try
            {
                txtPartyCode.Text = Helper.MyCStr(Helper.getNextID(TableNames.Party));
                pictureBox1.ImageLocation = null;
                cmbType.SelectedValue = 0;
                txt_name.Text = "";
                cmbNamePrefix.SelectedIndex = 0;
                txtRelation.Text = "";
                txtPrintName.Text = "";
                txt_mobile.Text = "";
                txt_address.Text = "";
                txt_email.Text = "";
                txt_remark.Text = "";
                dtp1.Value = DateTime.Now;
                cmbo_state.SelectedIndex = 0;
                cmbo_city.Text = "";
                txtOpeningCash.Text = "";
                cmbBalFormate.SelectedIndex = 0;
                txtIntRate.Text = "";
                cmbMinIntPer.Text = "";
                cmbType.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        public bool validate()
        {
            try
            {
                string name = txt_name.Text.Trim();
                string type = cmbType.Text.Trim();
                string state = cmbo_state.Text.Trim();
                string city = cmbo_city.Text.Trim();

                if (type == "" || type == "-------Type-------")
                {
                    MessageBox.Show("Please select Type.");
                    cmbType.Focus();
                    return false;
                }
                if (state == "" || state == "-----Select-----")
                {
                    MessageBox.Show("Please select state.");
                    cmbo_state.Focus();
                    return false;
                }
                if (city == "" || city == "-----Select-----")
                {
                    MessageBox.Show("Please select city.");
                    cmbo_city.Focus();
                    return false;
                }
                if (name == "")
                {
                    MessageBox.Show("Please fill the account name.");
                    txt_name.Focus();
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
        }

        private void btn_brows_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Select Image";
            DialogResult dr = openFileDialog1.ShowDialog();
            if(dr.ToString() == "OK")
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName.Replace("\\", "\\\\"); 
                this.imgPath = pictureBox1.ImageLocation;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!validate())
                return;
            string Id = Helper.MyCStr(Helper.getNextID(TableNames.Party));
            string Name = Helper.MyCStr(txt_name.Text);
            string namePrefix = Helper.MyCStr(cmbNamePrefix.SelectedValue);
            string relationalName = Helper.MyCStr(txtRelation.Text);
            string printName = Helper.MyCStr(txtPrintName.Text);
            string Address = Helper.MyCStr(txt_address.Text);
            string Remark = Helper.MyCStr(txt_remark.Text);
            string Mobile = Helper.MyCStr(txt_mobile.Text);
            string Date = Common.getVoucherMysqlDate(dtp1.Value);
            string Type = Helper.MyCStr(cmbType.Text);
            string Email = Helper.MyCStr(txt_email.Text);
            string City = Helper.MyCStr(cmbo_city.Text);
            string State = Helper.MyCStr(cmbo_state.Text);
            string openingCash = Helper.MyCStr(txtOpeningCash.Text);
            string balanceFormate = Helper.MyCStr(cmbBalFormate.SelectedValue);
            string intRate = Helper.MyCStr(txtIntRate.Text);
            string minIntPer = Helper.MyCStr(cmbMinIntPer.SelectedValue);
            string image = imgPath;
            Common.sav_Img(imgPath: imgPath, code: Id, form: "Party");

            NpgsqlConnection con = Helper.getConnection();
            NpgsqlTransaction trans = con.BeginTransaction();

            try
            {
                ColumnDataCollection coll = new ColumnDataCollection();

                coll.Add("code", Id);
                coll.Add("name", Name);
                coll.Add("nameprefix", namePrefix);
                coll.Add("relationalname", relationalName);
                coll.Add("printname", printName);
                coll.Add("address", Address);
                coll.Add("remark", Remark);
                coll.Add("mobile", Mobile);
                coll.Add("date", Date);
                coll.Add("type", Type);
                coll.Add("email", Email);
                coll.Add("city", City);
                coll.Add("state", State);
                coll.Add("cashbalance", openingCash);
                //coll.Add("openingcash", balanceFormate);
                coll.Add("interestrate", intRate);
                coll.Add("mininterestper", minIntPer);
                coll.Add("image", image);
                Helper.UpdateTable("party", coll, RSAUpdateTableType.Insert, null, con, trans);
                MessageBox.Show("Saved successfully");
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show(ex.Message);
            }
            Reset();
        }

        private void dtp1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbType.Focus();
        }

        private void CmbType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txt_name.Focus();
        }

        private void txt_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbNamePrefix.Focus();
        }

        private void cmbNamePrefix_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtRelation.Focus();
        }

        private void TxtRelation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtPrintName.Focus();
        }

        private void TxtPrintName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txt_mobile.Focus();
        }

        private void txt_mobile_KeyDown(object sender, KeyEventArgs e)
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
                txt_remark.Focus();
        }

        private void txt_remark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtOpeningCash.Focus();
        }

        private void TxtOpeningCash_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbBalFormate.Focus();
        }

        private void cmbBalFormate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtIntRate.Focus();
        }

        private void TxtIntRate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbMinIntPer.Focus();
        }

        private void CmbMinIntPer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_save.Focus();
        }

        
    }
    
}
