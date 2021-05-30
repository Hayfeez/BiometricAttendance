using System;
using System.Drawing;
using System.IO;
using System.Threading;
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
        public FrmLogin(bool showSplash = true)
        {
            if (showSplash)
            {
                var t = new Thread(new ThreadStart(ShowSplashScreen));
                t.Start();
                Thread.Sleep(5000);
                InitializeComponent();
                t.Abort();
            }
            else
            {
                InitializeComponent();
            }
            
            this.BringToFront();
            //this.Show();
            _authRepo = new AuthRepo();

            lblTitle.Text = ApplicationSetting.ApplicationName;
            lblTitle.ForeColor = ApplicationSetting.PrimaryColor;
            btnLogin.BackColor = ApplicationSetting.PrimaryColor;

            lblLogin.ForeColor = ApplicationSetting.SecondaryColor;
            lblEmail.ForeColor = ApplicationSetting.SecondaryColor;
            lblPassword.ForeColor = ApplicationSetting.SecondaryColor;
            lnkFingerprint.LinkColor = ApplicationSetting.SecondaryColor;
            linkForgotPassword.LinkColor = ApplicationSetting.SecondaryColor;
            
            using (MemoryStream ms = new MemoryStream(ApplicationSetting.LogoBytes))
            {
                pictureBox1.Image = Image.FromStream(ms);
            }

            GetRemoteServerConnectionState();
           // Helper.GetEnumValuesAndDescriptions<ReportType>();
        }

        private void ShowSplashScreen()
        {
            Application.Run(new SplashScreen());
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

                if (!Validations.IsValidEmail(model.Email))
                {
                    Base.ShowError("Invalid Email", "Email is invalid");
                    return;
                }

                if (_authRepo.StaffLogin(model))
                {
                    if (!LoggedInUser.PasswordChanged) // first time login
                    {
                        Base.ShowInfo("First time Login", "This is your first login with the default password. Kindly change your password");
                        var pwdForm = new FrmChangePassword(LoggedInUser.Email);
                        pwdForm.ShowDialog();
                        pwdForm.BringToFront();
                    }

                    using (var dashboard = new FrmContainer())
                    {
                        this.Hide();
                        this.ShowInTaskbar = false;
                        dashboard.ShowDialog();
                        dashboard.BringToFront();
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

        private async void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.CapsLock)
            //{
            //    txtPassword
            //}

           // if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Alt && e.KeyCode == Keys.D)
           if (e.Control && e.Alt && e.KeyCode == Keys.D)
           {
               var result = Base.ShowDialog(MessageBoxButtons.YesNo, "Data Download", "Do you want to proceed with data download?");
               if (result == DialogResult.Yes)
               {
                   if (Helper.CheckRemoteServerConnection())
                   {
                       Helper.MigrateAndSeedRemoteDb(); //seed remote if there's no data

                       var syncRepo = new SyncRepo();
                       var s = await syncRepo.SyncAllData();
                       if (s == string.Empty)
                       {
                           Base.ShowSuccess("Success", "Data synchronization successful");
                       }
                       else
                       {
                           Base.ShowError("Error", s);
                       }
                   }
                   else
                   {
                       Base.ShowError("Connection Failed", "Cannot connect to the remote server. Check your connection settings");
                       var frm = new FrmConnection();
                       frm.BringToFront();
                       frm.ShowDialog();
                   }
               }
           }

           if (e.Control && e.Alt && e.KeyCode == Keys.O)  //open connection string
           {
               var frm = new FrmConnection();
               frm.BringToFront();
               frm.ShowDialog();
               GetRemoteServerConnectionState();
           }
        }

        private void lnkFingerprint_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            this.ShowInTaskbar = false;
            var frm = new FrmFingerprintLogin();
            frm.ShowDialog();
        }

        private void linkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Helper.CheckRemoteServerConnection())
            {
                var frm = new FrmResetPassword(txtUsername.Text);
                frm.BringToFront();
                frm.ShowDialog();
            }
            else
            {
                Base.ShowError("Connection Failed", "You can only reset passwords while connected to the remote server. Check your connection settings");
            }
        }

        private void GetRemoteServerConnectionState()
        {
            var result = Helper.CheckRemoteServerConnection();
            if (result)
            {
                lblConnection.Text = "Remote server connection established";
                lblConnection.ForeColor = Color.Green;
            }
            else
            {
                lblConnection.Text = "Cannot connect to remote server";
                lblConnection.ForeColor = Color.Red;
            }
        }

        private void showPassword_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
        }
    }
}
