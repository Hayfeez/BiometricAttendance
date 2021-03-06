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
    public partial class FrmStudent : Form
    {
        private readonly StudentRepo _repo;

        private readonly string _id;

        private void LoadDropdowns()
        {
            DropdownControls.LoadDepartments(ref comboDept);
        }

        private string ValidateForm()
        {
            if ((comboDept.SelectedValue.ToString()) == Base.IdForSelect)
                return "Department is required";

            if (txtSurname.Text == "")
                return "Surname is required";

            if (txtFirstname.Text == "")
                return "Firstname is required";

            if (txtMatricNo.Text == "")
                return "Matric No is required";

            if (!Validations.IsValidEmail(txtEmail.Text))
                return "Valid Email is required";

            if (!Validations.IsDigitsOnly(txtPhoneNo.Text))
            {
                return "Valid phone number is required";
            }

            return "";
        }

        private void GetItem(string id)
        {
            var item = _repo.GetStudent(id);
            if (item == null)
            {
                Base.ShowError("Not Found", "Not Found");
                this.Close();
            }
            else
            {
                comboDept.SelectedValue = item.DepartmentId;
                txtSurname.Text = item.Lastname;
                txtFirstname.Text = item.Firstname;
                txtOthername.Text = item.Othername;
                txtMatricNo.Text = item.MatricNo;
                txtEmail.Text = item.Email;
                txtPhoneNo.Text = item.PhoneNo;
            }
        }

        private void AddOrUpdate(StudentDetail item)
        {
            var saveItem = _id == ""
                ? _repo.AddStudent(item)
                : _repo.UpdateStudent(item);

            if (saveItem == string.Empty)
            {
                Base.ShowSuccess("Success", "Student saved successfully");
                this.Close();
            }
            else
            {
                Base.ShowError("Failed", saveItem);
            }
        }

        public FrmStudent(string studentId = "")
        {
            InitializeComponent();
            _repo = new StudentRepo();
            _id = studentId;
            LoadDropdowns();
            if (studentId != "")
            {
                lblTitle.Text = "Update Student";
                comboDept.Enabled = false;
                GetItem(studentId);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!LoggedInUser.IsAdmin)
            {
                Base.ShowError("Access Denied", "You do not have the required permission");
                return;
            }

            var item = new StudentDetail()
            {
                Id = _id,
                DepartmentId = (comboDept.SelectedValue.ToString()),
                Lastname = txtSurname.Text.ToTitleCase(),
                Firstname = txtFirstname.Text.ToTitleCase(),
                Othername = txtOthername.Text.ToTitleCase(),
                Email = txtEmail.Text.ToLower(),
                MatricNo = txtMatricNo.Text.ToUpper(),
                PhoneNo = txtPhoneNo.Text,
            };

            var validate = ValidateForm();
            if (validate == string.Empty)
            {
                AddOrUpdate(item);
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSurname.Text ="";
            txtFirstname.Text = "";
            txtOthername.Text = "";
            txtMatricNo.Text = "";
            txtEmail.Text = "";
            txtPhoneNo.Text = "";
        }
    }
}
