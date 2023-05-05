using Kate.Classes;
using Kate.Forms.Pop_Up_Form;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kate.Forms.View
{
   public partial class frmItemList : Form
   {
        string imgPath = null;
        public frmItemList()
        {
            InitializeComponent();
            bind_Grid();
            bind_metal();
        }

        private void bind_Grid()
        {
            string get_Data = "select code AS CODE, name AS NAME, metal AS METAL from itemmaster";
            DataTable dt = Utilities.getTable(get_Data);
            if(dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                string code = Utilities.MyCStr(dt.Rows[0]["CODE"]);
                string get_data = "select * from itemmaster where code = '" + code + "'";
                DataTable dt0 = Utilities.getTable(get_data);
                if (dt0.Rows.Count > 0)
                {
                    txt_code.Text = Utilities.MyCStr(dt0.Rows[0]["code"]);
                    txt_item_name.Text = Utilities.MyCStr(dt0.Rows[0]["name"]);
                    ddl_date.Value = Utilities.MyCDate(dt0.Rows[0]["date"]);
                    cmbo_metal.Text = Utilities.MyCStr(dt0.Rows[0]["metal"]);
                    cmbo_catgry.Text = Utilities.MyCStr(dt0.Rows[0]["category"]);
                    txt_remark.Text = Utilities.MyCStr(dt0.Rows[0]["remark"]);
                    pictureBox1.ImageLocation = Common.bind_Img(code: txt_code.Text, form: "Item");
                }
            }
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

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            frmClsMsgBox frm = new frmClsMsgBox();
            frm.ShowDialog();
            if(frm.DialogResult == DialogResult.Yes)
                this.Close();
        }

        private void bind_metal()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("name");
            dt.Columns.Add("code");
            dt.Rows.Add("SILVER", "SILVER");
            dt.Rows.Add("GOLD", "GOLD");

            cmbo_metal.DataSource = dt;
            cmbo_metal.DisplayMember = "name";
            cmbo_metal.ValueMember = "code";
            cmbo_metal.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Select Image";
            DialogResult dr = openFileDialog1.ShowDialog();
            if(dr.ToString() == "OK")
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName.Replace("\\","\\\\");
                this.imgPath = pictureBox1.ImageLocation;
            }
        }

        private void txt_search_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                string keywords = txt_search.Text;
                DataTable dt = (DataTable)dataGridView1.DataSource;
                if (dt != null)
                    dt.DefaultView.RowFilter = string.Format("code LIKE '%{0}%' OR name LIKE '%{0}%' OR metal LIKE '%{0}%'", keywords);
                resizeGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToUpperInvariant());
            }
        }

       
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            pictureBox1.ImageLocation = null;
            int ind = e.RowIndex;
            DataGridViewRow selectedRows = dataGridView1.CurrentRow;
            if (selectedRows == null)
                return;

            string code = selectedRows.Cells[0].Value.ToString();
            string item = selectedRows.Cells[1].Value.ToString();
            string get_data = "SELECT CODE, NAME, remark, DATE(date) AS date, metal, category FROM itemmaster WHERE CODE = '" + code + "' AND NAME = '" + item + "'";
            DataTable dt = Utilities.getTable(get_data);
            if (dt.Rows.Count > 0)
            {
                txt_code.Text = Utilities.MyCStr(dt.Rows[0]["CODE"]);
                txt_item_name.Text = Utilities.MyCStr(dt.Rows[0]["NAME"]);
                txt_remark.Text = Utilities.MyCStr(dt.Rows[0]["remark"]);
                cmbo_metal.Text = Utilities.MyCStr(dt.Rows[0]["metal"]);
                ddl_date.Value = Utilities.MyCDate(dt.Rows[0]["date"]);
                cmbo_catgry.Text = Utilities.MyCStr(dt.Rows[0]["category"]);

                pictureBox1.ImageLocation = Common.bind_Img(code: txt_code.Text, form: "Item");
                if (pictureBox1.ImageLocation == null || pictureBox1.ImageLocation == "")
                    pictureBox1.Image = pictureBox1.BackgroundImage;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!validate())
                return;

            MySqlConnection con = Utilities.getConnection();
            MySqlTransaction trans = con.BeginTransaction();
            try
            {
                string Id = Utilities.MyCStr(txt_code.Text);
                string Name = Utilities.MyCStr(txt_item_name.Text);
                string Remark = Utilities.MyCStr(txt_remark.Text);
                string Date = Common.getVoucherMysqlDate(ddl_date.Value);
                string Category = Utilities.MyCStr(cmbo_catgry.Text);
                string Metal = Utilities.MyCStr(cmbo_metal.Text);
                string image = imgPath;
                Common.sav_Img(imgPath: imgPath, code: Id, form: "Item");

                ColumnDataCollection coll = new ColumnDataCollection();

                coll.Add("name", Name);
                coll.Add("remark", Remark);
                coll.Add("date", Date);
                coll.Add("category", Category);
                coll.Add("metal", Metal);
                coll.Add("image", image);
                Utilities.UpdateTable(TableNames.Item, coll, RSAUpdateTableType.Update, "code = '" + Id + "'", con, trans);
                MessageBox.Show("Saved successfully");

                trans.Commit();
                Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-US"));
                bind_Grid();
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
            string metal = cmbo_metal.Text.Trim();
            //string category = cmbo_catgry.Text.Trim();
            if (metal == "")
            {
                MessageBox.Show("Please select metal type.");
                cmbo_metal.Focus();
                return false;
            }
            //if (category == "")
            //{
            //    MessageBox.Show("Please select category.");
            //    return false;
            //}
            if (txt_item_name.Text.Trim() == "")
            {
                MessageBox.Show("Please fill the account name.");
                txt_item_name.Focus();
                return false;
            }

            return true;
        }

        private void ddl_date_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txt_item_name.Focus();
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
