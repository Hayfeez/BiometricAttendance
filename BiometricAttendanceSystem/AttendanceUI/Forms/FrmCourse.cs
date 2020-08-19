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
    public partial class FrmCourse : Form
    {
        private readonly CourseRepo _repo;

        private readonly int _id;

        private void LoadDropdowns()
        {
            DropdownControls.LoadDepartments(ref comboDept);
            DropdownControls.LoadLevels(ref comboLevel);
        }

        private string ValidateForm()
        {
            if (int.Parse(comboDept.SelectedValue.ToString()) == Base.IdForSelect)
                return "Department is required";

            if (int.Parse(comboLevel.SelectedValue.ToString()) == Base.IdForSelect)
                return "Level is required";

            if (txtCourseTitle.Text == "")
                return "Course Title is required";

            if (txtCourseCode.Text == "")
                return "Course Code is required";

            return "";
        }

        private void GetItem(int id)
        {
            var item = _repo.GetCourse(id);
            if (item == null)
            {
                Base.ShowError("Not Found", "Not Found");
                this.Close();
            }
            else
            {
                comboLevel.SelectedItem = item.LevelId;
                comboDept.SelectedItem = item.DepartmentId;
                txtCourseCode.Text = item.CourseCode;
                txtCourseTitle.Text = item.CourseTitle;
            }
        }

        private void AddOrUpdate(Course item)
        {
            var saveItem = _id == 0
                ? _repo.AddCourse(item)
                : _repo.UpdateCourse(item);

            if (saveItem != string.Empty)
            {
                Base.ShowSuccess("Success", saveItem);
            }
            else
            {
                saveItem = _id == 0 ? "Course could not be added" : "Course could not be updated";
                Base.ShowError("Error occured", saveItem);
            }
        }

        public FrmCourse(int courseId = 0)
        {
            InitializeComponent();
            _repo = new CourseRepo();
            _id = courseId;
            LoadDropdowns();

            if (courseId != 0)
            {
                lblTitle.Text = "Update Course";
                comboLevel.Enabled = false;
                comboDept.Enabled = false;
                GetItem(courseId);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var item = new Course
            {
                Id = _id,
                CourseCode = txtCourseCode.Text.ToUpper(),
                CourseTitle = txtCourseTitle.Text.ToTitleCase(),
                DepartmentId = int.Parse(comboDept.SelectedValue.ToString()),
                LevelId = int.Parse(comboLevel.SelectedValue.ToString())
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
