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
    public partial class frmItemMaster : Form
    {
        string imagePath = null;
        public frmItemMaster()
        {
            InitializeComponent();
            bind_metal();
            txt_item_name.Focus();
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            frmClsMsgBox frm = new frmClsMsgBox();
            frm.ShowDialog();
            if(frm.DialogResult == DialogResult.Yes)
                this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!validation())
                return;

            string Id = Helper.MyCStr(Helper.getNextID(TableNames.Item));
            string Name = Helper.MyCStr(txt_item_name.Text);
            string Metal = Helper.MyCStr(cmbo_metal.Text);
            string Category = Helper.MyCStr(cmbo_catgry.Text);
            string Remark = Helper.MyCStr(txt_remark.Text);

            Common.sav_Img(imgPath:imagePath , code:Id, form:"Item");

            NpgsqlConnection con = Helper.getConnection();
            NpgsqlTransaction trans = con.BeginTransaction();

            try
            {
                ColumnDataCollection coll = new ColumnDataCollection();

                coll.Add("code", Id);
                coll.Add("name", Name);
                coll.Add("metal", Metal);
                coll.Add("category", Category);
                coll.Add("remark", Remark);
                Helper.UpdateTable(TableNames.Item, coll, RSAUpdateTableType.Insert, null, con, trans);
                MessageBox.Show("Saved successfully");
                trans.Commit();
                Reset();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show(ex.Message);
            }
        }

        private void bind_metal()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("code");
            dt.Rows.Add("SILVER","SILVER");
            dt.Rows.Add("GOLD","GOLD");

            cmbo_metal.DataSource = dt;
            cmbo_metal.DisplayMember = "name";
            cmbo_metal.ValueMember = "code";
            cmbo_metal.SelectedIndex = 0;
        }

        private void Reset()
        {
            pictureBox1.ImageLocation = null;
            txt_item_name.Text = "";
            txt_remark.Text = "";
            cmbo_catgry.Text = "";
            bind_metal();
            txt_item_name.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Select Image";
            DialogResult dr = openFileDialog1.ShowDialog();
            if(dr.ToString() == "OK")
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName.Replace("\\", "\\\\");
                this.imagePath = pictureBox1.ImageLocation;
            }
        }

        public bool validation()
        {
            string item_name = txt_item_name.Text.Trim();
            string metal = cmbo_metal.Text.Trim();

            if (item_name == "")
            {
                MessageBox.Show("Please fill Item Name");
                txt_item_name.Focus();
                return false;
            }
            if (metal == "")
            {
                MessageBox.Show("Please select metal");
                cmbo_metal.Focus();
                return false;
            }
            

            return true;
        }

        private void txt_item_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbo_metal.Focus();
        }

        private void cmbo_metal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbo_catgry.Focus();
        }

        private void cmbo_catgry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txt_remark.Focus();
        }

        private void txt_remark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btn_save.Focus();
        }

       
    }
}
