using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;

using AttendanceLibrary.DataContext;
using AttendanceLibrary.Model;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace AttendanceLibrary.BaseClass
{
    public enum ReportType
    {
        [Description("Student Attendance Record")]
        studentAttendanceByCourse = 1,
        [Description("Staff Attendance Record")]
        staffAttendanceByCourse = 2

    }

    public class EnumValueModel
    {
        public string Name { get; set; }

        public object Value { get; set; }
    }

    public static class Helper
    {

        #region MyRegion

        public const string DatabaseName = "SchoolAttendanceDb";
        public const string SuperAdminId = "45da7b79-a641-4f9d-971a-8c85c7c516ab";
        private const int NoOfFinger = 2;
        private const string DefaultPassword = "12345678";
        private const string SuperAdminNo = "000001";
        private const string SuperAdminPassword = "password123";
        private const string SuperAdminEmail = "admin@abc.com";
        private const string SuperAdminFirstname = "Admin";
        private const string SuperAdminLastname = "Admin";
        public const string PrimaryColor = "54,78,114";
        public const string SecondaryColor = "152,201,60";

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }

        public static string GetMacAddress()
        {
            return NetworkInterface
                .GetAllNetworkInterfaces()
                .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                .Select(nic => nic.GetPhysicalAddress().ToString())
                .FirstOrDefault();
        }

        public static string GetConnectionStringFromSettings()
        {
            return Properties.Settings.Default.SqlServerConnectionString;
        }

        public static bool SaveConnectionStringInSettings(string server, string username, string password)
        {
            Properties.Settings.Default.SqlServerConnectionString = $"Data Source={server};Initial Catalog={DatabaseName};User Id={username};Password={password}";
            Properties.Settings.Default.Save();

           return true;
        }

        public static bool TestConnectionString(string server, string username, string password, string dbName = DatabaseName)
        {
            var conString = $"Data Source={server};Initial Catalog={dbName};User Id={username};Password={password}";
            using var connection = new SqlConnection(conString);
            try
            {
                connection.Open();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        #endregion

        #region Database Helper

        public static AttendanceContext GetDataContext(bool isSqlite = false)
        {
            if (isSqlite)
                return new SqliteContext();

            return new SqlServerContext();
        }

        public static SqlServerContext GetRemoteOnlyContext()
        {
            return new SqlServerContext();
        }

        public static SqliteContext GetLocalOnlyContext()
        {
            return new SqliteContext();
        }

        public static bool CheckRemoteServerConnection()
        {
            try
            {
                // GetDataContext().Database.OpenConnection();
                var context = GetDataContext();
                context.Database.SetCommandTimeout(3);
                return context.Database.CanConnect();
            }
            catch (SqlException e)
            {
                return false;
            }
        }

        public static void SeedData()
        {
            try
            {
                using var localDb = GetDataContext(true);
                //localDb.Database.EnsureCreated();
                localDb.Database.Migrate();

                if (!localDb.AppSettings.Any())
                {
                    localDb.AppSettings.Add(SeedAppSetting());
                }

                using var db = GetDataContext();
                if (CheckRemoteServerConnection())
                {
                    //   db.Database.EnsureCreated();
                    db.Database.Migrate();

                    if (!db.AppSettings.Any())
                    {
                        db.AppSettings.Add(SeedAppSetting());
                    }

                    if (!db.SystemSettings.Any())
                        db.SystemSettings.Add(new SystemSetting
                        {
                            Id = SuperAdminId,
                            NoOfFinger = NoOfFinger,
                            SuperAdminEmail = SuperAdminEmail,
                            SuperAdminFirstname = SuperAdminFirstname,
                            SuperAdminLastname = SuperAdminLastname,
                            SuperAdminNo = SuperAdminNo,
                            SuperAdminPassword = PasswordHash.sha256(SuperAdminPassword),
                            UserDefaultPassword = PasswordHash.sha256(DefaultPassword)
                        });

                    if (!db.Levels.Any())
                        db.Levels.AddRange(Levels());

                    if (!db.Titles.Any())
                        db.Titles.AddRange(Titles());

                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error has occured while initializing the database. " + ex.Message + " Inner exception: " + ex.InnerException);
            }
        }

        private static AppSetting SeedAppSetting()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var imagePath = $"{Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\"))}Resources\\biometric.png";

            var imageArray = File.ReadAllBytes(imagePath);
            var base64ImageRepresentation = Convert.ToBase64String(imageArray);

            return new AppSetting
            {
                Id = SuperAdminId,
                ApplicationName = "Biometric Attendance System",
                Title = "University of Ilorin",
                SubTitle = "Information and Communication Science",
                PrimaryColor = PrimaryColor,
                SecondaryColor = SecondaryColor,
                LogoBase64 = base64ImageRepresentation
            };
        }

        private static List<PersonTitle> Titles()
        {
            var titles = new List<PersonTitle>
            {
                new PersonTitle { Id = Guid.NewGuid().ToString(), Title = "Mr."},
                new PersonTitle { Id = Guid.NewGuid().ToString(), Title = "Dr."},
                new PersonTitle { Id = Guid.NewGuid().ToString(), Title = "Miss"},
                new PersonTitle { Id = Guid.NewGuid().ToString(), Title = "Mrs"},
                new PersonTitle { Id = Guid.NewGuid().ToString(), Title = "Dr.(Miss)"},
                new PersonTitle { Id = Guid.NewGuid().ToString(), Title = "Dr.(Mrs)"},
                new PersonTitle { Id = Guid.NewGuid().ToString(), Title = "Prof."},
                new PersonTitle { Id = Guid.NewGuid().ToString(), Title = "Prof.(Mrs)"}
            };

            return titles;
        }

        private static List<StudentLevel> Levels()
        {
            var levels = new List<StudentLevel>
            {
                new StudentLevel() { Id = Guid.NewGuid().ToString(), Level = "100"},
                new StudentLevel() { Id = Guid.NewGuid().ToString(), Level = "200"},
                new StudentLevel() { Id = Guid.NewGuid().ToString(), Level = "300"},
                new StudentLevel() { Id = Guid.NewGuid().ToString(), Level = "400"},
                new StudentLevel() { Id = Guid.NewGuid().ToString(), Level = "500"}
            };

            return levels;
        }

        #endregion

        public static void SetApplicationSettings()
        {
            using var localDb = GetDataContext(true);
            var appSetting = localDb.AppSettings.Single();
            ApplicationSetting.ApplicationName = appSetting.ApplicationName;
            ApplicationSetting.Title = appSetting.Title;
            ApplicationSetting.SubTitle = appSetting.SubTitle;
            ApplicationSetting.LogoBytes  = Convert.FromBase64String(appSetting.LogoBase64);

            var primaryColor = appSetting.PrimaryColor.Split(',');
            var primaryColorInt = Array.ConvertAll(primaryColor, int.Parse);

            // int[] myInts = Array.ConvertAll(primaryColor, s => int.Parse(s));
            //int[] myInts = primaryColor.Select(int.Parse).ToArray();

            var secColor = appSetting.SecondaryColor.Split(',');
            var secColorInt = Array.ConvertAll(secColor, int.Parse);

            ApplicationSetting.PrimaryColorRed = primaryColorInt[0];
            ApplicationSetting.PrimaryColorGreen = primaryColorInt[1];
            ApplicationSetting.PrimaryColorBlue = primaryColorInt[2];

            ApplicationSetting.SecondaryColorRed = secColorInt[0];
            ApplicationSetting.SecondaryColorGreen = secColorInt[1];
            ApplicationSetting.SecondaryColorBlue = secColorInt[2];
        }

        public static byte[] ConvertToByteArray(Bitmap value)
        {
            byte[] bitmapBytes;
            using (var stream = new MemoryStream())
            {
                value.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                bitmapBytes = stream.ToArray();
            }
            return bitmapBytes;
        }

        public static List<EnumValueModel> GetEnumValuesAndDescriptions<T>()
        {
            Type enumType = typeof(T);

            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("T is not System.Enum");

            var enumValList = new List<EnumValueModel>();

            foreach (var e in Enum.GetValues(typeof(T)))
            {
                var fi = e.GetType().GetField(e.ToString());
                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                enumValList.Add(new EnumValueModel
                {
                    Value = (int) e,
                    Name = (attributes.Length > 0) ? attributes[0].Description : e.ToString()
                });
            }

            return enumValList;
        }
    }
}
