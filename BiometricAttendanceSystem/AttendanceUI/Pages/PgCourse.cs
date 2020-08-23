using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AttendanceLibrary.Model.ViewModels;
using AttendanceLibrary.Repository;

using AttendanceUI.BaseClass;
using AttendanceUI.Forms;

namespace AttendanceUI.Pages
{
    public partial class PgCourse : UserControl
    {
        private bool _noItems = false;
        private DataTable _gridData;
        private readonly CourseRepo _repo;
        private string _deptId = "";
        private string _levelId = "";

        private void LoadFilter()
        {
            DropdownControls.LoadDepartments(ref comboDept, true);
            DropdownControls.LoadLevels(ref comboLevel, true);
        }

        private void LoadData()
        {
            try
            {
                _levelId = comboLevel.SelectedValue.ToString() == Base.IdForSelectAll ? "" : comboLevel.SelectedValue.ToString();
                _deptId = comboDept.SelectedValue.ToString() == Base.IdForSelectAll ? "" : comboDept.SelectedValue.ToString();

                var data = _repo.GetAllCourses(_deptId, _levelId);
                if (data != null && data.Count > 0)
                {
                    dataGrid.DataSource = data;
                    dataGrid.Columns["Id"].Visible = false;
                    dataGrid.Columns["CourseTitle"].HeaderText = "Course Title";
                    dataGrid.Columns["CourseCode"].HeaderText = "Course Code";
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
                Base.AddEditDeleteToGrid(ref dataGrid, _noItems); //add edit,delete icon

            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public PgCourse()
        {
            InitializeComponent();
            _repo = new CourseRepo();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var courseForm = new FrmCourse();
            courseForm.ShowDialog();
            LoadData();
        }

        private void btnStaffCourse_Click(object sender, EventArgs e)
        {
            var staffCourseForm = new FrmStaffCourse();
            staffCourseForm.ShowDialog();
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

        private void PgCourse_Load(object sender, EventArgs e)
        {
            LoadFilter();
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
              //  var d = (DataGridView)sender;
              //  var df = d.SelectedCells[0].Value.ToString();
              //  if(df == "Edit") (df == "Delete")

                //edit column 
                if (e.ColumnIndex == 0)
                {
                    var id = dataGrid.Rows[e.RowIndex].Cells["id"].Value.ToString();
                    var item = _repo.GetCourse(id);
                    if (item != null)
                    {
                        var updateForm = new FrmCourse(item.Id);
                        updateForm.ShowDialog();
                        LoadData();
                    }

                }

                //delete column
                if (e.ColumnIndex == 1)
                {
                    var result = Base.ShowDialog(MessageBoxButtons.YesNo, "Confirm Delete", "Are you sure you want to delete this record?");
                    if (result == DialogResult.Yes)
                    {
                        var id = dataGrid.Rows[e.RowIndex].Cells["id"].Value.ToString();
                        var response = _repo.DeleteCourse(id);

                        if (response == string.Empty)
                        {
                            Base.ShowInfo("Success", "Course deleted successfully");
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
    }
}
