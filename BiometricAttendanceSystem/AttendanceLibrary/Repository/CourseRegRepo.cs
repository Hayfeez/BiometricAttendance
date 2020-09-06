using AttendanceLibrary.Model;
using AttendanceLibrary.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AttendanceLibrary.BaseClass;
using AttendanceLibrary.DataContext;

namespace AttendanceLibrary.Repository
{
   public class CourseRegRepo
    {
        public string SaveCourseReg(CourseRegistration model)
        {
            try
            {
                using var context = new SqliteContext();
                if (context.CourseRegistrations.Any(a => a.StudentId == model.StudentId && a.CourseId == model.CourseId && a.SessionSemesterId == model.SessionSemesterId))
                    return "Course already registered";

                model.Id = Guid.NewGuid().ToString();
                context.CourseRegistrations.Add(model);

                return context.SaveChanges() > 0 ? "" : "Course could not be registered";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string RegisterCourseStudents(List<BulkStudentCourseReg> model, string courseId)
        {
            try
            {
                var studentRepo = new StudentRepo();
                var levelRepo = new LevelRepo();
               // var sessionRepo = new SessionSemesterRepo();

               using var context = new SqliteContext();
               var activeSession = LoggedInUser.ActiveSession; //sessionRepo.GetActiveSessionSemester();
               if (activeSession == null)
               {
                   return "You can't register students for course. There is no active semester";
               }

               var toAdd = new List<CourseRegistration>();
               foreach (var item in model)
               {
                   var student = studentRepo.GetStudentByMatricNo(item.MatricNumber);
                   var level = levelRepo.GetLevelByName(item.Level);
                   if (student == null || level == null)
                   {
                       return "No record saved. At least one student or level does not exist";
                   }

                   if (!context.CourseRegistrations.Any(a => a.StudentId == student.Id && a.CourseId == courseId && a.SessionSemesterId == activeSession.Id))
                   {
                       toAdd.Add(new CourseRegistration
                       {
                           CourseId = courseId,
                           DateRegistered = DateTime.Now,
                           Id = Guid.NewGuid().ToString(),
                           StudentId = student.Id,
                           LevelId = level.Id,
                           SessionSemesterId = activeSession.Id,
                           RegisteredBy = LoggedInUser.UserId,
                       });
                   }
               }
               context.CourseRegistrations.AddRange(toAdd);
               return context.SaveChanges() > 0 ? "" : "No record saved";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public string DeleteCourseReg(string id)
        {
            try
            {
                using var context = new SqliteContext();
                if (context.Attendances.Any(a => a.CourseRegistrationId == id))
                    return "Registered Course cannot be deleted";

                var item = context.CourseRegistrations.SingleOrDefault(x => x.Id == id);
                if (item == null)
                    return "Registered course not found";

                context.CourseRegistrations.Remove(item);
                return context.SaveChanges() > 0 ? "" : "Registered Course could not be deleted";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CourseRegistrationList> GetCoursesByStudent(string studentId, string semesterId)
        {
            try
            {
                using var context = new SqliteContext();
                var dt = (from att in context.CourseRegistrations
                          join sem in context.SessionSemesters on att.SessionSemesterId equals sem.Id
                          join cou in context.Courses on att.CourseId equals cou.Id
                          join st in context.Students on att.StudentId equals st.Id
                          join stLev in context.Levels on att.LevelId equals stLev.Id
                          join sta in context.Staff on att.RegisteredBy equals sta.Id
                          join ti in context.Titles on sta.TitleId equals ti.Id
                          where att.StudentId == studentId && att.SessionSemesterId == semesterId
                          select new CourseRegistrationList
                          {
                              Id = att.Id,
                              CourseTitle = cou.CourseTitle,
                              DateRegistered = att.DateRegistered.Date,
                              Semester = sem.Session + " - " + sem.Semester,
                              RegisteredBy = ti.Title + " " + sta.Lastname + ", " + sta.Firstname + " " + sta.Othername,
                              StudentLevel = stLev.Level,
                              StudentMatricNo = st.MatricNo,
                              StudentName = st.Lastname + ", " + st.Firstname + " " +st.Othername
                          }).ToList();

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CourseRegistrationList> GetStudentsByCourses(string courseId, string semesterId)
        {
            try
            {
                using var context = new SqliteContext();
                var dt = (from att in context.CourseRegistrations
                          join sem in context.SessionSemesters on att.SessionSemesterId equals sem.Id
                          join cou in context.Courses on att.CourseId equals cou.Id
                          join st in context.Students on att.StudentId equals st.Id
                          join stLev in context.Levels on att.LevelId equals stLev.Id
                          //join sta in context.Staff on att.RegisteredBy equals sta.Id into staff
                          //from staf in staff
                          //join ti in context.Titles on staf.TitleId equals ti.Id
                          where att.CourseId == courseId && att.SessionSemesterId == semesterId
                          select new CourseRegistrationList
                          {
                              Id = att.Id,
                              CourseTitle = cou.CourseTitle,
                              DateRegistered = att.DateRegistered.Date,
                              Semester = sem.Session + " - " + sem.Semester,
                              //RegisteredBy = ti.Title + " " + staf.Lastname + ", " + staf.Firstname + " " + staf.Othername,
                              StudentLevel = stLev.Level,
                              StudentMatricNo = st.MatricNo,
                              StudentName = st.Lastname + ", " + st.Firstname + " " + st.Othername
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
