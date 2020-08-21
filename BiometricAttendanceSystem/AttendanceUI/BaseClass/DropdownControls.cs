using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                    DepartmentName = "Select All",
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
        }

        public static void LoadTitles(ref ComboBox dropDown, bool includeAll = false)
        {
            var repo = new TitleRepo();
            var allItems = repo.GetAllTitles();

            if (includeAll)
            {
                allItems.Insert(0, new PersonTitle
                {
                    Title = "Select All",
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
        }

        public static void LoadLevels(ref ComboBox dropDown, bool includeAll = false)
        {
            var repo = new LevelRepo();
            var allItems = repo.GetAllLevels();

            if (includeAll)
            {
                allItems.Insert(0, new StudentLevel()
                {
                    Level = "Select All",
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
        }

        public static void LoadCourses(ref ComboBox dropDown, string deptId, string levelId, bool includeAll = false)
        {
            var repo = new CourseRepo();
            var allItems = repo.GetAllCoursesSlim(deptId, levelId);

            if (includeAll)
            {
                allItems.Insert(0, new Course
                {
                    CourseTitle = "Select All",
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
        }

        public static void LoadStaff(ref ComboBox dropDown, string deptId, bool includeAll = false)
        {
            var repo = new StaffRepo();
            var allItems = repo.GetAllDepartmentStaff(deptId);

            if (includeAll)
            {
                allItems.Insert(0, new StaffDetail()
                {
                    Lastname = "Select All",
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
        }

        public static void LoadStudents(ref ComboBox dropDown, string deptId, string levelId = "", bool includeGrad = false, bool includeAll = false)
        {
            var repo = new StudentRepo();
            var allItems = repo.GetAllDepartmentStudents(deptId, includeGrad);

            if (includeAll)
            {
                allItems.Insert(0, new StudentDetail()
                {
                    Lastname = "Select All",
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
        }


    }
}
