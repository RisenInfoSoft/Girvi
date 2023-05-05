using Girvi.Classes;
using Girvi.Forms.Desktop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Girvi.Forms.Pop_Up_Form
{
    public partial class popController : Form
    {
        public Boolean isMainController = false;
        public DataGridView tempGrid = new DataGridView();
        public popController()
        {
            InitializeComponent();
            createGrid();
            tempGrid.ColumnCount = 2;
            tempGrid.Columns[0].Name = HeaderName.Controls;
            tempGrid.Columns[1].Name = HeaderName.Value;
        }

        private void createGrid()
        {
            try
            {
                myGridView1.ColumnCount = 2;
                myGridView1.Columns[0].Name = HeaderName.Controls;
                myGridView1.Columns[1].Name = HeaderName.Value;

                double totalWidth = myGridView1.Width;
                myGridView1.Columns[HeaderName.Controls].Width = Helper.MycInt(totalWidth * 0.60);
                myGridView1.Columns[HeaderName.Value].Width = Helper.MycInt(totalWidth * 0.40);
                myGridView1.Columns[HeaderName.Controls].ReadOnly = true;

                this.myGridView1.RowCount = Instance.instanceVars.Count;

                int i = 0;
                foreach (string key in Instance.instanceVars.Keys)
                {
                    if (key == "")
                        continue;

                    this.myGridView1.Rows[i].Cells[HeaderName.Controls].Value = key;
                    this.myGridView1.Rows[i].Cells[HeaderName.Value].Value = Helper.MyCStr(Instance.instanceVars[key]);
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            txtSearch.Focus();
        }

        private void popController_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                    this.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
           
        }

        

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                SendKeys.Send("{tab}");
        }

        private void Btn_cancle_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Btn_save_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.tempGrid.Rows) 
                Instance.instanceVars[Helper.MyCStr(row.Cells[0].Value)] = Helper.MyCStr(row.Cells[1].Value);
            Stream stream = File.Open(Instance.instance_Directory, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, Instance.instanceVars);
            stream.Close();
            Instance.initializeMap(); 
            this.Dispose();
        }

        private void MyGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow gridRow = myGridView1.CurrentRow;
                DataGridViewRow gr = gridRow;
                if (gr != null)
                    tempGrid.Rows.Add(gr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void MyGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (myGridView1.CurrentRow == null)
                    return;
                string key_value = Helper.MyCStr(myGridView1.CurrentRow.Cells[1].Value);
                if ((myGridView1.CurrentRow.Cells[1].Value).Equals("True") || (myGridView1.CurrentRow.Cells[1].Value).Equals("False"))
                {

                    myGridView1.CurrentRow.Cells[1].ReadOnly = true;
                    if (e.KeyCode == Keys.T)
                    {
                        myGridView1.CurrentRow.Cells[1].Value = "True";
                    }
                    else if (e.KeyCode == Keys.F)
                    {
                        myGridView1.CurrentRow.Cells[1].Value = "False";
                    }
                    else
                        myGridView1.CurrentRow.Cells[1].Value = key_value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            MyGridView1_CellEndEdit(null, null);
        }
    }
}
