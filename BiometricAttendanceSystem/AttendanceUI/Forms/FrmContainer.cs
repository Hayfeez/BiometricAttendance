using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AttendanceLibrary.BaseClass;
using AttendanceLibrary.Model;
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
            if (LoggedInUser.UserId == "")
            {
                this.Close();
                var loginForm = new FrmLogin(false);
                loginForm.ShowDialog();
            }

            btnOpenConnSettings.Visible = LoggedInUser.IsSuperAdmin;
            lblFooter.Text = Convert.ToChar(169) + @" Dolapo Oguntuga 2020";
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

            SessionSemester activeSession;
            if (GetRemoteServerConnectionState())
                activeSession = _sessionRepo.GetActiveSessionSemester();

            else
            {
                activeSession = _sessionRepo.GetActiveSessionSemesterLocal();
                EnableMenus(false);
            }

            if (activeSession != null)
            {
                LoggedInUser.ActiveSession = activeSession;
            }

            ShowPage(new PgHome());
            SetActiveMenu(btnHome);
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
            if (LoggedInUser.UserId == Helper.SuperAdminId)
            {
                Base.ShowError("Access Denied", "You cannot take attendance");
                return;
            }

            var attendance = new FrmAttendance();
            attendance.ShowDialog();
          //  attendance.BringToFront();
            SetActiveMenu(btnAttendance);
        }

        private async void btnReport_Click(object sender, EventArgs e)
        {
            if (GetRemoteServerConnectionState())
            {
                var syncRepo = new SyncRepo();
                var s = await syncRepo.UploadAttendanceToRemote();
                if (s == string.Empty)
                {
                    syncRepo.SaveSync(new AppSync
                    {
                        Id = Guid.NewGuid().ToString(),
                        StaffId = LoggedInUser.UserId,
                        SystemId = Helper.GetMacAddress(),
                        SyncDate = DateTime.Now
                    });

                    ShowPage(new PgReport());
                    SetActiveMenu(btnReport);
                }
                else
                {
                    Base.ShowError("Error", s);
                }
            }
            else
            {
                Base.ShowError("Connection Failed", "You can only view reports from the remote server. Check your connection settings");
            }
        }

        private void iconLogout_Click(object sender, EventArgs e)
        {
            var logout = Base.ShowDialog(MessageBoxButtons.YesNo, "Logout?", "Are you sure you want to logout of your session?");
            if (logout != DialogResult.Yes)
            {
                return;
            }

            this.Hide();
           // Base.ShowSuccess("Success", "You have been successfully logged out");
            var loginForm = new FrmLogin(false);
            loginForm.Show();
        }

        private void iconUser_Click(object sender, EventArgs e)
        {
            if (LoggedInUser.UserId == Helper.SuperAdminId)
            {
                Base.ShowError("Access Denied", "You cannot change system admin password from here. Go to Settings");
                return;
            }

            if (GetRemoteServerConnectionState())
            {
                var frm = new FrmChangePassword(LoggedInUser.Email);
                frm.ShowDialog();
            }
            else
            {
                Base.ShowError("Connection Failed", "You can only change passwords while connected to the remote server. Check your connection settings");
            }
        }

        private void iconSettings_Click(object sender, EventArgs e)
        {
            if (!LoggedInUser.IsSuperAdmin)
            {
                Base.ShowError("Access Denied", "You do not have the required permission");
                return;
            }

            var settingsForm = new FrmSettings();
            settingsForm.ShowDialog();
        }

        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int conn, int value);

        private bool GetInternetConnectionState()
        {
            var result = InternetGetConnectedState(out var con, 0);
            if (result)
            {
                toolStripStatusLabel1.Text = "Connected to Internet";
                toolStripStatusLabel1.ForeColor = Color.Green;
            }
            else
            {
                toolStripStatusLabel1.Text = "No Internet Connection";
                toolStripStatusLabel1.ForeColor = Color.Red;
            }

            statusStrip1.Refresh();
            return result;
        }

        private bool GetRemoteServerConnectionState()
        {
            var result = Helper.CheckRemoteServerConnection();
            if (result)
            {
                toolStripStatusLabel1.Text = "Remote server connection established";
                toolStripStatusLabel1.ForeColor = Color.Green;
            }
            else
            {
                toolStripStatusLabel1.Text = "Cannot connect to remote server. Check settings";
                toolStripStatusLabel1.ForeColor = Color.Red;
            }

            statusStrip1.Refresh();
            return result;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
           var result = GetRemoteServerConnectionState();
           EnableMenus(result);
        }

        private void EnableMenus(bool enable)
        {
            btnCourseMgt.Enabled = enable;
            btnCourseReg.Enabled = enable;
            btnDept.Enabled = enable;
            btnReport.Enabled = enable;
            btnSession.Enabled = enable;
            btnUserMgt.Enabled = enable;
            btnStudentMgt.Enabled = enable;
            iconSettings.Enabled = enable;
            btnSyncData.Enabled = enable;

           // btnAttendance.Enabled = true;
           // btnHome.Enabled = true;
        }

        private void btnOpenConnSettings_Click(object sender, EventArgs e)
        {
            var frm = new FrmConnection();
            frm.ShowDialog();
        }

        private async Task SyncData()
        {
            var result = Base.ShowDialog(MessageBoxButtons.YesNo, "Data Download", "Do you want to proceed with data download?");
            if (result == DialogResult.Yes)
            {
                if (GetRemoteServerConnectionState())
                {
                    var syncRepo = new SyncRepo();
                    var s = await syncRepo.SyncAllData();
                    if (s == string.Empty)
                    {
                        Base.ShowSuccess("Success", "Data synchronization successful");
                    }
                    else
                    {
                        Base.ShowError("Error", s);
                    }
                }
                else
                {
                    Base.ShowError("Connection Failed", "Cannot connect to the remote server. Check your connection settings");
                    var frm = new FrmConnection();
                    frm.ShowDialog();
                }
            }
        }

        private async void btnSyncData_Click(object sender, EventArgs e)
        {
            await SyncData();
        }

        private async void FrmContainer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Alt && e.KeyCode == Keys.D)
            {
                await SyncData();
            }
        }
    }
}
