
using AttendanceLibrary.Model;
using AttendanceLibrary.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AttendanceLibrary.BaseClass;

namespace AttendanceLibrary.Repository
{
    public class StaffRepo
    {
        public string AddStaff(StaffDetail newStaff)
        {
            try
            {
                using (var context = new BASContext())
                {
                    if (context.Staff.Any(a => a.StaffNo == newStaff.StaffNo || a.Email == newStaff.Email && !a.IsDeleted))
                        return "Staff with this Staff number or Email address exists";

                    context.Staff.Add(newStaff);
                    return context.SaveChanges() > 0 ? "Staff added successfully" : "";
                }                    
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string AddBulkStaff(List<BulkStaff> data, string defaultpassword)
        {
            try
            {
                using (var context = new BASContext())
                {
                    return "";

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string DeleteStaff(int staffId)
        {
            using (var context = new BASContext())
            {
                if (context.Attendances.Any(a => a.MarkedBy == staffId))
                    return "Staff cannot be deleted because (s)he has marked attendance for a course";

                var staff = context.Staff.SingleOrDefault(a => a.Id == staffId);
                if (staff != null)
                {
                    //context.Staff.Remove(staff);
                    staff.IsDeleted = true;
                    return context.SaveChanges() > 0 ? "Staff deleted successfully" : "";
                }

                return "Staff not found";
            }                            
            
        }

        public List<StaffDetail> GetAllStaff()
        {
            try
            {
                using (var context = new BASContext())
                {                    
                    return context.Staff.Where(a => !a.IsDeleted).ToList();                   
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StaffDetail> GetAllDepartmentStaff(int departmentId)
        {
            try
            {
                using (var context = new BASContext())
                {
                    return context.Staff.Where(a => !a.IsDeleted && a.DepartmentId == departmentId).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public StaffDetail GetStaff(int staffId)
        {
            try
            {
                using (var context = new BASContext())
                {
                    return context.Staff.SingleOrDefault(a => a.Id == staffId  && !a.IsDeleted);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       

        public string UpdateStaff(StaffDetail staff)
        {
            using (var context = new BASContext())
            {
                var oldStaff = context.Staff.SingleOrDefault(a => a.Id == staff.Id && !a.IsDeleted);
                if (oldStaff == null)
                    return "Staff not found";

                if (context.Staff.Any(a => a.StaffNo == staff.StaffNo || a.Email == staff.Email && !a.IsDeleted && a.Id != staff.Id))
                    return "Staff with this Staff number or Email address exists";

                oldStaff.Email = staff.Email.ToLower();
                oldStaff.Firstname = staff.Firstname.ToTitleCase();
                oldStaff.IsAdmin = staff.IsAdmin;
                oldStaff.Lastname = staff.Lastname.ToTitleCase();
                oldStaff.Othername = staff.Othername.ToTitleCase();
                oldStaff.StaffNo = staff.StaffNo;
                oldStaff.TitleId = staff.TitleId;
                oldStaff.StaffNo = staff.StaffNo;
                oldStaff.DepartmentId = staff.DepartmentId;

                return context.SaveChanges() > 0 ? "Staff updated successfully" : "";
            }
        }

        public string UpdateStaffAdminStatus(int staffId, bool isAdmin)
        {
            using (var context = new BASContext())
            {
                var staff = context.Staff.SingleOrDefault(a => a.Id == staffId && !a.IsDeleted);
                if (staff == null)
                    return "Staff not found";

                staff.IsAdmin = isAdmin;
                return context.SaveChanges() > 0 
                    ? isAdmin 
                        ? "Staff is now an admin" : "Staff is no longer an admin" 
                    : "";

            }
        }
    }
}
