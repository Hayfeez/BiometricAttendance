using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
//using System.Reflection;
//using System.Runtime.InteropServices;
using System.Windows.Forms;

using AttendanceLibrary.BaseClass;
using AttendanceLibrary.Model.ViewModels;
using AttendanceLibrary.Repository;

using AttendanceUI.BaseClass;


namespace AttendanceUI.Forms
{
    public partial class FrmUploadCourseReg : Form
    {
        private string _deptId = "";
        private string _levelId = "";
        private string _courseId = "";
        private string _selectedFile = "";
        private DataTable _data;
        private List<BulkStudentCourseReg> _dataToUpload;
        private readonly CourseRegRepo _repo;

        private void LoadFilter()
        {
            DropdownControls.LoadLevels(ref comboLevel);
            DropdownControls.LoadDepartments(ref comboDept);
        }

        private void LoadCourses()
        {
            if (comboLevel.Items.Count > 0)
            {
                _levelId = comboLevel.SelectedValue.ToString() == Base.IdForSelect ? "" : comboLevel.SelectedValue.ToString();
                if (comboDept.Items.Count > 0)
                {
                    _deptId = comboDept.SelectedValue.ToString() == Base.IdForSelect ? "" : comboDept.SelectedValue.ToString();

                    if (_deptId == "" || _levelId == "")
                        return;

                    DropdownControls.LoadCourses(ref comboCourse, _deptId, _levelId);
                }
            }
        }

        public FrmUploadCourseReg()
        {
            InitializeComponent();
            _repo = new CourseRegRepo();
        }

        private void iconExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCourses();
        }

        private void comboLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCourses();
        }

        private void FrmCourseReg_Load(object sender, EventArgs e)
        {
            if (LoggedInUser.ActiveSession == null)
            {
                Base.ShowError("No Active Semester", "There is no active semester. You cannot upload Students' Registered Courses");
                this.Close();
                return;
            }

            LoadFilter();
            lblCurrentSemester.Text = "Active Semester " + LoggedInUser.ActiveSession.Fullname;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                var template = new List<BulkStudentCourseReg>();
                var dt = template.ConvertToDataTable();
               // dt.Columns["MatricNumber"].DataType = typeof(string);
                if (Base.SaveAsExcel(dt, "Student Course Register"))
                {
                    Base.ShowSuccess("", "File downloaded successfully");
                }

            }
            catch (Exception ex)
            {
                Base.ShowError("Error", ex.Message);
            }

        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                _selectedFile = openFileDialog.FileName;
                if (string.IsNullOrEmpty(_selectedFile) || _selectedFile.Contains(".lnk"))
                {
                    Base.ShowInfo("", "Please select a valid Excel File");
                }

                lblFile.Text = _selectedFile;
                btnPreview.Enabled = true;
            }
            else
            {
                _selectedFile = "";
                lblFile.Text = "";
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblFile.Text == "" || _selectedFile == "")
                    return;

                _data = Base.ReadExcelFile(_selectedFile);
                if (_data == null || _data.Rows.Count < 1)
                {
                    Base.ShowError("", "You cannot upload an empty file");
                    lblFile.Text = "";
                    _selectedFile = "";
                    return;
                }

                if (_data.Columns.Count == 0 || _data.Columns[0].ColumnName != nameof(BulkStudentCourseReg.MatricNumber))
                {
                    Base.ShowError("", "Header column could not be read. Please use the template");
                    lblFile.Text = "";
                    _selectedFile = "";
                    return;
                }

                //_dataToUpload = (from DataRow row in _data.Rows
                //            select new BulkStudentCourseReg
                //            {
                //                MatricNumber = row["MatricNumber"].ToString(),
                //                Firstname = row["Firstname"].ToString(),
                //                Lastname = row["Lastname"].ToString(),
                //                Othername = row["Othername"].ToString(),
                //                Level = row["Level"].ToString(),
                //            }).ToList();

               _dataToUpload = (List<BulkStudentCourseReg>)_data.ConvertToList<BulkStudentCourseReg>();
               var validation = ValidateData(_dataToUpload);
               if (validation == string.Empty)
               {
                   dataGrid.DataSource = _data;
                   dataGrid.Columns["MatricNumber"].HeaderText = "Matric Number";
                   btnUpload.Visible = true;
                   btnPreview.Enabled = false;
                }
               else
               {
                   Base.ShowError("", validation);
               }
            }

            catch (Exception ex)
            {
                Base.ShowError("Error", ex.Message);
            }
        }

        private string ValidateData(List<BulkStudentCourseReg> data)
        {
            if (data.Any(x => string.IsNullOrWhiteSpace(x.MatricNumber)))
                return "Matric Number cannot be empty";

            if (data.Any(x => string.IsNullOrWhiteSpace(x.Lastname)))
                return "Lastname cannot be empty";

            if (data.Any(x => string.IsNullOrWhiteSpace(x.Firstname)))
                return "Firstname cannot be empty";

            if (data.Any(x => string.IsNullOrWhiteSpace(x.Level)))
                return "Level cannot be empty";

            return string.Empty;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (LoggedInUser.UserId == Helper.SuperAdminId)
            {
                Base.ShowError("Access Denied", "You cannot upload course registration");
                return;
            }

            if (_deptId == "")
            {
                Base.ShowError("Required", "Please select a department");
                return;
            }
            if (_levelId == "")
            {
                Base.ShowError("Required", "Please select a level for the course");
                return;
            }

            _courseId = comboCourse.SelectedValue.ToString() == Base.IdForSelect ? "" : comboCourse.SelectedValue.ToString();

            if (_courseId == "")
            {
                Base.ShowError("Required", "Please select a course");
                return;
            }

            if (_dataToUpload == null || _dataToUpload.Count < 1)
            {
                return;
            }

            var upload = _repo.RegisterCourseStudents(_dataToUpload, _courseId);
            if (upload == string.Empty)
            {
                Base.ShowSuccess("Success", "Record uploaded successfully");
                this.Close();
            }
            else
            {
                Base.ShowError("Failed", upload);
            }

        }
    }
}
