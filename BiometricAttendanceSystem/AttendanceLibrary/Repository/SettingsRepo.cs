using AttendanceLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AttendanceLibrary.BaseClass;
using AttendanceLibrary.DataContext;

namespace AttendanceLibrary.Repository
{
    public class SettingsRepo : DisposeContext
    {
        private readonly AttendanceContext _context = Helper.GetDataContext();

        public SystemSetting GetSetting()
        {
            try
            {
                return _context.SystemSettings.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdateSetting(SystemSetting setting)
        {
            var oldSetting = _context.SystemSettings.FirstOrDefault();
            if (oldSetting == null)
                return "Setting not found";

            if (setting.NoOfFinger > 5)
                return "Number of fingers cannot be more than 5";

            oldSetting.SuperAdminFirstname = setting.SuperAdminFirstname;
            oldSetting.SuperAdminLastname = setting.SuperAdminLastname;
            oldSetting.SuperAdminEmail = setting.SuperAdminEmail;
            oldSetting.SuperAdminPassword = PasswordHash.sha256(setting.SuperAdminPassword);
            oldSetting.UserDefaultPassword = PasswordHash.sha256(setting.UserDefaultPassword);
            oldSetting.NoOfFinger = setting.NoOfFinger;

            return _context.SaveChanges() > 0 ? "" : "Settings could not be updated";
        }
    }
}
