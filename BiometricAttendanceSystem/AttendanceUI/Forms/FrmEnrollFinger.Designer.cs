namespace AttendanceUI.Forms
{
    partial class FrmEnrollFinger
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEnrollFinger));
            this.panelForm = new System.Windows.Forms.Panel();
            this.panelBody = new System.Windows.Forms.Panel();
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.lblFingerCount = new System.Windows.Forms.Label();
            this.lblFingersRequired = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelRequired = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lbClass = new System.Windows.Forms.Label();
            this.comboScanner = new System.Windows.Forms.ComboBox();
            this.btnStartCapture = new System.Windows.Forms.Button();
            this.btnStopCapture = new System.Windows.Forms.Button();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.PicAnalyzed = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlFInger = new System.Windows.Forms.Panel();
            this.btnDeleteEnrolled = new System.Windows.Forms.Button();
            this.lblFingersEnrolled = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblNo = new System.Windows.Forms.Label();
            this.labelNo = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.iconExit = new FontAwesome.Sharp.IconPictureBox();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelForm.SuspendLayout();
            this.panelBody.SuspendLayout();
            this.grpMain.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicAnalyzed)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.pnlFInger.SuspendLayout();
            this.StatusStrip1.SuspendLayout();
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
            this.panelForm.Size = new System.Drawing.Size(1019, 705);
            this.panelForm.TabIndex = 0;
            // 
            // panelBody
            // 
            this.panelBody.Controls.Add(this.grpMain);
            this.panelBody.Controls.Add(this.panel4);
            this.panelBody.Controls.Add(this.GroupBox1);
            this.panelBody.Controls.Add(this.StatusStrip1);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(11, 119);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(997, 575);
            this.panelBody.TabIndex = 1;
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.lblFingerCount);
            this.grpMain.Controls.Add(this.lblFingersRequired);
            this.grpMain.Controls.Add(this.label2);
            this.grpMain.Controls.Add(this.labelRequired);
            this.grpMain.Controls.Add(this.btnSave);
            this.grpMain.Controls.Add(this.btnClear);
            this.grpMain.Controls.Add(this.txtLog);
            this.grpMain.Controls.Add(this.lbClass);
            this.grpMain.Controls.Add(this.comboScanner);
            this.grpMain.Controls.Add(this.btnStartCapture);
            this.grpMain.Controls.Add(this.btnStopCapture);
            this.grpMain.Controls.Add(this.GroupBox3);
            this.grpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMain.Location = new System.Drawing.Point(0, 176);
            this.grpMain.Margin = new System.Windows.Forms.Padding(4);
            this.grpMain.Name = "grpMain";
            this.grpMain.Padding = new System.Windows.Forms.Padding(4);
            this.grpMain.Size = new System.Drawing.Size(997, 377);
            this.grpMain.TabIndex = 1;
            this.grpMain.TabStop = false;
            this.grpMain.Text = "Data Capture";
            // 
            // lblFingerCount
            // 
            this.lblFingerCount.AutoSize = true;
            this.lblFingerCount.Font = new System.Drawing.Font("Calisto MT", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFingerCount.Location = new System.Drawing.Point(715, 41);
            this.lblFingerCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFingerCount.Name = "lblFingerCount";
            this.lblFingerCount.Size = new System.Drawing.Size(34, 39);
            this.lblFingerCount.TabIndex = 0;
            this.lblFingerCount.Text = "0";
            this.lblFingerCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblFingerCount.TextChanged += new System.EventHandler(this.lblFingerCount_TextChanged);
            // 
            // lblFingersRequired
            // 
            this.lblFingersRequired.AutoSize = true;
            this.lblFingersRequired.Font = new System.Drawing.Font("Calisto MT", 20F, System.Drawing.FontStyle.Bold);
            this.lblFingersRequired.Location = new System.Drawing.Point(715, 77);
            this.lblFingersRequired.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFingersRequired.Name = "lblFingersRequired";
            this.lblFingersRequired.Size = new System.Drawing.Size(34, 39);
            this.lblFingersRequired.TabIndex = 0;
            this.lblFingersRequired.Text = "0";
            this.lblFingersRequired.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(567, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Finger Count";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelRequired
            // 
            this.labelRequired.AutoSize = true;
            this.labelRequired.Location = new System.Drawing.Point(567, 90);
            this.labelRequired.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRequired.Name = "labelRequired";
            this.labelRequired.Size = new System.Drawing.Size(148, 22);
            this.labelRequired.TabIndex = 0;
            this.labelRequired.Text = "Fingers Required";
            this.labelRequired.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calisto MT", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(173, 306);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(176, 33);
            this.btnSave.TabIndex = 65;
            this.btnSave.Text = "Save Fingerprints";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Red;
            this.btnClear.Enabled = false;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Calisto MT", 10F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(355, 306);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(152, 33);
            this.btnClear.TabIndex = 66;
            this.btnClear.Text = "Clear All";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.BackColor = System.Drawing.SystemColors.Window;
            this.txtLog.Font = new System.Drawing.Font("Calisto MT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Location = new System.Drawing.Point(18, 140);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(690, 185);
            this.txtLog.TabIndex = 0;
            // 
            // lbClass
            // 
            this.lbClass.AutoSize = true;
            this.lbClass.Location = new System.Drawing.Point(14, 36);
            this.lbClass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbClass.Name = "lbClass";
            this.lbClass.Size = new System.Drawing.Size(74, 22);
            this.lbClass.TabIndex = 64;
            this.lbClass.Text = "Scanner";
            this.lbClass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboScanner
            // 
            this.comboScanner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboScanner.FormattingEnabled = true;
            this.comboScanner.Location = new System.Drawing.Point(99, 29);
            this.comboScanner.Margin = new System.Windows.Forms.Padding(4);
            this.comboScanner.Name = "comboScanner";
            this.comboScanner.Size = new System.Drawing.Size(449, 29);
            this.comboScanner.TabIndex = 63;
            this.comboScanner.SelectedIndexChanged += new System.EventHandler(this.comboScanner_SelectedIndexChanged);
            // 
            // btnStartCapture
            // 
            this.btnStartCapture.Enabled = false;
            this.btnStartCapture.Font = new System.Drawing.Font("Calisto MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartCapture.Location = new System.Drawing.Point(100, 66);
            this.btnStartCapture.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartCapture.Name = "btnStartCapture";
            this.btnStartCapture.Size = new System.Drawing.Size(180, 46);
            this.btnStartCapture.TabIndex = 2;
            this.btnStartCapture.Text = "&Start Capture";
            this.btnStartCapture.UseVisualStyleBackColor = true;
            this.btnStartCapture.Click += new System.EventHandler(this.btnStartCapture_Click);
            // 
            // btnStopCapture
            // 
            this.btnStopCapture.Enabled = false;
            this.btnStopCapture.Font = new System.Drawing.Font("Calisto MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopCapture.Location = new System.Drawing.Point(368, 66);
            this.btnStopCapture.Margin = new System.Windows.Forms.Padding(4);
            this.btnStopCapture.Name = "btnStopCapture";
            this.btnStopCapture.Size = new System.Drawing.Size(180, 46);
            this.btnStopCapture.TabIndex = 3;
            this.btnStopCapture.Tag = "";
            this.btnStopCapture.Text = "Stop &Capture";
            this.btnStopCapture.UseVisualStyleBackColor = true;
            this.btnStopCapture.Click += new System.EventHandler(this.btnStopCapture_Click);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.PicAnalyzed);
            this.GroupBox3.Location = new System.Drawing.Point(757, 29);
            this.GroupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox3.Size = new System.Drawing.Size(215, 270);
            this.GroupBox3.TabIndex = 0;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Analyzed Finger";
            // 
            // PicAnalyzed
            // 
            this.PicAnalyzed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicAnalyzed.Location = new System.Drawing.Point(4, 25);
            this.PicAnalyzed.Margin = new System.Windows.Forms.Padding(4);
            this.PicAnalyzed.Name = "PicAnalyzed";
            this.PicAnalyzed.Size = new System.Drawing.Size(207, 241);
            this.PicAnalyzed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicAnalyzed.TabIndex = 1;
            this.PicAnalyzed.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 553);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(997, 22);
            this.panel4.TabIndex = 0;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.pnlFInger);
            this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupBox1.Location = new System.Drawing.Point(0, 0);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox1.Size = new System.Drawing.Size(997, 176);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Details";
            // 
            // pnlFInger
            // 
            this.pnlFInger.AutoScroll = true;
            this.pnlFInger.Controls.Add(this.btnDeleteEnrolled);
            this.pnlFInger.Controls.Add(this.lblFingersEnrolled);
            this.pnlFInger.Controls.Add(this.label6);
            this.pnlFInger.Controls.Add(this.lblNo);
            this.pnlFInger.Controls.Add(this.labelNo);
            this.pnlFInger.Controls.Add(this.lblName);
            this.pnlFInger.Controls.Add(this.label1);
            this.pnlFInger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFInger.Location = new System.Drawing.Point(4, 25);
            this.pnlFInger.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFInger.Name = "pnlFInger";
            this.pnlFInger.Size = new System.Drawing.Size(989, 147);
            this.pnlFInger.TabIndex = 0;
            // 
            // btnDeleteEnrolled
            // 
            this.btnDeleteEnrolled.BackColor = System.Drawing.Color.Red;
            this.btnDeleteEnrolled.Enabled = false;
            this.btnDeleteEnrolled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteEnrolled.Font = new System.Drawing.Font("Calisto MT", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeleteEnrolled.ForeColor = System.Drawing.Color.White;
            this.btnDeleteEnrolled.Location = new System.Drawing.Point(302, 92);
            this.btnDeleteEnrolled.Name = "btnDeleteEnrolled";
            this.btnDeleteEnrolled.Size = new System.Drawing.Size(242, 33);
            this.btnDeleteEnrolled.TabIndex = 67;
            this.btnDeleteEnrolled.Text = "Delete Enrolled Fingers";
            this.btnDeleteEnrolled.UseVisualStyleBackColor = false;
            this.btnDeleteEnrolled.Click += new System.EventHandler(this.btnDeleteEnrolled_Click);
            // 
            // lblFingersEnrolled
            // 
            this.lblFingersEnrolled.AutoSize = true;
            this.lblFingersEnrolled.Font = new System.Drawing.Font("Calisto MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFingersEnrolled.Location = new System.Drawing.Point(165, 103);
            this.lblFingersEnrolled.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFingersEnrolled.Name = "lblFingersEnrolled";
            this.lblFingersEnrolled.Size = new System.Drawing.Size(86, 22);
            this.lblFingersEnrolled.TabIndex = 0;
            this.lblFingersEnrolled.Text = "Enrolled";
            this.lblFingersEnrolled.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 103);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 22);
            this.label6.TabIndex = 0;
            this.label6.Text = "Fingers Enrolled";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNo
            // 
            this.lblNo.AutoSize = true;
            this.lblNo.Font = new System.Drawing.Font("Calisto MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNo.Location = new System.Drawing.Point(165, 62);
            this.lblNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNo.Name = "lblNo";
            this.lblNo.Size = new System.Drawing.Size(95, 22);
            this.lblNo.TabIndex = 5;
            this.lblNo.Text = "MatricNo";
            this.lblNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelNo
            // 
            this.labelNo.AutoSize = true;
            this.labelNo.Location = new System.Drawing.Point(21, 62);
            this.labelNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNo.Name = "labelNo";
            this.labelNo.Size = new System.Drawing.Size(136, 22);
            this.labelNo.TabIndex = 0;
            this.labelNo.Text = "Matric Number";
            this.labelNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Calisto MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(165, 21);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(62, 22);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.ToolStripStatusLabel1});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 549);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.StatusStrip1.Size = new System.Drawing.Size(997, 26);
            this.StatusStrip1.TabIndex = 0;
            this.StatusStrip1.Text = "StatusStrip1";
            this.StatusStrip1.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(69, 20);
            this.lblStatus.Text = "Waiting...";
            // 
            // ToolStripStatusLabel1
            // 
            this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
            this.ToolStripStatusLabel1.Size = new System.Drawing.Size(153, 20);
            this.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(11, 694);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(997, 11);
            this.panel3.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1008, 119);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(11, 586);
            this.panel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(11, 586);
            this.panel1.TabIndex = 0;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.panelTop.Controls.Add(this.iconExit);
            this.panelTop.Controls.Add(this.lblPageTitle);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1019, 119);
            this.panelTop.TabIndex = 0;
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
            this.iconExit.Location = new System.Drawing.Point(934, 12);
            this.iconExit.Name = "iconExit";
            this.iconExit.Size = new System.Drawing.Size(74, 60);
            this.iconExit.TabIndex = 4;
            this.iconExit.TabStop = false;
            this.iconExit.Click += new System.EventHandler(this.iconExit_Click_1);
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
            this.lblPageTitle.Size = new System.Drawing.Size(295, 31);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "Fingerprint Enrollment";
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
            this.lblTitle.Size = new System.Drawing.Size(143, 22);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Enroll Fingers";
            // 
            // FrmEnrollFinger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1019, 705);
            this.Controls.Add(this.panelForm);
            this.Font = new System.Drawing.Font("Calisto MT", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmEnrollFinger";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Finger Enrollment";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmEnrollFinger_FormClosed);
            this.Load += new System.EventHandler(this.FrmEnrollFinger_Load);
            this.panelForm.ResumeLayout(false);
            this.panelBody.ResumeLayout(false);
            this.panelBody.PerformLayout();
            this.grpMain.ResumeLayout(false);
            this.grpMain.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicAnalyzed)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.pnlFInger.ResumeLayout(false);
            this.pnlFInger.PerformLayout();
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconExit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelBody;
        internal System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.TextBox txtLog;
        internal System.Windows.Forms.Label lbClass;
        internal System.Windows.Forms.ComboBox comboScanner;
        internal System.Windows.Forms.Button btnStartCapture;
        internal System.Windows.Forms.Button btnStopCapture;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.PictureBox PicAnalyzed;
        private System.Windows.Forms.Panel panel4;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Panel pnlFInger;
        internal System.Windows.Forms.StatusStrip StatusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel lblStatus;
        internal System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1;
        internal System.Windows.Forms.Label lblFingersRequired;
        internal System.Windows.Forms.Label labelRequired;
        internal System.Windows.Forms.Label lblFingersEnrolled;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label lblNo;
        internal System.Windows.Forms.Label labelNo;
        internal System.Windows.Forms.Label lblName;
        internal System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconPictureBox iconExit;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        internal System.Windows.Forms.Label lblFingerCount;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnDeleteEnrolled;
    }
}