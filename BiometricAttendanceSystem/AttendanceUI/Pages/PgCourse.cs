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

namespace AttendanceUI.Pages
{
    public partial class PgCourse : UserControl
    {
        public PgCourse()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var courseForm = new FrmCourse();
            courseForm.ShowDialog();
        }

        private void btnStaffCourse_Click(object sender, EventArgs e)
        {
            var staffCourseForm = new FrmStaffCourse();
            staffCourseForm.ShowDialog();
        }
    }
}
