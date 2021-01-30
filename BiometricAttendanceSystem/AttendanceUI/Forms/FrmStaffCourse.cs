using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

using AttendanceLibrary.BaseClass;
using AttendanceLibrary.Repository;

using AttendanceUI.BaseClass;

namespace AttendanceUI.Forms
{
    public partial class FrmStaffCourse : Form
    {
        private bool _noItems = false;
        private DataTable _gridData;
        private readonly StaffCourseRepo _repo;
        private string _deptId = "";
        private string _levelId = "";
        private string _courseId = "";

        private void LoadFilter()
        {
            DropdownControls.LoadLevels(ref comboLevel, true);
            DropdownControls.LoadDepartments(ref comboDept, true);
        }

        private void LoadData()
        {
            try
            {
                _levelId = comboLevel.SelectedValue.ToString() == Base.IdForSelectAll ? "" : comboLevel.SelectedValue.ToString();
                _deptId = comboDept.SelectedValue.ToString() == Base.IdForSelectAll ? "" : comboDept.SelectedValue.ToString();

                _courseId = comboCourse.SelectedValue.ToString() == Base.IdForSelectAll ? "" : comboCourse.SelectedValue.ToString();

                var data = _repo.GetStaffByCourse(_courseId);
                if (data != null && data.Count > 0)
                {
                    dataGrid.DataSource = data;
                    dataGrid.Columns["Id"].Visible = false;
                    dataGrid.Columns["CourseId"].Visible = false;
                    dataGrid.Columns["CourseTitle"].HeaderText = "Course Title";
                    dataGrid.Columns["DateAssigned"].HeaderText = "Date Assigned";
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

                    DropdownControls.LoadCourses(ref comboCourse, _deptId, _levelId, true);
                }
            }
        }

        public FrmStaffCourse()
        {
            InitializeComponent();
            _repo = new StaffCourseRepo();
        }


        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (!LoggedInUser.IsAdmin)
            {
                Base.ShowError("Access Denied", "You do not have the required permission");
                return;
            }

            if (LoggedInUser.UserId == Helper.SuperAdminId)
            {
                Base.ShowError("Access Denied", "You cannot assign staff course");
                return;
            }

            var courseStaffForm = new FrmAssignStaffCourse();
            courseStaffForm.ShowDialog();
            LoadData();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
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

        private void FrmStaffCourse_Load(object sender, EventArgs e)
        {
            LoadFilter();
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
                if (e.ColumnIndex == 0 || e.ColumnIndex == 5)  //TODO: why is this 5 at times and 0 at other times
                {
                    var result = Base.ShowDialog(MessageBoxButtons.YesNo, "Confirm Delete", "Are you sure you want to delete this record?");
                    if (result == DialogResult.Yes)
                    {
                        var id = dataGrid.Rows[e.RowIndex].Cells["id"].Value.ToString();
                        var response = _repo.DeleteStaffCourse(id);

                        if (response == string.Empty)
                            Base.ShowInfo("Success", "Staff Course deleted successfully");

                        else
                            Base.ShowError("Failed", response);

                        LoadData();
                    }
                }

            }
            catch (Exception ex)
            {
                Base.ShowError("Error occured", ex.Message);
            }
        }

        private void comboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCourses();
        }

        private void comboLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCourses();
        }

        private void iconExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
