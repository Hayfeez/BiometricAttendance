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
    public partial class FrmConnection : Form
    {
        public FrmConnection()
        {
            InitializeComponent();
        }

        private void FrmConnection_Load(object sender, EventArgs e)
        {
            var item = Helper.GetConnectionStringFromSettings();
            var conString = item.Split(';');
            lblDatabase.Text = "Database: " + Helper.DatabaseName;
            txtServer.Text = conString[0].Split('=')[1];
            txtUsername.Text = conString[2].Split('=')[1];
            txtPassword.Text = conString[3].Split('=')[1];
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
                var saveItem = Helper.SaveConnectionStringInSettings(txtServer.Text.Trim(), txtUsername.Text.Trim(), txtPassword.Text.Trim());
                if (saveItem)
                {
                    Base.ShowSuccess("Success", "Connection String saved successfully");
                    this.Close();
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
        
    }
}
