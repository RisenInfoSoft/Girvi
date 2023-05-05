using Girvi.Classes;
using Girvi.Forms.Desktop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Girvi.Forms.Pop_Up_Form
{
    public partial class ListPopup : Form
    {
        public string CodeColumn = null;
        public Boolean dialogResult = true;
        public string TableName = "";
        public string QueryString = "";
        public ListPopup(string TableName = "", string QueryString = "")
        {
            InitializeComponent();
            this.TableName = TableName;
            this.QueryString = QueryString;
        }

        private void ListPopup_Load(object sender, EventArgs e)
        {
            if (this.QueryString != "")
            {
                DataTable dt = Helper.getTable(this.QueryString);
                dt.DefaultView.Sort = "name asc";
                dt = dt.DefaultView.ToTable();

                if (dt.Rows.Count > 0)
                {
                    myGridView1.DataSource = dt;
                    myGridView1.Columns["Code"].Width = 40;
                    myGridView1.Columns["Name"].Width = 100;
                    myGridView1.Columns["Code"].Visible = false;
                    myGridView1.Columns["Name"].HeaderText = "Select";
                }
            }
            
        }

        private void ListPopup_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string name = Helper.MyCStr(textBox1.Text);
                    string gridName = "";
                    if (myGridView1.Columns.Contains("Name"))
                         gridName = Helper.MyCStr(myGridView1.Rows[0].Cells["Name"].Value);

                    if (name.ToLower() == gridName.ToLower())
                    {
                        this.CodeColumn = Helper.MyCStr(myGridView1.Rows[0].Cells[0].Value);
                        this.DialogResult = DialogResult.OK;
                        this.dialogResult = true;
                    }

                    int i = 0;
                    foreach (DataGridViewRow grid in myGridView1.Rows)
                    {
                        if (myGridView1.Rows[i].Cells[1].Selected == true)
                        {
                            this.CodeColumn = Helper.MyCStr(myGridView1.Rows[i].Cells[0].Value);
                            this.DialogResult = DialogResult.OK;
                            this.dialogResult = true;
                            break;
                        }
                        i++;
                    }

                }

                if (e.KeyCode == Keys.Escape)
                    this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            string keywords = textBox1.Text;
            DataTable dt = (DataTable)myGridView1.DataSource;
            if (dt != null)
                dt.DefaultView.RowFilter = string.Format("Name LIKE '%{0}%'", keywords);
            resizeGridView();
        }

        private void resizeGridView()
        {
            this.myGridView1.Width = this.Width - 20;
            this.myGridView1.Height = this.myGridView1.Rows.Count * 22 + 21;
            if (this.myGridView1.Height > this.Height - this.myGridView1.Location.Y)
            {
                this.myGridView1.Height = this.Height - this.myGridView1.Location.Y;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                SendKeys.Send("{tab}");
        }
    }
}
