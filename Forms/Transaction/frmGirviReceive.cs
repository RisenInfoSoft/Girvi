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
    public partial class frmGirviReceive : Form
    {
        String Code = "";
        
        public frmGirviReceive(String Code = null)
        {
            InitializeComponent();
            
            this.Code = Code; 
            //if(this.Code == "" || this.Code == null)
            //    txt_code.Text = Helper.MyCStr(Helper.getNextID(TableNames.Tunch));

            bindGrid();
            bindParty();
            bindSubParty();
            bindItem();
            //Common.getMetal(cmbo_metal);
            dtp1.Focus();
        }

        private void btn_cancle_Click(object sender, EventArgs e)
        {
            frmClsMsgBox frm = new frmClsMsgBox();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.Yes)
                Dispose(true);
        }

        public void Reset()
        {
            cmbName.SelectedIndex = 0;
            //cmbo_metal.SelectedIndex = 0;
            dtp1.Value = DateTime.Now;
            //txt_code.Text = Helper.MyCStr(Helper.getNextID(TableNames.Tunch));
            cmbName.Focus();
        }
       
        public bool validate()
        {
            string name = Helper.MyCStr(cmbName.Text.Trim());
            //string matel = Helper.MyCStr(cmbo_metal.Text.Trim());

            if (name == "")
            {
                MessageBox.Show("Please select the Party Name.");
                cmbName.Focus();
                return false;
            }
            //if (matel == "")
            //{
            //    MessageBox.Show("Please select Metal.");
            //    cmbo_metal.Focus();
            //    return false;
            //}
            
            return true;
        }

        
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (!validate())
                return;

            string Code = Helper.MyCStr(txt_code.Text);
            string Date = Common.getVoucherMysqlDate(dtp1.Value);
            string Name = Helper.MyCStr(cmbName.SelectedValue);

            NpgsqlConnection con = Helper.getConnection();
            NpgsqlTransaction trans = con.BeginTransaction();

            try
            {
                Boolean Update = Common.getPresentID(fieldName: "code", tableName: TableNames.Tunch, Id: Code);
                ColumnDataCollection coll = new ColumnDataCollection();
                
                coll.Add("bill_date", Date);
                coll.Add("party_code", Name);

                if (Update)
                {
                    Helper.UpdateTable(TableNames.Tunch, coll, RSAUpdateTableType.Update, "code = '" + Code + "'", con, trans);
                }
                else
                {
                    coll.Add("code", Code);
                    Helper.UpdateTable(TableNames.Tunch, coll, RSAUpdateTableType.Insert, null, con, trans);
                }

                MessageBox.Show("Saved successfully");
                trans.Commit();
                
            }
            catch (Exception ex)
            {
                trans.Rollback();
                MessageBox.Show(ex.Message); 
            }
            try
            {
                btnPrint.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void cmb_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string chkQuery = "Select code, name from party where name = '" + cmbName.Text + "'";
                    DataTable dt = Helper.getTable(chkQuery);
                    if (dt.Rows.Count == 0)
                    {
                        DialogResult result = MessageBox.Show("" + cmbName.Text + " Does not exist,do you want to Create Now? ", "", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            string newPartyCode = Helper.getNextID(TableNames.Party);
                            string partyname = Helper.MyCStr(cmbName.Text);
                            if (partyname == "")
                            {
                                MessageBox.Show("Please fill the Party Name.");
                                return;
                            }

                            NpgsqlConnection con = Helper.getConnection();
                            ColumnDataCollection coll = new ColumnDataCollection();
                            DateTime defaultDate = new DateTime(2016, 4, 1, 12, 0, 0);

                            coll.Add("code", newPartyCode);
                            coll.Add("name", partyname);
                            coll.Add("type", "Customer");
                            coll.Add("date", Common.getVoucherMysqlDate(defaultDate));

                            Helper.UpdateTable(TableNames.Party, coll, RSAUpdateTableType.Insert, "", con);
                            bindParty();
                            cmbName.Text = partyname;
                        }
                        else
                        {
                            cmbName.Text = "";
                            bindParty();
                            cmbName.SelectedValue = Common.callList("Party");
                        }
                    }
                    else
                        cmbName.SelectedValue = Common.callList("Party");
                    
                }
                catch (Exception ex) { }
            }
                
        }

        private void bindParty()
        {
            string getParty = "SELECT code, name FROM " + TableNames.Party;
            DataTable dt = Helper.getTable(getParty);
            if (dt.Rows.Count > 0 && dt.Rows != null)
            {
                cmbName.DataSource = dt;
                cmbName.DisplayMember = "name";
                cmbName.ValueMember = "code";
            }
        }

        private void bindSubParty()
        {
            string getParty = "SELECT code, name FROM " + TableNames.Party;
            DataTable dt = Helper.getTable(getParty);
            if (dt.Rows.Count > 0 && dt.Rows != null)
            {
                DataRow dr = dt.NewRow();
                dr["name"] = "";
                dr["code"] = "";
                dt.Rows.InsertAt(dr, 0);
            }
        }

        private void bindItem()
        {
            String getItem = "SELECT code , name FROM " + TableNames.Item;
            DataTable dt = Helper.getTable(getItem);
            if (dt.Rows.Count > 0 && dt.Rows != null)
            {
                //cmb_item.DataSource = dt;
                //cmb_item.DisplayMember = "name";
                //cmb_item.ValueMember = "code";
            }
        }

        private void btn_Clr_Click(object sender, EventArgs e)
        {
            Reset();
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            btn_Clr.Focus();
        }

        private void bindGrid()
        {
            //try
            //{
            //    myGridView1.ColumnCount = 11;
            //    myGridView1.Columns[0].Name = HeaderName.Sn;
            //    myGridView1.Columns[1].Name = HeaderName.Metal;
            //    myGridView1.Columns[2].Name = HeaderName.Item;
            //    myGridView1.Columns[3].Name = HeaderName.Quantity;
            //    myGridView1.Columns[4].Name = HeaderName.Gross_Wt;
            //    myGridView1.Columns[5].Name = HeaderName.Less;
            //    myGridView1.Columns[6].Name = HeaderName.Net_Wt;
            //    myGridView1.Columns[7].Name = HeaderName.Tunch;
            //    myGridView1.Columns[8].Name = HeaderName.Metal_Rate;
            //    myGridView1.Columns[9].Name = HeaderName.Fine;
            //    myGridView1.Columns[10].Name = HeaderName.Valuation;

            //    myGridView1.Columns[HeaderName.Sn].FillWeight = 1.0f;
            //    myGridView1.Columns[HeaderName.Metal].FillWeight = 2.0f;
            //    myGridView1.Columns[HeaderName.Item].FillWeight = 7.0f;
            //    myGridView1.Columns[HeaderName.Quantity].FillWeight = 2.0f;
            //    myGridView1.Columns[HeaderName.Gross_Wt].FillWeight = 3.0f;
            //    myGridView1.Columns[HeaderName.Less].FillWeight = 2.0f;
            //    myGridView1.Columns[HeaderName.Net_Wt].FillWeight = 3.0f;
            //    myGridView1.Columns[HeaderName.Tunch].FillWeight = 2.0f;
            //    myGridView1.Columns[HeaderName.Metal_Rate].FillWeight = 3.0f;   
            //    myGridView1.Columns[HeaderName.Fine].FillWeight = 3.0f;
            //    myGridView1.Columns[HeaderName.Valuation].FillWeight = 5.0f;

            //    myGridView1.Columns[HeaderName.Sn].ReadOnly = true;
            //    myGridView1.Columns[HeaderName.Item].ReadOnly = true;
            //    myGridView1.Columns[HeaderName.Fine].ReadOnly = true;
            //    myGridView1.Columns[HeaderName.Valuation].ReadOnly = true;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            //try
            //{
            //    string[] headers = new string[] { HeaderName.Sn, HeaderName.Metal, HeaderName.Item, HeaderName.Quantity, HeaderName.Gross_Wt, HeaderName.Less, HeaderName.Net_Wt, HeaderName.Tunch, HeaderName.Metal_Rate, HeaderName.Fine, HeaderName.Valuation };
            //    float[] fillWeights = new float[] { 1.0f, 2.0f, 7.0f, 2.0f, 3.0f, 2.0f, 3.0f, 2.0f, 3.0f, 3.0f, 4.0f };

            //    myGridView1.ColumnCount = headers.Length;
            //    for (int i = 0; i < headers.Length; i++)
            //    {
            //        myGridView1.Columns[i].Name = headers[i];
            //        myGridView1.Columns[i].FillWeight = fillWeights[i];
            //        myGridView1.Columns[i].ReadOnly = (headers[i] == HeaderName.Sn || headers[i] == HeaderName.Item || headers[i] == HeaderName.Fine);
            //    }

            //    double totalWeight = 1.0;
            //    totalWeight += fillWeights.Sum();
            //    for (int i = 0; i < headers.Length; i++)
            //    {
            //        myGridView1.Columns[i].Width = (int)((myGridView1.Width - myGridView1.RowHeadersWidth) * (myGridView1.Columns[i].FillWeight / totalWeight));
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            try
            {
                string[] headers = new string[] { HeaderName.Sn, HeaderName.Item, HeaderName.Quantity, HeaderName.Gross_Wt, HeaderName.Less, HeaderName.Net_Wt, HeaderName.Tunch, HeaderName.Metal_Rate, HeaderName.Fine, HeaderName.Valuation };
                float[] fillWeights = new float[] { 1.0f, 5.0f, 1.5f, 2.0f, 1.5f, 2.0f, 1.2f, 2.0f, 2.0f, 3.0f };

                myGridView1.ColumnCount = headers.Length;
                for (int i = 0; i < headers.Length; i++)
                {
                    myGridView1.Columns[i].Name = headers[i];
                    myGridView1.Columns[i].FillWeight = fillWeights[i];
                    myGridView1.Columns[i].ReadOnly = (headers[i] == HeaderName.Fine);

                    if (headers[i] == HeaderName.Item)
                    {
                        DataTable colTable = new DataTable();
                        if (headers[i] == HeaderName.Item)
                            colTable = Common.bindItems();

                        int originalIndex = myGridView1.Columns[HeaderName.Item].Index;
                        myGridView1.Columns.RemoveAt(originalIndex);

                        DataGridViewComboBoxColumn itemComboBoxColumn = CreateComboBoxColumn(headers[i], fillWeights[i], colTable);
                        myGridView1.Columns.Insert(originalIndex, itemComboBoxColumn);

                        myGridView1.EditingControlShowing += (sender, e) =>
                        {
                            if (e.Control is ComboBox comboBox && myGridView1.CurrentCell.OwningColumn.Name == HeaderName.Item)
                            {
                                comboBox.DropDownStyle = ComboBoxStyle.DropDown;
                                comboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                                comboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
                                comboBox.DisplayMember = "name";
                                comboBox.ValueMember = "code";
                                comboBox.DataSource = colTable;
                            }
                        };
                    }
                }

                double totalWeight = 1.0;
                totalWeight += fillWeights.Sum();
                for (int i = 0; i < headers.Length; i++)
                {
                    myGridView1.Columns[i].Width = (int)((myGridView1.Width - myGridView1.RowHeadersWidth) * (myGridView1.Columns[i].FillWeight / totalWeight));
                }
            }
            catch(Exception ex)
            {
                
            }
            
        }

        private DataGridViewComboBoxColumn CreateComboBoxColumn(string columnName, float fillWeights, DataTable dataSource)
        {
            DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            comboBoxColumn.HeaderText = columnName;
            comboBoxColumn.Name = columnName;
            comboBoxColumn.FillWeight = fillWeights;
            comboBoxColumn.AutoComplete = true;
            comboBoxColumn.DisplayMember = "name";
            comboBoxColumn.ValueMember = "code";
            comboBoxColumn.DataSource = dataSource;

            return comboBoxColumn;
        }

        private void MyGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            //{
            //    if (myGridView1.CurrentCell.ReadOnly)
            //        myGridView1.CurrentCell = Common.GetNextCell(gridView: myGridView1);
            //    e.Handled = true;
            //}

            //if (e.KeyCode == Keys.Enter)
            //{
            //    e.SuppressKeyPress = true;
            //    int rowIndex = myGridView1.CurrentCell.RowIndex;
            //    int columnIndex = myGridView1.CurrentCell.ColumnIndex;
            //    DataGridViewCell nextCell = null;
            //    if (columnIndex < myGridView1.Columns.Count - 1)
            //    {
            //        nextCell = myGridView1[columnIndex + 1, rowIndex];
            //    }
            //    else if (rowIndex < myGridView1.Rows.Count - 1)
            //    {
            //        nextCell = myGridView1[0, rowIndex + 1];
            //    }
            //    if (nextCell != null && !nextCell.ReadOnly)
            //    {
            //        myGridView1.CurrentCell = nextCell;
            //    }
            //}

            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.SuppressKeyPress = true;
                    int rowIndex = myGridView1.CurrentCell.RowIndex;
                    int columnIndex = myGridView1.CurrentCell.ColumnIndex;
                    DataGridViewCell nextCell = null;

                    do
                    {
                        if (columnIndex < myGridView1.Columns.Count - 1)
                        {
                            nextCell = myGridView1[columnIndex + 1, rowIndex];
                            columnIndex++;
                        }
                        else if (rowIndex < myGridView1.Rows.Count - 1)
                        {
                            nextCell = myGridView1[0, rowIndex + 1];
                            rowIndex++;
                            columnIndex = 0;
                        }
                        else
                        {
                            nextCell = null;
                        }
                    }
                    while (nextCell != null && nextCell.ReadOnly);

                    if (nextCell != null)
                    {
                        myGridView1.CurrentCell = nextCell;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            
        }

        private void FrmGirviReceive_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //if (e.KeyCode == Keys.Enter && myGridView1.CurrentCell.OwningColumn.Name == HeaderName.Name)
                //{
                //    string QueryString = "select  code, name  from party";
                //    ListPopup frm = new ListPopup(QueryString: QueryString);
                //    if (myGridView1.CurrentRow != null)
                //        frm.ShowDialog();
                //    if (frm.DialogResult == DialogResult.OK)
                //    {
                //        myGridView1.CurrentRow.Cells[HeaderName.Name].Value = Common.getNameByCode(Code: frm.CodeColumn, TableName: TableNames.Party);
                //        myGridView1.CurrentRow.Cells[HeaderName.Name].Tag = frm.CodeColumn;
                //    }
                //}

                //if (e.KeyCode == Keys.Enter && myGridView1.CurrentCell.OwningColumn.Name == HeaderName.Item)
                //{
                //    string party = Helper.MyCStr(myGridView1.CurrentRow.Cells[HeaderName.Name].Tag);
                //    //string QueryString = "SELECT p.item_code CODE, im.name NAME FROM " + TableNames.PartyWiseValueSet + " p JOIN itemmaster im ON (p.item_code = im.code) WHERE party_code = '" + party + "' ";
                //    string QueryString = "SELECT code, name  from " + TableNames.Item;
                //    ListPopup frm = new ListPopup(QueryString: QueryString);
                //    if (myGridView1.CurrentRow != null)
                //        frm.ShowDialog();
                //    if (frm.DialogResult == DialogResult.OK)
                //    {
                //        myGridView1.CurrentRow.Cells[HeaderName.Item].Value = Common.getNameByCode(Code: frm.CodeColumn, TableName: TableNames.Item);
                //        myGridView1.CurrentRow.Cells[HeaderName.Item].Tag = frm.CodeColumn;
                //    }
                //}

                if (e.KeyCode == Keys.Escape)
                    btn_cancle_Click(null, null);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void Dtp1_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbName.Focus();
        }

        private void CmbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txt_mobile.Focus();
        }

        private void Txt_mobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txt_address.Focus();
        }

        private void Txt_address_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txt_remark.Focus();
        }

        private void Txt_remark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                cmbInterestType.Focus();
        }

        private void CmbInterestType_KeyDown(object sender, KeyEventArgs e)
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
                txtPrincipleAmt.Focus();
        }

        private void TxtPrincipleAmt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                rdoSecure.Focus();
        }

        private void RdoSecure_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                rdoUnSecure.Focus();
        }

        private void RdoUnSecure_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                myGridView1.Focus();
        }

        private void myGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double netWt = Helper.MyCDbl(myGridView1.Rows[e.RowIndex].Cells[HeaderName.Net_Wt].Value);
            double tunch = Helper.MyCDbl(myGridView1.Rows[e.RowIndex].Cells[HeaderName.Tunch].Value);

            if (myGridView1.Columns[e.ColumnIndex].Name == HeaderName.Tunch)
            {
                double fine = (netWt * tunch) / 100;
                myGridView1.Rows[e.RowIndex].Cells[HeaderName.Fine].Value = fine;
            }
        }
    }
    

}
