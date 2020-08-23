using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AttendanceLibrary.DataContext;
using AttendanceLibrary.Model;

namespace AttendanceLibrary.BaseClass
{
    public static class Helper
    {
        #region MyRegion

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

        #endregion

        #region Database Helper

        private const string SuperAdminId = "45da7b79-a641-4f9d-971a-8c85c7c516ab";
        private const int NoOfFinger = 2;
        private const string DefaultPassword = "12345678";
        private const string SuperAdminNo = "000001";
        private const string SuperAdminPassword = "password123";
        private const string SuperAdminEmail = "admin@abc.com";
        private const string SuperAdminFirstname = "Admin";
        private const string SuperAdminLastname = "Admin";

        public static void SeedData()
        {
            try
            {
                // Initialize the database context (ensure the database is created, if it's a new database)
                //  using var db = new SqliteContext(SqliteContext.Defaultdbfile);
                using var db = new SqliteContext();
                db.Database.EnsureCreated();

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
            catch (Exception ex)
            {
                throw new Exception("An error has occured while initializing the database. " + ex.Message + " Inner exception: " + ex.InnerException);
            }


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
    }
}
