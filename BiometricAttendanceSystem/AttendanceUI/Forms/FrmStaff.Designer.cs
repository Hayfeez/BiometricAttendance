namespace AttendanceUI.Forms
{
    partial class FrmStaff
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
            this.panelForm = new System.Windows.Forms.Panel();
            this.panelBody = new System.Windows.Forms.Panel();
            this.comboTitle = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkIsSystemAdmin = new XanderUI.XUICheckBox();
            this.checkIsAdmin = new XanderUI.XUICheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtStaffNo = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOthername = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtFirstname = new System.Windows.Forms.TextBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboDept = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.iconExit = new FontAwesome.Sharp.IconPictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelForm.SuspendLayout();
            this.panelBody.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconExit)).BeginInit();
            this.SuspendLayout();
            // 
            // panelForm
            // 
            this.panelForm.BackColor = System.Drawing.Color.White;
            this.panelForm.Controls.Add(this.panelBody);
            this.panelForm.Controls.Add(this.panel3);
            this.panelForm.Controls.Add(this.panel2);
            this.panelForm.Controls.Add(this.panel1);
            this.panelForm.Controls.Add(this.panelTop);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForm.Location = new System.Drawing.Point(0, 0);
            this.panelForm.Name = "panelForm";
            this.panelForm.Size = new System.Drawing.Size(1033, 559);
            this.panelForm.TabIndex = 0;
            // 
            // panelBody
            // 
            this.panelBody.Controls.Add(this.comboTitle);
            this.panelBody.Controls.Add(this.label8);
            this.panelBody.Controls.Add(this.checkIsSystemAdmin);
            this.panelBody.Controls.Add(this.checkIsAdmin);
            this.panelBody.Controls.Add(this.btnClear);
            this.panelBody.Controls.Add(this.txtPhoneNo);
            this.panelBody.Controls.Add(this.label5);
            this.panelBody.Controls.Add(this.txtStaffNo);
            this.panelBody.Controls.Add(this.txtEmail);
            this.panelBody.Controls.Add(this.label6);
            this.panelBody.Controls.Add(this.label7);
            this.panelBody.Controls.Add(this.txtOthername);
            this.panelBody.Controls.Add(this.label4);
            this.panelBody.Controls.Add(this.btnSave);
            this.panelBody.Controls.Add(this.txtFirstname);
            this.panelBody.Controls.Add(this.txtSurname);
            this.panelBody.Controls.Add(this.label3);
            this.panelBody.Controls.Add(this.label2);
            this.panelBody.Controls.Add(this.label1);
            this.panelBody.Controls.Add(this.comboDept);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(11, 119);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(1011, 429);
            this.panelBody.TabIndex = 1;
            // 
            // comboTitle
            // 
            this.comboTitle.Font = new System.Drawing.Font("Calisto MT", 12F);
            this.comboTitle.FormattingEnabled = true;
            this.comboTitle.Location = new System.Drawing.Point(637, 106);
            this.comboTitle.Name = "comboTitle";
            this.comboTitle.Size = new System.Drawing.Size(236, 31);
            this.comboTitle.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.label8.Location = new System.Drawing.Point(505, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 22);
            this.label8.TabIndex = 0;
            this.label8.Text = "Title";
            // 
            // checkIsSystemAdmin
            // 
            this.checkIsSystemAdmin.CheckboxCheckColor = System.Drawing.Color.Black;
            this.checkIsSystemAdmin.CheckboxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(250)))));
            this.checkIsSystemAdmin.CheckboxHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.checkIsSystemAdmin.CheckboxStyle = XanderUI.XUICheckBox.Style.Material;
            this.checkIsSystemAdmin.Checked = false;
            this.checkIsSystemAdmin.Font = new System.Drawing.Font("Calisto MT", 12F);
            this.checkIsSystemAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.checkIsSystemAdmin.Location = new System.Drawing.Point(405, 315);
            this.checkIsSystemAdmin.Name = "checkIsSystemAdmin";
            this.checkIsSystemAdmin.Size = new System.Drawing.Size(202, 24);
            this.checkIsSystemAdmin.TabIndex = 10;
            this.checkIsSystemAdmin.Text = "Is System Admin";
            this.checkIsSystemAdmin.TickThickness = 2;
            // 
            // checkIsAdmin
            // 
            this.checkIsAdmin.CheckboxCheckColor = System.Drawing.Color.Black;
            this.checkIsAdmin.CheckboxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(250)))));
            this.checkIsAdmin.CheckboxHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.checkIsAdmin.CheckboxStyle = XanderUI.XUICheckBox.Style.Material;
            this.checkIsAdmin.Checked = false;
            this.checkIsAdmin.Font = new System.Drawing.Font("Calisto MT", 12F);
            this.checkIsAdmin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.checkIsAdmin.Location = new System.Drawing.Point(258, 315);
            this.checkIsAdmin.Name = "checkIsAdmin";
            this.checkIsAdmin.Size = new System.Drawing.Size(122, 24);
            this.checkIsAdmin.TabIndex = 9;
            this.checkIsAdmin.Text = "Is Admin";
            this.checkIsAdmin.TickThickness = 2;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Red;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(604, 362);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(269, 48);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Font = new System.Drawing.Font("Calisto MT", 12F);
            this.txtPhoneNo.Location = new System.Drawing.Point(637, 205);
            this.txtPhoneNo.MaxLength = 11;
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(236, 31);
            this.txtPhoneNo.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.label5.Location = new System.Drawing.Point(505, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 22);
            this.label5.TabIndex = 0;
            this.label5.Text = "Phone No";
            // 
            // txtStaffNo
            // 
            this.txtStaffNo.Font = new System.Drawing.Font("Calisto MT", 12F);
            this.txtStaffNo.Location = new System.Drawing.Point(258, 206);
            this.txtStaffNo.Name = "txtStaffNo";
            this.txtStaffNo.Size = new System.Drawing.Size(236, 31);
            this.txtStaffNo.TabIndex = 6;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Calisto MT", 12F);
            this.txtEmail.Location = new System.Drawing.Point(258, 261);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(615, 31);
            this.txtEmail.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.label6.Location = new System.Drawing.Point(126, 269);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 22);
            this.label6.TabIndex = 0;
            this.label6.Text = "Email";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.label7.Location = new System.Drawing.Point(126, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 22);
            this.label7.TabIndex = 0;
            this.label7.Text = "Staff No";
            // 
            // txtOthername
            // 
            this.txtOthername.Font = new System.Drawing.Font("Calisto MT", 12F);
            this.txtOthername.Location = new System.Drawing.Point(637, 154);
            this.txtOthername.Name = "txtOthername";
            this.txtOthername.Size = new System.Drawing.Size(236, 31);
            this.txtOthername.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.label4.Location = new System.Drawing.Point(505, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "Othername";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(258, 362);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(269, 48);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtFirstname
            // 
            this.txtFirstname.Font = new System.Drawing.Font("Calisto MT", 12F);
            this.txtFirstname.Location = new System.Drawing.Point(258, 155);
            this.txtFirstname.Name = "txtFirstname";
            this.txtFirstname.Size = new System.Drawing.Size(236, 31);
            this.txtFirstname.TabIndex = 4;
            // 
            // txtSurname
            // 
            this.txtSurname.Font = new System.Drawing.Font("Calisto MT", 12F);
            this.txtSurname.Location = new System.Drawing.Point(258, 107);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(236, 31);
            this.txtSurname.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.label3.Location = new System.Drawing.Point(126, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Surname";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.label2.Location = new System.Drawing.Point(126, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Firstname";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.label1.Location = new System.Drawing.Point(126, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Department";
            // 
            // comboDept
            // 
            this.comboDept.Font = new System.Drawing.Font("Calisto MT", 12F);
            this.comboDept.FormattingEnabled = true;
            this.comboDept.Location = new System.Drawing.Point(258, 54);
            this.comboDept.Name = "comboDept";
            this.comboDept.Size = new System.Drawing.Size(615, 31);
            this.comboDept.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(11, 548);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1011, 11);
            this.panel3.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1022, 119);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(11, 440);
            this.panel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(11, 440);
            this.panel1.TabIndex = 1;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.panelTop.Controls.Add(this.lblPageTitle);
            this.panelTop.Controls.Add(this.iconExit);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1033, 119);
            this.panelTop.TabIndex = 0;
            // 
            // lblPageTitle
            // 
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPageTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPageTitle.Font = new System.Drawing.Font("Calisto MT", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageTitle.ForeColor = System.Drawing.Color.White;
            this.lblPageTitle.Location = new System.Drawing.Point(0, 0);
            this.lblPageTitle.Margin = new System.Windows.Forms.Padding(10);
            this.lblPageTitle.Name = "lblPageTitle";
            this.lblPageTitle.Size = new System.Drawing.Size(237, 31);
            this.lblPageTitle.TabIndex = 1;
            this.lblPageTitle.Text = "Staff Management";
            // 
            // iconExit
            // 
            this.iconExit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iconExit.BackColor = System.Drawing.Color.Transparent;
            this.iconExit.ForeColor = System.Drawing.Color.Red;
            this.iconExit.IconChar = FontAwesome.Sharp.IconChar.TimesCircle;
            this.iconExit.IconColor = System.Drawing.Color.Red;
            this.iconExit.IconSize = 60;
            this.iconExit.Location = new System.Drawing.Point(952, 3);
            this.iconExit.Name = "iconExit";
            this.iconExit.Size = new System.Drawing.Size(70, 60);
            this.iconExit.TabIndex = 3;
            this.iconExit.TabStop = false;
            this.iconExit.Click += new System.EventHandler(this.iconExit_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitle.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(10, 78);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(93, 22);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Add Staff";
            // 
            // FrmStaff
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 559);
            this.Controls.Add(this.panelForm);
            this.Font = new System.Drawing.Font("Calisto MT", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmStaff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmCourse";
            this.panelForm.ResumeLayout(false);
            this.panelBody.ResumeLayout(false);
            this.panelBody.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconExit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblPageTitle;
        private FontAwesome.Sharp.IconPictureBox iconExit;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtFirstname;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboDept;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtPhoneNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStaffNo;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOthername;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboTitle;
        private System.Windows.Forms.Label label8;
        private XanderUI.XUICheckBox checkIsSystemAdmin;
        private XanderUI.XUICheckBox checkIsAdmin;
    }
}