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
    public partial class FrmSession : Form
    {
        private readonly SessionSemesterRepo _repo;

        private readonly string _id;

        private string ValidateForm()
        {
            if (txtSession.Text == "")
                return "Session is required";

            if (txtSemester.Text == "")
                return "Semester is required";

            return "";
        }

        private void GetItem(string id)
        {
            var item = _repo.GetSessionSemester(id);
            if (item == null)
            {
                Base.ShowError("Not Found", "Not Found");
                this.Close();
            }
            else
            {
                txtSession.Text = item.Session;
                txtSemester.Text = item.Semester;
                checkActive.Checked = item.IsActive;
            }
        }

        private void AddOrUpdate(SessionSemester item)
        {
            var saveItem = _id == ""
                ? _repo.AddSessionSemester(item)
                : _repo.UpdateSessionSemester(item);

            if (saveItem == string.Empty)
            {
                Base.ShowSuccess("Success", "Session/Semester saved successfully");
                this.Close();
            }
            else
            {
                Base.ShowError("Failed", saveItem);
            }
        }

        public FrmSession(string sessionId = "")
        {
            InitializeComponent();
            _repo = new SessionSemesterRepo();
            _id = sessionId;

            if (sessionId != "")
            {
                lblTitle.Text = "Update Session/Semester";
                GetItem(sessionId);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!LoggedInUser.IsAdmin)
            {
                Base.ShowError("Access Denied", "You do not have the required permission");
                return;
            }

            var item = new SessionSemester()
            {
                Id = _id,
                Session = txtSession.Text.ToTitleCase(),
                Semester = txtSemester.Text.ToTitleCase(),
                IsActive = checkActive.Checked
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
