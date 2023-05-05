
namespace Girvi.Forms.Master_Form
{
    partial class frmAccountMaster
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccountMaster));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbBalFormate = new System.Windows.Forms.ComboBox();
            this.lblOpeningCash = new System.Windows.Forms.Label();
            this.txtOpeningCash = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbMinIntPer = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIntRate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPartyCode = new System.Windows.Forms.TextBox();
            this.lbl_date = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancle = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrintName = new System.Windows.Forms.TextBox();
            this.cmbNamePrefix = new System.Windows.Forms.ComboBox();
            this.txtRelation = new System.Windows.Forms.TextBox();
            this.cmbo_city = new System.Windows.Forms.ComboBox();
            this.cmbo_state = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.txt_remark = new System.Windows.Forms.TextBox();
            this.btn_brows = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_mobile = new System.Windows.Forms.Label();
            this.txt_mobile = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.lbl_remark = new System.Windows.Forms.Label();
            this.lbl_address = new System.Windows.Forms.Label();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.lbl_email = new System.Windows.Forms.Label();
            this.txt_address = new System.Windows.Forms.TextBox();
            this.dtp1 = new System.Windows.Forms.DateTimePicker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LemonChiffon;
            this.groupBox1.Controls.Add(this.cmbType);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPartyCode);
            this.groupBox1.Controls.Add(this.lbl_date);
            this.groupBox1.Controls.Add(this.btn_save);
            this.groupBox1.Controls.Add(this.btn_cancle);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.dtp1);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // cmbType
            // 
            this.cmbType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            resources.ApplyResources(this.cmbType, "cmbType");
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Name = "cmbType";
            this.cmbType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbType_KeyDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.cmbBalFormate);
            this.panel2.Controls.Add(this.lblOpeningCash);
            this.panel2.Controls.Add(this.txtOpeningCash);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // cmbBalFormate
            // 
            this.cmbBalFormate.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbBalFormate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            resources.ApplyResources(this.cmbBalFormate, "cmbBalFormate");
            this.cmbBalFormate.FormattingEnabled = true;
            this.cmbBalFormate.Name = "cmbBalFormate";
            this.cmbBalFormate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBalFormate_KeyDown);
            // 
            // lblOpeningCash
            // 
            resources.ApplyResources(this.lblOpeningCash, "lblOpeningCash");
            this.lblOpeningCash.Name = "lblOpeningCash";
            // 
            // txtOpeningCash
            // 
            resources.ApplyResources(this.txtOpeningCash, "txtOpeningCash");
            this.txtOpeningCash.Name = "txtOpeningCash";
            this.txtOpeningCash.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtOpeningCash_KeyDown);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkKhaki;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.cmbMinIntPer);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtIntRate);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
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
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // txtPartyCode
            // 
            resources.ApplyResources(this.txtPartyCode, "txtPartyCode");
            this.txtPartyCode.Name = "txtPartyCode";
            this.txtPartyCode.ReadOnly = true;
            // 
            // lbl_date
            // 
            resources.ApplyResources(this.lbl_date, "lbl_date");
            this.lbl_date.Name = "lbl_date";
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.Crimson;
            this.btn_save.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtPrintName);
            this.panel1.Controls.Add(this.cmbNamePrefix);
            this.panel1.Controls.Add(this.txtRelation);
            this.panel1.Controls.Add(this.cmbo_city);
            this.panel1.Controls.Add(this.cmbo_state);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbl_name);
            this.panel1.Controls.Add(this.txt_remark);
            this.panel1.Controls.Add(this.btn_brows);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lbl_mobile);
            this.panel1.Controls.Add(this.txt_mobile);
            this.panel1.Controls.Add(this.txt_name);
            this.panel1.Controls.Add(this.lbl_remark);
            this.panel1.Controls.Add(this.lbl_address);
            this.panel1.Controls.Add(this.txt_email);
            this.panel1.Controls.Add(this.lbl_email);
            this.panel1.Controls.Add(this.txt_address);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // txtPrintName
            // 
            resources.ApplyResources(this.txtPrintName, "txtPrintName");
            this.txtPrintName.Name = "txtPrintName";
            this.txtPrintName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPrintName_KeyDown);
            // 
            // cmbNamePrefix
            // 
            this.cmbNamePrefix.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbNamePrefix.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbNamePrefix.FormattingEnabled = true;
            resources.ApplyResources(this.cmbNamePrefix, "cmbNamePrefix");
            this.cmbNamePrefix.Name = "cmbNamePrefix";
            this.cmbNamePrefix.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbNamePrefix_KeyDown);
            // 
            // txtRelation
            // 
            resources.ApplyResources(this.txtRelation, "txtRelation");
            this.txtRelation.Name = "txtRelation";
            this.txtRelation.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtRelation_KeyDown);
            // 
            // cmbo_city
            // 
            this.cmbo_city.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbo_city.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            resources.ApplyResources(this.cmbo_city, "cmbo_city");
            this.cmbo_city.FormattingEnabled = true;
            this.cmbo_city.Name = "cmbo_city";
            this.cmbo_city.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbo_city_KeyDown);
            // 
            // cmbo_state
            // 
            this.cmbo_state.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbo_state.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            resources.ApplyResources(this.cmbo_state, "cmbo_state");
            this.cmbo_state.FormattingEnabled = true;
            this.cmbo_state.Name = "cmbo_state";
            this.cmbo_state.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbo_state_KeyDown);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lbl_name
            // 
            resources.ApplyResources(this.lbl_name, "lbl_name");
            this.lbl_name.Name = "lbl_name";
            // 
            // txt_remark
            // 
            resources.ApplyResources(this.txt_remark, "txt_remark");
            this.txt_remark.Name = "txt_remark";
            this.txt_remark.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_remark_KeyDown);
            // 
            // btn_brows
            // 
            resources.ApplyResources(this.btn_brows, "btn_brows");
            this.btn_brows.Name = "btn_brows";
            this.btn_brows.UseVisualStyleBackColor = true;
            this.btn_brows.Click += new System.EventHandler(this.btn_brows_Click);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // lbl_mobile
            // 
            resources.ApplyResources(this.lbl_mobile, "lbl_mobile");
            this.lbl_mobile.Name = "lbl_mobile";
            // 
            // txt_mobile
            // 
            resources.ApplyResources(this.txt_mobile, "txt_mobile");
            this.txt_mobile.Name = "txt_mobile";
            this.txt_mobile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_mobile_KeyDown);
            // 
            // txt_name
            // 
            resources.ApplyResources(this.txt_name, "txt_name");
            this.txt_name.Name = "txt_name";
            this.txt_name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_name_KeyDown);
            // 
            // lbl_remark
            // 
            resources.ApplyResources(this.lbl_remark, "lbl_remark");
            this.lbl_remark.Name = "lbl_remark";
            // 
            // lbl_address
            // 
            resources.ApplyResources(this.lbl_address, "lbl_address");
            this.lbl_address.Name = "lbl_address";
            // 
            // txt_email
            // 
            resources.ApplyResources(this.txt_email, "txt_email");
            this.txt_email.Name = "txt_email";
            this.txt_email.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_email_KeyDown);
            // 
            // lbl_email
            // 
            resources.ApplyResources(this.lbl_email, "lbl_email");
            this.lbl_email.Name = "lbl_email";
            // 
            // txt_address
            // 
            resources.ApplyResources(this.txt_address, "txt_address");
            this.txt_address.Name = "txt_address";
            this.txt_address.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_address_KeyDown);
            // 
            // dtp1
            // 
            resources.ApplyResources(this.dtp1, "dtp1");
            this.dtp1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp1.Name = "dtp1";
            this.dtp1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtp1_KeyDown);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmAccountMaster
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SaddleBrown;
            this.CancelButton = this.btn_cancle;
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAccountMaster";
            this.Opacity = 0.95D;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.TransparencyKey = System.Drawing.Color.SaddleBrown;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label lbl_address;
        private System.Windows.Forms.TextBox txt_address;
        private System.Windows.Forms.Label lbl_remark;
        private System.Windows.Forms.Label lbl_mobile;
        private System.Windows.Forms.TextBox txt_mobile;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_brows;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.TextBox txt_remark;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancle;
        private System.Windows.Forms.Label lbl_date;
        private System.Windows.Forms.ComboBox cmbo_city;
        private System.Windows.Forms.ComboBox cmbo_state;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPartyCode;
        private System.Windows.Forms.ComboBox cmbNamePrefix;
        private System.Windows.Forms.TextBox txtRelation;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cmbMinIntPer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtIntRate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPrintName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblOpeningCash;
        private System.Windows.Forms.TextBox txtOpeningCash;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.ComboBox cmbBalFormate;
    }
}