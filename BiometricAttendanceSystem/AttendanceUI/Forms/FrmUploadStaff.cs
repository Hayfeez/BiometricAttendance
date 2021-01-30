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
    public partial class FrmUploadStaff : Form
    {
        private string _deptId = "";
        private string _selectedFile = "";
        private DataTable _data;
        private List<BulkStaff> _dataToUpload;
        private StaffRepo _repo;

        public FrmUploadStaff()
        {
            InitializeComponent();
            _repo = new StaffRepo();
        }

        private void FrmUploadStaff_Load(object sender, EventArgs e)
        {
            DropdownControls.LoadDepartments(ref comboDept);
        }

        private void iconExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                var template = new List<BulkStaff>();
                var dt = template.ConvertToDataTable();
                if (Base.SaveAsExcel(dt, "Staff Record"))
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

                if (_data.Columns.Count == 0 || _data.Columns[0].ColumnName != nameof(BulkStaff.StaffNumber))
                {
                    Base.ShowError("", "Header column could not be read. Please use the template");
                    lblFile.Text = "";
                    _selectedFile = "";
                    return;
                }

                _dataToUpload = (List<BulkStaff>)_data.ConvertToList<BulkStaff>();
               var validation = ValidateData(_dataToUpload);
               if (validation == string.Empty)
               {
                   dataGrid.DataSource = _data;
                   dataGrid.Columns["StaffNumber"].HeaderText = "Staff Number";
                   dataGrid.Columns["PhoneNo"].HeaderText = "Phone Number";
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

        private string ValidateData(List<BulkStaff> data)
        {
            if (data.Any(x => string.IsNullOrWhiteSpace(x.StaffNumber)))
                return "Staff Number cannot be empty";

            if (data.Any(x => string.IsNullOrWhiteSpace(x.Lastname)))
                return "Lastname cannot be empty";

            if (data.Any(x => string.IsNullOrWhiteSpace(x.Firstname)))
                return "Firstname cannot be empty";

            if (data.Any(x => string.IsNullOrWhiteSpace(x.Email)))
                return "Email address cannot be empty";

            if (data.Any(x => string.IsNullOrWhiteSpace(x.Title)))
                return "Title cannot be empty";

            var distinctStaffNos = data.Select(x => x.StaffNumber).ToHashSet();
            if (distinctStaffNos.Count < data.Count)
                return "Staff Number cannot contain duplicates";

            var distinctEmail = data.Select(x => x.Email).ToHashSet();
            if (distinctEmail.Count < data.Count)
                return "Email address cannot contain duplicates";

            return string.Empty;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (_deptId == "")
            {
                Base.ShowError("Required", "Please select a department");
                return;
            }

            if (_dataToUpload == null || _dataToUpload.Count < 1)
            {
                return;
            }

            var upload = _repo.AddBulkStaff(_dataToUpload, _deptId);
            if (upload == string.Empty)
            {
                Base.ShowSuccess("Success", "Record uploaded successfully.");
                this.Close();
            }
            else
            {
                Base.ShowError("Failed", upload);
            }
        }

    }
}
