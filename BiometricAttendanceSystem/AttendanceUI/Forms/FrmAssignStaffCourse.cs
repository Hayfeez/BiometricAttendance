﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

using AttendanceLibrary.BaseClass;
using AttendanceLibrary.Model;
using AttendanceLibrary.Repository;

using AttendanceUI.BaseClass;

namespace AttendanceUI.Forms
{
    public partial class FrmAssignStaffCourse : Form
    {
        private readonly StaffCourseRepo _repo;
        private string _deptId = "";
        private string _levelId = "";
        private string _staffId = "";

        private void LoadFilter()
        {
            DropdownControls.LoadLevels(ref comboLevel);
            DropdownControls.LoadDepartments(ref comboDept);
        }

        private void LoadCourses()
        {
            if (comboLevel.Items.Count > 0)
            {
                _levelId = comboLevel.SelectedValue.ToString() == Base.IdForSelect ? "" : comboLevel.SelectedValue.ToString();
                if (comboDept.Items.Count > 0)
                {
                    _deptId = comboDept.SelectedValue.ToString() == Base.IdForSelect ? "" : comboDept.SelectedValue.ToString();

                    if (_deptId == "" || _levelId == "")
                        return;

                    var courseRepo = new CourseRepo();
                    var courses = courseRepo.GetAllCoursesSlim(_deptId, _levelId);
                    checkCourses.DataSource = courses;
                    checkCourses.DisplayMember = "CourseTitle";
                    checkCourses.ValueMember = "Id";
                }
            }
        }

        private void LoadStaff()
        {
            if (comboDept.Items.Count > 0)
            {
                _deptId = comboDept.SelectedValue.ToString() == Base.IdForSelect ? "" : comboDept.SelectedValue.ToString();

                if (_deptId == "")
                    return;

                DropdownControls.LoadStaff(ref comboStaff, _deptId);
            }
        }

        public FrmAssignStaffCourse()
        {
            InitializeComponent();
            _repo = new StaffCourseRepo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!LoggedInUser.IsAdmin)
            {
                Base.ShowError("Access Denied", "You do not have the required permission");
                return;
            }

            _staffId = comboStaff.SelectedValue.ToString() == Base.IdForSelect ? "" : comboStaff.SelectedValue.ToString();

            if (_staffId == "")
            {
                Base.ShowError("Required", "Please select a staff");
                return;
            }

            // var checkedCourses = checkCourses.CheckedItems;
            var courseIds = new List<string>();
            Course course;
            for (var i = 0; i < checkCourses.Items.Count; i++)
            {
                // var chk = checkedCourses[index]; 
                if (checkCourses.GetItemChecked(i))
                {
                    course = (Course)checkCourses.Items[i];
                    courseIds.Add(course.Id);
                }
            }

            if (courseIds.Count > 0)
            {
                var assign = _repo.AssignCoursesToStaff(courseIds, _staffId);
                if (assign == string.Empty)
                {
                    Base.ShowSuccess("Success", "Selected Courses assigned to the staff successfully");
                    this.Close();
                }
                else
                {
                    Base.ShowError("Failed", assign);
                }
            }
            else
            {
                Base.ShowError("Required", "You must select at least one course");
            }
        }

        private void iconExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmAssignStaffCourse_Load(object sender, EventArgs e)
        {
            LoadFilter();
            LoadStaff();
            LoadCourses();
        }

        private void comboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStaff();
            LoadCourses();
        }

        private void comboLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCourses();
        }
    }
}
