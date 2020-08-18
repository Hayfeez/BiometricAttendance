﻿using System.Drawing;
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
            this.panelActive = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelControls = new System.Windows.Forms.Panel();
            this.panelWelcome = new System.Windows.Forms.Panel();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();
            this.xuiFormHandle1 = new XanderUI.XUIFormHandle();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.iconMinimize = new FontAwesome.Sharp.IconPictureBox();
            this.iconExit = new FontAwesome.Sharp.IconPictureBox();
            this.btnLogout = new XanderUI.XUIButton();
            this.btnReport = new XanderUI.XUIButton();
            this.btnAttendance = new XanderUI.XUIButton();
            this.btnCourseReg = new XanderUI.XUIButton();
            this.btnUserMgt = new XanderUI.XUIButton();
            this.btnStudentMgt = new XanderUI.XUIButton();
            this.btnCourseMgt = new XanderUI.XUIButton();
            this.btnDept = new XanderUI.XUIButton();
            this.btnSession = new XanderUI.XUIButton();
            this.btnHome = new XanderUI.XUIButton();
            this.iconUserImage = new FontAwesome.Sharp.IconPictureBox();
            this.iconMenu = new FontAwesome.Sharp.IconPictureBox();
            this.panelMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelWelcome.SuspendLayout();
            this.panelHeader.SuspendLayout();
            this.panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconUserImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.Gainsboro;
            this.panelMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMenu.Controls.Add(this.panelActive);
            this.panelMenu.Controls.Add(this.btnLogout);
            this.panelMenu.Controls.Add(this.btnReport);
            this.panelMenu.Controls.Add(this.btnAttendance);
            this.panelMenu.Controls.Add(this.btnCourseReg);
            this.panelMenu.Controls.Add(this.btnUserMgt);
            this.panelMenu.Controls.Add(this.btnStudentMgt);
            this.panelMenu.Controls.Add(this.btnCourseMgt);
            this.panelMenu.Controls.Add(this.btnDept);
            this.panelMenu.Controls.Add(this.btnSession);
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
            // panelActive
            // 
            this.panelActive.BackColor = System.Drawing.Color.DodgerBlue;
            this.panelActive.Location = new System.Drawing.Point(5, 477);
            this.panelActive.Name = "panelActive";
            this.panelActive.Size = new System.Drawing.Size(17, 51);
            this.panelActive.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.iconUserImage);
            this.panel1.Controls.Add(this.iconMenu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 178);
            this.panel1.TabIndex = 2;
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
            this.panelControls.Size = new System.Drawing.Size(733, 718);
            this.panelControls.TabIndex = 5;
            // 
            // panelWelcome
            // 
            this.panelWelcome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.panelWelcome.Controls.Add(this.lblUsername);
            this.panelWelcome.Controls.Add(this.lblRole);
            this.panelWelcome.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelWelcome.Location = new System.Drawing.Point(5, 81);
            this.panelWelcome.Name = "panelWelcome";
            this.panelWelcome.Size = new System.Drawing.Size(733, 102);
            this.panelWelcome.TabIndex = 2;
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
            this.lblUsername.TabIndex = 3;
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
            this.lblRole.TabIndex = 4;
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
            this.panelHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Bookman Old Style", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(201)))), ((int)(((byte)(60)))));
            this.lblTitle.Location = new System.Drawing.Point(17, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(576, 32);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Biometric Student Attendance System";
            // 
            // panelFooter
            // 
            this.panelFooter.Controls.Add(this.lblFooter);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(5, 901);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(733, 44);
            this.panelFooter.TabIndex = 4;
            // 
            // lblFooter
            // 
            this.lblFooter.AutoSize = true;
            this.lblFooter.Font = new System.Drawing.Font("Bookman Old Style", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(201)))), ((int)(((byte)(60)))));
            this.lblFooter.Location = new System.Drawing.Point(7, 11);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(157, 20);
            this.lblFooter.TabIndex = 5;
            this.lblFooter.Text = "Copyrights 2020";
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
            this.iconExit.Click += new System.EventHandler(this.iconExit_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnLogout.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnLogout.ButtonImage")));
            this.btnLogout.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btnLogout.ButtonText = "Logout";
            this.btnLogout.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btnLogout.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btnLogout.CornerRadius = 5;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnLogout.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnLogout.HoverTextColor = System.Drawing.Color.Black;
            this.btnLogout.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btnLogout.Location = new System.Drawing.Point(5, 895);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(331, 50);
            this.btnLogout.TabIndex = 12;
            this.btnLogout.TextColor = System.Drawing.Color.DodgerBlue;
            this.btnLogout.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnReport
            // 
            this.btnReport.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnReport.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnReport.ButtonImage")));
            this.btnReport.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btnReport.ButtonText = "Report";
            this.btnReport.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btnReport.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btnReport.CornerRadius = 5;
            this.btnReport.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnReport.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnReport.HoverTextColor = System.Drawing.Color.Black;
            this.btnReport.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btnReport.Location = new System.Drawing.Point(23, 826);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(288, 50);
            this.btnReport.TabIndex = 11;
            this.btnReport.TextColor = System.Drawing.Color.DodgerBlue;
            this.btnReport.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnAttendance
            // 
            this.btnAttendance.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnAttendance.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnAttendance.ButtonImage")));
            this.btnAttendance.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btnAttendance.ButtonText = "Atttendance";
            this.btnAttendance.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btnAttendance.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btnAttendance.CornerRadius = 5;
            this.btnAttendance.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttendance.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnAttendance.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnAttendance.HoverTextColor = System.Drawing.Color.Black;
            this.btnAttendance.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btnAttendance.Location = new System.Drawing.Point(23, 753);
            this.btnAttendance.Name = "btnAttendance";
            this.btnAttendance.Size = new System.Drawing.Size(288, 50);
            this.btnAttendance.TabIndex = 10;
            this.btnAttendance.TextColor = System.Drawing.Color.DodgerBlue;
            this.btnAttendance.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnAttendance.Click += new System.EventHandler(this.btnAttendance_Click);
            // 
            // btnCourseReg
            // 
            this.btnCourseReg.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnCourseReg.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnCourseReg.ButtonImage")));
            this.btnCourseReg.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btnCourseReg.ButtonText = "Course Registration";
            this.btnCourseReg.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btnCourseReg.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btnCourseReg.CornerRadius = 5;
            this.btnCourseReg.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCourseReg.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnCourseReg.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnCourseReg.HoverTextColor = System.Drawing.Color.Black;
            this.btnCourseReg.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btnCourseReg.Location = new System.Drawing.Point(23, 684);
            this.btnCourseReg.Name = "btnCourseReg";
            this.btnCourseReg.Size = new System.Drawing.Size(288, 50);
            this.btnCourseReg.TabIndex = 9;
            this.btnCourseReg.TextColor = System.Drawing.Color.DodgerBlue;
            this.btnCourseReg.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnCourseReg.Click += new System.EventHandler(this.btnCourseReg_Click);
            // 
            // btnUserMgt
            // 
            this.btnUserMgt.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnUserMgt.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnUserMgt.ButtonImage")));
            this.btnUserMgt.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btnUserMgt.ButtonText = "User Managment";
            this.btnUserMgt.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btnUserMgt.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btnUserMgt.CornerRadius = 5;
            this.btnUserMgt.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserMgt.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnUserMgt.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnUserMgt.HoverTextColor = System.Drawing.Color.Black;
            this.btnUserMgt.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btnUserMgt.Location = new System.Drawing.Point(23, 612);
            this.btnUserMgt.Name = "btnUserMgt";
            this.btnUserMgt.Size = new System.Drawing.Size(288, 50);
            this.btnUserMgt.TabIndex = 8;
            this.btnUserMgt.TextColor = System.Drawing.Color.DodgerBlue;
            this.btnUserMgt.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnUserMgt.Click += new System.EventHandler(this.btnUserMgt_Click);
            // 
            // btnStudentMgt
            // 
            this.btnStudentMgt.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnStudentMgt.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnStudentMgt.ButtonImage")));
            this.btnStudentMgt.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btnStudentMgt.ButtonText = "Student Management";
            this.btnStudentMgt.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btnStudentMgt.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btnStudentMgt.CornerRadius = 5;
            this.btnStudentMgt.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudentMgt.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnStudentMgt.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnStudentMgt.HoverTextColor = System.Drawing.Color.Black;
            this.btnStudentMgt.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btnStudentMgt.Location = new System.Drawing.Point(23, 540);
            this.btnStudentMgt.Name = "btnStudentMgt";
            this.btnStudentMgt.Size = new System.Drawing.Size(288, 50);
            this.btnStudentMgt.TabIndex = 7;
            this.btnStudentMgt.TextColor = System.Drawing.Color.DodgerBlue;
            this.btnStudentMgt.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnStudentMgt.Click += new System.EventHandler(this.btnStudentMgt_Click);
            // 
            // btnCourseMgt
            // 
            this.btnCourseMgt.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnCourseMgt.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnCourseMgt.ButtonImage")));
            this.btnCourseMgt.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btnCourseMgt.ButtonText = "Course Management";
            this.btnCourseMgt.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btnCourseMgt.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btnCourseMgt.CornerRadius = 5;
            this.btnCourseMgt.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCourseMgt.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnCourseMgt.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnCourseMgt.HoverTextColor = System.Drawing.Color.Black;
            this.btnCourseMgt.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btnCourseMgt.Location = new System.Drawing.Point(23, 477);
            this.btnCourseMgt.Name = "btnCourseMgt";
            this.btnCourseMgt.Size = new System.Drawing.Size(288, 50);
            this.btnCourseMgt.TabIndex = 6;
            this.btnCourseMgt.TextColor = System.Drawing.Color.DodgerBlue;
            this.btnCourseMgt.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnCourseMgt.Click += new System.EventHandler(this.btnCourseMgt_Click);
            // 
            // btnDept
            // 
            this.btnDept.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnDept.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnDept.ButtonImage")));
            this.btnDept.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btnDept.ButtonText = "Department";
            this.btnDept.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btnDept.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btnDept.CornerRadius = 5;
            this.btnDept.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDept.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnDept.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnDept.HoverTextColor = System.Drawing.Color.Black;
            this.btnDept.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btnDept.Location = new System.Drawing.Point(23, 408);
            this.btnDept.Name = "btnDept";
            this.btnDept.Size = new System.Drawing.Size(288, 50);
            this.btnDept.TabIndex = 5;
            this.btnDept.TextColor = System.Drawing.Color.DodgerBlue;
            this.btnDept.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnDept.Click += new System.EventHandler(this.btnDept_Click);
            // 
            // btnSession
            // 
            this.btnSession.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnSession.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnSession.ButtonImage")));
            this.btnSession.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btnSession.ButtonText = "Session/Semester";
            this.btnSession.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btnSession.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btnSession.CornerRadius = 5;
            this.btnSession.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSession.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnSession.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnSession.HoverTextColor = System.Drawing.Color.Black;
            this.btnSession.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btnSession.Location = new System.Drawing.Point(23, 336);
            this.btnSession.Name = "btnSession";
            this.btnSession.Size = new System.Drawing.Size(288, 50);
            this.btnSession.TabIndex = 4;
            this.btnSession.TextColor = System.Drawing.Color.DodgerBlue;
            this.btnSession.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnSession.Click += new System.EventHandler(this.btnSession_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnHome.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnHome.ButtonImage")));
            this.btnHome.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btnHome.ButtonText = "Home";
            this.btnHome.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btnHome.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btnHome.CornerRadius = 5;
            this.btnHome.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnHome.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnHome.HoverTextColor = System.Drawing.Color.Black;
            this.btnHome.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btnHome.Location = new System.Drawing.Point(23, 264);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(288, 50);
            this.btnHome.TabIndex = 3;
            this.btnHome.TextColor = System.Drawing.Color.DodgerBlue;
            this.btnHome.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // iconUserImage
            // 
            this.iconUserImage.BackColor = System.Drawing.Color.Transparent;
            this.iconUserImage.ForeColor = System.Drawing.Color.Black;
            this.iconUserImage.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            this.iconUserImage.IconColor = System.Drawing.Color.Black;
            this.iconUserImage.IconSize = 98;
            this.iconUserImage.Location = new System.Drawing.Point(84, 30);
            this.iconUserImage.Name = "iconUserImage";
            this.iconUserImage.Size = new System.Drawing.Size(98, 103);
            this.iconUserImage.TabIndex = 2;
            this.iconUserImage.TabStop = false;
            // 
            // iconMenu
            // 
            this.iconMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconMenu.BackColor = System.Drawing.Color.Transparent;
            this.iconMenu.ForeColor = System.Drawing.Color.Black;
            this.iconMenu.IconChar = FontAwesome.Sharp.IconChar.Bars;
            this.iconMenu.IconColor = System.Drawing.Color.Black;
            this.iconMenu.IconSize = 35;
            this.iconMenu.Location = new System.Drawing.Point(284, 6);
            this.iconMenu.Name = "iconMenu";
            this.iconMenu.Size = new System.Drawing.Size(44, 35);
            this.iconMenu.TabIndex = 1;
            this.iconMenu.TabStop = false;
            this.iconMenu.Click += new System.EventHandler(this.iconMenu_Click);
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmContainer";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panelMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelWelcome.ResumeLayout(false);
            this.panelWelcome.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconUserImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconMenu)).EndInit();
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
        private FontAwesome.Sharp.IconPictureBox iconUserImage;
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
        private XanderUI.XUIButton btnLogout;
        private System.Windows.Forms.Panel panelActive;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelControls;
    }
}