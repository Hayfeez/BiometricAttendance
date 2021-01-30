namespace AttendanceUI.Pages
{
    partial class PgHome
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.cardStudent = new XanderUI.XUICard();
            this.cardUsers = new XanderUI.XUICard();
            this.cardSession = new XanderUI.XUICard();
            this.clock1 = new XanderUI.XUIClock();
            this.cardDate = new XanderUI.XUICard();
            this.panelBody = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelAttendance = new System.Windows.Forms.Panel();
            this.dataGridAttendance = new System.Windows.Forms.DataGridView();
            this.panelCourseReg = new System.Windows.Forms.Panel();
            this.dataGridCourses = new System.Windows.Forms.DataGridView();
            this.cardCourses = new XanderUI.XUICard();
            this.panelHeader.SuspendLayout();
            this.panelBody.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelAttendance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAttendance)).BeginInit();
            this.panelCourseReg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCourses)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1140, 17);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 17);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(18, 585);
            this.panel3.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(1122, 17);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(18, 585);
            this.panel4.TabIndex = 0;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.White;
            this.panelHeader.Controls.Add(this.cardCourses);
            this.panelHeader.Controls.Add(this.cardStudent);
            this.panelHeader.Controls.Add(this.cardUsers);
            this.panelHeader.Controls.Add(this.cardSession);
            this.panelHeader.Controls.Add(this.clock1);
            this.panelHeader.Controls.Add(this.cardDate);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(18, 17);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1104, 144);
            this.panelHeader.TabIndex = 1;
            // 
            // cardStudent
            // 
            this.cardStudent.BackColor = System.Drawing.Color.Transparent;
            this.cardStudent.Color1 = System.Drawing.Color.DodgerBlue;
            this.cardStudent.Color2 = System.Drawing.Color.LimeGreen;
            this.cardStudent.Font = new System.Drawing.Font("Calisto MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardStudent.ForeColor = System.Drawing.Color.White;
            this.cardStudent.Location = new System.Drawing.Point(734, 23);
            this.cardStudent.Name = "cardStudent";
            this.cardStudent.Size = new System.Drawing.Size(169, 114);
            this.cardStudent.TabIndex = 4;
            this.cardStudent.Text1 = "Students";
            this.cardStudent.Text2 = "";
            this.cardStudent.Text3 = "";
            // 
            // cardUsers
            // 
            this.cardUsers.BackColor = System.Drawing.Color.Transparent;
            this.cardUsers.Color1 = System.Drawing.Color.DodgerBlue;
            this.cardUsers.Color2 = System.Drawing.Color.LimeGreen;
            this.cardUsers.Font = new System.Drawing.Font("Calisto MT", 10.2F, System.Drawing.FontStyle.Bold);
            this.cardUsers.ForeColor = System.Drawing.Color.White;
            this.cardUsers.Location = new System.Drawing.Point(544, 23);
            this.cardUsers.Name = "cardUsers";
            this.cardUsers.Size = new System.Drawing.Size(169, 114);
            this.cardUsers.TabIndex = 3;
            this.cardUsers.Text1 = "Staff";
            this.cardUsers.Text2 = "";
            this.cardUsers.Text3 = "";
            // 
            // cardSession
            // 
            this.cardSession.BackColor = System.Drawing.Color.Transparent;
            this.cardSession.Color1 = System.Drawing.Color.DodgerBlue;
            this.cardSession.Color2 = System.Drawing.Color.LimeGreen;
            this.cardSession.Font = new System.Drawing.Font("Calisto MT", 10.2F, System.Drawing.FontStyle.Bold);
            this.cardSession.ForeColor = System.Drawing.Color.White;
            this.cardSession.Location = new System.Drawing.Point(354, 23);
            this.cardSession.Name = "cardSession";
            this.cardSession.Size = new System.Drawing.Size(169, 114);
            this.cardSession.TabIndex = 2;
            this.cardSession.Text1 = "Active Session";
            this.cardSession.Text2 = "";
            this.cardSession.Text3 = "";
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
            this.clock1.Location = new System.Drawing.Point(16, 7);
            this.clock1.Name = "clock1";
            this.clock1.ShowAmPm = false;
            this.clock1.ShowHexagon = true;
            this.clock1.ShowMinutesCircle = true;
            this.clock1.ShowSecondsCircle = true;
            this.clock1.Size = new System.Drawing.Size(120, 130);
            this.clock1.TabIndex = 1;
            this.clock1.Text = "xuiClock1";
            this.clock1.UnfilledHourColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(70)))), ((int)(((byte)(85)))));
            this.clock1.UnfilledMinuteColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.clock1.UnfilledSecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            // 
            // cardDate
            // 
            this.cardDate.BackColor = System.Drawing.Color.Transparent;
            this.cardDate.Color1 = System.Drawing.Color.DodgerBlue;
            this.cardDate.Color2 = System.Drawing.Color.LimeGreen;
            this.cardDate.Font = new System.Drawing.Font("Calisto MT", 10.2F, System.Drawing.FontStyle.Bold);
            this.cardDate.ForeColor = System.Drawing.Color.White;
            this.cardDate.Location = new System.Drawing.Point(164, 23);
            this.cardDate.Name = "cardDate";
            this.cardDate.Size = new System.Drawing.Size(169, 114);
            this.cardDate.TabIndex = 0;
            this.cardDate.Text1 = "Today";
            this.cardDate.Text2 = "";
            this.cardDate.Text3 = "";
            // 
            // panelBody
            // 
            this.panelBody.Controls.Add(this.tableLayoutPanel1);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(18, 161);
            this.panelBody.Margin = new System.Windows.Forms.Padding(4);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(1104, 441);
            this.panelBody.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panelAttendance, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelCourseReg, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1104, 441);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panelAttendance
            // 
            this.panelAttendance.Controls.Add(this.dataGridAttendance);
            this.panelAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAttendance.Location = new System.Drawing.Point(555, 3);
            this.panelAttendance.Name = "panelAttendance";
            this.panelAttendance.Size = new System.Drawing.Size(546, 435);
            this.panelAttendance.TabIndex = 1;
            // 
            // dataGridAttendance
            // 
            this.dataGridAttendance.AllowUserToAddRows = false;
            this.dataGridAttendance.AllowUserToDeleteRows = false;
            this.dataGridAttendance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridAttendance.BackgroundColor = System.Drawing.Color.White;
            this.dataGridAttendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridAttendance.Location = new System.Drawing.Point(0, 0);
            this.dataGridAttendance.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridAttendance.Name = "dataGridAttendance";
            this.dataGridAttendance.ReadOnly = true;
            this.dataGridAttendance.RowHeadersWidth = 51;
            this.dataGridAttendance.RowTemplate.Height = 24;
            this.dataGridAttendance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridAttendance.Size = new System.Drawing.Size(546, 435);
            this.dataGridAttendance.TabIndex = 1;
            // 
            // panelCourseReg
            // 
            this.panelCourseReg.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelCourseReg.Controls.Add(this.dataGridCourses);
            this.panelCourseReg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCourseReg.Location = new System.Drawing.Point(3, 3);
            this.panelCourseReg.Name = "panelCourseReg";
            this.panelCourseReg.Size = new System.Drawing.Size(546, 435);
            this.panelCourseReg.TabIndex = 0;
            // 
            // dataGridCourses
            // 
            this.dataGridCourses.AllowUserToAddRows = false;
            this.dataGridCourses.AllowUserToDeleteRows = false;
            this.dataGridCourses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridCourses.BackgroundColor = System.Drawing.Color.White;
            this.dataGridCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCourses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridCourses.Location = new System.Drawing.Point(0, 0);
            this.dataGridCourses.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridCourses.Name = "dataGridCourses";
            this.dataGridCourses.ReadOnly = true;
            this.dataGridCourses.RowHeadersWidth = 51;
            this.dataGridCourses.RowTemplate.Height = 24;
            this.dataGridCourses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridCourses.Size = new System.Drawing.Size(546, 435);
            this.dataGridCourses.TabIndex = 1;
            // 
            // cardCourses
            // 
            this.cardCourses.BackColor = System.Drawing.Color.Transparent;
            this.cardCourses.Color1 = System.Drawing.Color.DodgerBlue;
            this.cardCourses.Color2 = System.Drawing.Color.LimeGreen;
            this.cardCourses.Font = new System.Drawing.Font("Calisto MT", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardCourses.ForeColor = System.Drawing.Color.White;
            this.cardCourses.Location = new System.Drawing.Point(921, 23);
            this.cardCourses.Name = "cardCourses";
            this.cardCourses.Size = new System.Drawing.Size(169, 114);
            this.cardCourses.TabIndex = 5;
            this.cardCourses.Text1 = "Courses";
            this.cardCourses.Text2 = "";
            this.cardCourses.Text3 = "";
            // 
            // PgHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calisto MT", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PgHome";
            this.Size = new System.Drawing.Size(1140, 602);
            this.Load += new System.EventHandler(this.PgHome_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelBody.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelAttendance.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAttendance)).EndInit();
            this.panelCourseReg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCourses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelBody;
        private XanderUI.XUICard cardDate;
        private XanderUI.XUICard cardStudent;
        private XanderUI.XUICard cardUsers;
        private XanderUI.XUICard cardSession;
        private XanderUI.XUIClock clock1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panelAttendance;
        private System.Windows.Forms.Panel panelCourseReg;
        private System.Windows.Forms.DataGridView dataGridAttendance;
        private System.Windows.Forms.DataGridView dataGridCourses;
        private XanderUI.XUICard cardCourses;
    }
}
