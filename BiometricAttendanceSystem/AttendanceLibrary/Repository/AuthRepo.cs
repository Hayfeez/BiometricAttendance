
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
    public class AuthRepo  : DisposeContext
    {
        private readonly AttendanceContext _localContext = Helper.GetDataContext(true);
        private readonly AttendanceContext _remoteContext = Helper.GetDataContext();

        public string StaffChangePassword(ChangePassword pwd)
        {
            try
            {
                pwd.OldPassword = PasswordHash.sha256(pwd.OldPassword);
                pwd.NewPassword = PasswordHash.sha256(pwd.NewPassword);

                var d = _remoteContext.Staff.SingleOrDefault(a => a.Email == pwd.Email && a.Password == pwd.OldPassword);
                if (d == null)
                    return "Current Password is not valid";

                d.Password = pwd.NewPassword;
                d.PasswordChanged = true;

                if (_remoteContext.SaveChanges() > 0)
                {
                    //change the password on local sqlite
                    var s = _localContext.Staff.Single(a => a.Email == pwd.Email);
                   
                    s.Password = pwd.NewPassword;
                    s.PasswordChanged = true;
                    _localContext.SaveChanges();

                    return "";
                }
                else
                {
                    return "Password could not be updated";
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

        public string StaffForgotPassword(ForgotPassword model)
        {
            try
            {
                var remoteOnlyContext = Helper.GetRemoteOnlyContext();
                var d = remoteOnlyContext.Staff.SingleOrDefault(a => a.Email == model.Email 
                                                                     && a.StaffNo.ToLower() == model.StaffNo.ToLower());
                if (d == null)
                    return "Incorrect credentials";

                if (remoteOnlyContext.PasswordResets.Any(x => x.UserId == d.Id && !x.IsReset))
                {
                    return "There is a pending password reset request awaiting admin action";
                }

                remoteOnlyContext.PasswordResets.Add(new PasswordReset
                {
                    Id = Guid.NewGuid().ToString(),
                    UserId = d.Id,
                    RequestingSystemId = model.SystemId,
                    DateRequested = DateTime.Now
                });

                if (remoteOnlyContext.SaveChanges() > 0)
                {
                    return "";
                }
                
                return "An error occured";
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string AdminResetPassword(string userId, string resetBy)
        {
            try
            {
                if (string.Equals(userId, resetBy))
                {
                    return "You cannot reset your own password";
                }

                var remoteOnlyContext = Helper.GetRemoteOnlyContext();
                var d = remoteOnlyContext.Staff.SingleOrDefault(a => a.Id == userId);
                if (d == null)
                    return "User not found";

                var resetRequest = remoteOnlyContext.PasswordResets.SingleOrDefault(x => x.UserId == userId && !x.IsReset);
                if (resetRequest == null)
                {
                    return "There is no pending password reset request for this user";
                }

                var systemSetting = remoteOnlyContext.SystemSettings.Single();
                d.Password = systemSetting.UserDefaultPassword;
                d.PasswordChanged = false;

                resetRequest.IsReset = true;
                resetRequest.ResetBy = resetBy;
                resetRequest.DateReset = DateTime.Now;

                if (remoteOnlyContext.SaveChanges() > 0)
                {
                    return "";
                }

                return "An error occured while resetting password";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PasswordResetList> GetPasswordResetRequests()
        {
            try
            {
                var remoteOnlyContext = Helper.GetRemoteOnlyContext();
                var resetRequests = (from request in remoteOnlyContext.PasswordResets
                                     join user in remoteOnlyContext.Staff on request.UserId equals user.Id
                                     join resetBy in remoteOnlyContext.Staff on request.ResetBy equals resetBy.Id into resetByUser
                                     from resetBy in resetByUser.DefaultIfEmpty()
                                     orderby request.DateRequested descending 
                                     select new PasswordResetList
                                     {
                                         DateRequested = request.DateRequested,
                                         DateReset = request.DateReset,
                                         IsReset = request.IsReset,
                                         Id = request.Id,
                                         UserId = request.UserId,
                                         RequestingSystemId = request.RequestingSystemId,
                                         ResetBy = resetBy.Lastname + ", " + resetBy.Firstname + " " + resetBy.Othername,
                                         User = user.Lastname + ", " + user.Firstname + " " + user.Othername,
                                     }).ToList();
                
                return resetRequests;
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
                var staff = _localContext.Staff.SingleOrDefault(a => !a.IsDeleted && a.Email == model.Email && a.Password == model.Password);
                if (staff == null)
                {
                    var superAdmin = _localContext.SystemSettings.SingleOrDefault(a => a.SuperAdminEmail == model.Email && a.SuperAdminPassword == model.Password);
                    if (superAdmin == null)
                        return false;

                    LoggedInUser.UserId = superAdmin.Id;
                    LoggedInUser.Email = superAdmin.SuperAdminEmail;
                    LoggedInUser.Fullname = $"{superAdmin.SuperAdminLastname}, {superAdmin.SuperAdminFirstname}";
                    LoggedInUser.IsAdmin = true;
                    LoggedInUser.IsSuperAdmin = true;
                    LoggedInUser.PasswordChanged = true;
                    return true;
                }

                LoggedInUser.UserId = staff.Id;
                LoggedInUser.Email = staff.Email;
                LoggedInUser.Fullname = staff.Fullname;
                LoggedInUser.IsAdmin = staff.IsAdmin;
                LoggedInUser.IsSuperAdmin = staff.IsSuperAdmin;
                LoggedInUser.PasswordChanged = staff.PasswordChanged;

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool StaffLoginWithFingerPrint(string id)
        {
            try
            {
                var staff = _localContext.Staff.SingleOrDefault(a => !a.IsDeleted && a.Id == id);
                if (staff == null)
                {
                    return false;
                }

                LoggedInUser.UserId = staff.Id;
                LoggedInUser.Email = staff.Email;
                LoggedInUser.Fullname = staff.Fullname;
                LoggedInUser.IsAdmin = staff.IsAdmin;
                LoggedInUser.IsSuperAdmin = staff.IsSuperAdmin;
                LoggedInUser.PasswordChanged = staff.PasswordChanged;

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StaffFingerprint> GetStaffFingersForSignIn()
        {
            try
            {
                var d = (from c in _localContext.Staff
                         where !c.IsDeleted 
                         join st in _localContext.StaffFingers on c.Id equals st.StaffId into staffFingers
                         from fings in staffFingers
                         select new StaffFingerprint
                         {
                             Fingerprint = fings.Fingerprint,
                             Id = fings.Id,
                             StaffId = fings.StaffId,
                             Email = c.Email
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
