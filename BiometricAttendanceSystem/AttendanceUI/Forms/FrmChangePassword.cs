using System;
using System.Windows.Forms;

using AttendanceLibrary.Model.ViewModels;
using AttendanceLibrary.Repository;

using AttendanceUI.BaseClass;

namespace AttendanceUI.Forms
{
    public partial class FrmChangePassword : Form
    {
        private readonly AuthRepo _repo;

        private readonly string _id;

        private string ValidateForm()
        {
            if (txtOld.Text == "")
                return "Current password is required";

            if (txtNew.Text == "")
                return "New password is required";

            if (txtOld.Text == txtNew.Text)
                return "Current password cannot be the same as New password";

            return "";
        }

        public FrmChangePassword(string userEmail)
        {
            InitializeComponent();
            _repo = new AuthRepo();
            _id = userEmail;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var validate = ValidateForm();
            if (validate == string.Empty)
            {
                var item = new ChangePassword()
                {
                    Email = _id,
                    OldPassword = txtOld.Text,
                    NewPassword = txtNew.Text
                };

                var saveItem = _repo.StaffChangePassword(item);

                if (saveItem == string.Empty)
                {
                    Base.ShowSuccess("Success", "Password changed successfully");
                    this.Close();
                }
                else
                {
                    Base.ShowError("Failed", saveItem);
                }
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

        private void checkPwd_CheckedStateChanged(object sender, EventArgs e)
        {
            txtNew.UseSystemPasswordChar = !checkPwd.Checked;
            txtOld.UseSystemPasswordChar = !checkPwd.Checked;
        }
    }
}
