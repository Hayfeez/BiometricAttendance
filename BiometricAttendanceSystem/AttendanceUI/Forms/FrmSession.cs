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

        private readonly int _id;

        private string ValidateForm()
        {
            if (txtSession.Text == "")
                return "Session is required";

            if (txtSemester.Text == "")
                return "Semester is required";

            return "";
        }

        private void GetItem(int id)
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
            var saveItem = _id == 0
                ? _repo.AddSessionSemester(item)
                : _repo.UpdateSessionSemester(item);

            if (saveItem != string.Empty)
            {
                Base.ShowSuccess("Success", saveItem);
            }
            else
            {
                saveItem = _id == 0 ? "Session/Semester could not be added" : "Session/Semester could not be updated";
                Base.ShowError("Error occured", saveItem);
            }
        }

        public FrmSession(int sessionId = 0)
        {
            InitializeComponent();
            _repo = new SessionSemesterRepo();
            _id = sessionId;

            if (sessionId != 0)
            {
                lblTitle.Text = "Update Session/Semester";
                GetItem(sessionId);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
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
