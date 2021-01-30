namespace AttendanceUI.Forms
{
    partial class FrmAttendance
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAttendance));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.iconExit = new FontAwesome.Sharp.IconPictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelBody = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lbClass = new System.Windows.Forms.Label();
            this.comboScanner = new System.Windows.Forms.ComboBox();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.PicAnalyzed = new System.Windows.Forms.PictureBox();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlFInger = new System.Windows.Forms.Panel();
            this.lblRegistered = new System.Windows.Forms.Label();
            this.clock1 = new XanderUI.XUIClock();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblCourse = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnStopAttendance = new System.Windows.Forms.Button();
            this.comboLevel = new System.Windows.Forms.ComboBox();
            this.btnTakeAttendance = new System.Windows.Forms.Button();
            this.comboCourse = new System.Windows.Forms.ComboBox();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconExit)).BeginInit();
            this.panelBody.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.grpMain.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicAnalyzed)).BeginInit();
            this.GroupBox1.SuspendLayout();
            this.pnlFInger.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.panelFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1194, 17);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 17);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(18, 627);
            this.panel3.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1176, 17);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(18, 627);
            this.panel4.TabIndex = 0;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.panelHeader.Controls.Add(this.iconExit);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(18, 17);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1158, 62);
            this.panelHeader.TabIndex = 1;
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
            this.iconExit.Location = new System.Drawing.Point(1088, 0);
            this.iconExit.Name = "iconExit";
            this.iconExit.Size = new System.Drawing.Size(70, 60);
            this.iconExit.TabIndex = 4;
            this.iconExit.TabStop = false;
            this.iconExit.Click += new System.EventHandler(this.iconExit_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitle.Font = new System.Drawing.Font("Calisto MT", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(151, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Attendance";
            // 
            // panelBody
            // 
            this.panelBody.Controls.Add(this.tableLayoutPanel1);
            this.panelBody.Controls.Add(this.panelFilter);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(18, 79);
            this.panelBody.Margin = new System.Windows.Forms.Padding(4);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(1158, 565);
            this.panelBody.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 79);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1158, 486);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.grpMain);
            this.panel2.Controls.Add(this.GroupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(688, 480);
            this.panel2.TabIndex = 0;
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.txtLog);
            this.grpMain.Controls.Add(this.lbClass);
            this.grpMain.Controls.Add(this.comboScanner);
            this.grpMain.Controls.Add(this.GroupBox3);
            this.grpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMain.Location = new System.Drawing.Point(0, 180);
            this.grpMain.Margin = new System.Windows.Forms.Padding(4);
            this.grpMain.Name = "grpMain";
            this.grpMain.Padding = new System.Windows.Forms.Padding(4);
            this.grpMain.Size = new System.Drawing.Size(688, 300);
            this.grpMain.TabIndex = 0;
            this.grpMain.TabStop = false;
            this.grpMain.Text = "Data Capture";
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.BackColor = System.Drawing.SystemColors.Window;
            this.txtLog.Font = new System.Drawing.Font("Calisto MT", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Location = new System.Drawing.Point(18, 101);
            this.txtLog.Margin = new System.Windows.Forms.Padding(4);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(431, 195);
            this.txtLog.TabIndex = 0;
            // 
            // lbClass
            // 
            this.lbClass.AutoSize = true;
            this.lbClass.Location = new System.Drawing.Point(14, 36);
            this.lbClass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbClass.Name = "lbClass";
            this.lbClass.Size = new System.Drawing.Size(74, 22);
            this.lbClass.TabIndex = 0;
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
            this.comboScanner.Size = new System.Drawing.Size(332, 29);
            this.comboScanner.TabIndex = 5;
            this.comboScanner.SelectedIndexChanged += new System.EventHandler(this.comboScanner_SelectedIndexChanged);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.PicAnalyzed);
            this.GroupBox3.Location = new System.Drawing.Point(468, 76);
            this.GroupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox3.Size = new System.Drawing.Size(215, 220);
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
            this.PicAnalyzed.Size = new System.Drawing.Size(207, 191);
            this.PicAnalyzed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicAnalyzed.TabIndex = 1;
            this.PicAnalyzed.TabStop = false;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.pnlFInger);
            this.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.GroupBox1.Location = new System.Drawing.Point(0, 0);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.GroupBox1.Size = new System.Drawing.Size(688, 180);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Details";
            // 
            // pnlFInger
            // 
            this.pnlFInger.AutoScroll = true;
            this.pnlFInger.Controls.Add(this.lblRegistered);
            this.pnlFInger.Controls.Add(this.clock1);
            this.pnlFInger.Controls.Add(this.lblDate);
            this.pnlFInger.Controls.Add(this.lblCourse);
            this.pnlFInger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFInger.Location = new System.Drawing.Point(4, 25);
            this.pnlFInger.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFInger.Name = "pnlFInger";
            this.pnlFInger.Size = new System.Drawing.Size(680, 151);
            this.pnlFInger.TabIndex = 0;
            // 
            // lblRegistered
            // 
            this.lblRegistered.AutoSize = true;
            this.lblRegistered.Font = new System.Drawing.Font("Calisto MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistered.Location = new System.Drawing.Point(198, 100);
            this.lblRegistered.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegistered.Name = "lblRegistered";
            this.lblRegistered.Size = new System.Drawing.Size(103, 22);
            this.lblRegistered.TabIndex = 0;
            this.lblRegistered.Text = "Registered";
            this.lblRegistered.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblRegistered.Visible = false;
            // 
            // clock1
            // 
            this.clock1.CircleThickness = 6;
            this.clock1.DisplayFormat = XanderUI.XUIClock.HourFormat.TwelveHour;
            this.clock1.FilledHourColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(190)))), ((int)(((byte)(155)))));
            this.clock1.FilledMinuteColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.clock1.FilledSecondColor = System.Drawing.Color.DarkOrchid;
            this.clock1.Font = new System.Drawing.Font("Impact", 15F);
            this.clock1.HexagonColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.clock1.Location = new System.Drawing.Point(14, 3);
            this.clock1.Name = "clock1";
            this.clock1.ShowAmPm = false;
            this.clock1.ShowHexagon = true;
            this.clock1.ShowMinutesCircle = true;
            this.clock1.ShowSecondsCircle = true;
            this.clock1.Size = new System.Drawing.Size(120, 130);
            this.clock1.TabIndex = 0;
            this.clock1.Text = "xuiClock1";
            this.clock1.UnfilledHourColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(70)))), ((int)(((byte)(85)))));
            this.clock1.UnfilledMinuteColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.clock1.UnfilledSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Calisto MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(198, 26);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(53, 22);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Date";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblDate.Visible = false;
            // 
            // lblCourse
            // 
            this.lblCourse.AutoSize = true;
            this.lblCourse.Font = new System.Drawing.Font("Calisto MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourse.Location = new System.Drawing.Point(198, 60);
            this.lblCourse.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCourse.Name = "lblCourse";
            this.lblCourse.Size = new System.Drawing.Size(72, 22);
            this.lblCourse.TabIndex = 0;
            this.lblCourse.Text = "Course";
            this.lblCourse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCourse.Visible = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.dataGrid);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(697, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(458, 480);
            this.panel5.TabIndex = 1;
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid.BackgroundColor = System.Drawing.Color.White;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(0, 0);
            this.dataGrid.Margin = new System.Windows.Forms.Padding(4);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.RowHeadersWidth = 51;
            this.dataGrid.RowTemplate.Height = 24;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(458, 480);
            this.dataGrid.TabIndex = 6;
            // 
            // panelFilter
            // 
            this.panelFilter.BackColor = System.Drawing.Color.White;
            this.panelFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFilter.Controls.Add(this.btnLoad);
            this.panelFilter.Controls.Add(this.btnStopAttendance);
            this.panelFilter.Controls.Add(this.comboLevel);
            this.panelFilter.Controls.Add(this.btnTakeAttendance);
            this.panelFilter.Controls.Add(this.comboCourse);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(0, 0);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(1158, 79);
            this.panelFilter.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(979, 41);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(171, 31);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Load Attendance";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnStopAttendance
            // 
            this.btnStopAttendance.Location = new System.Drawing.Point(733, 25);
            this.btnStopAttendance.Name = "btnStopAttendance";
            this.btnStopAttendance.Size = new System.Drawing.Size(171, 31);
            this.btnStopAttendance.TabIndex = 0;
            this.btnStopAttendance.Text = "Stop Attendance";
            this.btnStopAttendance.UseVisualStyleBackColor = true;
            this.btnStopAttendance.Visible = false;
            this.btnStopAttendance.Click += new System.EventHandler(this.btnStopAttendance_Click);
            // 
            // comboLevel
            // 
            this.comboLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLevel.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboLevel.FormattingEnabled = true;
            this.comboLevel.Location = new System.Drawing.Point(6, 25);
            this.comboLevel.Name = "comboLevel";
            this.comboLevel.Size = new System.Drawing.Size(251, 31);
            this.comboLevel.TabIndex = 1;
            this.comboLevel.SelectedIndexChanged += new System.EventHandler(this.comboLevel_SelectedIndexChanged);
            // 
            // btnTakeAttendance
            // 
            this.btnTakeAttendance.Enabled = false;
            this.btnTakeAttendance.Location = new System.Drawing.Point(547, 25);
            this.btnTakeAttendance.Name = "btnTakeAttendance";
            this.btnTakeAttendance.Size = new System.Drawing.Size(171, 31);
            this.btnTakeAttendance.TabIndex = 3;
            this.btnTakeAttendance.Text = "Mark Attendance";
            this.btnTakeAttendance.UseVisualStyleBackColor = true;
            this.btnTakeAttendance.Click += new System.EventHandler(this.btnTakeAttendance_Click);
            // 
            // comboCourse
            // 
            this.comboCourse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboCourse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCourse.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCourse.FormattingEnabled = true;
            this.comboCourse.Location = new System.Drawing.Point(277, 25);
            this.comboCourse.Name = "comboCourse";
            this.comboCourse.Size = new System.Drawing.Size(251, 31);
            this.comboCourse.TabIndex = 2;
            this.comboCourse.SelectedIndexChanged += new System.EventHandler(this.comboCourse_SelectedIndexChanged);
            // 
            // FrmAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 644);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calisto MT", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmAttendance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAttendance_FormClosed);
            this.Load += new System.EventHandler(this.FrmAttendance_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconExit)).EndInit();
            this.panelBody.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.grpMain.ResumeLayout(false);
            this.grpMain.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicAnalyzed)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.pnlFInger.ResumeLayout(false);
            this.pnlFInger.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.panelFilter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.ComboBox comboCourse;
        private System.Windows.Forms.Button btnTakeAttendance;
        private System.Windows.Forms.ComboBox comboLevel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dataGrid;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Panel pnlFInger;
        internal System.Windows.Forms.Label lblDate;
        internal System.Windows.Forms.Label lblCourse;
        internal System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.TextBox txtLog;
        internal System.Windows.Forms.Label lbClass;
        internal System.Windows.Forms.ComboBox comboScanner;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.PictureBox PicAnalyzed;
        private XanderUI.XUIClock clock1;
        private System.Windows.Forms.Button btnStopAttendance;
        internal System.Windows.Forms.Label lblRegistered;
        private FontAwesome.Sharp.IconPictureBox iconExit;
        private System.Windows.Forms.Button btnLoad;
    }
}
