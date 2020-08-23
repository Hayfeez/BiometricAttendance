
using AttendanceLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AttendanceLibrary.BaseClass;
using AttendanceLibrary.Model.ViewModels;

namespace AttendanceLibrary.Repository
{
    public class CourseRepo
    {
        public string AddCourse(Course newCourse)
        {
            try
            {
                using (var context = new BASContext())
                {
                    if (context.Courses.Any(a => a.CourseCode == newCourse.CourseCode || a.CourseTitle == newCourse.CourseTitle && a.DepartmentId == newCourse.DepartmentId && !a.IsDeleted))
                        return "Course with this Title or Course Code exists";

                    newCourse.Id = Guid.NewGuid().ToString();
                    context.Courses.Add(newCourse);
                    return context.SaveChanges() > 0 ? "" : "Course could not be added";

                }                    
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteCourse(string courseId)
        {
            using (var context = new BASContext())
            {
                if (context.CourseRegistrations.Any(a => a.CourseId == courseId))
                    return "Course cannot be deleted because it has course registration records";

                var course = context.Courses.SingleOrDefault(a => a.Id == courseId);
                if (course != null)
                {
                    //context.Staff.Remove(staff);
                    course.IsDeleted = true;
                    return context.SaveChanges() > 0 ? "" : "Course could not be deleted";
                }

                return "Course not found";
            }                            
            
        }

        //public List<CourseList> GetAllCourses()
        //{
        //    try
        //    {
        //        using (var context = new BASContext())
        //        {                    
        //            //return context.Courses.Where(a => !a.IsDeleted)
        //            //    .Join(context.Departments, c => c.DepartmentId, d => d.Id, (c, d) => new
        //            //    {
        //            //        course = c,
        //            //        deptName = d.DepartmentName
        //            //    })
        //            //    .Join(context.Levels, x => x.course.LevelId, d => d.Id, (course, d) => new
        //            //    {
        //            //        course,
        //            //        levelName = d.Level
        //            //    }).Select(x=> new CourseList
        //            //    {
        //            //        CourseCode = x.course.
        //            //    })

        //            return (from c in context.Courses
        //                          where !c.IsDeleted
        //                          join d in context.Departments on c.DepartmentId equals d.Id
        //                          join l in context.Levels on c.LevelId equals l.Id
        //                          select new CourseList
        //                          {
        //                              CourseCode = c.CourseCode,
        //                              CourseTitle = c.CourseTitle,
        //                              Id = c.Id,
        //                              Department = d.DepartmentName,
        //                              Level = l.Level
        //                          }).ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public List<CourseList> GetAllCourses(string departmentId, string levelId)
        {
            try
            {
                using (var context = new BASContext())
                {
                    return (from c in context.Courses
                            where !c.IsDeleted && (departmentId == "" || c.DepartmentId == departmentId) && (levelId == "" || c.LevelId == levelId)
                            join d in context.Departments on c.DepartmentId equals d.Id
                            join l in context.Levels on c.LevelId equals l.Id
                            select new CourseList
                            {
                                CourseCode = c.CourseCode,
                                CourseTitle = c.CourseTitle,
                                Id = c.Id,
                                Department = d.DepartmentName,
                                Level = l.Level
                            }).ToList();

                }
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
                using (var context = new BASContext())
                {
                    return context.Courses
                        .Where(c => !c.IsDeleted && (departmentId == "" || c.DepartmentId == departmentId) && (levelId == "" || c.LevelId == levelId))
                        .ToList();
                }
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
                using (var context = new BASContext())
                {
                    return context.Courses.SingleOrDefault(a => a.Id == courseId  && !a.IsDeleted);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       

        public string UpdateCourse(Course course)
        {
            using (var context = new BASContext())
            {
                var oldCourse = context.Courses.SingleOrDefault(a => a.Id == course.Id && !a.IsDeleted);
                if (oldCourse == null)
                    return "Course not found";

                if (context.Courses.Any(a => !a.IsDeleted && a.Id != course.Id && (a.CourseTitle == course.CourseTitle || a.CourseCode == course.CourseCode)))
                    return "Course with this Title or Course Code exists";

                //oldCourse.DepartmentId = course.DepartmentId;
                //oldCourse.LevelId = course.LevelId;
                oldCourse.CourseCode = course.CourseCode;
                oldCourse.CourseTitle = course.CourseTitle.ToTitleCase();

                return context.SaveChanges() > 0 ? "" : "Course could not be updated";

            }
        }

    }
}
