
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
    public class StaffRepo
    {
        public string AddStaff(StaffDetail newStaff)
        {
            try
            {
                using var context = new SqliteContext();
                if (context.Staff.Any(a => a.StaffNo == newStaff.StaffNo || a.Email == newStaff.Email && !a.IsDeleted))
                    return "Staff with this Staff number or Email address exists";

                var defaultPwd = context.SystemSettings.First().UserDefaultPassword;

                newStaff.Id = Guid.NewGuid().ToString();
                newStaff.Password = defaultPwd;
                context.Staff.Add(newStaff);
                return context.SaveChanges() > 0 ? "" : "Staff could not be added";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string AddBulkStaff(List<BulkStaff> data)
        {
            try
            {
                using var context = new SqliteContext();
                return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string DeleteStaff(string staffId)
        {
            using var context = new SqliteContext();
            if (context.Attendances.Any(a => a.MarkedBy == staffId))
                return "Staff cannot be deleted because (s)he has marked attendance for a course";

            var staff = context.Staff.SingleOrDefault(a => a.Id == staffId);
            if (staff != null)
            {
                //context.Staff.Remove(staff);
                staff.IsDeleted = true;
                return context.SaveChanges() > 0 ? "" : "Staff could not be updated";
            }

            return "Staff not found";
        }

        public List<StaffDetail> GetAllStaff()
        {
            try
            {
                using var context = new SqliteContext();
                return context.Staff.Where(a => !a.IsDeleted).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StaffDetail> GetDepartmentStaffSlim(string departmentId)
        {
            try
            {
                using var context = new SqliteContext();
                return context.Staff.Where(a => !a.IsDeleted && a.DepartmentId == departmentId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StaffList> GetDepartmentStaff(string departmentId)
        {
            try
            {
                using var context = new SqliteContext();
                var dt = (
                    from st in context.Staff
                    join dep in context.Departments on st.DepartmentId equals dep.Id 
                    join ti in context.Titles on st.TitleId equals ti.Id
                    where (departmentId == "" || st.DepartmentId == departmentId) && !st.IsDeleted
                    select new StaffList
                    {
                        Id = st.Id,
                        Department = dep.DepartmentName,
                        Email = st.Email,
                        PhoneNo = st.PhoneNo, 
                        Fullname = st.Lastname + ", " + st.Firstname + " " + st.Othername,
                        StaffNo = st.StaffNo,
                        Title = ti.Title,
                        IsSuperAdmin = st.IsSuperAdmin,
                        IsAdmin = st.IsAdmin
                    }).ToList();

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public StaffDetail GetStaff(string staffId)
        {
            try
            {
                using var context = new SqliteContext();
                return context.Staff.SingleOrDefault(a => a.Id == staffId  && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       

        public string UpdateStaff(StaffDetail staff)
        {
            using var context = new SqliteContext();
            var oldStaff = context.Staff.SingleOrDefault(a => a.Id == staff.Id && !a.IsDeleted);
            if (oldStaff == null)
                return "Staff not found";

            if (context.Staff.Any(a => (a.StaffNo == staff.StaffNo || a.Email == staff.Email && !a.IsDeleted) && a.Id != staff.Id))
                return "Staff with this Staff number or Email address exists";

            oldStaff.Email = staff.Email.ToLower();
            oldStaff.Firstname = staff.Firstname.ToTitleCase();
            oldStaff.IsAdmin = staff.IsAdmin;
            oldStaff.IsSuperAdmin = staff.IsSuperAdmin;
            oldStaff.Lastname = staff.Lastname.ToTitleCase();
            oldStaff.Othername = staff.Othername.ToTitleCase();
            oldStaff.StaffNo = staff.StaffNo;
            oldStaff.TitleId = staff.TitleId;
            oldStaff.StaffNo = staff.StaffNo;
            oldStaff.DepartmentId = staff.DepartmentId;

            if (context.SaveChanges() > 0)
            {
                if (LoggedInUser.UserId == staff.Id)
                {
                    LoggedInUser.IsSuperAdmin = staff.IsSuperAdmin;
                    LoggedInUser.IsAdmin = staff.IsAdmin;
                }
                return "";
            }

            return  "Staff could not be updated";
        }

        public string UpdateStaffAdminStatus(string staffId, bool isAdmin)
        {
            using var context = new SqliteContext();
            var staff = context.Staff.SingleOrDefault(a => a.Id == staffId && !a.IsDeleted);
            if (staff == null)
                return "Staff not found";

            staff.IsAdmin = isAdmin;
            return context.SaveChanges() > 0 
                ? ""
                : "Operation failed";
        }
    }
}
