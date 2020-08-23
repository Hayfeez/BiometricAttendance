
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
    public class AuthRepo
    {
        public string StaffChangePassword(ChangePassword pwd)
        {
            try
            {
                pwd.OldPassword = PasswordHash.sha256(pwd.OldPassword);
                pwd.NewPassword = PasswordHash.sha256(pwd.NewPassword);
                using (var context = new SqliteContext())
                {
                    var d = context.Staff.SingleOrDefault(a => a.Email == pwd.Email && a.Password == pwd.OldPassword);
                    if (d == null)
                        return "Current Password is not valid";

                    d.Password = pwd.NewPassword;
                    d.PasswordChanged = true;

                    return context.SaveChanges() > 0 ? "" : "Password could not be updated";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string StaffSignOut()
        {
            return "";
        }

        public ChangePassword StaffForgotPassword(ForgotPassword model)
        {
            try
            {
                using (var context = new SqliteContext())
                {
                    var d = context.Staff.SingleOrDefault(a => a.Email == model.Email);
                    if (d == null) return null;
                    return new ChangePassword
                    {
                        Email = d.Email,
                        IsReset = true,
                        OldPassword = d.Password
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool StaffLogin(Login model)
        {
            try
            {
                using (var context = new SqliteContext())
                {

                    var staff = context.Staff.SingleOrDefault(a => !a.IsDeleted && a.Email == model.Email && a.Password == model.Password);
                    if (staff == null)
                    {
                        var superAdmin = context.SystemSettings.SingleOrDefault(a => a.SuperAdminEmail == model.Email && a.SuperAdminPassword == model.Password);
                        if (superAdmin == null)
                            return false;

                        LoggedInUser.UserId = superAdmin.Id;
                        LoggedInUser.Email = superAdmin.SuperAdminEmail;
                        LoggedInUser.Fullname = $"{superAdmin.SuperAdminLastname}, {superAdmin.SuperAdminFirstname}";
                        LoggedInUser.IsAdmin = true;
                        LoggedInUser.IsSuperAdmin = true;
                        LoggedInUser.PasswordChanged = true;
                        LoggedInUser.Department = "System Administrator";
                        return true;
                    }

                    var deptRepo = new DepartmentRepo();

                    LoggedInUser.UserId = staff.Id;
                    LoggedInUser.Email = staff.Email;
                    LoggedInUser.Fullname = staff.Fullname;
                    LoggedInUser.IsAdmin = staff.IsAdmin;
                    LoggedInUser.IsSuperAdmin = staff.IsSuperAdmin;
                    LoggedInUser.PasswordChanged = staff.PasswordChanged;
                    LoggedInUser.Department = deptRepo.GetDepartment(staff.DepartmentId)?.DepartmentName;

                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       

    }
}
