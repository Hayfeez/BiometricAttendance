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

        private readonly string _id;

        private string ValidateForm()
        {
            if (txtLevel.Text == "")
                return "Level is required";

            return "";
        }

        private void GetItem(string id)
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
            var saveItem = _id == ""
                ? _repo.AddLevel(item)
                : _repo.UpdateLevel(item);

            if (saveItem == string.Empty)
            {
                Base.ShowSuccess("Success", "Level saved successfully");
            }
            else
            {
                Base.ShowError("Failed", saveItem);
            }
        }

        public FrmLevel(string levelId = "")
        {
            InitializeComponent();
            _repo = new LevelRepo();
            _id = levelId;

            if (levelId != "")
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
                this.Close();
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
