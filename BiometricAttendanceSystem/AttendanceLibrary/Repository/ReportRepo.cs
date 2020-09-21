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
    public class ReportRepo : DisposeContext
    {
        private readonly AttendanceContext _context = Helper.GetDataContext();

        public IEnumerable<EnumValueModel> GetReportType()
        {
            return Helper.GetEnumValuesAndDescriptions<ReportType>();
        }

        public string GetReportDescription(int value)
        {
            return Helper.GetEnumValuesAndDescriptions<ReportType>()
                .FirstOrDefault(x=>x.Value.ToString() == value.ToString())?.Name;
        }

        #region reports

        public List<AttendanceReport> GetStudentAttendanceRecord(string semesterId, string courseId, string studentId, DateTime startDate, DateTime endDate)
        {
            //startDate ??= DateTime.MinValue.Date;
            //endDate ??= DateTime.MaxValue.Date;

            
            var attendances = (from att in _context.Attendances
                               join reg in _context.CourseRegistrations on att.CourseRegistrationId equals reg.Id
                               join st in _context.Students on reg.StudentId equals st.Id
                               join c in _context.Courses on reg.CourseId equals c.Id
                               join s in _context.SessionSemesters on reg.SessionSemesterId equals s.Id
                               join le in _context.Levels on reg.LevelId equals le.Id
                               join dep in _context.Departments on st.DepartmentId equals dep.Id
                               join l in _context.Staff on att.MarkedBy equals l.Id
                               where (studentId == ""
                                      || reg.StudentId == studentId)
                                     && reg.SessionSemesterId == semesterId
                                     && reg.CourseId == courseId
                                     && att.DateMarked.Date >= startDate
                                     && att.DateMarked.Date <= endDate
                                     && !st.IsDeleted && !st.IsGraduated
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
            
            var attendances = (from att in _context.Attendances
                               join reg in _context.CourseRegistrations on att.CourseRegistrationId equals reg.Id
                               join c in _context.Courses on reg.CourseId equals c.Id
                               join stc in _context.StaffCourses on reg.CourseId equals stc.CourseId
                               join s in _context.SessionSemesters on reg.SessionSemesterId equals s.Id
                               join l in _context.Staff on att.MarkedBy equals l.Id
                               join ti in _context.Titles on l.TitleId equals ti.Id
                               where reg.SessionSemesterId == semesterId
                                     && reg.CourseId == courseId
                                     && att.DateMarked.Date >= startDate
                                     && att.DateMarked.Date <= endDate
                                     && !l.IsDeleted
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
