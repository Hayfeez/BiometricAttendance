using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AttendanceLibrary.BaseClass;
using AttendanceLibrary.Repository;

namespace AttendanceUI.Pages
{
    public partial class PgHome : UserControl
    {
        private readonly DashboardRepo _repo;

        public PgHome()
        {
            InitializeComponent();
            _repo = new DashboardRepo();
        }

        private void PgHome_Load(object sender, EventArgs e)
        {
            var studentCount = _repo.GetStudentCount();
            var staffCount = _repo.GetStaffCount();

            cardDate.Text2 = DateTime.Now.ToShortDateString();
            cardDate.Text3 = DateTime.Now.DayOfWeek.ToString();
            cardSession.Text2 = LoggedInUser.ActiveSession == null ? "None Active" : LoggedInUser.ActiveSession.Session;
            cardSession.Text3 = LoggedInUser.ActiveSession == null ? "" : LoggedInUser.ActiveSession.Semester;
            cardStudent.Text2 = studentCount.ToString();
            cardUsers.Text2 = staffCount.ToString();

        }
    }
}
