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
    public class DashboardRepo
    {
        public int GetStudentCount()
        {
            try
            {
                using var context = new SqliteContext();
                return context.Students.Count(a => !a.IsDeleted && !a.IsGraduated);
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
                using var context = new SqliteContext();
                return context.Staff.Count(a => !a.IsDeleted);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StaffCourseRegCount> GetCourseAttendanceCount(string userId, string semesterId)
        {
            return new ReportRepo().GetStaffCourseAttendanceCount(semesterId, false);
        }

        public List<StaffCourseRegCount> GetCourseRegCount(string userId, string semesterId)
        {
            if (userId == Helper.SuperAdminId)
                userId = "";

            return new ReportRepo().GetStaffCourseRegCount(semesterId, userId);
        }

    }
}
