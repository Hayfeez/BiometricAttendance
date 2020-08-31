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
        private readonly CourseRegRepo _courseRegRepo;
        private readonly AttendanceRepo _attendanceRepo;
        public PgHome()
        {
            InitializeComponent();
            _repo = new DashboardRepo();
            _courseRegRepo = new CourseRegRepo();
            _attendanceRepo = new AttendanceRepo();
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

            LoadCourseRegData();
            LoadCourseAttendanceData();
        }

        private void LoadCourseRegData()
        {
            try
            {
                var data = _courseRegRepo.GetCourseRegCount(LoggedInUser.UserId, LoggedInUser.ActiveSession.Id);
                if (data != null && data.Count > 0)
                {
                    dataGridCourses.DataSource = data;
                    dataGridCourses.Columns["CourseTitle"].HeaderText = "Course";
                }
                else
                {
                    var dt = new DataTable();
                    dataGridCourses.Columns.Clear();
                    dt.Columns.Add("Message", typeof(string));
                    dt.Rows.Add("No record found");
                    dataGridCourses.DataSource = dt;
                }
            }
            catch (Exception e)
            {
            }
        }
        
        private void LoadCourseAttendanceData()
        {
            try
            {
                var data = _attendanceRepo.GetCourseAttendanceCount(LoggedInUser.UserId, LoggedInUser.ActiveSession.Id);
                if (data != null && data.Count > 0)
                {
                    dataGridAttendance.DataSource = data;
                    dataGridAttendance.Columns["CourseTitle"].HeaderText = "Course";
                }
                else
                {
                    var dt = new DataTable();
                    dataGridAttendance.Columns.Clear();
                    dt.Columns.Add("Message", typeof(string));
                    dt.Rows.Add("No record found");
                    dataGridAttendance.DataSource = dt;
                }
            }
            catch (Exception e)
            {
            }
        }
    }
}
