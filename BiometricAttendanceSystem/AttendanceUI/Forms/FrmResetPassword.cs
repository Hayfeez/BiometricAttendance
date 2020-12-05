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
using AttendanceLibrary.Model.ViewModels;
using AttendanceLibrary.Repository;

using AttendanceUI.BaseClass;

namespace AttendanceUI.Forms
{
    public partial class FrmResetPassword : Form
    {
        private readonly AuthRepo _repo;
        
        private string ValidateForm()
        {
            if (txtEmail.Text == "")
                return "Email address is required";

            if (txtStaffNo.Text == "")
                return "Staff Number is required";

            return "";
        }

        public FrmResetPassword(string userEmail)
        {
            InitializeComponent();
            _repo = new AuthRepo();
            txtEmail.Text = userEmail;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var validate = ValidateForm();
            if (validate == string.Empty)
            {
                var item = new ForgotPassword
                {
                    Email = txtEmail.Text.Trim().ToLower(),
                    StaffNo = txtStaffNo.Text.Trim(),
                    SystemId = Helper.GetMacAddress()
                };

                var saveItem = _repo.StaffForgotPassword(item);

                if (saveItem == string.Empty)
                {
                    Base.ShowSuccess("Success", "Password reset request saved successfully. An admin will reset the password as soon as possible");
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

    }
}
