
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
    public class StaffRepo : DisposeContext
    {
        private readonly AttendanceContext _context = Helper.GetDataContext();

        public string AddStaff(StaffDetail newStaff)
        {
            try
            {
                
                if (_context.Staff.Any(a => a.StaffNo == newStaff.StaffNo || a.Email == newStaff.Email && !a.IsDeleted))
                    return "Staff with this Staff number or Email address exists";

                var defaultPwd = _context.SystemSettings.First().UserDefaultPassword;

                newStaff.Id = Guid.NewGuid().ToString();
                newStaff.Password = defaultPwd;
                _context.Staff.Add(newStaff);
                return _context.SaveChanges() > 0 ? "" : "Staff could not be added";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string AddBulkStaff(List<BulkStaff> data, string deptId)
        {
            try
            {
                var existing = _context.Staff.Where(x => x.Email != string.Empty)
                    .Select(x => new
                    {
                        x.StaffNo,
                        x.Email
                    })
                    .ToHashSet();

                var existingStaffNos = existing.Select(x => x.StaffNo).ToHashSet();
                var existingEmails = existing.Select(x => x.Email).ToHashSet();

                var defaultPwd = _context.SystemSettings.First().UserDefaultPassword;
                var toAdd = new List<StaffDetail>();
                var titleRepo = new TitleRepo();
                foreach (var item in data)
                {
                    var titleId = titleRepo.GetTitleId(item.Title);
                    if (titleId == null)
                    {
                        return "No record saved. At least one title does not exist";
                    }
                    if (!existingEmails.Contains(item.Email) && !existingStaffNos.Contains(item.StaffNo))
                    {
                        toAdd.Add(new StaffDetail()
                        {
                            Id = Guid.NewGuid().ToString(),
                            StaffNo = item.StaffNo,
                            Lastname = item.Lastname,
                            Firstname = item.Firstname,
                            Othername = item.Othername,
                            Email = item.Email,
                            PhoneNo = item.PhoneNo,
                            DepartmentId = deptId,
                            Password = defaultPwd,
                            TitleId = titleId
                        });
                    }
                }

                _context.Staff.AddRange(toAdd);
                return _context.SaveChanges() > 0 ? "" : "No new student added";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteStaff(string staffId)
        {
            
            if (_context.Attendances.Any(a => a.MarkedBy == staffId))
                return "Staff cannot be deleted because (s)he has marked attendance for a course";

            var staff = _context.Staff.SingleOrDefault(a => a.Id == staffId);
            if (staff != null)
            {
                //_context.Staff.Remove(staff);
                staff.IsDeleted = true;
                return _context.SaveChanges() > 0 ? "" : "Staff could not be updated";
            }

            return "Staff not found";
        }

        public List<StaffDetail> GetAllStaff()
        {
            try
            {
                return _context.Staff.Where(a => !a.IsDeleted).ToList();
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
                
                return _context.Staff.Where(a => !a.IsDeleted && a.DepartmentId == departmentId).ToList();
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
                
                var dt = (
                    from st in _context.Staff
                    join dep in _context.Departments on st.DepartmentId equals dep.Id 
                    join ti in _context.Titles on st.TitleId equals ti.Id
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
                
                return _context.Staff.SingleOrDefault(a => a.Id == staffId  && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       

        public string UpdateStaff(StaffDetail staff)
        {
            
            var oldStaff = _context.Staff.SingleOrDefault(a => a.Id == staff.Id && !a.IsDeleted);
            if (oldStaff == null)
                return "Staff not found";

            if (_context.Staff.Any(a => (a.StaffNo == staff.StaffNo || a.Email == staff.Email && !a.IsDeleted) && a.Id != staff.Id))
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

            if (_context.SaveChanges() > 0)
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
            
            var staff = _context.Staff.SingleOrDefault(a => a.Id == staffId && !a.IsDeleted);
            if (staff == null)
                return "Staff not found";

            staff.IsAdmin = isAdmin;
            return _context.SaveChanges() > 0 
                ? ""
                : "Operation failed";
        }
    }
}
