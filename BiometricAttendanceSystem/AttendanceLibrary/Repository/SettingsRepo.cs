using AttendanceLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AttendanceLibrary.BaseClass;

namespace AttendanceLibrary.Repository
{
    public class SettingsRepo
    {
        public SystemSetting GetSetting()
        {
            try
            {
                using (var context = new BASContext())
                {
                    return context.SystemSettings.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdateSetting(SystemSetting setting)
        {
            using (var context = new BASContext())
            {
                var oldSetting = context.SystemSettings.FirstOrDefault();
                if (oldSetting == null)
                    return "Setting not found";

                oldSetting.SuperAdminFirstname = setting.SuperAdminFirstname;
                oldSetting.SuperAdminLastname = setting.SuperAdminLastname;
                oldSetting.SuperAdminNo = setting.SuperAdminNo;
                oldSetting.SuperAdminEmail = setting.SuperAdminEmail;
                oldSetting.SuperAdminPassword = PasswordHash.sha256(setting.SuperAdminPassword);
                oldSetting.NoOfFinger = setting.NoOfFinger;

                return context.SaveChanges() > 0 ? "Setting updated successfully" : "";
            }
        }
    }
}
