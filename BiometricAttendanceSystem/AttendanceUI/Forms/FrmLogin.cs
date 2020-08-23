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
using AttendanceLibrary.Repository;
using AttendanceLibrary.Model.ViewModels;
using AttendanceUI.BaseClass;

namespace AttendanceUI.Forms
{
    public partial class FrmLogin : Form
    {
        private readonly AuthRepo _authRepo;
        public FrmLogin()
        {
            InitializeComponent();
            _authRepo = new AuthRepo();
        }

        private void iconExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var model = new Login
                {
                    Email = txtUsername.Text.Trim(),
                    Password = PasswordHash.sha256(txtPassword.Text)
                };

                if (model.Email.Length == 0 || model.Password.Length == 0)
                {
                    Base.ShowError("Required fields missing", "Email and Password cannot be empty");
                    return;
                }

                if (!ValidateEmail.IsValidEmail(model.Email))
                {
                    Base.ShowError("Invalid Email", "Email is invalid");
                    return;
                }

                if (_authRepo.StaffLogin(model))
                {
                    if (!LoggedInUser.IsSuperAdmin && !LoggedInUser.PasswordChanged) // first time login
                    {
                        Base.ShowInfo("First time Login", "This is your first login. Kindly change your password");
                        var pwdForm = new FrmChangePassword(LoggedInUser.Email);
                        pwdForm.ShowDialog();
                    }

                    using (var dashboard = new FrmContainer())
                    {
                        this.Hide();
                        this.ShowInTaskbar = false;
                        dashboard.ShowDialog();
                    }

                }
                else
                {
                    Base.ShowError("Invalid Login", "Username and Password is incorrect");
                    return;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
           
        }

    }
}
