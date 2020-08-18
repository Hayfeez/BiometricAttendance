using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AttendanceLibrary.BaseClass;
using AttendanceLibrary.Repository;

using AttendanceUI.BaseClass;
using AttendanceUI.Pages;

namespace AttendanceUI.Forms
{
    public partial class FrmContainer : Form
    {
        private readonly int _panelWidth;
        private bool _isCollapsed;
        private readonly SessionSemesterRepo _sessionRepo;

        public FrmContainer()
        {
            InitializeComponent();
            _sessionRepo = new SessionSemesterRepo();
            _panelWidth = panelMenu.Width;
            _isCollapsed = false;
            if (LoggedInUser.UserId == 0)
            {
                this.Close();
                var loginForm = new FrmLogin();
                loginForm.ShowDialog();
            }

        }

        private void ShowPage(Control page)
        {
            page.Dock = DockStyle.Fill;
            panelControls.Controls.Clear();
            panelControls.Controls.Add(page);
        }

        private void SetActiveMenu(Control activeMenu)
        {
            panelActive.Top = activeMenu.Top;
            panelActive.Height = activeMenu.Height;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_isCollapsed)
            {
                panelMenu.Width += 25;
                if (panelMenu.Width >= _panelWidth)
                {
                    timer1.Stop();
                    _isCollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                panelMenu.Width -= 25;
                if (panelMenu.Width <= 75)
                {
                    timer1.Stop();
                    _isCollapsed = true;
                    this.Refresh();
                }
            }
        }

        private void iconExit_Click(object sender, EventArgs e)
        {
            var exit = Base.ShowDialog(MessageBoxButtons.YesNo, "Close Application?", "Are you sure you want to exit the Application?");
            if (exit != DialogResult.Yes)
            {
                return;
            }

            Application.Exit();
        }

        private void iconMinimize_Click(object sender, EventArgs e)
        {
           this.WindowState = FormWindowState.Minimized;
        }

        private void iconMenu_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
             this.WindowState = FormWindowState.Maximized;
            //Left = Top = 0;
            //Width = Screen.PrimaryScreen.WorkingArea.Width;
            //Height = Screen.PrimaryScreen.WorkingArea.Height;

            lblUsername.Text = $@"Welcome, {LoggedInUser.Fullname}";
            lblRole.Text = LoggedInUser.IsSuperAdmin
                ? "System Admin"
                : LoggedInUser.IsAdmin
                    ? "Admin User"
                    : "User";

            var activeSession = _sessionRepo.GetActiveSessionSemester();
            if (activeSession != null)
            {
                LoggedInUser.ActiveSession = activeSession;
            }

            ShowPage(new PgHome());
            SetActiveMenu(btnHome);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var logout = Base.ShowDialog(MessageBoxButtons.YesNo, "Logout?", "Are you sure you want to logout of your session?");
            if (logout != DialogResult.Yes)
            {
                return;
            }

            this.Hide();
            Base.ShowSuccess("Success", "You have been successfully logged out");
            var loginForm = new FrmLogin();
            loginForm.Show();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            ShowPage(new PgHome());
            SetActiveMenu(btnHome);
        }

        private void btnSession_Click(object sender, EventArgs e)
        {
            ShowPage(new PgSession());
            SetActiveMenu(btnSession);
        }

        private void btnDept_Click(object sender, EventArgs e)
        {
            ShowPage(new PgDept());
            SetActiveMenu(btnDept);
        }

        private void btnCourseMgt_Click(object sender, EventArgs e)
        {
            ShowPage(new PgCourse());
            SetActiveMenu(btnCourseMgt);
        }

        private void btnStudentMgt_Click(object sender, EventArgs e)
        {
            ShowPage(new PgStudent());
            SetActiveMenu(btnStudentMgt);
        }

        private void btnUserMgt_Click(object sender, EventArgs e)
        {
            ShowPage(new PgUser());
            SetActiveMenu(btnUserMgt);
        }

        private void btnCourseReg_Click(object sender, EventArgs e)
        {
            ShowPage(new PgCourseReg());
            SetActiveMenu(btnCourseReg);
        }

        private void btnAttendance_Click(object sender, EventArgs e)
        {
            ShowPage(new PgAttendance());
            SetActiveMenu(btnAttendance);
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            ShowPage(new PgReport());
            SetActiveMenu(btnReport);
        }
    }
}
