using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AttendanceLibrary.Repository;

using AttendanceUI.BaseClass;
using AttendanceUI.Forms;

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
                }
                else
                {
                    _noItems = true;
                    var dt = new DataTable();
                    dataGrid.Columns.Clear();
                    dt.Columns.Add("Message", typeof(string));
                    dt.Rows.Add("No items found");
                    dataGrid.DataSource = dt;
                }

                _gridData = data.ConvertToDataTable(); //save records in datatable for searching, export etc
                Base.AddDeleteToGrid(ref dataGrid, _noItems); //add delete icon

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


        private void btnCourse_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
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
                //delete column
                if (e.ColumnIndex == 0)
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
    }
}
