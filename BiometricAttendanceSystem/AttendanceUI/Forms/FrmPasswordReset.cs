using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

using AttendanceLibrary.BaseClass;
using AttendanceLibrary.Repository;

using AttendanceUI.BaseClass;

namespace AttendanceUI.Forms
{
    public partial class FrmPasswordReset : Form
    {
        private bool _noItems = false;
        private DataTable _gridData;
        private readonly AuthRepo _repo;


        private void LoadData()
        {
            try
            {
                var data = _repo.GetPasswordResetRequests();
                if (data != null && data.Count > 0)
                {
                    dataGrid.DataSource = data;
                    dataGrid.Columns["Id"].Visible = false;
                    dataGrid.Columns["UserId"].Visible = false;
                    dataGrid.Columns["RequestingSystemId"].HeaderText = "System ID";
                    dataGrid.Columns["DateRequested"].HeaderText = "Date Requested";
                    dataGrid.Columns["ResetBy"].HeaderText = "Reset By";
                    dataGrid.Columns["DateReset"].HeaderText = "Date Reset";
                    dataGrid.Columns["IsReset"].HeaderText = "Is Reset";
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
                    "Reset Password",
                }, _noItems);

            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public FrmPasswordReset()
        {
            InitializeComponent();
            _repo = new AuthRepo();
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
            LoadData();
        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var isReset = bool.Parse(dataGrid.Rows[e.RowIndex].Cells["IsReset"].Value.ToString());
                if (isReset)
                {
                    return;
                }

                if (!LoggedInUser.IsSuperAdmin)
                {
                    Base.ShowError("Access Denied", "You do not have the required permission");
                    return;
                }

                //reset password
                if (e.ColumnIndex == 8)  //TODO: why 8
                {
                    var result = Base.ShowDialog(MessageBoxButtons.YesNo, "Confirm Delete", "Are you sure you want to reset this user's password?");
                    if (result == DialogResult.Yes)
                    {
                        var id = dataGrid.Rows[e.RowIndex].Cells["UserId"].Value.ToString();
                        var response = _repo.AdminResetPassword(id, LoggedInUser.UserId);

                        if (response == string.Empty)
                            Base.ShowInfo("Success", "User password reset to the default password successfully");

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

        private void iconExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
