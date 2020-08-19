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
    public partial class FrmTitle : Form
    {
        private readonly TitleRepo _repo;

        private readonly int _id;

        private string ValidateForm()
        {
            if (txtTitle.Text == "")
                return "Title is required";

            return "";
        }

        private void GetItem(int id)
        {
            var item = _repo.GetTitle(id);
            if (item == null)
            {
                Base.ShowError("Not Found", "Not Found");
                this.Close();
            }
            else
            {
                txtTitle.Text = item.Title;
            }
        }

        private void AddOrUpdate(PersonTitle item)
        {
            var saveItem = _id == 0
                ? _repo.AddTitle(item)
                : _repo.UpdateTitle(item);

            if (saveItem != string.Empty)
            {
                Base.ShowSuccess("Success", saveItem);
            }
            else
            {
                saveItem = _id == 0 ? "Title could not be added" : "Title could not be updated";
                Base.ShowError("Error occured", saveItem);
            }
        }

        public FrmTitle(int titleId = 0)
        {
            InitializeComponent();
            _repo = new TitleRepo();
            _id = titleId;

            if (titleId != 0)
            {
                lblTitle.Text = "Update Title";
                GetItem(titleId);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var item = new PersonTitle()
            {
                Id = _id,
                Title = txtTitle.Text.ToTitleCase(),
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
