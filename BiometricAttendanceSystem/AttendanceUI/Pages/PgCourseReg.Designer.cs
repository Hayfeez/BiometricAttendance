﻿namespace AttendanceUI.Pages
{
    partial class PgCourseReg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PgCourseReg));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnImport = new XanderUI.XUIButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelBody = new System.Windows.Forms.Panel();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.comboCourse = new System.Windows.Forms.ComboBox();
            this.comboLevel = new System.Windows.Forms.ComboBox();
            this.comboDept = new System.Windows.Forms.ComboBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.comboSemester = new System.Windows.Forms.ComboBox();
            this.panelHeader.SuspendLayout();
            this.panelBody.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(958, 17);
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
            this.panel4.Location = new System.Drawing.Point(940, 17);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(18, 585);
            this.panel4.TabIndex = 0;
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(78)))), ((int)(((byte)(114)))));
            this.panelHeader.Controls.Add(this.btnImport);
            this.panelHeader.Controls.Add(this.btnSearch);
            this.panelHeader.Controls.Add(this.txtSearch);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(18, 17);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(922, 144);
            this.panelHeader.TabIndex = 1;
            // 
            // btnImport
            // 
            this.btnImport.BackgroundColor = System.Drawing.Color.Transparent;
            this.btnImport.ButtonImage = ((System.Drawing.Image)(resources.GetObject("btnImport.ButtonImage")));
            this.btnImport.ButtonStyle = XanderUI.XUIButton.Style.MaterialRounded;
            this.btnImport.ButtonText = "Upload Course Registration";
            this.btnImport.ClickBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(195)))), ((int)(((byte)(195)))), ((int)(((byte)(195)))));
            this.btnImport.ClickTextColor = System.Drawing.Color.DodgerBlue;
            this.btnImport.CornerRadius = 5;
            this.btnImport.Font = new System.Drawing.Font("Calisto MT", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Horizontal_Alignment = System.Drawing.StringAlignment.Center;
            this.btnImport.HoverBackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.btnImport.HoverTextColor = System.Drawing.Color.DodgerBlue;
            this.btnImport.ImagePosition = XanderUI.XUIButton.imgPosition.Left;
            this.btnImport.Location = new System.Drawing.Point(18, 87);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(260, 50);
            this.btnImport.TabIndex = 1;
            this.btnImport.TextColor = System.Drawing.Color.White;
            this.btnImport.Vertical_Alignment = System.Drawing.StringAlignment.Center;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(839, 107);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(76, 31);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(548, 106);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(285, 31);
            this.txtSearch.TabIndex = 2;
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
            this.lblTitle.Size = new System.Drawing.Size(257, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Course Registration";
            // 
            // panelBody
            // 
            this.panelBody.Controls.Add(this.dataGrid);
            this.panelBody.Controls.Add(this.panelFilter);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(18, 161);
            this.panelBody.Margin = new System.Windows.Forms.Padding(4);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(922, 441);
            this.panelBody.TabIndex = 2;
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGrid.BackgroundColor = System.Drawing.Color.White;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGrid.Location = new System.Drawing.Point(0, 79);
            this.dataGrid.Margin = new System.Windows.Forms.Padding(4);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.RowHeadersWidth = 51;
            this.dataGrid.RowTemplate.Height = 24;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(922, 362);
            this.dataGrid.TabIndex = 2;
            this.dataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGrid_CellContentClick);
            // 
            // panelFilter
            // 
            this.panelFilter.BackColor = System.Drawing.Color.White;
            this.panelFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFilter.Controls.Add(this.comboCourse);
            this.panelFilter.Controls.Add(this.comboLevel);
            this.panelFilter.Controls.Add(this.comboDept);
            this.panelFilter.Controls.Add(this.btnLoad);
            this.panelFilter.Controls.Add(this.comboSemester);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(0, 0);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(922, 79);
            this.panelFilter.TabIndex = 1;
            // 
            // comboCourse
            // 
            this.comboCourse.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboCourse.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboCourse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboCourse.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboCourse.FormattingEnabled = true;
            this.comboCourse.Location = new System.Drawing.Point(580, 27);
            this.comboCourse.Name = "comboCourse";
            this.comboCourse.Size = new System.Drawing.Size(252, 31);
            this.comboCourse.TabIndex = 3;
            // 
            // comboLevel
            // 
            this.comboLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboLevel.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboLevel.FormattingEnabled = true;
            this.comboLevel.Location = new System.Drawing.Point(427, 26);
            this.comboLevel.Name = "comboLevel";
            this.comboLevel.Size = new System.Drawing.Size(147, 31);
            this.comboLevel.TabIndex = 2;
            this.comboLevel.SelectedValueChanged += new System.EventHandler(this.comboLevel_SelectedValueChanged);
            // 
            // comboDept
            // 
            this.comboDept.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboDept.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDept.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboDept.FormattingEnabled = true;
            this.comboDept.Location = new System.Drawing.Point(192, 27);
            this.comboDept.Name = "comboDept";
            this.comboDept.Size = new System.Drawing.Size(229, 31);
            this.comboDept.TabIndex = 1;
            this.comboDept.SelectedValueChanged += new System.EventHandler(this.comboDept_SelectedValueChanged);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(838, 27);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(76, 31);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // comboSemester
            // 
            this.comboSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSemester.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSemester.FormattingEnabled = true;
            this.comboSemester.Location = new System.Drawing.Point(17, 26);
            this.comboSemester.Name = "comboSemester";
            this.comboSemester.Size = new System.Drawing.Size(169, 31);
            this.comboSemester.TabIndex = 0;
            // 
            // PgCourseReg
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
            this.Name = "PgCourseReg";
            this.Size = new System.Drawing.Size(958, 602);
            this.Load += new System.EventHandler(this.PgCourseReg_Load);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelBody.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.ComboBox comboSemester;
        private System.Windows.Forms.Button btnLoad;
        private XanderUI.XUIButton btnImport;
        private System.Windows.Forms.ComboBox comboCourse;
        private System.Windows.Forms.ComboBox comboLevel;
        private System.Windows.Forms.ComboBox comboDept;
    }
}
