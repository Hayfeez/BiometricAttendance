using AttendanceLibrary.Model;
using AttendanceLibrary.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

using AttendanceLibrary.BaseClass;
using AttendanceLibrary.DataContext;

namespace AttendanceLibrary.Repository
{   
   public class AttendanceRepo : DisposeContext
    {
        private readonly AttendanceContext _context = Helper.GetDataContext(true);

        public string SaveAttendance(string courseId, string studentId, string semesterId, string markedBy)
        {
            try
            {
                var dateMarked = DateTime.Now;

                var courseRegId = _context.CourseRegistrations.SingleOrDefault(a => a.CourseId == courseId && a.SessionSemesterId == semesterId && a.StudentId == studentId)?.Id;

                if (courseRegId == null)
                    return "You are not registered for this course this semester";

                if (_context.Attendances.Any(a => a.CourseRegistrationId == courseRegId && a.DateMarked.Date == dateMarked.Date))
                    return "You have marked attendance for this course today";

                _context.Attendances.Add(new Attendance
                {
                    Id = Guid.NewGuid().ToString(),
                    CourseRegistrationId = courseRegId,
                    DateMarked = dateMarked,
                    MarkedBy = markedBy
                });

                return _context.SaveChanges() > 0 ? "" : "Attendance could not be saved";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AttendanceList> GetTodayAttendanceByCourse(string courseId)
        {
            try
            {
                var dateNow = DateTime.Now.Date;
                var dt = (from att in _context.Attendances
                          join reg in _context.CourseRegistrations on att.CourseRegistrationId equals reg.Id
                          join st in _context.Students on reg.StudentId equals st.Id
                          where reg.CourseId == courseId && att.DateMarked.Date == dateNow
                          select new AttendanceList
                          {
                              Id = att.Id,
                              StudentMatricNo = st.MatricNo,
                              StudentName = st.Lastname + ", " + st.Firstname + " " + st.Othername,
                              DateMarked = att.DateMarked.Date,
                              TimeIn = att.DateMarked.ToShortTimeString()
                          }
                    ).ToList();

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StudentFinger> GetFingersOfCourseStudents(string courseId)
        {
            try
            {
                var activeSemesterId = _context.SessionSemesters.SingleOrDefault(x => x.IsActive)?.Id;
                if (activeSemesterId == null)
                    return null;

                var d = (from c in _context.CourseRegistrations
                         where c.CourseId == courseId && c.SessionSemesterId == activeSemesterId
                         // let studentId = c.StudentId
                         join st in _context.StudentFingers on c.StudentId equals st.StudentId into studentFingers
                         from fings in studentFingers
                         join s in _context.Students on fings.StudentId equals s.Id
                         where !s.IsDeleted && !s.IsGraduated
                         select new StudentFinger
                         {
                             FingerTemplate = fings.FingerTemplate,
                             Id = fings.Id,
                             StudentId = fings.StudentId,
                             MatricNo = s.MatricNo
                         }).ToList();

                return d;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
