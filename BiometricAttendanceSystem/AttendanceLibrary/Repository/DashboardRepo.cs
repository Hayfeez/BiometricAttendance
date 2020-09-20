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
    public class DashboardRepo : DisposeContext
    {
        private readonly AttendanceContext _context = Helper.GetDataContext(true);

        public int GetStudentCount()
        {
            try
            {
                return _context.Students.Count(a => !a.IsDeleted && !a.IsGraduated);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetStaffCount()
        {
            try
            {
                return _context.Staff.Count(a => !a.IsDeleted);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StaffCourseRegCount> GetCourseAttendanceCount(string userId, string semesterId)
        {
            var startDate = DateTime.MinValue.Date;
            var endDate = DateTime.Now.Date;
            var listMarkedBy = false;

            var attendances = (from att in _context.Attendances
                               join reg in _context.CourseRegistrations on att.CourseRegistrationId equals reg.Id
                               join st in _context.StaffCourses on reg.CourseId equals st.CourseId
                               join c in _context.Courses on reg.CourseId equals c.Id
                               join s in _context.SessionSemesters on reg.SessionSemesterId equals s.Id
                               join l in _context.Staff on att.MarkedBy equals l.Id
                               join ti in _context.Titles on l.TitleId equals ti.Id
                               where reg.SessionSemesterId == semesterId
                                     && att.DateMarked.Date >= startDate
                                     && att.DateMarked.Date <= endDate
                                     && !c.IsDeleted
                               select new AttendanceList
                               {
                                   Course = c.CourseCode + " - " + c.CourseTitle,
                                   DateMarked = att.DateMarked.Date,
                                   MarkedBy = ti.Title + " " + l.Lastname + ", " + l.Firstname + " " + l.Othername
                               }
                ).ToList();
            List<StaffCourseRegCount> dt;
            if (listMarkedBy)
            {
                dt = attendances.GroupBy(x => new
                {
                    x.Course,
                    x.MarkedBy
                })
                    .Select(y => new StaffCourseRegCount
                    {
                        CourseTitle = y.Key.Course,
                        MarkedBy = y.Key.MarkedBy,
                        Count = y.GroupBy(z => z.DateMarked.Date).Count()
                    })
                    .ToList();
            }
            else
            {
                dt = attendances.GroupBy(x => new
                {
                    x.Course,
                })
                    .Select(y => new StaffCourseRegCount
                    {
                        CourseTitle = y.Key.Course,
                        Count = y.GroupBy(z => z.DateMarked.Date).Count()
                    })
                    .ToList();
            }

            return dt;
        }

        public List<StaffCourseRegCount> GetCourseRegCount(string userId, string semesterId)
        {
            if (userId == Helper.SuperAdminId)
                userId = "";

            var regs = (from att in _context.StaffCourses
                        join reg in _context.CourseRegistrations on att.CourseId equals reg.CourseId
                        join c in _context.Courses on reg.CourseId equals c.Id
                        join s in _context.SessionSemesters on reg.SessionSemesterId equals s.Id
                        where reg.SessionSemesterId == semesterId
                              && (userId == "" || att.StaffId == userId)
                              && !c.IsDeleted
                        group att by new
                        {
                            c.CourseTitle
                        });

            return (from dt in regs
                    select new StaffCourseRegCount
                    {
                        CourseTitle = dt.Key.CourseTitle,
                        Count = dt.Count()
                    }).ToList();
        }

    }
}
