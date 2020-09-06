using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AttendanceLibrary.BaseClass;
using AttendanceLibrary.Model;
using AttendanceLibrary.Model.ViewModels;
using AttendanceLibrary.Repository;

namespace AttendanceUI.BaseClass
{
    public static class DropdownControls
    {
        public static void LoadDepartments(ref ComboBox dropDown, bool includeAll = false)
        {
            var repo = new DepartmentRepo();
            var allItems = repo.GetAllDepartments();

            if (includeAll)
            {
                allItems.Insert(0, new Department
                {
                    DepartmentName = "All Departments",
                    Id = Base.IdForSelectAll
                });
            }
            else
            {
                allItems.Insert(0, new Department
                {
                    DepartmentName = "Select Department",
                    Id = Base.IdForSelect
                });
            }

            dropDown.DataSource = allItems;
            dropDown.DisplayMember = "DepartmentName";
            dropDown.ValueMember = "Id";
            dropDown.SelectedIndex = 0;
        }

        public static void LoadSessions(ref ComboBox dropDown, bool includeAll = false)
        {
            var repo = new SessionSemesterRepo();
            var allItems = repo.GetAllSessionSemesters();

            if (includeAll)
            {
                allItems.Insert(0, new SessionSemester
                {
                    Session = "Select All",
                    Id = Base.IdForSelectAll
                });
            }
            else
            {
                allItems.Insert(0, new SessionSemester
                {
                    Session = "Select Session/Semester",
                    Id = Base.IdForSelect
                });
            }

            dropDown.DataSource = allItems;
            dropDown.DisplayMember = "Fullname";
            dropDown.ValueMember = "Id";
            dropDown.SelectedIndex = 0;
        }

        public static void LoadTitles(ref ComboBox dropDown, bool includeAll = false)
        {
            var repo = new TitleRepo();
            var allItems = repo.GetAllTitles();

            if (includeAll)
            {
                allItems.Insert(0, new PersonTitle
                {
                    Title = "All Titles",
                    Id = Base.IdForSelectAll
                });
            }
            else
            {
                allItems.Insert(0, new PersonTitle()
                {
                    Title = "Select Title",
                    Id = Base.IdForSelect
                });
            }

            dropDown.DataSource = allItems;
            dropDown.DisplayMember = "Title";
            dropDown.ValueMember = "Id";
            dropDown.SelectedIndex = 0;
        }

        public static void LoadLevels(ref ComboBox dropDown, bool includeAll = false)
        {
            var repo = new LevelRepo();
            var allItems = repo.GetAllLevels();

            if (includeAll)
            {
                allItems.Insert(0, new StudentLevel()
                {
                    Level = "All Levels",
                    Id = Base.IdForSelectAll
                });
            }
            else
            {
                allItems.Insert(0, new StudentLevel()
                {
                    Level = "Select Level",
                    Id = Base.IdForSelect
                });
            }

            dropDown.DataSource = allItems;
            dropDown.DisplayMember = "Level";
            dropDown.ValueMember = "Id";
            dropDown.SelectedIndex = 0;
        }

        public static void LoadCourses(ref ComboBox dropDown, string deptId, string levelId, bool includeAll = false)
        {
            var repo = new CourseRepo();
            var allItems = repo.GetAllCoursesSlim(deptId, levelId);

            if (includeAll)
            {
                allItems.Insert(0, new Course
                {
                    CourseTitle = "All Courses",
                    Id = Base.IdForSelectAll
                });
            }
            else
            {
                allItems.Insert(0, new Course
                {
                    CourseTitle = "Select Course",
                    Id = Base.IdForSelect
                });
            }

            dropDown.DataSource = allItems;
            dropDown.DisplayMember = "CourseTitle";
            dropDown.ValueMember = "Id";
            dropDown.SelectedIndex = 0;
        }

        public static void LoadStaff(ref ComboBox dropDown, string deptId, bool includeAll = false)
        {
            var repo = new StaffRepo();
            var allItems = repo.GetDepartmentStaffSlim(deptId);

            if (includeAll)
            {
                allItems.Insert(0, new StaffDetail()
                {
                    Lastname = "All Staff",
                    Id = Base.IdForSelectAll
                });
            }
            else
            {
                allItems.Insert(0, new StaffDetail()
                {
                    Lastname = "Select Staff",
                    Id = Base.IdForSelect
                });
            }

            dropDown.DataSource = allItems;
            dropDown.DisplayMember = "Fullname";
            dropDown.ValueMember = "Id";
            dropDown.SelectedIndex = 0;
        }

        public static void LoadStaffCourses(ref ComboBox dropDown, string staffId, string levelId = "",  bool includeAll = false)
        {
            var repo = new StaffCourseRepo();
            var allItems = repo.GetCoursesByStaff(staffId, levelId);

            if (includeAll)
            {
                allItems.Insert(0, new StaffCourseList
                {
                    CourseTitle = "All Courses",
                    Id = Base.IdForSelectAll
                });
            }
            else
            {
                allItems.Insert(0, new StaffCourseList()
                {
                    CourseTitle = "Select Course",
                    Id = Base.IdForSelect
                });
            }

            dropDown.DataSource = allItems;
            dropDown.DisplayMember = "CourseTitle";
            dropDown.ValueMember = "CourseId";
            dropDown.SelectedIndex = 0;
        }

        public static void LoadStudents(ref ComboBox dropDown, string deptId, string levelId = "", bool includeGrad = false, bool includeAll = false)
        {
            var repo = new StudentRepo();
            var allItems = repo.GetDepartmentStudentsSlim(deptId, levelId, includeGrad);

            if (includeAll)
            {
                allItems.Insert(0, new StudentDetail()
                {
                    Lastname = "All Students",
                    Id = Base.IdForSelectAll
                });
            }
            else
            {
                allItems.Insert(0, new StudentDetail()
                {
                    Lastname = "Select Staff",
                    Id = Base.IdForSelect
                });
            }

            dropDown.DataSource = allItems;
            dropDown.DisplayMember = "Fullname";
            dropDown.ValueMember = "Id";
            dropDown.SelectedIndex = 0;
        }

        public static void LoadReportType(ref ComboBox dropDown)
        {
            var repo = new ReportRepo();
            var allItems = repo.GetReportType().ToList();

            allItems.Insert(0, new EnumValueModel
            {
                Name = "Select Report type",
                Value = 0
            });

            dropDown.DataSource = allItems;
            dropDown.DisplayMember = "Name";
            dropDown.ValueMember = "Value";
            dropDown.SelectedIndex = 0;
        }
    }
}
