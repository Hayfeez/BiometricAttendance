namespace AttendanceUI.Forms
{
    partial class FrmAssignStaffCourse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAssignStaffCourse));
            this.panelForm = new System.Windows.Forms.Panel();
            this.panelBody = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.checkCourses = new System.Windows.Forms.CheckedListBox();
            this.comboStaff = new System.Windows.Forms.ComboBox();
            this.comboLevel = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
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
            this.panelForm.Size = new System.Drawing.Size(781, 622);
            this.panelForm.TabIndex = 0;
            // 
            // panelBody
            // 
            this.panelBody.Controls.Add(this.label4);
            this.panelBody.Controls.Add(this.checkCourses);
            this.panelBody.Controls.Add(this.comboStaff);
            this.panelBody.Controls.Add(this.comboLevel);
            this.panelBody.Controls.Add(this.btnSave);
            this.panelBody.Controls.Add(this.label3);
            this.panelBody.Controls.Add(this.label2);
            this.panelBody.Controls.Add(this.label1);
            this.panelBody.Controls.Add(this.comboDept);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(11, 119);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(759, 492);
            this.panelBody.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.label4.Location = new System.Drawing.Point(17, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "Courses";
            // 
            // checkCourses
            // 
            this.checkCourses.FormattingEnabled = true;
            this.checkCourses.HorizontalScrollbar = true;
            this.checkCourses.Location = new System.Drawing.Point(149, 144);
            this.checkCourses.Name = "checkCourses";
            this.checkCourses.Size = new System.Drawing.Size(574, 211);
            this.checkCourses.TabIndex = 4;
            // 
            // comboStaff
            // 
            this.comboStaff.Font = new System.Drawing.Font("Calisto MT", 12F);
            this.comboStaff.FormattingEnabled = true;
            this.comboStaff.Location = new System.Drawing.Point(149, 89);
            this.comboStaff.Name = "comboStaff";
            this.comboStaff.Size = new System.Drawing.Size(574, 31);
            this.comboStaff.TabIndex = 3;
            // 
            // comboLevel
            // 
            this.comboLevel.Font = new System.Drawing.Font("Calisto MT", 12F);
            this.comboLevel.FormattingEnabled = true;
            this.comboLevel.Location = new System.Drawing.Point(487, 38);
            this.comboLevel.Name = "comboLevel";
            this.comboLevel.Size = new System.Drawing.Size(236, 31);
            this.comboLevel.TabIndex = 2;
            this.comboLevel.SelectedIndexChanged += new System.EventHandler(this.comboLevel_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(307, 374);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(236, 33);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.label3.Location = new System.Drawing.Point(404, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Level";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.label2.Location = new System.Drawing.Point(17, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Staff";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.label1.Location = new System.Drawing.Point(17, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Department";
            // 
            // comboDept
            // 
            this.comboDept.Font = new System.Drawing.Font("Calisto MT", 12F);
            this.comboDept.FormattingEnabled = true;
            this.comboDept.Location = new System.Drawing.Point(149, 39);
            this.comboDept.Name = "comboDept";
            this.comboDept.Size = new System.Drawing.Size(236, 31);
            this.comboDept.TabIndex = 1;
            this.comboDept.SelectedIndexChanged += new System.EventHandler(this.comboDept_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(11, 611);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(759, 11);
            this.panel3.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(770, 119);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(11, 503);
            this.panel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(11, 503);
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
            this.panelTop.Size = new System.Drawing.Size(781, 119);
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
            this.lblPageTitle.Size = new System.Drawing.Size(175, 31);
            this.lblPageTitle.TabIndex = 1;
            this.lblPageTitle.Text = "Staff Courses";
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
            this.iconExit.Location = new System.Drawing.Point(696, 3);
            this.iconExit.Name = "iconExit";
            this.iconExit.Size = new System.Drawing.Size(74, 60);
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
            this.lblTitle.Size = new System.Drawing.Size(189, 22);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Assign Staff Course";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FrmAssignStaffCourse
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(781, 622);
            this.Controls.Add(this.panelForm);
            this.Font = new System.Drawing.Font("Calisto MT", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmAssignStaffCourse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmCourse";
            this.Load += new System.EventHandler(this.FrmAssignStaffCourse_Load);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboDept;
        private System.Windows.Forms.ComboBox comboStaff;
        private System.Windows.Forms.ComboBox comboLevel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckedListBox checkCourses;
        private System.Windows.Forms.Label label4;
    }
}