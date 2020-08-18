using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AttendanceUI.Forms;

namespace AttendanceUI.Forms
{
    public partial class FrmStaffCourse : Form
    {
        public FrmStaffCourse()
        {
            InitializeComponent();
        }


        private void btnCourse_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            var courseStaffForm = new FrmAssignStaffCourse();
            courseStaffForm.ShowDialog();
        }
    }
}
