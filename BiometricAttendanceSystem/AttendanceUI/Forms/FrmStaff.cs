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

        private readonly int _id;

        private void LoadDropdowns()
        {
            DropdownControls.LoadDepartments(ref comboDept);
            DropdownControls.LoadTitles(ref comboTitle);
        }

        private string ValidateForm()
        {
            if (int.Parse(comboDept.SelectedValue.ToString()) == Base.IdForSelect)
                return "Department is required";

            if (int.Parse(comboTitle.SelectedValue.ToString()) == Base.IdForSelect)
                return "Title is required";

            if (txtSurname.Text == "")
                return "Surname is required";

            if (txtFirstname.Text == "")
                return "Firstname is required";

            if (txtStaffNo.Text == "")
                return "Staff No is required";

            if (txtEmail.Text == "")
                return "Email is required";

            return "";
        }

        private void GetItem(int id)
        {
            var item = _repo.GetStaff(id);
            if (item == null)
            {
                Base.ShowError("Not Found", "Not Found");
                this.Close();
            }
            else
            {
                comboDept.SelectedItem = item.DepartmentId;
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
            var saveItem = _id == 0
                ? _repo.AddStaff(item)
                : _repo.UpdateStaff(item);

            if (saveItem != string.Empty)
            {
                Base.ShowSuccess("Success", saveItem);
            }
            else
            {
                saveItem = _id == 0 ? "Staff could not be added" : "Staff could not be updated";
                Base.ShowError("Error occured", saveItem);
            }
        }

        public FrmStaff(int staffId = 0)
        {
            InitializeComponent();
            _repo = new StaffRepo();
            _id = staffId;
            LoadDropdowns();
            if (staffId != 0)
            {
                lblTitle.Text = "Update Staff";
              //  comboDept.Enabled = false;
                GetItem(staffId);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var item = new StaffDetail()
            {
                Id = _id,
                DepartmentId = int.Parse(comboDept.SelectedValue.ToString()),
                TitleId = int.Parse(comboTitle.SelectedValue.ToString()),
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
    }
}
