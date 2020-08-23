using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AttendanceLibrary.BaseClass;
using AttendanceLibrary.Repository;

using AttendanceUI.BaseClass;

using Microsoft.Office.Interop.Excel;

namespace AttendanceUI.Forms
{
    public partial class FrmCourseReg : Form
    {
        private string _deptId = "";
        private string _levelId = "";
        private string _courseId = "";
        private string selectedFile = "";

        private void LoadFilter()
        {
            DropdownControls.LoadLevels(ref comboLevel, false);
            DropdownControls.LoadDepartments(ref comboDept, false);
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

                    DropdownControls.LoadCourses(ref comboCourse, _deptId, _levelId, false);
                }
            }
        }

        public FrmCourseReg()
        {
            InitializeComponent();
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

        private void btnUpload_Click(object sender, EventArgs e)
        {
            _courseId = comboCourse.SelectedValue.ToString() == Base.IdForSelect ? "" : comboCourse.SelectedValue.ToString();

            if (_courseId == "")
            {
                Base.ShowError("Required", "Please select a course");
                return;
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (lblFile.Text == "")
                return;
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                selectedFile = openFileDialog.FileName;
                if (string.IsNullOrEmpty(selectedFile) || selectedFile.Contains(".lnk"))
                {
                    Base.ShowInfo("","Please select a valid Excel File");
                }
                try
                {
                    lblFile.Text = selectedFile;
                    // string text = File.ReadAllText(file);
                    // var size = text.Length;
                }
                catch (IOException)
                {
                }
            }
            else
            {
                selectedFile = "";
                lblFile.Text = "";
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            // You have an executable bin folder and in it you have files folder.
            // string filePath = Path.Combine(Application.ExecutablePath, "files", myFilename)

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var execPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
                var filePath = Path.Combine(execPath, "Templates/StudentCourseRegister.xlsx");

                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                var workBook = excelApp.Workbooks.Open(filePath);
                var workSheet = (Worksheet) workBook.Worksheets[1];

                workBook.SaveAs(saveFileDialog.FileName);
                workBook.Close();
                Marshal.ReleaseComObject(workBook);

                Base.ShowSuccess("", "File saved successfully");
            }
        }
    }
}
