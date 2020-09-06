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
    public class ReportRepo
    {
        public IEnumerable<EnumValueModel> GetReportType()
        {
            return Helper.GetEnumValuesAndDescriptions<ReportType>();
        }

        public string GetReportDescription(int value)
        {
            return Helper.GetEnumValuesAndDescriptions<ReportType>()
                .FirstOrDefault(x=>x.Value.ToString() == value.ToString())?.Name;
        }

        #region Dashboard

        public List<StaffCourseRegCount> GetStaffCourseAttendanceCount(string semesterId, bool listMarkedBy)
        {
            var startDate = DateTime.MinValue.Date;
            var endDate = DateTime.Now.Date;

            using var context = new SqliteContext();
            var attendances = (from att in context.Attendances
                               join reg in context.CourseRegistrations on att.CourseRegistrationId equals reg.Id
                               join st in context.StaffCourses on reg.CourseId equals st.CourseId
                               join c in context.Courses on reg.CourseId equals c.Id
                               join s in context.SessionSemesters on reg.SessionSemesterId equals s.Id
                               join l in context.Staff on att.MarkedBy equals l.Id
                               join ti in context.Titles on l.TitleId equals ti.Id
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

        public List<StaffCourseRegCount> GetStaffCourseRegCount(string semesterId, string userId)
        {
            using var context = new SqliteContext();
            var regs = (from att in context.StaffCourses
                        join reg in context.CourseRegistrations on att.CourseId equals reg.CourseId
                        join c in context.Courses on reg.CourseId equals c.Id
                        join s in context.SessionSemesters on reg.SessionSemesterId equals s.Id
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

        #endregion


        #region reports

        public List<AttendanceReport> GetStudentAttendanceRecord(string semesterId, string courseId, string studentId, DateTime startDate, DateTime endDate)
        {
            //startDate ??= DateTime.MinValue.Date;
            //endDate ??= DateTime.MaxValue.Date;

            using var context = new SqliteContext();
            var attendances = (from att in context.Attendances
                               join reg in context.CourseRegistrations on att.CourseRegistrationId equals reg.Id
                               join st in context.Students on reg.StudentId equals st.Id
                               join c in context.Courses on reg.CourseId equals c.Id
                               join s in context.SessionSemesters on reg.SessionSemesterId equals s.Id
                               join le in context.Levels on reg.LevelId equals le.Id
                               join dep in context.Departments on st.DepartmentId equals dep.Id
                               join l in context.Staff on att.MarkedBy equals l.Id
                               where (studentId == ""
                                      || reg.StudentId == studentId)
                                     && reg.SessionSemesterId == semesterId
                                     && reg.CourseId == courseId
                                     && att.DateMarked.Date >= startDate
                                     && att.DateMarked.Date <= endDate
                               select new AttendanceList
                               {
                                   StudentMatricNo = st.MatricNo,
                                   StudentName = st.Lastname + ", " + st.Firstname + " " + st.Othername,
                                   StudentLevel = le.Level,
                                   Course = c.CourseCode + " - " + c.CourseTitle,
                                   DateMarked = att.DateMarked.Date,
                                   MarkedBy = l.Lastname + ", " + l.Firstname + " " + l.Othername,
                                   SessionSemester = s.Session + " - " + s.Semester,
                                   DepartmentName = dep.DepartmentName,
                               }
                ).ToList();
            var dt = attendances.GroupBy(x => new
            {
                x.StudentName,
                x.StudentMatricNo,
                x.StudentLevel,
                x.Course,
                x.SessionSemester,
                x.DepartmentName
            })
                .Select(y => new AttendanceReport
                {
                    StudentName = y.Key.StudentName,
                    StudentMatricNo = y.Key.StudentMatricNo,
                    StudentLevel = y.Key.StudentLevel,
                    Course = y.Key.Course,
                    SessionSemester = y.Key.SessionSemester,
                    DepartmentName = y.Key.DepartmentName,
                    Count = y.GroupBy(z => z.DateMarked.Date).Count(),
                    Dates = string.Join(", ", y.GroupBy(z => z.DateMarked.Date)
                        .OrderBy(x => x.Key)
                        .Select(a => a.Key.ToShortDateString())
                        .ToList())
                })
                .ToList();

            return dt;
        }

        public List<AttendanceReport> GetStaffAttendanceRecord(string semesterId, string courseId, DateTime startDate, DateTime endDate)
        {
            using var context = new SqliteContext();
            var attendances = (from att in context.Attendances
                               join reg in context.CourseRegistrations on att.CourseRegistrationId equals reg.Id
                               join c in context.Courses on reg.CourseId equals c.Id
                               join stc in context.StaffCourses on reg.CourseId equals stc.CourseId
                               join s in context.SessionSemesters on reg.SessionSemesterId equals s.Id
                               join l in context.Staff on att.MarkedBy equals l.Id
                               join ti in context.Titles on l.TitleId equals ti.Id
                               where reg.SessionSemesterId == semesterId
                                     && reg.CourseId == courseId
                                     && att.DateMarked.Date >= startDate
                                     && att.DateMarked.Date <= endDate
                               select new AttendanceList
                               {
                                   Course = c.CourseCode + " - " + c.CourseTitle,
                                   DateMarked = att.DateMarked.Date,
                                   MarkedBy = ti.Title + " " + l.Lastname + ", " + l.Firstname + " " + l.Othername,
                                   SessionSemester = s.Session + " - " + s.Semester,
                               }
                ).ToList();

            var dt = attendances.GroupBy(x => new
            {
                x.MarkedBy,
                x.Course,
                x.SessionSemester,
            })
                .Select(y => new AttendanceReport
                {
                    MarkedBy = y.Key.MarkedBy,
                    Course = y.Key.Course,
                    SessionSemester = y.Key.SessionSemester,
                    Count = y.GroupBy(z => z.DateMarked.Date).Count(),
                    Dates = string.Join(", ", y.GroupBy(z => z.DateMarked.Date)
                        .OrderBy(x => x.Key)
                        .Select(a => a.Key.ToShortDateString())
                        .ToList())
                })
                .ToList();

            return dt;
        }


        #endregion
    }
}
