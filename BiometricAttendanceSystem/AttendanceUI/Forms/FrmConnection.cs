using System;
using System.Windows.Forms;

using AttendanceLibrary.BaseClass;
using AttendanceLibrary.Repository;

using AttendanceUI.BaseClass;

using DocumentFormat.OpenXml.Office2016.Drawing.Charts;

namespace AttendanceUI.Forms
{
    public partial class FrmConnection : Form
    {
        private readonly AppSettingsRepo _repo;
        public FrmConnection()
        {
            InitializeComponent();
            _repo = new AppSettingsRepo();
            btnSave.Enabled = false;
        }

        private void FrmConnection_Load(object sender, EventArgs e)
        {
            lblDatabase.Text = "Database: " + ApplicationSetting.DatabaseName;
            txtServer.Text = ApplicationSetting.DatabaseServer;
            txtUsername.Text = ApplicationSetting.DbUsername;
            txtPassword.Text = ApplicationSetting.DbPassword;
        }

        private string ValidateForm()
        {
            if (txtServer.Text == "")
                return "Server is required";

            if (txtUsername.Text == "")
                return "Username is required";

            if (txtPassword.Text == "")
                return "Password is required";

            return "";
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            var validate = ValidateForm();
            if (validate == string.Empty)
            {
               // var saveItem = Helper.SaveConnectionStringInSettings(txtServer.Text.Trim(), txtUsername.Text.Trim(), txtPassword.Text.Trim());
                var saveItem = _repo.SaveConnectionString(txtServer.Text.Trim(), Helper.DatabaseName, txtUsername.Text.Trim(), txtPassword.Text.Trim());
                if (saveItem == string.Empty)
                {
                    var saveRemote = new SyncRepo().UploadConnectionStringToRemote();
                    if (saveRemote == string.Empty)
                    {
                        Base.ShowSuccess("Success", "Connection String saved successfully");
                        this.Close();
                    }
                    else
                    {
                        Base.ShowError("Failed", saveRemote);
                    }
                }
                else
                {
                    Base.ShowError("Failed", "An error occured");
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

        private void btnTest_Click(object sender, EventArgs e)
        {
            var validate = ValidateForm();
            if (validate == string.Empty)
            {
                var test = Helper.TestConnectionString(txtServer.Text.Trim(), txtUsername.Text.Trim(), txtPassword.Text.Trim());
                if (test)
                {
                    btnSave.Enabled = true;
                    Base.ShowSuccess("Success", "Connection established successfully");
                }
                else
                {
                    btnSave.Enabled = false;
                    Base.ShowError("Failed", "Could not connect to remote server. Check your credentials or the server could be unavailable");
                }
            }
            else
            {
                Base.ShowInfo("Validation Failed", validate);
            }
        }
    }
}
