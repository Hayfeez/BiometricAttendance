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

namespace AttendanceUI.Pages
{
    public partial class PgDept : UserControl
    {
        private bool _noItems = false;
        private DataTable _gridData;
        private readonly DepartmentRepo _repo;

        private void LoadData()
        {
            try
            {
               var data = _repo.GetAllDepartments();
                if (data != null && data.Count > 0)
                {
                    dataGrid.DataSource = data;
                    dataGrid.Columns["Id"].Visible = false;
                    dataGrid.Columns["IsDeleted"].Visible = false;
                    dataGrid.Columns["DepartmentName"].HeaderText = "Department Name";
                    dataGrid.Columns["DepartmentCode"].HeaderText = "Department Code";
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

        public PgDept()
        {
            InitializeComponent();
            _repo = new DepartmentRepo();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var deptForm = new FrmDept();
            deptForm.ShowDialog();
            LoadData();
        }

        private void PgDept_Load(object sender, EventArgs e)
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
                    var item = _repo.GetDepartment(id);
                    if (item != null)
                    {
                        var updateForm = new FrmDept(item.Id);
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
                        var response = _repo.DeleteDepartment(id);

                        if (response == string.Empty)
                            Base.ShowInfo("Success", "Department deleted successfully");

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
    }
}
