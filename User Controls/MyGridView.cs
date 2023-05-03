using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using Girvi.Classes;

namespace Girvi
{
    public class MyGridView : DataGridView
    {
        public Boolean editMode = false;
        public Boolean isReport = false;
        public Boolean isHindiOn = false;
        public Boolean keepOnCurrentCell = false;
        public Boolean ignoreEnter = false;

        //public Boolean sameBarcode = false;
        public DataGridViewRow deletedRow;
        public MyGridView()
        {
            this.RowsDefaultCellStyle.BackColor = Color.FromArgb(200,200,255);
            this.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 220, 255);
            //this.CellEndEdit += new DataGridViewCellEventHandler(MyGridView_CellEndEdit);
            this.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;
            this.RowsDefaultCellStyleChanged += new System.EventHandler(this.MyGridView_RowsDefaultCellStyleChanged);
            this.StandardTab = true;
        }

        //private void MyGridView_CellEndEdit(Object sender, EventArgs e)
        //{
        //    //MyListView listView = Global.objRetailShop.frmmylistview.myListView1;
        //    if (Global.objRetailShop_ListView_PopUp != null)
        //    {
        //        MyListView listView = Global.objRetailShop_ListView_PopUp.frmmylistview.myListView1; //Global.objRetailShop.frmmylistview.myListView1;
        //        String entered_val = Utilities.MyCStr(this.CurrentCell.Value);
        //        String tag = listView.validate(Utilities.MyCStr(this.CurrentCell.Value));
        //        if (editMode)
        //        {
        //            //MyListView listView = Global.objRetailShop.frmmylistview.myListView1;
        //            //String entered_val = Utilities.MyCStr(this.CurrentCell.Value);
        //            //String tag = listView.validate(Utilities.MyCStr(this.CurrentCell.Value));
        //            if (tag == null)
        //            {

        //                this.CurrentCell.Value = "";
        //                this.CurrentCell.Tag = "";
        //                /*
        //                if (this.Columns[this.CurrentCell.ColumnIndex].Name == HeaderNames.Item_Description)
        //                {
        //                    DialogResult result = MessageBox.Show("Do You want to create item", "", MessageBoxButtons.YesNo);
        //                    if (result == DialogResult.Yes)
        //                    {
        //                        String code = Common.createNewItem(entered_val);
        //                        this.CurrentCell.Tag = code;
        //                        this.CurrentCell.Value = entered_val;
        //                        DataTable dt = Utilities.getTable("select code, name from " + TableNames.ItemMaster);
        //                        Global.objRetailShop.frmmylistview.myListView1.DataSource = dt;
        //                    }
        //                    //Common.attachTextboxToListView(frmMylistView1, "Item Name", dt, (TextBox)e.Control, 1, 0);
        //                }
        //                 */

        //            }
        //            else
        //                this.CurrentCell.Tag = tag;
        //        }
        //        else
        //            this.CurrentCell.Tag = tag;
        //    }
        //}

        private List<ClsColumnStyle> CollColumnStyle=new List<ClsColumnStyle>();
       
        //public void AddColumn(ClsColumnStyle colstyle)
        //{
           
        //    CollColumnStyle.Add(colstyle);
        //}
        public void CreateGrid()
        {
            foreach (ClsColumnStyle obj in CollColumnStyle)
            {
                if (obj.IsComboColumn)
                {
                    DataGridViewComboBoxColumn col = new DataGridViewComboBoxColumn();
                    col.AutoComplete = true;
                    col.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
                    col.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.AliceBlue;
                    String qry;
                    if(obj.TableComboName == TableNames.Party)
                        qry = "select code,name from " + obj.TableComboName;
                    else
                        qry = "select code,CONCAT(code,' || ',name) name from " + obj.TableComboName;
                    DataTable dtCombo = Helper.getTable(qry);
                    col.DataSource = dtCombo;
                    col.ValueMember = "code";
                    col.DisplayMember = "name";
                    DataRow dr = dtCombo.NewRow();
                    dr["code"]="select";
                    dr["name"] = "--select--";
                    dtCombo.Rows.InsertAt(dr, 0);
                    
                    
                    col.DisplayIndex = obj.ColumnPosition;
                    col.HeaderText = obj.ColumnName;
                    col.Name = obj.ColumnName;
                    col.Width = obj.ColumnWidth;
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    Columns.Add(col);
                    
                }
                else
                {
                    
                    DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                    col.HeaderText = obj.ColumnName;
                    col.Name = obj.ColumnName;
                    col.Width = obj.ColumnWidth;
                    col.DisplayIndex = obj.ColumnPosition;
                    col.DefaultCellStyle.Alignment = obj.Alignment;
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    Columns.Add(col);
                    if (obj.IsEditable == false)
                    {
                        Columns[col.DisplayIndex].ReadOnly = true;
                    }
                
                }
                
            }
        }
        
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (this.ignoreEnter)
                return base.ProcessCmdKey(ref msg, keyData);

            if (keyData == Keys.Enter && !isReport)
            {
                DataGridViewCell currCell = this.CurrentCell;
                if(currCell.ReadOnly == true)
                    return base.ProcessCmdKey(ref msg, keyData);

            }

            if (keyData == Keys.Enter && !isReport)
            {
                DataGridViewCell currCell = this.CurrentCell;
                if (currCell == null)
                    return base.ProcessCmdKey(ref msg, keyData);
                int colNo = this.CurrentCell.ColumnIndex;
                int rowNo = this.CurrentCell.RowIndex;
                int numCols = this.ColumnCount;
                int numRows = this.RowCount;

              
                
                while (true)
                {
                    if (colNo == numCols - 1)
                    {
                        if (rowNo < numRows - 1)
                        {
                            rowNo += 1;
                            colNo = 0;
                            if (this[colNo, rowNo].Visible)
                                this.CurrentCell = this[colNo, rowNo];
                            else
                                continue;
                        }
                        break;
                    }
                    else
                    {
                        colNo += 1;
                        if (this[colNo, rowNo].Visible)
                            this.CurrentCell = this[colNo, rowNo];
                        else
                            continue;
                        break;
                    }
                }
                return true;
                //return base.ProcessCmdKey(ref msg, keyData);
            }
            else if (keyData == Keys.Delete && !isReport)
            {
                Boolean isEdit = this.CurrentCell.IsInEditMode;
                if (isEdit) return base.ProcessCmdKey(ref msg, keyData);
                else
                {
                    try
                    {
                        deletedRow = this.CurrentRow;
                        //return base.ProcessCmdKey(ref msg, keyData);
                        this.Rows.RemoveAt(this.CurrentRow.Index);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
                return true;
            }
            else if (keyData == Keys.Escape && !isReport)
            {
                try
                {
                    return base.ProcessCmdKey(ref msg, keyData);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void setAlignment()
        {
            if (this.DataSource == null || this.RowCount == 0)
                return;
            else
            {
                for (int i = 0; i < this.ColumnCount; i++)
                {
                    Object val = this.Rows[0].Cells[i].Value;
                    try
                    {
                        double doubleVal = Convert.ToDouble(val);
                        this.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                    }
                    catch (Exception e)
                    {

                    }

                }
            }
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // MyGridView
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.EditModeChanged += new System.EventHandler(this.MyGridView_EditModeChanged);
            this.Enter += new System.EventHandler(this.MyGridView_Enter);
            this.Leave += new System.EventHandler(this.MyGridView_Leave);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        private void MyGridView_RowsDefaultCellStyleChanged(object sender, EventArgs e)
        {
            
        }

        //private void MyGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        //{
        //    if (this.Columns[this.CurrentCell.ColumnIndex].HeaderText == HeaderNames.Barcode)
        //    {
        //        this.keepOnCurrentCell = true;
        //    }
        //}

        private void MyGridView_EditModeChanged(object sender, EventArgs e)
        {
            
        }

        public void MyGridView_Enter(object sender, EventArgs e)
        {
            this.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        }

        public void MyGridView_Leave(object sender, EventArgs e)
        {
            this.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
        }

      
        
        
    }



}


