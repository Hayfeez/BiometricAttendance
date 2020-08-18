using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceUI.Forms
{
    public partial class FrmStaff : Form
    {
        public FrmStaff(int staffId = 0)
        {
            InitializeComponent();
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
