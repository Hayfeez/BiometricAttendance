using AttendanceSystem.BaseClass;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceSystem.Forms
{
    public partial class Container : MaterialForm
    {
        public Container()
        {
            InitializeComponent();
            MaterialSkinBase.InitializeForm(this);
            if (LoggedInUser.UserId == 0)
            {
                FrmLogin loginForm = new FrmLogin();
                loginForm.Show();
            }

            FrmAttendance markAttendance = new FrmAttendance(1, "New course");
            markAttendance.Show();
        }
    }
}
