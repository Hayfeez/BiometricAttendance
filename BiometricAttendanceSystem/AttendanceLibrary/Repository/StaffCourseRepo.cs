using AttendanceLibrary.Model;
using AttendanceLibrary.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AttendanceLibrary.DataContext;

namespace AttendanceLibrary.Repository
{
   public class StaffCourseRepo
    {
        public string AssignCourse(StaffCourse model)
        {
            try
            {
                using var context = new SqliteContext();
                if (context.StaffCourses.Any(a => a.StaffId == model.StaffId && a.CourseId == model.CourseId))
                    return "Course already assigned to staff";

                model.Id = Guid.NewGuid().ToString();
                model.DateAssigned = DateTime.Now;
                context.StaffCourses.Add(model);

                return context.SaveChanges() > 0 ? "" : "Course could not be assigned to staff";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string AssignCoursesToStaff(List<string> courseIds, string staffId)
        {
            try
            {
                var skipped = new List<string>();
                using var context = new SqliteContext();
                var toAdd = new List<StaffCourse>();
                foreach (var courseId in courseIds)
                {
                    if (context.StaffCourses.Any(a => a.StaffId == staffId && a.CourseId == courseId))
                        skipped.Add(courseId);

                    toAdd.Add(new StaffCourse
                    {
                        CourseId = courseId,
                        DateAssigned = DateTime.Now,
                        Id = Guid.NewGuid().ToString(),
                        StaffId = staffId
                    });
                }
                context.StaffCourses.AddRange(toAdd);
                return context.SaveChanges() > 0 ? "" : "Course could not be assigned to staff";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteStaffCourse(string id)
        {
            try
            {
                using var context = new SqliteContext();
                var item = context.StaffCourses.SingleOrDefault(x => x.Id == id);
                if (item == null)
                    return "Staff course not found";

                context.StaffCourses.Remove(item);
                return context.SaveChanges() > 0 ? "" : "Staff course could not be deleted";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StaffCourseList> GetCoursesByStaff(string staffId, string levelId)
        {
            try
            {
                using var context = new SqliteContext();
                var dt = (from att in context.StaffCourses
                          join cou in context.Courses on att.CourseId equals cou.Id
                          join st in context.Staff on att.StaffId equals st.Id
                          join ti in context.Titles on st.TitleId equals ti.Id
                          where att.StaffId == staffId && !cou.IsDeleted && (levelId == "" || levelId == cou.LevelId)
                          select new StaffCourseList
                          {
                              Id = att.Id,
                              CourseId = cou.Id,
                              CourseTitle = cou.CourseTitle,
                              Fullname = st.Lastname + ", " + st.Firstname + " "  + st.Othername,
                              Title =ti.Title,
                              DateAssigned = att.DateAssigned
                          }).ToList();

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StaffCourseList> GetStaffByCourse(string courseId)
        {
            try
            {
                using var context = new SqliteContext();
                var dt = (from att in context.StaffCourses
                          join cou in context.Courses on att.CourseId equals cou.Id
                          join st in context.Staff on att.StaffId equals st.Id
                          join ti in context.Titles on st.TitleId equals ti.Id
                          where (courseId == "" || att.CourseId == courseId) && !cou.IsDeleted && !st.IsDeleted
                          select new StaffCourseList
                          {
                              Id = att.Id,
                              CourseId = cou.Id,
                              CourseTitle = cou.CourseTitle,
                              Fullname = st.Lastname + ", " + st.Firstname + " " + st.Othername,
                              Title = ti.Title,
                              DateAssigned = att.DateAssigned.Date
                          }).ToList();

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
