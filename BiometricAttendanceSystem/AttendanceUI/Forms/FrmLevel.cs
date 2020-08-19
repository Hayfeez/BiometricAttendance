using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AttendanceLibrary.Model;
using AttendanceLibrary.Repository;

using AttendanceUI.BaseClass;

namespace AttendanceUI.Forms
{
    public partial class FrmLevel : Form
    {
        private readonly LevelRepo _repo;

        private readonly int _id;

        private string ValidateForm()
        {
            if (txtLevel.Text == "")
                return "Level is required";

            return "";
        }

        private void GetItem(int id)
        {
            var item = _repo.GetLevel(id);
            if (item == null)
            {
                Base.ShowError("Not Found", "Not Found");
                this.Close();
            }
            else
            {
                txtLevel.Text = item.Level;
            }
        }

        private void AddOrUpdate(StudentLevel item)
        {
            var saveItem = _id == 0
                ? _repo.AddLevel(item)
                : _repo.UpdateLevel(item);

            if (saveItem != string.Empty)
            {
                Base.ShowSuccess("Success", saveItem);
            }
            else
            {
                saveItem = _id == 0 ? "Level could not be added" : "Level could not be updated";
                Base.ShowError("Error occured", saveItem);
            }
        }

        public FrmLevel(int levelId = 0)
        {
            InitializeComponent();
            _repo = new LevelRepo();
            _id = levelId;

            if (levelId != 0)
            {
                lblTitle.Text = "Update Level";
                GetItem(levelId);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var item = new StudentLevel
            {
                Id = _id,
                Level = txtLevel.Text.ToUpper(),
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
