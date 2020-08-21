using AttendanceLibrary.Model;
using AttendanceLibrary.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceLibrary.Repository
{
   public class CourseRegRepo
    {
        public string SaveCourseReg(CourseRegistration model)
        {
            try
            {
                using (var context = new BASContext())
                {
                    if (context.CourseRegistrations.Any(a => a.StudentId == model.StudentId && a.CourseId == model.CourseId && a.SessionSemesterId == model.SessionSemesterId))
                        return "Course already registered";

                    model.Id = Guid.NewGuid().ToString();
                    context.CourseRegistrations.Add(model);

                    return context.SaveChanges() > 0 ? "" : "Course could not be registered";

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CourseRegistration> GetCoursesByStudent(string studentId, string semesterId)
        {
            try
            {
                using (var context = new BASContext())
                {
                    var dt = (from att in context.CourseRegistrations
                              where att.StudentId == studentId && att.SessionSemesterId == semesterId
                              select att).ToList();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CourseRegistration> GetStudentsByCourses(string courseId, string semesterId)
        {
            try
            {
                using (var context = new BASContext())
                {
                    var dt = (from att in context.CourseRegistrations
                              where att.CourseId == courseId && att.SessionSemesterId == semesterId
                              select att).ToList();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
