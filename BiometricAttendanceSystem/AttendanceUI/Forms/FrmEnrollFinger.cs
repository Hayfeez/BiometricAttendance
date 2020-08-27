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
using AttendanceLibrary.Model;
using AttendanceLibrary.Repository;

using AttendanceUI.BaseClass;

namespace AttendanceUI.Forms
{
    public partial class FrmEnrollFinger : Form
    {
        private readonly BiometricsRepo _bioRrepo;
        private readonly StudentRepo _studentRepo;
        private readonly StaffRepo _staffRepo;

        private readonly string _id;
        private readonly bool _isStudent;
        private int _fingerCount;
        private readonly int _requiredFingers;
        private Bitmap[] _fingers;
        private Bitmap[] _confirmationFingers;

        public FrmEnrollFinger(string id, bool isStudent = true)
        {
            InitializeComponent();
            _bioRrepo = new BiometricsRepo();
            _id = id;
            _isStudent = isStudent;
            var settingsRepo = new SettingsRepo();

            if (isStudent)
            {
                _studentRepo = new StudentRepo();
            }
            else
            {
                _staffRepo = new StaffRepo();
                labelNo.Text = "Staff Number";
                labelRequired.Visible = false;
                lblFingersRequired.Visible = false;
            }

            _requiredFingers = settingsRepo.GetSetting().NoOfFinger;
        }

        private void LoadStudentDetails(string id)
        {
            var student = _studentRepo.GetStudent(id);
            if (student == null)
            {
                Base.ShowError("Not found", "Student cannot be found");
                this.Close();
            }
            else
            {
                var enrolledFingers = _bioRrepo.GetStudentFingers(id).Count;
                lblName.Text = student.Fullname;
                lblNo.Text = student.MatricNo;
                lblFingersRequired.Text = _requiredFingers.ToString();
                lblFingersEnrolled.Text = enrolledFingers.ToString();
            }
        }

        private void LoadStaffDetails(string id)
        {
            var staff = _staffRepo.GetStaff(id);
            if (staff == null)
            {
                Base.ShowError("Not found", "Student cannot be found");
                this.Close();
            }
            else
            {
                var enrolledFingers = _bioRrepo.GetStaffFingers(id).Count;
                lblName.Text = staff.Fullname;
                lblNo.Text = staff.StaffNo;
                lblFingersRequired.Text = _requiredFingers.ToString();
                lblFingersEnrolled.Text = enrolledFingers.ToString();
            }
        }

        private void iconExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEnrollFinger_Load(object sender, EventArgs e)
        {
            if (_isStudent)
            {
                LoadStudentDetails(_id);
            }
            else
            {
                LoadStaffDetails(_id);
            }
        }

        private void comboScanner_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnStartCapture_Click(object sender, EventArgs e)
        {

        }

        private void btnStopCapture_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblFingerCount.Text = "0";
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!LoggedInUser.IsAdmin)
            {
                Base.ShowError("Access Denied", "You do not have the required permission");
                return;
            }

        }

        private void btnDeleteEnrolled_Click(object sender, EventArgs e)
        {
            
        }

        private void lblFingerCount_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(lblFingerCount.Text, out var finger) && finger > 0)
            {
                btnClear.Enabled = true;
                if (!_isStudent)
                {
                    btnSave.Enabled = true;
                }
                if (_isStudent && lblFingerCount.Text == lblFingersRequired.Text)
                {
                    btnSave.Enabled = true;
                }
            }
            else
            {
                btnSave.Enabled = false;
                btnClear.Enabled = false;
            }
        }
    }
}
