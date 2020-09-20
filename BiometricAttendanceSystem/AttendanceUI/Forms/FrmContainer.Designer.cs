using System.Drawing;
using FontAwesome.Sharp;

namespace AttendanceUI.Forms
{
    partial class FrmContainer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmContainer));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnSyncData = new XanderUI.XUIButton();
            this.panelActive = new System.Windows.Forms.Panel();
            this.btnStudentMgt = new XanderUI.XUIButton();
            this.btnSession = new XanderUI.XUIButton();
            this.btnReport = new XanderUI.XUIButton();
            this.btnAttendance = new XanderUI.XUIButton();
            this.btnCourseReg = new XanderUI.XUIButton();
            this.btnUserMgt = new XanderUI.XUIButton();
            this.btnCourseMgt = new XanderUI.XUIButton();
            this.btnDept = new XanderUI.XUIButton();
            this.btnHome = new XanderUI.XUIButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.iconMenu = new FontAwesome.Sharp.IconPictureBox();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelControls = new System.Windows.Forms.Panel();
            this.panelWelcome = new System.Windows.Forms.Panel();
            this.iconAlert = new FontAwesome.Sharp.IconPictureBox();
            this.iconSettings = new FontAwesome.Sharp.IconPictureBox();
            this.iconLogout = new FontAwesome.Sharp.IconPictureBox();
            this.iconUser = new FontAwesome.Sharp.IconPictureBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.iconMinimize = new FontAwesome.Sharp.IconPictureBox();
            this.iconExit = new FontAwesome.Sharp.IconPictureBox();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.btnOpenConnSettings = new FontAwesome.Sharp.IconPictureBox();
            this.btnRefresh = new FontAwesome.Sharp.IconPictureBox();
            this.lblFooter = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.xuiFormHandle1 = new XanderUI.XUIFormHandle();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panelMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconMenu)).BeginInit();
            this.panelRight.SuspendLayout();
            this.panelWelcome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconAlert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconUser)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconExit)).BeginInit();
            this.panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenConnSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.Gainsboro;
            this.panelMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMenu.Controls.Add(this.btnSyncData);
            this.panelMenu.Controls.Add(this.panelActive);
            this.panelMenu.Controls.Add(this.btnStudentMgt);
            this.panelMenu.Controls.Add(this.btnSession);
            this.panelMenu.Controls.Add(this.btnReport);
            this.panelMenu.Controls.Add(this.btnAttendance);
            this.panelMenu.Controls.Add(this.btnCourseReg);
            this.panelMenu.Controls.Add(this.btnUserMgt);
            this.panelMenu.Controls.Add(this.btnCourseMgt);
            this.panelMenu.Controls.Add(this.btnDept);
            this.panelMenu.Controls.Add(this.btnHome);
            this.panelMenu.Controls.Add(this.panel1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Margin = new System.Windows.Forms.Padding(10);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Padding = new System.Windows.Forms.Padding(5);
            this.panelMenu.Size = new System.Drawing.Size(345, 954);
            this.panelMenu.TabIndex = 0;
            // 
            // btnSyncData
            // 
            this.btnSyncData.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnSyncData.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnSyncData.ButtonImage")));
            this.btnSyncData.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btnSyncData.ButtonText = "Sync Data";
            this.btnSyncData.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(201)))), ((int)(((byte)(60)))));
            this.btnSyncData.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btnSyncData.CornerRadius = 5;
            this.btnSyncData.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSyncData.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnSyncData.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnSyncData.HoverTextColor = System.Drawing.Color.Black;
            this.btnSyncData.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btnSyncData.Location = new System.Drawing.Point(23, 868);
            this.btnSyncData.Name = "btnSyncData";
            this.btnSyncData.Size = new System.Drawing.Size(288, 50);
            this.btnSyncData.TabIndex = 1;
            this.btnSyncData.TextColor = System.Drawing.Color.Black;
            this.toolTip1.SetToolTip(this.btnSyncData, "Sync Data");
            this.btnSyncData.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnSyncData.Click += new System.EventHandler(this.btnSyncData_Click);
            // 
            // panelActive
            // 
            this.panelActive.BackColor = System.Drawing.Color.OrangeRed;
            this.panelActive.Location = new System.Drawing.Point(10, 208);
            this.panelActive.Name = "panelActive";
            this.panelActive.Size = new System.Drawing.Size(10, 50);
            this.panelActive.TabIndex = 0;
            // 
            // btnStudentMgt
            // 
            this.btnStudentMgt.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnStudentMgt.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnStudentMgt.ButtonImage")));
            this.btnStudentMgt.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btnStudentMgt.ButtonText = "Manage Students";
            this.btnStudentMgt.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(201)))), ((int)(((byte)(60)))));
            this.btnStudentMgt.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btnStudentMgt.CornerRadius = 5;
            this.btnStudentMgt.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudentMgt.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnStudentMgt.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnStudentMgt.HoverTextColor = System.Drawing.Color.Black;
            this.btnStudentMgt.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btnStudentMgt.Location = new System.Drawing.Point(23, 665);
            this.btnStudentMgt.Name = "btnStudentMgt";
            this.btnStudentMgt.Size = new System.Drawing.Size(288, 50);
            this.btnStudentMgt.TabIndex = 0;
            this.btnStudentMgt.TextColor = System.Drawing.Color.Black;
            this.toolTip1.SetToolTip(this.btnStudentMgt, "Manage Students");
            this.btnStudentMgt.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnStudentMgt.Click += new System.EventHandler(this.btnStudentMgt_Click);
            // 
            // btnSession
            // 
            this.btnSession.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnSession.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnSession.ButtonImage")));
            this.btnSession.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btnSession.ButtonText = "Session/Semester";
            this.btnSession.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(201)))), ((int)(((byte)(60)))));
            this.btnSession.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btnSession.CornerRadius = 5;
            this.btnSession.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSession.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnSession.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnSession.HoverTextColor = System.Drawing.Color.Black;
            this.btnSession.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btnSession.Location = new System.Drawing.Point(23, 458);
            this.btnSession.Name = "btnSession";
            this.btnSession.Size = new System.Drawing.Size(288, 50);
            this.btnSession.TabIndex = 0;
            this.btnSession.TextColor = System.Drawing.Color.Black;
            this.toolTip1.SetToolTip(this.btnSession, "Session/Semester");
            this.btnSession.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnSession.Click += new System.EventHandler(this.btnSession_Click);
            // 
            // btnReport
            // 
            this.btnReport.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnReport.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnReport.ButtonImage")));
            this.btnReport.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btnReport.ButtonText = "Report";
            this.btnReport.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(201)))), ((int)(((byte)(60)))));
            this.btnReport.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btnReport.CornerRadius = 5;
            this.btnReport.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnReport.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnReport.HoverTextColor = System.Drawing.Color.Black;
            this.btnReport.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btnReport.Location = new System.Drawing.Point(23, 802);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(288, 50);
            this.btnReport.TabIndex = 0;
            this.btnReport.TextColor = System.Drawing.Color.Black;
            this.toolTip1.SetToolTip(this.btnReport, "Report");
            this.btnReport.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnAttendance
            // 
            this.btnAttendance.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnAttendance.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnAttendance.ButtonImage")));
            this.btnAttendance.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btnAttendance.ButtonText = "Take Atttendance";
            this.btnAttendance.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(201)))), ((int)(((byte)(60)))));
            this.btnAttendance.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btnAttendance.CornerRadius = 5;
            this.btnAttendance.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttendance.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnAttendance.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnAttendance.HoverTextColor = System.Drawing.Color.Black;
            this.btnAttendance.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btnAttendance.Location = new System.Drawing.Point(23, 328);
            this.btnAttendance.Name = "btnAttendance";
            this.btnAttendance.Size = new System.Drawing.Size(288, 50);
            this.btnAttendance.TabIndex = 0;
            this.btnAttendance.TextColor = System.Drawing.Color.Black;
            this.toolTip1.SetToolTip(this.btnAttendance, "Take Atttendance");
            this.btnAttendance.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnAttendance.Click += new System.EventHandler(this.btnAttendance_Click);
            // 
            // btnCourseReg
            // 
            this.btnCourseReg.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnCourseReg.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnCourseReg.ButtonImage")));
            this.btnCourseReg.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btnCourseReg.ButtonText = "Course Registration";
            this.btnCourseReg.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(201)))), ((int)(((byte)(60)))));
            this.btnCourseReg.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btnCourseReg.CornerRadius = 5;
            this.btnCourseReg.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCourseReg.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnCourseReg.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnCourseReg.HoverTextColor = System.Drawing.Color.Black;
            this.btnCourseReg.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btnCourseReg.Location = new System.Drawing.Point(23, 596);
            this.btnCourseReg.Name = "btnCourseReg";
            this.btnCourseReg.Size = new System.Drawing.Size(288, 50);
            this.btnCourseReg.TabIndex = 0;
            this.btnCourseReg.TextColor = System.Drawing.Color.Black;
            this.toolTip1.SetToolTip(this.btnCourseReg, "Course Registration");
            this.btnCourseReg.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnCourseReg.Click += new System.EventHandler(this.btnCourseReg_Click);
            // 
            // btnUserMgt
            // 
            this.btnUserMgt.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnUserMgt.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnUserMgt.ButtonImage")));
            this.btnUserMgt.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btnUserMgt.ButtonText = "Manage Users";
            this.btnUserMgt.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(201)))), ((int)(((byte)(60)))));
            this.btnUserMgt.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btnUserMgt.CornerRadius = 5;
            this.btnUserMgt.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserMgt.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnUserMgt.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnUserMgt.HoverTextColor = System.Drawing.Color.Black;
            this.btnUserMgt.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btnUserMgt.Location = new System.Drawing.Point(23, 734);
            this.btnUserMgt.Name = "btnUserMgt";
            this.btnUserMgt.Size = new System.Drawing.Size(288, 50);
            this.btnUserMgt.TabIndex = 0;
            this.btnUserMgt.TextColor = System.Drawing.Color.Black;
            this.toolTip1.SetToolTip(this.btnUserMgt, "Manage Users");
            this.btnUserMgt.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnUserMgt.Click += new System.EventHandler(this.btnUserMgt_Click);
            // 
            // btnCourseMgt
            // 
            this.btnCourseMgt.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnCourseMgt.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnCourseMgt.ButtonImage")));
            this.btnCourseMgt.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btnCourseMgt.ButtonText = "Manage Courses";
            this.btnCourseMgt.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(201)))), ((int)(((byte)(60)))));
            this.btnCourseMgt.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btnCourseMgt.CornerRadius = 5;
            this.btnCourseMgt.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCourseMgt.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnCourseMgt.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnCourseMgt.HoverTextColor = System.Drawing.Color.Black;
            this.btnCourseMgt.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btnCourseMgt.Location = new System.Drawing.Point(23, 527);
            this.btnCourseMgt.Name = "btnCourseMgt";
            this.btnCourseMgt.Size = new System.Drawing.Size(288, 50);
            this.btnCourseMgt.TabIndex = 0;
            this.btnCourseMgt.TextColor = System.Drawing.Color.Black;
            this.toolTip1.SetToolTip(this.btnCourseMgt, "Manage Courses");
            this.btnCourseMgt.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnCourseMgt.Click += new System.EventHandler(this.btnCourseMgt_Click);
            // 
            // btnDept
            // 
            this.btnDept.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnDept.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnDept.ButtonImage")));
            this.btnDept.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btnDept.ButtonText = "Department";
            this.btnDept.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(201)))), ((int)(((byte)(60)))));
            this.btnDept.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btnDept.CornerRadius = 5;
            this.btnDept.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDept.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnDept.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnDept.HoverTextColor = System.Drawing.Color.Black;
            this.btnDept.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btnDept.Location = new System.Drawing.Point(23, 389);
            this.btnDept.Name = "btnDept";
            this.btnDept.Size = new System.Drawing.Size(288, 50);
            this.btnDept.TabIndex = 0;
            this.btnDept.TextColor = System.Drawing.Color.Black;
            this.toolTip1.SetToolTip(this.btnDept, "Department");
            this.btnDept.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnDept.Click += new System.EventHandler(this.btnDept_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnHome.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnHome.ButtonImage")));
            this.btnHome.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btnHome.ButtonText = "Home";
            this.btnHome.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(201)))), ((int)(((byte)(60)))));
            this.btnHome.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btnHome.CornerRadius = 5;
            this.btnHome.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnHome.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnHome.HoverTextColor = System.Drawing.Color.Black;
            this.btnHome.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btnHome.Location = new System.Drawing.Point(23, 264);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(288, 50);
            this.btnHome.TabIndex = 0;
            this.btnHome.TextColor = System.Drawing.Color.Black;
            this.toolTip1.SetToolTip(this.btnHome, "Home");
            this.btnHome.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.iconMenu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 178);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(18, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(223, 167);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // iconMenu
            // 
            this.iconMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconMenu.BackColor = System.Drawing.Color.Transparent;
            this.iconMenu.ForeColor = System.Drawing.Color.Black;
            this.iconMenu.IconChar = FontAwesome.Sharp.IconChar.Bars;
            this.iconMenu.IconColor = System.Drawing.Color.Black;
            this.iconMenu.IconSize = 44;
            this.iconMenu.Location = new System.Drawing.Point(284, 6);
            this.iconMenu.Name = "iconMenu";
            this.iconMenu.Size = new System.Drawing.Size(44, 51);
            this.iconMenu.TabIndex = 1;
            this.iconMenu.TabStop = false;
            this.iconMenu.Click += new System.EventHandler(this.iconMenu_Click);
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.White;
            this.panelRight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelRight.Controls.Add(this.panelControls);
            this.panelRight.Controls.Add(this.panelWelcome);
            this.panelRight.Controls.Add(this.panelHeader);
            this.panelRight.Controls.Add(this.panelFooter);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(345, 0);
            this.panelRight.Margin = new System.Windows.Forms.Padding(10);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(5);
            this.panelRight.Size = new System.Drawing.Size(747, 954);
            this.panelRight.TabIndex = 0;
            // 
            // panelControls
            // 
            this.panelControls.BackColor = System.Drawing.Color.Gainsboro;
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControls.Location = new System.Drawing.Point(5, 183);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(733, 724);
            this.panelControls.TabIndex = 1;
            // 
            // panelWelcome
            // 
            this.panelWelcome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.panelWelcome.Controls.Add(this.iconAlert);
            this.panelWelcome.Controls.Add(this.iconSettings);
            this.panelWelcome.Controls.Add(this.iconLogout);
            this.panelWelcome.Controls.Add(this.iconUser);
            this.panelWelcome.Controls.Add(this.lblUsername);
            this.panelWelcome.Controls.Add(this.lblRole);
            this.panelWelcome.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelWelcome.Location = new System.Drawing.Point(5, 81);
            this.panelWelcome.Name = "panelWelcome";
            this.panelWelcome.Size = new System.Drawing.Size(733, 102);
            this.panelWelcome.TabIndex = 1;
            // 
            // iconAlert
            // 
            this.iconAlert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconAlert.BackColor = System.Drawing.Color.Transparent;
            this.iconAlert.IconChar = FontAwesome.Sharp.IconChar.Bell;
            this.iconAlert.IconColor = System.Drawing.Color.White;
            this.iconAlert.IconSize = 35;
            this.iconAlert.Location = new System.Drawing.Point(534, 25);
            this.iconAlert.Name = "iconAlert";
            this.iconAlert.Size = new System.Drawing.Size(44, 35);
            this.iconAlert.TabIndex = 8;
            this.iconAlert.TabStop = false;
            this.toolTip1.SetToolTip(this.iconAlert, "Notifications");
            this.iconAlert.Visible = false;
            this.iconAlert.Click += new System.EventHandler(this.iconAlert_Click);
            // 
            // iconSettings
            // 
            this.iconSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconSettings.BackColor = System.Drawing.Color.Transparent;
            this.iconSettings.IconChar = FontAwesome.Sharp.IconChar.Cog;
            this.iconSettings.IconColor = System.Drawing.Color.White;
            this.iconSettings.IconSize = 35;
            this.iconSettings.Location = new System.Drawing.Point(584, 25);
            this.iconSettings.Name = "iconSettings";
            this.iconSettings.Size = new System.Drawing.Size(44, 35);
            this.iconSettings.TabIndex = 7;
            this.iconSettings.TabStop = false;
            this.toolTip1.SetToolTip(this.iconSettings, "Settings");
            this.iconSettings.Click += new System.EventHandler(this.iconSettings_Click);
            // 
            // iconLogout
            // 
            this.iconLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconLogout.BackColor = System.Drawing.Color.Transparent;
            this.iconLogout.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.iconLogout.IconColor = System.Drawing.Color.White;
            this.iconLogout.IconSize = 35;
            this.iconLogout.Location = new System.Drawing.Point(684, 25);
            this.iconLogout.Name = "iconLogout";
            this.iconLogout.Size = new System.Drawing.Size(44, 35);
            this.iconLogout.TabIndex = 6;
            this.iconLogout.TabStop = false;
            this.toolTip1.SetToolTip(this.iconLogout, "Log Out");
            this.iconLogout.Click += new System.EventHandler(this.iconLogout_Click);
            // 
            // iconUser
            // 
            this.iconUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconUser.BackColor = System.Drawing.Color.Transparent;
            this.iconUser.IconChar = FontAwesome.Sharp.IconChar.Key;
            this.iconUser.IconColor = System.Drawing.Color.White;
            this.iconUser.IconSize = 35;
            this.iconUser.Location = new System.Drawing.Point(634, 25);
            this.iconUser.Name = "iconUser";
            this.iconUser.Size = new System.Drawing.Size(44, 35);
            this.iconUser.TabIndex = 5;
            this.iconUser.TabStop = false;
            this.toolTip1.SetToolTip(this.iconUser, "Change Password");
            this.iconUser.Click += new System.EventHandler(this.iconUser_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblUsername.Font = new System.Drawing.Font("Calisto MT", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(21, 25);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(104, 22);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "User name";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblRole.Font = new System.Drawing.Font("Calisto MT", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.ForeColor = System.Drawing.Color.White;
            this.lblRole.Location = new System.Drawing.Point(21, 58);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(73, 22);
            this.lblRole.TabIndex = 0;
            this.lblRole.Text = "User role";
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.iconMinimize);
            this.panelHeader.Controls.Add(this.iconExit);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(5, 5);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(733, 76);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Bookman Old Style", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(201)))), ((int)(((byte)(60)))));
            this.lblTitle.Location = new System.Drawing.Point(17, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(576, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Biometric Student Attendance System";
            // 
            // iconMinimize
            // 
            this.iconMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconMinimize.BackColor = System.Drawing.Color.Transparent;
            this.iconMinimize.ForeColor = System.Drawing.Color.Blue;
            this.iconMinimize.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.iconMinimize.IconColor = System.Drawing.Color.Blue;
            this.iconMinimize.IconSize = 35;
            this.iconMinimize.Location = new System.Drawing.Point(636, 8);
            this.iconMinimize.Name = "iconMinimize";
            this.iconMinimize.Size = new System.Drawing.Size(44, 35);
            this.iconMinimize.TabIndex = 3;
            this.iconMinimize.TabStop = false;
            this.toolTip1.SetToolTip(this.iconMinimize, "Minimize");
            this.iconMinimize.Click += new System.EventHandler(this.iconMinimize_Click);
            // 
            // iconExit
            // 
            this.iconExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconExit.BackColor = System.Drawing.Color.Transparent;
            this.iconExit.ForeColor = System.Drawing.Color.Red;
            this.iconExit.IconChar = FontAwesome.Sharp.IconChar.TimesCircle;
            this.iconExit.IconColor = System.Drawing.Color.Red;
            this.iconExit.IconSize = 35;
            this.iconExit.Location = new System.Drawing.Point(686, 8);
            this.iconExit.Name = "iconExit";
            this.iconExit.Size = new System.Drawing.Size(44, 35);
            this.iconExit.TabIndex = 2;
            this.iconExit.TabStop = false;
            this.toolTip1.SetToolTip(this.iconExit, "Exit Application");
            this.iconExit.Click += new System.EventHandler(this.iconExit_Click);
            // 
            // panelFooter
            // 
            this.panelFooter.Controls.Add(this.btnOpenConnSettings);
            this.panelFooter.Controls.Add(this.btnRefresh);
            this.panelFooter.Controls.Add(this.lblFooter);
            this.panelFooter.Controls.Add(this.statusStrip1);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(5, 907);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(733, 38);
            this.panelFooter.TabIndex = 0;
            // 
            // btnOpenConnSettings
            // 
            this.btnOpenConnSettings.BackColor = System.Drawing.Color.White;
            this.btnOpenConnSettings.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOpenConnSettings.IconChar = FontAwesome.Sharp.IconChar.Cog;
            this.btnOpenConnSettings.IconColor = System.Drawing.SystemColors.ControlText;
            this.btnOpenConnSettings.IconSize = 27;
            this.btnOpenConnSettings.Location = new System.Drawing.Point(464, 12);
            this.btnOpenConnSettings.Name = "btnOpenConnSettings";
            this.btnOpenConnSettings.Size = new System.Drawing.Size(31, 27);
            this.btnOpenConnSettings.TabIndex = 9;
            this.btnOpenConnSettings.TabStop = false;
            this.toolTip1.SetToolTip(this.btnOpenConnSettings, "Open Connection Settings");
            this.btnOpenConnSettings.Click += new System.EventHandler(this.btnOpenConnSettings_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRefresh.IconChar = FontAwesome.Sharp.IconChar.Retweet;
            this.btnRefresh.IconColor = System.Drawing.SystemColors.ControlText;
            this.btnRefresh.IconSize = 27;
            this.btnRefresh.Location = new System.Drawing.Point(431, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(31, 27);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.TabStop = false;
            this.toolTip1.SetToolTip(this.btnRefresh, "Refresh Server Connection Status");
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblFooter
            // 
            this.lblFooter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFooter.AutoSize = true;
            this.lblFooter.BackColor = System.Drawing.SystemColors.Control;
            this.lblFooter.Font = new System.Drawing.Font("Bookman Old Style", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFooter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFooter.Location = new System.Drawing.Point(493, 15);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(100, 21);
            this.lblFooter.TabIndex = 0;
            this.lblFooter.Text = "Copyrights";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 12);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(733, 26);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // xuiFormHandle1
            // 
            this.xuiFormHandle1.DockAtTop = true;
            this.xuiFormHandle1.HandleControl = this;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1092, 954);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelMenu);
            this.Font = new System.Drawing.Font("Calisto MT", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmContainer";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmContainer_KeyDown);
            this.panelMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconMenu)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.panelWelcome.ResumeLayout(false);
            this.panelWelcome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconAlert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconUser)).EndInit();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconExit)).EndInit();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOpenConnSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        //private XanderUI.XUISlidingPanel panelMenu;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panel1;
        private XanderUI.XUIFormHandle xuiFormHandle1;
        private System.Windows.Forms.Panel panelHeader;
        private FontAwesome.Sharp.IconPictureBox iconMenu;
        private System.Windows.Forms.Timer timer1;
        private FontAwesome.Sharp.IconPictureBox iconExit;
        private FontAwesome.Sharp.IconPictureBox iconMinimize;
        private XanderUI.XUIButton btnHome;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Panel panelWelcome;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label lblFooter;
        private XanderUI.XUIButton btnSession;
        private XanderUI.XUIButton btnCourseMgt;
        private XanderUI.XUIButton btnDept;
        private XanderUI.XUIButton btnAttendance;
        private XanderUI.XUIButton btnCourseReg;
        private XanderUI.XUIButton btnUserMgt;
        private XanderUI.XUIButton btnStudentMgt;
        private XanderUI.XUIButton btnReport;
        private System.Windows.Forms.Panel panelActive;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelControls;
        private IconPictureBox iconAlert;
        private IconPictureBox iconSettings;
        private IconPictureBox iconLogout;
        private IconPictureBox iconUser;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private IconPictureBox btnRefresh;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private IconPictureBox btnOpenConnSettings;
        private XanderUI.XUIButton btnSyncData;
    }
}