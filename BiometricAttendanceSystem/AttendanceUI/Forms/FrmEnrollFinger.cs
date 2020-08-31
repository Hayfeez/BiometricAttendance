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
        private readonly BiometricsRepo _bioRepo;
        private readonly StudentRepo _studentRepo;
        private readonly StaffRepo _staffRepo;

        private readonly string _id;
        private readonly bool _isStudent;
        private readonly int _requiredFingers;
        private DigitalPersonaLibrary _digitalPersona;

        public FrmEnrollFinger(string id, bool isStudent = true)
        {
            InitializeComponent();
            _bioRepo = new BiometricsRepo();
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

            btnStartCapture.Enabled = false;
            btnStopCapture.Enabled = false;
            btnSave.Enabled = false;
            btnClear.Enabled = false;
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
                var enrolledFingers = _bioRepo.GetStudentFingers(id).Count;
                lblName.Text = student.Fullname;
                lblNo.Text = student.MatricNo;
                lblFingersRequired.Text = _requiredFingers.ToString();
                lblFingersEnrolled.Text = enrolledFingers.ToString();

                btnDeleteEnrolled.Enabled = enrolledFingers > 0;
            }
        }

        private void LoadStaffDetails(string id)
        {
            var staff = _staffRepo.GetStaff(id);
            if (staff == null)
            {
                Base.ShowError("Not found", "Staff cannot be found");
                this.Close();
            }
            else
            {
                var enrolledFingers = _bioRepo.GetStaffFingers(id).Count;
                lblName.Text = staff.Fullname;
                lblNo.Text = staff.StaffNo;
                lblFingersRequired.Text = _requiredFingers.ToString();
                lblFingersEnrolled.Text = enrolledFingers.ToString();

                btnDeleteEnrolled.Enabled = enrolledFingers > 0;

            }
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
            
            comboScanner.Items.Clear();
            comboScanner.Items.Add("Digital Persona Scanner");
            comboScanner.SelectedIndex = 0;
            comboScanner.Enabled = true;
        }

        private void comboScanner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboScanner.SelectedIndex == 0) //digital persona scanner
            {
                try
                {
                    _digitalPersona = new DigitalPersonaLibrary(txtLog, PicAnalyzed, lblFingerCount);
                    if (_digitalPersona.Capturer == null)
                    {
                        btnStartCapture.Enabled = false;
                        Base.ShowError("No Scanner", "Fingerprint scanner is not connected");
                    }
                    else
                    {
                        btnStartCapture.Enabled = true;
                    }
                }
                catch (Exception exception)
                {
                    Base.ShowError("Error", exception.Message);
                }
            }
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

                if (finger == _requiredFingers)
                {
                    Base.ShowInfo("", "Required number of fingers captured. Save the fingerprints");
                    btnStopCapture.PerformClick();
                }
            }
            else
            {
                btnSave.Enabled = false;
                btnClear.Enabled = false;
            }
        }

        private void FrmEnrollFinger_FormClosed(object sender, FormClosedEventArgs e)
        {
            btnStopCapture.PerformClick();
            _digitalPersona?.Dispose();
        }

        private void btnStartCapture_Click(object sender, EventArgs e)
        {
            _digitalPersona.StartCapture();
            btnStartCapture.Enabled = false;
            btnStopCapture.Enabled = true;
            lblFingerCount.Text = "0";
            _digitalPersona.FingerBitmaps = new List<Bitmap>();
        }

        private void btnStopCapture_Click(object sender, EventArgs e)
        {
            _digitalPersona.StopCapture();
            btnStartCapture.Enabled = true;
            btnStopCapture.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _digitalPersona.FingerBitmaps = new List<Bitmap>();
            lblFingerCount.Text = "0";
            txtLog.AppendText("Fingers cleared. Restart Capture");
            PicAnalyzed.Image = null;
            _digitalPersona.FingerBitmaps = new List<Bitmap>();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (!LoggedInUser.IsAdmin)
            {
                Base.ShowError("Access Denied", "You do not have the required permission");
                return;
            }

            if (_digitalPersona.FingerBitmaps.Count > 0)
            {
                if (_isStudent && _digitalPersona.FingerBitmaps.Count < _requiredFingers)
                {
                    Base.ShowError("Not enough Fingers", "You must enroll at the required number of fingerprints");
                    return;
                }

                string saveItem;
                if (_isStudent)
                {
                     var fingers = new List<StudentFinger>();
                     foreach (var finger in _digitalPersona.FingerBitmaps)
                     {
                         fingers.Add(new StudentFinger
                         {
                             Id = Guid.NewGuid().ToString(),
                             StudentId = _id,
                             FingerTemplate = Helper.ConvertToByteArray(finger)
                         });
                     }

                     saveItem = _bioRepo.SaveStudentFingers(fingers);
                }

                else
                {
                    var fingers = new List<StaffFinger>();
                    foreach (var finger in _digitalPersona.FingerBitmaps)
                    {
                        fingers.Add(new StaffFinger()
                        {
                            Id = Guid.NewGuid().ToString(),
                            StaffId = _id,
                            Fingerprint = Helper.ConvertToByteArray(finger)
                        });
                    }

                    saveItem = _bioRepo.SaveStaffFingers(fingers);
                }

                if (saveItem == string.Empty)
                {
                    Base.ShowSuccess("Success", "Fingerprints saved successfully");
                    this.Close();
                }
                else
                {
                    Base.ShowError("Failed", saveItem);
                    return;
                }
            }
            else
            {
                Base.ShowError("No Fingers", "You must enroll at least one fingerprint");
                return;
            }

        }

        private void btnDeleteEnrolled_Click(object sender, EventArgs e)
        {
            var result = Base.ShowDialog(MessageBoxButtons.YesNo, "Confirm Delete", "Are you sure you want to delete all fingerprints?");
            if (result == DialogResult.Yes)
            {
                string response;
                if (_isStudent)
                {
                    response = _bioRepo.DeleteStudentFingers(_id);
                }
                else
                {
                    response = _bioRepo.DeleteStaffFingers(_id);
                }

                if (response == string.Empty)
                {
                    Base.ShowInfo("Success", "All fingerprints deleted successfully");
                    btnDeleteEnrolled.Enabled = false;
                }

                else
                    Base.ShowError("Failed", response);
            }
        }

        private void iconExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
