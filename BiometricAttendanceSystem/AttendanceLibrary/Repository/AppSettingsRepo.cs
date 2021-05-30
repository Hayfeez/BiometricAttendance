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
    public class AppSettingsRepo : DisposeContext
    {
        private readonly AttendanceContext _context = Helper.GetDataContext();

        public AppSetting GetSetting()
        {
            try
            {
                return _context.AppSettings.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdateSetting(AppSetting setting)
        {
            var oldSetting = _context.AppSettings.FirstOrDefault();
            if (oldSetting == null)
                return "Setting not found";

            oldSetting.ApplicationName = setting.ApplicationName;
            oldSetting.Title = setting.Title;
            oldSetting.SubTitle = setting.SubTitle;
            oldSetting.LogoBase64 = setting.LogoBase64;
            oldSetting.PrimaryColor = setting.PrimaryColor;
            oldSetting.SecondaryColor = setting.SecondaryColor;

            // do on local
            var _localContext = Helper.GetDataContext(true);
            var oldSettingLocal = _localContext.AppSettings.First();

            oldSettingLocal.ApplicationName = setting.ApplicationName;
            oldSettingLocal.Title = setting.Title;
            oldSettingLocal.SubTitle = setting.SubTitle;
            oldSettingLocal.LogoBase64 = setting.LogoBase64;
            oldSettingLocal.PrimaryColor = setting.PrimaryColor;
            oldSettingLocal.SecondaryColor = setting.SecondaryColor;
            _localContext.SaveChanges();

            return _context.SaveChanges() > 0 ? "" : "Settings could not be updated";
        }

        public string SaveConnectionString(string server, string dbname, string username, string password)
        {
            var localContext = Helper.GetDataContext(true);
            var oldSetting = localContext.AppSettings.FirstOrDefault();
            if (oldSetting == null)
                return "Setting not found";

            oldSetting.DatabaseServer = server;
            oldSetting.DbUsername = username;
            oldSetting.DatabaseName = dbname;
            oldSetting.DbPassword = StringCipher.Encrypt(password);

            if (localContext.SaveChanges() > 0)
            {
                ApplicationSetting.DatabaseServer = server;
                ApplicationSetting.DatabaseName = dbname;
                ApplicationSetting.DbPassword = password;
                ApplicationSetting.DbUsername = username;

                return "";
            }

            return "Settings could not be updated";
        }

    }
}
