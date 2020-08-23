namespace AttendanceUI.Forms
{
    partial class FrmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettings));
            this.panelForm = new System.Windows.Forms.Panel();
            this.panelBody = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridLevel = new System.Windows.Forms.DataGridView();
            this.dataGridTitle = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.checkPwd = new XanderUI.XUICheckBox();
            this.txtNoOfFinger = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUserDefaultPassword = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAdminPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAdminEmail = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAdminFirstname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtAdminLastname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.iconExit = new FontAwesome.Sharp.IconPictureBox();
            this.btnAddTitle = new XanderUI.XUIButton();
            this.btnAddLevel = new XanderUI.XUIButton();
            this.panelForm.SuspendLayout();
            this.panelBody.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTitle)).BeginInit();
            this.panel4.SuspendLayout();
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
            this.panelForm.Size = new System.Drawing.Size(1088, 786);
            this.panelForm.TabIndex = 0;
            // 
            // panelBody
            // 
            this.panelBody.Controls.Add(this.tableLayoutPanel1);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(11, 119);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(1066, 656);
            this.panelBody.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridLevel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridTitle, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1066, 656);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Calisto MT", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.label3.Location = new System.Drawing.Point(712, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(344, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "System Settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Calisto MT", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.label2.Location = new System.Drawing.Point(361, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(331, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Title";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Calisto MT", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Level";
            // 
            // dataGridLevel
            // 
            this.dataGridLevel.AllowUserToAddRows = false;
            this.dataGridLevel.AllowUserToDeleteRows = false;
            this.dataGridLevel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridLevel.BackgroundColor = System.Drawing.Color.White;
            this.dataGridLevel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridLevel.Location = new System.Drawing.Point(4, 49);
            this.dataGridLevel.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridLevel.Name = "dataGridLevel";
            this.dataGridLevel.ReadOnly = true;
            this.dataGridLevel.RowHeadersWidth = 51;
            this.dataGridLevel.RowTemplate.Height = 24;
            this.dataGridLevel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridLevel.Size = new System.Drawing.Size(343, 603);
            this.dataGridLevel.TabIndex = 1;
            this.dataGridLevel.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridLevel_CellContentClick);
            // 
            // dataGridTitle
            // 
            this.dataGridTitle.AllowUserToAddRows = false;
            this.dataGridTitle.AllowUserToDeleteRows = false;
            this.dataGridTitle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridTitle.BackgroundColor = System.Drawing.Color.White;
            this.dataGridTitle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridTitle.Location = new System.Drawing.Point(355, 49);
            this.dataGridTitle.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridTitle.Name = "dataGridTitle";
            this.dataGridTitle.ReadOnly = true;
            this.dataGridTitle.RowHeadersWidth = 51;
            this.dataGridTitle.RowTemplate.Height = 24;
            this.dataGridTitle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridTitle.Size = new System.Drawing.Size(343, 603);
            this.dataGridTitle.TabIndex = 2;
            this.dataGridTitle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridTitle_CellContentClick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.checkPwd);
            this.panel4.Controls.Add(this.txtNoOfFinger);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.txtUserDefaultPassword);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.txtAdminPassword);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.txtAdminEmail);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.txtAdminFirstname);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.btnSave);
            this.panel4.Controls.Add(this.txtAdminLastname);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(705, 48);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(358, 605);
            this.panel4.TabIndex = 6;
            // 
            // checkPwd
            // 
            this.checkPwd.CheckboxCheckColor = System.Drawing.Color.White;
            this.checkPwd.CheckboxColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(162)))), ((int)(((byte)(250)))));
            this.checkPwd.CheckboxHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(55)))), ((int)(((byte)(98)))));
            this.checkPwd.CheckboxStyle = XanderUI.XUICheckBox.Style.Material;
            this.checkPwd.Checked = false;
            this.checkPwd.Font = new System.Drawing.Font("Calisto MT", 10F);
            this.checkPwd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.checkPwd.Location = new System.Drawing.Point(32, 436);
            this.checkPwd.Name = "checkPwd";
            this.checkPwd.Size = new System.Drawing.Size(188, 20);
            this.checkPwd.TabIndex = 9;
            this.checkPwd.Text = "Show Passwords";
            this.checkPwd.TickThickness = 2;
            this.checkPwd.CheckedStateChanged += new System.EventHandler(this.checkPwd_CheckedStateChanged);
            // 
            // txtNoOfFinger
            // 
            this.txtNoOfFinger.Font = new System.Drawing.Font("Calisto MT", 10F);
            this.txtNoOfFinger.Location = new System.Drawing.Point(32, 391);
            this.txtNoOfFinger.Name = "txtNoOfFinger";
            this.txtNoOfFinger.Size = new System.Drawing.Size(287, 27);
            this.txtNoOfFinger.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calisto MT", 10F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.label8.Location = new System.Drawing.Point(28, 366);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(217, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "No of Fingers for Enrollment";
            // 
            // txtUserDefaultPassword
            // 
            this.txtUserDefaultPassword.Font = new System.Drawing.Font("Calisto MT", 10F);
            this.txtUserDefaultPassword.Location = new System.Drawing.Point(32, 324);
            this.txtUserDefaultPassword.Name = "txtUserDefaultPassword";
            this.txtUserDefaultPassword.Size = new System.Drawing.Size(287, 27);
            this.txtUserDefaultPassword.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calisto MT", 10F);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.label9.Location = new System.Drawing.Point(28, 299);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(175, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "User Default Password";
            // 
            // txtAdminPassword
            // 
            this.txtAdminPassword.Font = new System.Drawing.Font("Calisto MT", 10F);
            this.txtAdminPassword.Location = new System.Drawing.Point(32, 261);
            this.txtAdminPassword.Name = "txtAdminPassword";
            this.txtAdminPassword.Size = new System.Drawing.Size(287, 27);
            this.txtAdminPassword.TabIndex = 6;
            this.txtAdminPassword.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calisto MT", 10F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.label6.Location = new System.Drawing.Point(28, 236);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Admin Password";
            // 
            // txtAdminEmail
            // 
            this.txtAdminEmail.Font = new System.Drawing.Font("Calisto MT", 10F);
            this.txtAdminEmail.Location = new System.Drawing.Point(32, 194);
            this.txtAdminEmail.Name = "txtAdminEmail";
            this.txtAdminEmail.Size = new System.Drawing.Size(287, 27);
            this.txtAdminEmail.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calisto MT", 10F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.label7.Location = new System.Drawing.Point(28, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Admin Email";
            // 
            // txtAdminFirstname
            // 
            this.txtAdminFirstname.Font = new System.Drawing.Font("Calisto MT", 10F);
            this.txtAdminFirstname.Location = new System.Drawing.Point(32, 132);
            this.txtAdminFirstname.Name = "txtAdminFirstname";
            this.txtAdminFirstname.Size = new System.Drawing.Size(287, 27);
            this.txtAdminFirstname.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calisto MT", 10F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.label5.Location = new System.Drawing.Point(28, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Admin Firstname";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(132, 462);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(113, 48);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtAdminLastname
            // 
            this.txtAdminLastname.Font = new System.Drawing.Font("Calisto MT", 10F);
            this.txtAdminLastname.Location = new System.Drawing.Point(32, 65);
            this.txtAdminLastname.Name = "txtAdminLastname";
            this.txtAdminLastname.Size = new System.Drawing.Size(287, 27);
            this.txtAdminLastname.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calisto MT", 10F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.label4.Location = new System.Drawing.Point(28, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Admin Lastname";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(11, 775);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1066, 11);
            this.panel3.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1077, 119);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(11, 667);
            this.panel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(11, 667);
            this.panel1.TabIndex = 1;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.panelTop.Controls.Add(this.lblPageTitle);
            this.panelTop.Controls.Add(this.iconExit);
            this.panelTop.Controls.Add(this.btnAddTitle);
            this.panelTop.Controls.Add(this.btnAddLevel);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1088, 119);
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
            this.lblPageTitle.Size = new System.Drawing.Size(110, 31);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Settings";
            // 
            // iconExit
            // 
            this.iconExit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.iconExit.BackColor = System.Drawing.Color.Transparent;
            this.iconExit.ForeColor = System.Drawing.Color.Red;
            this.iconExit.IconChar = FontAwesome.Sharp.IconChar.TimesCircle;
            this.iconExit.IconColor = System.Drawing.Color.Red;
            this.iconExit.IconSize = 46;
            this.iconExit.Location = new System.Drawing.Point(1019, 3);
            this.iconExit.Name = "iconExit";
            this.iconExit.Size = new System.Drawing.Size(58, 46);
            this.iconExit.TabIndex = 3;
            this.iconExit.TabStop = false;
            this.iconExit.Click += new System.EventHandler(this.iconExit_Click);
            // 
            // btnAddTitle
            // 
            this.btnAddTitle.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnAddTitle.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnAddTitle.ButtonImage")));
            this.btnAddTitle.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btnAddTitle.ButtonText = "Add New Title";
            this.btnAddTitle.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btnAddTitle.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btnAddTitle.CornerRadius = 5;
            this.btnAddTitle.Font = new System.Drawing.Font("Calisto MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTitle.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnAddTitle.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnAddTitle.HoverTextColor = System.Drawing.Color.DodgerBlue;
            this.btnAddTitle.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btnAddTitle.Location = new System.Drawing.Point(222, 63);
            this.btnAddTitle.Name = "btnAddTitle";
            this.btnAddTitle.Size = new System.Drawing.Size(184, 50);
            this.btnAddTitle.TabIndex = 0;
            this.btnAddTitle.TextColor = System.Drawing.Color.White;
            this.btnAddTitle.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnAddTitle.Click += new System.EventHandler(this.btnAddTitle_Click);
            // 
            // btnAddLevel
            // 
            this.btnAddLevel.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnAddLevel.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnAddLevel.ButtonImage")));
            this.btnAddLevel.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btnAddLevel.ButtonText = "Add New Level";
            this.btnAddLevel.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btnAddLevel.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btnAddLevel.CornerRadius = 5;
            this.btnAddLevel.Font = new System.Drawing.Font("Calisto MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddLevel.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnAddLevel.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnAddLevel.HoverTextColor = System.Drawing.Color.DodgerBlue;
            this.btnAddLevel.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btnAddLevel.Location = new System.Drawing.Point(11, 63);
            this.btnAddLevel.Name = "btnAddLevel";
            this.btnAddLevel.Size = new System.Drawing.Size(197, 50);
            this.btnAddLevel.TabIndex = 0;
            this.btnAddLevel.TextColor = System.Drawing.Color.White;
            this.btnAddLevel.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnAddLevel.Click += new System.EventHandler(this.btnAddLevel_Click);
            // 
            // FrmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 786);
            this.Controls.Add(this.panelForm);
            this.Font = new System.Drawing.Font("Calisto MT", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmCourse";
            this.Load += new System.EventHandler(this.FrmSettings_Load);
            this.panelForm.ResumeLayout(false);
            this.panelBody.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTitle)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelBody;
        private XanderUI.XUIButton btnAddTitle;
        private XanderUI.XUIButton btnAddLevel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridLevel;
        private System.Windows.Forms.DataGridView dataGridTitle;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtAdminFirstname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtAdminLastname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNoOfFinger;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUserDefaultPassword;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAdminPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAdminEmail;
        private System.Windows.Forms.Label label7;
        private XanderUI.XUICheckBox checkPwd;
    }
}