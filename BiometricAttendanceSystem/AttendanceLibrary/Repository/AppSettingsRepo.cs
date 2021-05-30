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

            return _context.SaveChanges() > 0 ? "" : "Settings could not be updated";
        }

        public string GetConnectionString()
        {
            try
            {
                var setting = _context.AppSettings.FirstOrDefault();
                return $"Data Source={setting?.DatabaseServer};Initial Catalog={setting?.DatabaseName};User Id={setting?.DbUsername};Password={setting?.DbPassword}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string SaveConnectionString(string server, string dbname, string username, string password)
        {
            var oldSetting = _context.AppSettings.FirstOrDefault();
            if (oldSetting == null)
                return "Setting not found";

            oldSetting.DatabaseServer = server;
            oldSetting.DbUsername = username;
            oldSetting.DatabaseName = dbname;
            oldSetting.DbPassword = password;

            return _context.SaveChanges() > 0 ? "" : "Settings could not be updated";
        }

    }
}
