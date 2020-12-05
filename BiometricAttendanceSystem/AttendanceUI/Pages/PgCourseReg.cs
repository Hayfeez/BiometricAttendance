using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

using AttendanceLibrary.BaseClass;
using AttendanceLibrary.Repository;

using AttendanceUI.BaseClass;
using AttendanceUI.Forms;

namespace AttendanceUI.Pages
{
    public partial class PgCourseReg : UserControl
    {
        private bool _noItems = false;
        private DataTable _gridData;
        private readonly CourseRegRepo _repo;
        private string _deptId = "";
        private string _levelId = "";
        private string _semesterId = "";
        private string _courseId = "";

        private void LoadFilter()
        {
            DropdownControls.LoadSessions(ref comboSemester);
            DropdownControls.LoadLevels(ref comboLevel, true);
            DropdownControls.LoadDepartments(ref comboDept, true);
        }

        private void LoadData()
        {
            try
            {
                _levelId = comboLevel.SelectedValue.ToString() == Base.IdForSelectAll ? "" : comboLevel.SelectedValue.ToString();
                _deptId = comboDept.SelectedValue.ToString() == Base.IdForSelectAll ? "" : comboDept.SelectedValue.ToString();

                _semesterId = comboSemester.SelectedValue.ToString() == Base.IdForSelect ? "" : comboSemester.SelectedValue.ToString();
                _courseId = comboCourse.SelectedValue.ToString() == Base.IdForSelect ? "" : comboCourse.SelectedValue.ToString();

                if (_courseId == "" || _semesterId == "")
                    return;

                var data = _repo.GetStudentsByCourses(_courseId, _semesterId);
                if (data != null && data.Count > 0)
                {
                    dataGrid.DataSource = data;
                    dataGrid.Columns["Id"].Visible = false;

                    dataGrid.Columns["StudentName"].HeaderText = "Student Name";
                    dataGrid.Columns["StudentMatricNo"].HeaderText = "Matric No.";
                    dataGrid.Columns["CourseTitle"].HeaderText = "Course Title";
                    dataGrid.Columns["StudentLevel"].HeaderText = "Student Level";
                    dataGrid.Columns["DateRegistered"].HeaderText = "Date Registered";
                    dataGrid.Columns["RegisteredBy"].Visible = false;
                }
                else
                {
                    _noItems = true;
                    var dt = new DataTable();
                    dataGrid.Columns.Clear();
                    dt.Columns.Add("Message", typeof(string));
                    dt.Rows.Add("No record found");
                    dataGrid.DataSource = dt;
                }

                _gridData = data.ConvertToDataTable(); //save records in datatable for searching, export etc
                Base.AddLinksToGrid(ref dataGrid, new List<string>
                {
                    "Delete",
                }, _noItems);

            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCourses()
        {
            if (comboLevel.Items.Count > 0)
            {
                _levelId = comboLevel.SelectedValue.ToString() == Base.IdForSelectAll ? "" : comboLevel.SelectedValue.ToString();
                if (comboDept.Items.Count > 0)
                {
                    _deptId = comboDept.SelectedValue.ToString() == Base.IdForSelectAll ? "" : comboDept.SelectedValue.ToString();

                    DropdownControls.LoadCourses(ref comboCourse, _deptId, _levelId);
                }
            }
        }

        public PgCourseReg()
        {
            InitializeComponent();
            _repo = new CourseRegRepo();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (!LoggedInUser.IsAdmin)
            {
                Base.ShowError("Access Denied", "You do not have the required permission");
                return;
            }
            if (LoggedInUser.UserId == Helper.SuperAdminId)
            {
                Base.ShowError("Access Denied", "You cannot import course registration");
                return;
            }
            var courseRegForm = new FrmUploadCourseReg();
            courseRegForm.ShowDialog();
            LoadData();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!LoggedInUser.IsAdmin)
                {
                    Base.ShowError("Access Denied", "You do not have the required permission");
                    return;
                }

                //delete column
                if (e.ColumnIndex == 0)
                {
                    var result = Base.ShowDialog(MessageBoxButtons.YesNo, "Confirm Delete", "Are you sure you want to delete this record?");
                    if (result == DialogResult.Yes)
                    {
                        var id = dataGrid.Rows[e.RowIndex].Cells["id"].Value.ToString();
                        var response = _repo.DeleteCourseReg(id);

                        if (response == string.Empty)
                        {
                            Base.ShowInfo("Success", "Registered Course deleted successfully");
                            LoadData();
                        }

                        else
                            Base.ShowError("Failed", response);

                    }
                }

            }
            catch (Exception ex)
            {
                Base.ShowError("Error occured", ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var i = Base.SearchGrid(_gridData, txtSearch.Text.Trim());
            if (i != null)
            {
                dataGrid.DataSource = i;
                dataGrid.Refresh();
            }
            else
            {
                Base.ShowInfo("Not Found", "No record found");
            }
        }
        
        private void comboDept_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadCourses();
        }

        private void comboLevel_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadCourses();
        }

        private void PgCourseReg_Load(object sender, EventArgs e)
        {
            LoadFilter();
            LoadCourses();
            LoadData();
        }
    }
}
