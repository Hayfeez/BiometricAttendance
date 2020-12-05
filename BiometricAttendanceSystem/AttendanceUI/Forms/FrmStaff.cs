using System;
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
    public partial class FrmStaff : Form
    {
        private readonly StaffRepo _repo;

        private readonly string _id;

        private void LoadDropdowns()
        {
            DropdownControls.LoadDepartments(ref comboDept);
            DropdownControls.LoadTitles(ref comboTitle);
        }

        private string ValidateForm()
        {
            if ((comboDept.SelectedValue.ToString()) == Base.IdForSelect)
                return "Department is required";

            if ((comboTitle.SelectedValue.ToString()) == Base.IdForSelect)
                return "Title is required";

            if (txtSurname.Text == "")
                return "Surname is required";

            if (txtFirstname.Text == "")
                return "Firstname is required";

            if (txtStaffNo.Text == "")
                return "Staff No is required";

            if (!Validations.IsValidEmail(txtEmail.Text))
                return "Valid Email is required";

            if (txtPhoneNo.Text != "" && !Validations.IsDigitsOnly(txtPhoneNo.Text))
            {
                return "Valid phone number is required";
            }

            return "";
        }

        private void GetItem(string id)
        {
            var item = _repo.GetStaff(id);
            if (item == null)
            {
                Base.ShowError("Not Found", "Not Found");
                this.Close();
            }
            else
            {
                comboDept.SelectedValue = item.DepartmentId;
                comboTitle.SelectedValue = item.TitleId;
                txtSurname.Text = item.Lastname;
                txtFirstname.Text = item.Firstname;
                txtOthername.Text = item.Othername;
                txtStaffNo.Text = item.StaffNo;
                txtEmail.Text = item.Email;
                txtPhoneNo.Text = item.PhoneNo;
                checkIsAdmin.Checked = item.IsAdmin;
                checkIsSystemAdmin.Checked = item.IsSuperAdmin;
            }
        }

        private void AddOrUpdate(StaffDetail item)
        {
            var saveItem = _id == ""
                ? _repo.AddStaff(item)
                : _repo.UpdateStaff(item);

            if (saveItem == string.Empty)
            {
                Base.ShowSuccess("Success", "Staff saved successfully");
                this.Close();
            }
            else
            {
                Base.ShowError("Failed", saveItem);
            }
        }

        public FrmStaff(string staffId = "")
        {
            InitializeComponent();
            _repo = new StaffRepo();
            _id = staffId;
            LoadDropdowns();
            if (staffId != "")
            {
                lblTitle.Text = "Update Staff";
              //  comboDept.Enabled = false;
                GetItem(staffId);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!LoggedInUser.IsAdmin)
            {
                Base.ShowError("Access Denied", "You do not have the required permission");
                return;
            }

            var item = new StaffDetail()
            {
                Id = _id,
                DepartmentId = (comboDept.SelectedValue.ToString()),
                TitleId = (comboTitle.SelectedValue.ToString()),
                Lastname = txtSurname.Text.ToTitleCase(),
                Firstname = txtFirstname.Text.ToTitleCase(),
                Othername = txtOthername.Text.ToTitleCase(),
                Email = txtEmail.Text.ToLower(),
                StaffNo = txtStaffNo.Text.ToUpper(),
                PhoneNo = txtPhoneNo.Text,
                IsAdmin = checkIsAdmin.Checked,
                IsSuperAdmin = checkIsSystemAdmin.Checked
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
            comboTitle.SelectedIndex = 0;
            txtSurname.Text = "";
            txtFirstname.Text = "";
            txtOthername.Text = "";
            txtStaffNo.Text ="";
            txtEmail.Text = "";
            txtPhoneNo.Text = "";
            checkIsAdmin.Checked = false;
            checkIsSystemAdmin.Checked = false;
        }

        private void checkIsAdmin_CheckedStateChanged(object sender, EventArgs e)
        {
            
        }

        private void checkIsSystemAdmin_CheckedStateChanged(object sender, EventArgs e)
        {
            if (checkIsSystemAdmin.Checked)
            {
                checkIsAdmin.Checked = true;
                checkIsAdmin.Enabled = false;
            }
            else
            {
               // checkIsAdmin.Checked = false;
                checkIsAdmin.Enabled = true;
            }
        }
    }
}
