
using AttendanceLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AttendanceLibrary.BaseClass;
using AttendanceLibrary.DataContext;
using AttendanceLibrary.Model.ViewModels;

namespace AttendanceLibrary.Repository
{
    public class CourseRepo : DisposeContext
    {
        private readonly AttendanceContext _context = Helper.GetDataContext();

        public string AddCourse(Course newCourse)
        {
            try
            {
                
                if (_context.Courses.Any(a => a.CourseCode == newCourse.CourseCode || a.CourseTitle == newCourse.CourseTitle && a.DepartmentId == newCourse.DepartmentId && !a.IsDeleted))
                    return "Course with this Title or Course Code exists";

                newCourse.Id = Guid.NewGuid().ToString();
                _context.Courses.Add(newCourse);
                return _context.SaveChanges() > 0 ? "" : "Course could not be added";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteCourse(string courseId)
        {
            
            if (_context.CourseRegistrations.Any(a => a.CourseId == courseId))
                return "Course cannot be deleted because it has course registration records";

            var course = _context.Courses.SingleOrDefault(a => a.Id == courseId);
            if (course != null)
            {
                //_context.Staff.Remove(staff);
                course.IsDeleted = true;
                return _context.SaveChanges() > 0 ? "" : "Course could not be deleted";
            }

            return "Course not found";
        }

        public List<CourseList> GetAllCourses(string departmentId, string levelId)
        {
            try
            {
                
                return (from c in _context.Courses
                        where !c.IsDeleted && (departmentId == "" || c.DepartmentId == departmentId) && (levelId == "" || c.LevelId == levelId)
                        join d in _context.Departments on c.DepartmentId equals d.Id
                        join l in _context.Levels on c.LevelId equals l.Id
                        select new CourseList
                        {
                            CourseCode = c.CourseCode,
                            CourseTitle = c.CourseTitle,
                            Id = c.Id,
                            Department = d.DepartmentName,
                            Level = l.Level
                        })
                    .OrderBy(x => x.CourseCode)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Course> GetAllCoursesSlim(string departmentId, string levelId)
        {
            try
            {
                
                return _context.Courses
                    .Where(c => !c.IsDeleted && (departmentId == "" || c.DepartmentId == departmentId) && (levelId == "" || c.LevelId == levelId))
                    .OrderBy(x => x.CourseCode)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Course GetCourse(string courseId)
        {
            try
            {
                
                return _context.Courses.SingleOrDefault(a => a.Id == courseId  && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       

        public string UpdateCourse(Course course)
        {
            
            var oldCourse = _context.Courses.SingleOrDefault(a => a.Id == course.Id && !a.IsDeleted);
            if (oldCourse == null)
                return "Course not found";

            if (_context.Courses.Any(a => !a.IsDeleted && a.Id != course.Id && (a.CourseTitle == course.CourseTitle || a.CourseCode == course.CourseCode)))
                return "Course with this Title or Course Code exists";

            //oldCourse.DepartmentId = course.DepartmentId;
            //oldCourse.LevelId = course.LevelId;
            oldCourse.CourseCode = course.CourseCode;
            oldCourse.CourseTitle = course.CourseTitle.ToTitleCase();

            return _context.SaveChanges() > 0 ? "" : "Course could not be updated";
        }

    }
}
