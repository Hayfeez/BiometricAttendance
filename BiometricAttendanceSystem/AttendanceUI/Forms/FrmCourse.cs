﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AttendanceLibrary.Repository;

using AttendanceUI.BaseClass;

namespace AttendanceUI.Forms
{
    public partial class FrmCourse : Form
    {
        
        public FrmCourse(int courseId = 0)
        {
            InitializeComponent();
        }

        private void LoadForm()
        {
            DropdownControls.LoadDepartments(ref comboDept);
            DropdownControls.LoadLevels(ref comboLevel);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void iconExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
