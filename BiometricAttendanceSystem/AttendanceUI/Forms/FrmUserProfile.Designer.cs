namespace AttendanceUI.Forms
{
    partial class FrmUserProfile
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridCourses = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblDept = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.iconUserImage = new FontAwesome.Sharp.IconPictureBox();
            this.btnChangePwd = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.iconExit = new FontAwesome.Sharp.IconPictureBox();
            this.panelForm.SuspendLayout();
            this.panelBody.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCourses)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconUserImage)).BeginInit();
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
            this.panelBody.Location = new System.Drawing.Point(11, 84);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(1066, 691);
            this.panelBody.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridCourses, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1066, 691);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Calisto MT", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.label2.Location = new System.Drawing.Point(543, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(513, 28);
            this.label2.TabIndex = 0;
            this.label2.Text = "My Courses";
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
            this.label1.Size = new System.Drawing.Size(513, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Profile";
            // 
            // dataGridCourses
            // 
            this.dataGridCourses.AllowUserToAddRows = false;
            this.dataGridCourses.AllowUserToDeleteRows = false;
            this.dataGridCourses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridCourses.BackgroundColor = System.Drawing.Color.White;
            this.dataGridCourses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCourses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridCourses.Location = new System.Drawing.Point(537, 52);
            this.dataGridCourses.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridCourses.Name = "dataGridCourses";
            this.dataGridCourses.ReadOnly = true;
            this.dataGridCourses.RowHeadersWidth = 51;
            this.dataGridCourses.RowTemplate.Height = 24;
            this.dataGridCourses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridCourses.Size = new System.Drawing.Size(525, 635);
            this.dataGridCourses.TabIndex = 2;
            this.dataGridCourses.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridTitle_CellContentClick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lblDept);
            this.panel4.Controls.Add(this.lblName);
            this.panel4.Controls.Add(this.iconUserImage);
            this.panel4.Controls.Add(this.btnChangePwd);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 51);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(527, 637);
            this.panel4.TabIndex = 3;
            // 
            // lblDept
            // 
            this.lblDept.AutoSize = true;
            this.lblDept.Location = new System.Drawing.Point(189, 240);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(107, 22);
            this.lblDept.TabIndex = 0;
            this.lblDept.Text = "Department";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(189, 209);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(59, 22);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // iconUserImage
            // 
            this.iconUserImage.BackColor = System.Drawing.Color.Transparent;
            this.iconUserImage.ForeColor = System.Drawing.Color.Black;
            this.iconUserImage.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            this.iconUserImage.IconColor = System.Drawing.Color.Black;
            this.iconUserImage.IconSize = 146;
            this.iconUserImage.Location = new System.Drawing.Point(12, 132);
            this.iconUserImage.Name = "iconUserImage";
            this.iconUserImage.Size = new System.Drawing.Size(162, 146);
            this.iconUserImage.TabIndex = 12;
            this.iconUserImage.TabStop = false;
            // 
            // btnChangePwd
            // 
            this.btnChangePwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.btnChangePwd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePwd.Font = new System.Drawing.Font("Calisto MT", 10F, System.Drawing.FontStyle.Bold);
            this.btnChangePwd.ForeColor = System.Drawing.Color.White;
            this.btnChangePwd.Location = new System.Drawing.Point(317, 14);
            this.btnChangePwd.Name = "btnChangePwd";
            this.btnChangePwd.Size = new System.Drawing.Size(203, 42);
            this.btnChangePwd.TabIndex = 1;
            this.btnChangePwd.Text = "Change Password";
            this.btnChangePwd.UseVisualStyleBackColor = false;
            this.btnChangePwd.Click += new System.EventHandler(this.btnChangePwd_Click);
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
            this.panel2.Location = new System.Drawing.Point(1077, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(11, 702);
            this.panel2.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(11, 702);
            this.panel1.TabIndex = 1;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.panelTop.Controls.Add(this.lblPageTitle);
            this.panelTop.Controls.Add(this.iconExit);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1088, 84);
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
            this.lblPageTitle.Size = new System.Drawing.Size(142, 31);
            this.lblPageTitle.TabIndex = 0;
            this.lblPageTitle.Text = "My Profile";
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
            // FrmUserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 786);
            this.Controls.Add(this.panelForm);
            this.Font = new System.Drawing.Font("Calisto MT", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmUserProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmCourse";
            this.Load += new System.EventHandler(this.FrmSettings_Load);
            this.panelForm.ResumeLayout(false);
            this.panelBody.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCourses)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconUserImage)).EndInit();
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridCourses;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnChangePwd;
        private System.Windows.Forms.Label lblDept;
        private System.Windows.Forms.Label lblName;
        private FontAwesome.Sharp.IconPictureBox iconUserImage;
    }
}