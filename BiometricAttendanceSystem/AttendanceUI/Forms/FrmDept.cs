﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AttendanceLibrary.BaseClass;
using AttendanceLibrary.Model;
using AttendanceLibrary.Repository;

using AttendanceUI.BaseClass;

namespace AttendanceUI.Forms
{
    public partial class FrmDept : Form
    {
        private readonly DepartmentRepo _repo;

        private readonly string _id;
        
        private string ValidateForm()
        {
            if (txtDeptTitle.Text == "")
                return "Course Title is required";

            if (txtDeptCode.Text == "")
                return "Course Code is required";

            return "";
        }

        private void GetItem(string id)
        {
            var item = _repo.GetDepartment(id);
            if (item == null)
            {
                Base.ShowError("Not Found", "Not Found");
                this.Close();
            }
            else
            {
                txtDeptCode.Text = item.DepartmentCode;
                txtDeptTitle.Text = item.DepartmentName;
            }
        }

        private void AddOrUpdate(Department item)
        {
            var saveItem = _id == ""
                ? _repo.AddDepartment(item)
                : _repo.UpdateDepartment(item);

            if (saveItem != string.Empty)
            {
                Base.ShowSuccess("Success", saveItem);
            }
            else
            {
                saveItem = _id == "" ? "Department could not be added" : "Department could not be updated";
                Base.ShowError("Error occured", saveItem);
            }
        }
       
        public FrmDept(string deptId = "")
        {
            InitializeComponent();
            _repo = new DepartmentRepo();
            _id = deptId;

            if (deptId != "")
            {
                lblTitle.Text = "Update Department";
                GetItem(deptId);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var item = new Department
            {
                Id = _id,
                DepartmentCode = txtDeptCode.Text.ToUpper(),
                DepartmentName = txtDeptTitle.Text.ToTitleCase(),
            };

            var validate = ValidateForm();
            if (validate == string.Empty)
            {
                AddOrUpdate(item);
                this.Close();
            }
            else
            {
                Base.ShowInfo("Validation Failed", validate);
            }
        }

        private void iconExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
