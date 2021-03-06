﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

using AttendanceLibrary.BaseClass;
using AttendanceLibrary.Repository;

using AttendanceUI.BaseClass;
using AttendanceUI.Forms;

namespace AttendanceUI.Pages
{
    public partial class PgUser : UserControl
    {
        private bool _noItems = false;
        private DataTable _gridData;
        private readonly StaffRepo _repo;
        private string _deptId = "";

        private void LoadFilter()
        {
            DropdownControls.LoadDepartments(ref comboDept, true);
        }

        private void LoadData()
        {
            try
            {
                _deptId = comboDept.SelectedValue.ToString() == Base.IdForSelectAll ? "" : comboDept.SelectedValue.ToString();

                var data = _repo.GetDepartmentStaff(_deptId);
                if (data != null && data.Count > 0)
                {
                    dataGrid.DataSource = data;
                    dataGrid.Columns["Id"].Visible = false;
                    dataGrid.Columns["StaffNo"].HeaderText = "Staff Number";
                    dataGrid.Columns["PhoneNo"].HeaderText = "Phone Number";

                    dataGrid.Columns["IsAdmin"].HeaderText = "Admin User?";
                    dataGrid.Columns["IsSuperAdmin"].HeaderText = "System Admin?";
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
                    "Edit",
                    "Delete",
                    "Manage Fingerprints"
                }, _noItems);
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public PgUser()
        {
            InitializeComponent();
            _repo = new StaffRepo();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!LoggedInUser.IsSuperAdmin)
            {
                Base.ShowError("Access Denied", "You do not have the required permission");
                return;
            }
            var staffForm = new FrmStaff();
            staffForm.ShowDialog();
            LoadData();
        }

        private void PgUser_Load(object sender, EventArgs e)
        {
            LoadFilter();
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
                    if (!LoggedInUser.IsSuperAdmin)
                    {
                        Base.ShowError("Access Denied", "You do not have the required permission");
                        return;
                    }

                    var id = dataGrid.Rows[e.RowIndex].Cells["id"].Value.ToString();
                    var item = _repo.GetStaff(id);
                    if (item != null)
                    {
                        var updateForm = new FrmStaff(item.Id);
                        updateForm.ShowDialog();
                        LoadData();
                    }
                }

                //delete column
                if (e.ColumnIndex == 1)
                {
                    if (!LoggedInUser.IsSuperAdmin)
                    {
                        Base.ShowError("Access Denied", "You do not have the required permission");
                        return;
                    }

                    var result = Base.ShowDialog(MessageBoxButtons.YesNo, "Confirm Delete", "Are you sure you want to delete this record?");
                    if (result == DialogResult.Yes)
                    {
                        var id = dataGrid.Rows[e.RowIndex].Cells["id"].Value.ToString();
                        var response = _repo.DeleteStaff(id);

                        if (response == string.Empty)
                        {
                            Base.ShowInfo("Success", "Staff deleted successfully");
                            LoadData();
                        }

                        else
                            Base.ShowError("Failed", response);
                    }
                }

                //enroll fingerprint column 
                if (e.ColumnIndex == 2)
                {
                    var id = dataGrid.Rows[e.RowIndex].Cells["id"].Value.ToString();
                    if (LoggedInUser.IsSuperAdmin || LoggedInUser.UserId == id)
                    {
                        var enrollForm = new FrmEnrollFinger(id, false);
                        enrollForm.ShowDialog();
                    }

                    else
                    {
                        Base.ShowError("Denied", "You cannot manage fingerprints for another staff ");
                    }
                }

            }
            catch (Exception ex)
            {
                Base.ShowError("Error occured", ex.Message);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (!LoggedInUser.IsSuperAdmin)
            {
                Base.ShowError("Access Denied", "You do not have the required permission");
                return;
            }
            var staffForm = new FrmUploadStaff();
            staffForm.ShowDialog();
            LoadData();
        }

        private void btnPasswordReset_Click(object sender, EventArgs e)
        {
            if (LoggedInUser.UserId == Helper.SuperAdminId)
            {
                Base.ShowError("Access Denied", "You cannot reset user passwords");
                return;
            }

            if (!LoggedInUser.IsSuperAdmin)
            {
                Base.ShowError("Access Denied", "You do not have the required permission");
                return;
            }
            var staffForm = new FrmPasswordReset();
            staffForm.ShowDialog();
        }
    }
}
