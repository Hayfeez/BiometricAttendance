using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
//using System.Reflection;
//using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AttendanceLibrary.BaseClass;
using AttendanceLibrary.Model.ViewModels;
using AttendanceLibrary.Repository;

using AttendanceUI.BaseClass;


namespace AttendanceUI.Forms
{
    public partial class FrmUploadGraduateStudent : Form
    {
        private string _sessionId = "";
        private string _selectedFile = "";
        private DataTable _data;
        private List<BulkGraduateStudent> _dataToUpload;
        private StudentRepo _repo;

        public FrmUploadGraduateStudent()
        {
            InitializeComponent();
            _repo = new StudentRepo();
        }

        private void iconExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmUploadStudent_Load(object sender, EventArgs e)
        {
            DropdownControls.LoadSessions(ref comboSession, noSemesters: true);
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                var template = new List<BulkGraduateStudent>();
                var dt = template.ConvertToDataTable();
               // dt.Columns["MatricNumber"].DataType = typeof(string);
                if (Base.SaveAsExcel(dt, "Graduated Student Record"))
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
                    return;
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

                if (_data.Columns.Count == 0 || _data.Columns[0].ColumnName != nameof(BulkGraduateStudent.MatricNumber))
                {
                    Base.ShowError("", "Header column could not be read. Please use the template");
                    lblFile.Text = "";
                    _selectedFile = "";
                    return;
                }

                _dataToUpload = (List<BulkGraduateStudent>)_data.ConvertToList<BulkGraduateStudent>();
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

        private string ValidateData(List<BulkGraduateStudent> data)
        {
            if (data.Any(x => string.IsNullOrWhiteSpace(x.MatricNumber)))
                return "Matric Number cannot be empty";

            if (data.Any(x => string.IsNullOrWhiteSpace(x.Lastname)))
                return "Lastname cannot be empty";

            if (data.Any(x => string.IsNullOrWhiteSpace(x.Firstname)))
                return "Firstname cannot be empty";

            var distinctMatricNos = data.Select(x => x.MatricNumber).ToHashSet();
            if (distinctMatricNos.Count < data.Count)
                return "Matric Number cannot contain duplicates";

            return string.Empty;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (_sessionId == "")
            {
                Base.ShowError("Required", "Please select a department");
                return;
            }

            if (_dataToUpload == null || _dataToUpload.Count < 1)
            {
                return;
            }

            var upload = _repo.GraduateStudent(_dataToUpload, _sessionId);
            if (upload == string.Empty)
            {
                Base.ShowSuccess("Success", "Student has been marked as graduated successfully.");
                this.Close();
            }
            else
            {
                Base.ShowError("Failed", upload);
            }
        }

      
    }
}
