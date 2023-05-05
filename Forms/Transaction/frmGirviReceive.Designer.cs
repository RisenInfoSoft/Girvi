
namespace Girvi.Forms.Master_Form
{
    partial class frmGirviReceive
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        /// DONE by akhil.....
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGirviReceive));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblFine = new System.Windows.Forms.Label();
            this.txtFine = new System.Windows.Forms.TextBox();
            this.lblValuation = new System.Windows.Forms.Label();
            this.txtValuation = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btn_Clr = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAddon = new System.Windows.Forms.Button();
            this.txtPrincipleAmt = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.lblPrincipleAmt = new System.Windows.Forms.Label();
            this.rdoSecure = new System.Windows.Forms.RadioButton();
            this.btnPayment = new System.Windows.Forms.Button();
            this.rdoUnSecure = new System.Windows.Forms.RadioButton();
            this.cmbInterestType = new System.Windows.Forms.ComboBox();
            this.lblInterestType = new System.Windows.Forms.Label();
            this.cmbMinIntPer = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIntRate = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_brows = new System.Windows.Forms.Button();
            this.txt_code = new System.Windows.Forms.TextBox();
            this.txt_remark = new System.Windows.Forms.TextBox();
            this.txt_address = new System.Windows.Forms.TextBox();
            this.cmbName = new System.Windows.Forms.ComboBox();
            this.txt_mobile = new System.Windows.Forms.TextBox();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_mobile = new System.Windows.Forms.Label();
            this.lbl_code = new System.Windows.Forms.Label();
            this.lbl_remark = new System.Windows.Forms.Label();
            this.lbl_address = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.myGridView1 = new Girvi.MyGridView();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.SandyBrown;
            this.groupBox3.Controls.Add(this.lblFine);
            this.groupBox3.Controls.Add(this.txtFine);
            this.groupBox3.Controls.Add(this.lblValuation);
            this.groupBox3.Controls.Add(this.txtValuation);
            this.groupBox3.Controls.Add(this.btnPrint);
            this.groupBox3.Controls.Add(this.btn_Clr);
            this.groupBox3.Controls.Add(this.panel2);
            this.groupBox3.Controls.Add(this.btn_save);
            this.groupBox3.Controls.Add(this.btn_cancle);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // lblFine
            // 
            resources.ApplyResources(this.lblFine, "lblFine");
            this.lblFine.ForeColor = System.Drawing.Color.Black;
            this.lblFine.Name = "lblFine";
            // 
            // txtFine
            // 
            resources.ApplyResources(this.txtFine, "txtFine");
            this.txtFine.Name = "txtFine";
            // 
            // lblValuation
            // 
            resources.ApplyResources(this.lblValuation, "lblValuation");
            this.lblValuation.ForeColor = System.Drawing.Color.Black;
            this.lblValuation.Name = "lblValuation";
            // 
            // txtValuation
            // 
            resources.ApplyResources(this.txtValuation, "txtValuation");
            this.txtValuation.Name = "txtValuation";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.Lime;
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btn_Clr
            // 
            this.btn_Clr.BackColor = System.Drawing.Color.Red;
            this.btn_Clr.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btn_Clr, "btn_Clr");
            this.btn_Clr.ForeColor = System.Drawing.Color.White;
            this.btn_Clr.Name = "btn_Clr";
            this.btn_Clr.UseVisualStyleBackColor = false;
            this.btn_Clr.Click += new System.EventHandler(this.btn_Clr_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.dataGridView1);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.SaddleBrown;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.Crimson;
            resources.ApplyResources(this.btn_save, "btn_save");
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Name = "btn_save";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancle
            // 
            this.btn_cancle.BackColor = System.Drawing.Color.Red;
            this.btn_cancle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btn_cancle, "btn_cancle");
            this.btn_cancle.ForeColor = System.Drawing.Color.White;
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.UseVisualStyleBackColor = false;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LemonChiffon;
            this.groupBox1.Controls.Add(this.dtp1);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // dtp1
            // 
            resources.ApplyResources(this.dtp1, "dtp1");
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp1.Name = "dtp1";
            this.dtp1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Dtp1_KeyDown_1);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkKhaki;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btnAddon);
            this.panel3.Controls.Add(this.txtPrincipleAmt);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.btnTransfer);
            this.panel3.Controls.Add(this.lblPrincipleAmt);
            this.panel3.Controls.Add(this.rdoSecure);
            this.panel3.Controls.Add(this.btnPayment);
            this.panel3.Controls.Add(this.rdoUnSecure);
            this.panel3.Controls.Add(this.cmbInterestType);
            this.panel3.Controls.Add(this.lblInterestType);
            this.panel3.Controls.Add(this.cmbMinIntPer);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtIntRate);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // btnAddon
            // 
            this.btnAddon.BackColor = System.Drawing.Color.DarkSlateGray;
            resources.ApplyResources(this.btnAddon, "btnAddon");
            this.btnAddon.ForeColor = System.Drawing.Color.White;
            this.btnAddon.Name = "btnAddon";
            this.btnAddon.UseVisualStyleBackColor = false;
            // 
            // txtPrincipleAmt
            // 
            resources.ApplyResources(this.txtPrincipleAmt, "txtPrincipleAmt");
            this.txtPrincipleAmt.Name = "txtPrincipleAmt";
            this.txtPrincipleAmt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPrincipleAmt_KeyDown);
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.cmbType);
            this.panel5.Controls.Add(this.lblType);
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Name = "panel5";
            // 
            // cmbType
            // 
            this.cmbType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            resources.ApplyResources(this.cmbType, "cmbType");
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Name = "cmbType";
            // 
            // lblType
            // 
            resources.ApplyResources(this.lblType, "lblType");
            this.lblType.Name = "lblType";
            // 
            // btnTransfer
            // 
            this.btnTransfer.BackColor = System.Drawing.Color.DarkSlateGray;
            resources.ApplyResources(this.btnTransfer, "btnTransfer");
            this.btnTransfer.ForeColor = System.Drawing.Color.White;
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.UseVisualStyleBackColor = false;
            // 
            // lblPrincipleAmt
            // 
            resources.ApplyResources(this.lblPrincipleAmt, "lblPrincipleAmt");
            this.lblPrincipleAmt.Name = "lblPrincipleAmt";
            // 
            // rdoSecure
            // 
            resources.ApplyResources(this.rdoSecure, "rdoSecure");
            this.rdoSecure.Name = "rdoSecure";
            this.rdoSecure.TabStop = true;
            this.rdoSecure.UseVisualStyleBackColor = true;
            this.rdoSecure.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RdoSecure_KeyDown);
            // 
            // btnPayment
            // 
            this.btnPayment.BackColor = System.Drawing.Color.DarkSlateGray;
            resources.ApplyResources(this.btnPayment, "btnPayment");
            this.btnPayment.ForeColor = System.Drawing.Color.White;
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.UseVisualStyleBackColor = false;
            // 
            // rdoUnSecure
            // 
            resources.ApplyResources(this.rdoUnSecure, "rdoUnSecure");
            this.rdoUnSecure.Name = "rdoUnSecure";
            this.rdoUnSecure.TabStop = true;
            this.rdoUnSecure.UseVisualStyleBackColor = true;
            this.rdoUnSecure.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RdoUnSecure_KeyDown);
            // 
            // cmbInterestType
            // 
            this.cmbInterestType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbInterestType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            resources.ApplyResources(this.cmbInterestType, "cmbInterestType");
            this.cmbInterestType.FormattingEnabled = true;
            this.cmbInterestType.Name = "cmbInterestType";
            this.cmbInterestType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbInterestType_KeyDown);
            // 
            // lblInterestType
            // 
            resources.ApplyResources(this.lblInterestType, "lblInterestType");
            this.lblInterestType.Name = "lblInterestType";
            // 
            // cmbMinIntPer
            // 
            this.cmbMinIntPer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMinIntPer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            resources.ApplyResources(this.cmbMinIntPer, "cmbMinIntPer");
            this.cmbMinIntPer.FormattingEnabled = true;
            this.cmbMinIntPer.Name = "cmbMinIntPer";
            this.cmbMinIntPer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbMinIntPer_KeyDown);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // txtIntRate
            // 
            resources.ApplyResources(this.txtIntRate, "txtIntRate");
            this.txtIntRate.Name = "txtIntRate";
            this.txtIntRate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtIntRate_KeyDown);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btn_brows);
            this.panel1.Controls.Add(this.txt_code);
            this.panel1.Controls.Add(this.txt_remark);
            this.panel1.Controls.Add(this.txt_address);
            this.panel1.Controls.Add(this.cmbName);
            this.panel1.Controls.Add(this.txt_mobile);
            this.panel1.Controls.Add(this.lbl_name);
            this.panel1.Controls.Add(this.lbl_mobile);
            this.panel1.Controls.Add(this.lbl_code);
            this.panel1.Controls.Add(this.lbl_remark);
            this.panel1.Controls.Add(this.lbl_address);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // btn_brows
            // 
            resources.ApplyResources(this.btn_brows, "btn_brows");
            this.btn_brows.Name = "btn_brows";
            this.btn_brows.UseVisualStyleBackColor = true;
            // 
            // txt_code
            // 
            resources.ApplyResources(this.txt_code, "txt_code");
            this.txt_code.Name = "txt_code";
            this.txt_code.ReadOnly = true;
            // 
            // txt_remark
            // 
            resources.ApplyResources(this.txt_remark, "txt_remark");
            this.txt_remark.Name = "txt_remark";
            this.txt_remark.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_remark_KeyDown);
            // 
            // txt_address
            // 
            resources.ApplyResources(this.txt_address, "txt_address");
            this.txt_address.Name = "txt_address";
            this.txt_address.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_address_KeyDown);
            // 
            // cmbName
            // 
            this.cmbName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            resources.ApplyResources(this.cmbName, "cmbName");
            this.cmbName.FormattingEnabled = true;
            this.cmbName.Name = "cmbName";
            this.cmbName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbName_KeyDown);
            // 
            // txt_mobile
            // 
            resources.ApplyResources(this.txt_mobile, "txt_mobile");
            this.txt_mobile.Name = "txt_mobile";
            this.txt_mobile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txt_mobile_KeyDown);
            // 
            // lbl_name
            // 
            resources.ApplyResources(this.lbl_name, "lbl_name");
            this.lbl_name.Name = "lbl_name";
            // 
            // lbl_mobile
            // 
            resources.ApplyResources(this.lbl_mobile, "lbl_mobile");
            this.lbl_mobile.ForeColor = System.Drawing.Color.Black;
            this.lbl_mobile.Name = "lbl_mobile";
            // 
            // lbl_code
            // 
            resources.ApplyResources(this.lbl_code, "lbl_code");
            this.lbl_code.ForeColor = System.Drawing.Color.Black;
            this.lbl_code.Name = "lbl_code";
            // 
            // lbl_remark
            // 
            resources.ApplyResources(this.lbl_remark, "lbl_remark");
            this.lbl_remark.ForeColor = System.Drawing.Color.Black;
            this.lbl_remark.Name = "lbl_remark";
            // 
            // lbl_address
            // 
            resources.ApplyResources(this.lbl_address, "lbl_address");
            this.lbl_address.ForeColor = System.Drawing.Color.Black;
            this.lbl_address.Name = "lbl_address";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.SandyBrown;
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.myGridView1);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // myGridView1
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.myGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.myGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.myGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.myGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.myGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.myGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.myGridView1, "myGridView1");
            this.myGridView1.Name = "myGridView1";
            this.myGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.myGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.myGridView1.StandardTab = true;
            this.myGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.myGridView1_CellEndEdit);
            this.myGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MyGridView1_KeyDown);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmGirviReceive
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SaddleBrown;
            this.CancelButton = this.btn_cancle;
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "frmGirviReceive";
            this.Opacity = 0.95D;
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.TransparencyKey = System.Drawing.Color.SaddleBrown;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmGirviReceive_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbl_code;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private MyGridView myGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btn_Clr;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.ComboBox cmbMinIntPer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIntRate;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.Label lbl_mobile;
        private System.Windows.Forms.Label lbl_remark;
        private System.Windows.Forms.Label lbl_address;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.TextBox txt_remark;
        private System.Windows.Forms.TextBox txt_address;
        private System.Windows.Forms.ComboBox cmbName;
        private System.Windows.Forms.TextBox txt_mobile;
        private System.Windows.Forms.Button btnAddon;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.TextBox txt_code;
        private System.Windows.Forms.RadioButton rdoSecure;
        private System.Windows.Forms.RadioButton rdoUnSecure;
        private System.Windows.Forms.ComboBox cmbInterestType;
        private System.Windows.Forms.Label lblInterestType;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_brows;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblPrincipleAmt;
        private System.Windows.Forms.TextBox txtPrincipleAmt;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblFine;
        private System.Windows.Forms.TextBox txtFine;
        private System.Windows.Forms.Label lblValuation;
        private System.Windows.Forms.TextBox txtValuation;
    }
}