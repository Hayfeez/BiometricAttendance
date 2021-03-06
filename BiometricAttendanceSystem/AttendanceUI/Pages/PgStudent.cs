﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AttendanceLibrary.BaseClass;
using AttendanceLibrary.Repository;

using AttendanceUI.BaseClass;
using AttendanceUI.Forms;

namespace AttendanceUI.Pages
{
    public partial class PgStudent : UserControl
    {
        private bool _noItems = false;
        private DataTable _gridData;
        private readonly StudentRepo _repo;
        private string _deptId = "";
        private string _levelId = "";

        private void LoadFilter()
        {
            DropdownControls.LoadDepartments(ref comboDept, true);
        }

        private void LoadData()
        {
            try
            {
                _deptId = comboDept.SelectedValue.ToString() == Base.IdForSelectAll ? "" : comboDept.SelectedValue.ToString();

                var data = _repo.GetDepartmentStudents(_deptId, _levelId);
                if (data != null && data.Count > 0)
                {
                    dataGrid.DataSource = data;
                    dataGrid.Columns["Id"].Visible = false;
                    dataGrid.Columns["MatricNo"].HeaderText = "Matric Number";
                    dataGrid.Columns["PhoneNo"].HeaderText = "Phone Number";
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

        public PgStudent()
        {
            InitializeComponent();
            _repo = new StudentRepo();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!LoggedInUser.IsAdmin)
            {
                Base.ShowError("Access Denied", "You do not have the required permission");
                return;
            }
            var studentForm = new FrmStudent();
            studentForm.ShowDialog();
            LoadData();
        }

        private void PgStudent_Load(object sender, EventArgs e)
        {
            LoadFilter();
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

                if (!LoggedInUser.IsAdmin)
                {
                    Base.ShowError("Access Denied", "You do not have the required permission");
                    return;
                }

                //edit column 
                if (e.ColumnIndex == 0)
                {
                    var id = dataGrid.Rows[e.RowIndex].Cells["id"].Value.ToString();
                    var item = _repo.GetStudent(id);
                    if (item != null)
                    {
                        var updateForm = new FrmStudent(item.Id);
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
                        var response = _repo.DeleteStudent(id);

                        if (response == string.Empty)
                        {
                            Base.ShowInfo("Success", "Student deleted successfully");
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
                    var enrollForm = new FrmEnrollFinger(id);
                    enrollForm.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                Base.ShowError("Error occured", ex.Message);
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (!LoggedInUser.IsAdmin)
            {
                Base.ShowError("Access Denied", "You do not have the required permission");
                return;
            }
            var studentForm = new FrmUploadStudent();
            studentForm.ShowDialog();
            LoadData();
        }

        private void btnUploadGrad_Click(object sender, EventArgs e)
        {
            if (!LoggedInUser.IsAdmin)
            {
                Base.ShowError("Access Denied", "You do not have the required permission");
                return;
            }
            var studentForm = new FrmUploadGraduateStudent();
            studentForm.ShowDialog();
            LoadData();
        }
    }
}
