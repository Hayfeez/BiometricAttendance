using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

using AttendanceLibrary.BaseClass;
using AttendanceLibrary.Model;
using AttendanceLibrary.Repository;

using AttendanceUI.BaseClass;

namespace AttendanceUI.Forms
{
    public partial class FrmAttendance : Form
    {
        private static AttendanceRepo _repo;
        private string _levelId = "";
        private static string _courseId = "";

        private DigitalPersonaLibrary _digitalPersona;
        private List<StudentFinger> _studentFingers;


        private void LoadTodayAttendanceForCourse()
        {
            try
            {
                var data = _repo.GetTodayAttendanceByCourse(_courseId);
                if (data != null && data.Count > 0)
                {
                    dataGrid.DataSource = data;
                    dataGrid.Columns["Id"].Visible = false;
                    dataGrid.Columns["SessionSemester"].Visible = false;
                    dataGrid.Columns["Course"].Visible = false;
                    dataGrid.Columns["DepartmentName"].Visible = false;
                    dataGrid.Columns["MarkedBy"].Visible = false;
                    dataGrid.Columns["StudentLevel"].Visible = false;
                    dataGrid.Columns["DateMarked"].Visible = false;

                    dataGrid.Columns["StudentMatricNo"].HeaderText = "Matric Number";
                    dataGrid.Columns["StudentName"].HeaderText = "Student Name";
                    dataGrid.Columns["TimeIn"].HeaderText = "Time In";
                }
                else
                {
                    var dt = new DataTable();
                    dataGrid.Columns.Clear();
                    dt.Columns.Add("Message", typeof(string));
                    dt.Rows.Add("No record found");
                    dataGrid.DataSource = dt;
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Error occured loading attendance", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public FrmAttendance()
        {
            InitializeComponent();
            _repo = new AttendanceRepo();
        }

        private void comboLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            _levelId = comboLevel.SelectedValue.ToString() == Base.IdForSelect ? "" : comboLevel.SelectedValue.ToString();
            DropdownControls.LoadStaffCoursesLocal(ref comboCourse, LoggedInUser.UserId, _levelId);
        }

        private void comboCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnStopAttendance.Visible = false;
            lblCourse.Visible = false;
            lblRegistered.Visible = false;
            btnTakeAttendance.Enabled = false;

            if (comboCourse.SelectedIndex > 0)
            {
                _courseId = comboCourse.SelectedValue.ToString();
               _studentFingers = _repo.GetFingersOfCourseStudents(_courseId);
                if (_studentFingers == null)
                {
                    Base.ShowError("", "There is no active semester. You cannot take attendance");
                    return;
                }
                if (_studentFingers.Count == 0)
                {
                    Base.ShowError("", "There is no registered students with fingerprints enrolled. You cannot take attendance");
                    return;
                }

                btnTakeAttendance.Enabled = true;
                lblCourse.Text = comboCourse.SelectedText;
                lblCourse.Visible = true;
                lblRegistered.Text = "Registered Students (with Fingerprints enrolled): " + _studentFingers.Select(x=>x.StudentId).Distinct().Count().ToString();
                lblRegistered.Visible = true;

                comboScanner.Items.Clear();
                comboScanner.Items.Add("Digital Persona Scanner");
                comboScanner.SelectedIndex = 0;
                comboScanner.Enabled = true;

                LoadTodayAttendanceForCourse();
            }
            
        }

        private void FrmAttendance_Load(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblDate.Visible = true;
            DropdownControls.LoadLevelsLocal(ref comboLevel);
        }

        private void btnTakeAttendance_Click(object sender, EventArgs e)
        {
            btnStopAttendance.Visible = true;
            _digitalPersona.StartCapture();
            btnTakeAttendance.Enabled = false;
            _digitalPersona.FingerBitmap = null;
        }

        private void comboScanner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboScanner.SelectedIndex == 0) //digital persona scanner
            {
                try
                {
                    _digitalPersona = new DigitalPersonaLibrary(txtLog, PicAnalyzed, _studentFingers);
                    if (_digitalPersona.Capturer == null)
                    {
                        Base.ShowError("No Scanner", "Fingerprint scanner is not connected");
                    }
                    else
                    {
                    }
                }
                catch (Exception exception)
                {
                    Base.ShowError("Error", exception.Message);
                }
            }
        }


        private void btnStopAttendance_Click(object sender, EventArgs e)
        {
            _digitalPersona.StopCapture();
            btnTakeAttendance.Enabled = true;
            btnStopAttendance.Visible = false;
        }

        private void FrmAttendance_FormClosed(object sender, FormClosedEventArgs e)
        {
            btnStopAttendance.PerformClick();
            _digitalPersona?.Dispose();
        }

        private void iconExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static void SaveAttendance(VerifiedData data)
        {
            try
            {

                var save = _repo.SaveAttendance(_courseId, data.Id, LoggedInUser.ActiveSession.Id, LoggedInUser.UserId);
                if (save == string.Empty)
                {
                    Base.ShowSuccess("", "Attendance saved");
                  //  lblMsg.Invoke(new Action(Load));
                }
                else
                {
                    Base.ShowInfo("", save);
                }
            }
            catch (Exception e)
            {
                Base.ShowError("Error", e.Message);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadTodayAttendanceForCourse();
        }
    }
}
