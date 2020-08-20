using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AttendanceLibrary.Model;

namespace AttendanceLibrary.BaseClass
{
    public class SQLiteHandler
    {
        public static SQLiteConnection conn;
        static readonly string DataFolder = @"C:\BAS4196D-621C-478A-81F7-49J16EF2B"; // AppDomain.CurrentDomain.BaseDirectory; //;
        public static string SQLiteDB = DataFolder + @"\BAS.sqlite";
       
        public static string ConnectionString()
        {
            conn = new SQLiteConnection("Data Source=" + SQLiteDB + "; Version = 3; New = True; Compress = True; Default TimeOut=30; Max Pool Size=100");
            return conn.ConnectionString;
        }
        private static SQLiteConnection con = new SQLiteConnection(SQLiteHandler.ConnectionString());

        public static bool CreateSqliteDb()
        {         
            try
            {
                if (!Directory.Exists(DataFolder))
                {
                    Directory.CreateDirectory(DataFolder);
                }

                if (File.Exists(SQLiteDB))
                    return true;

                else
                {
                    SQLiteConnection.CreateFile(SQLiteDB);
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error has occured while creating the database. " + ex.Message + " Inner exception: " + ex.InnerException);
            }

            
        }

        public static void CreateTable()
        {
            try
            {
                var tablesSql = "Create TABLE if not exists PersonTitle(Id varchar(50) Primary Key, Title varchar(50) not null, IsDeleted bit not null default 0); " +
                    "Create TABLE IF NOT EXISTS StudentLevel(Id varchar(50) Primary Key, Level varchar(5) not null, IsDeleted bit not null default 0);" +
                    "Create Table if not exists Department(Id varchar(50) Primary Key,  DepartmentName varchar(200), DepartmentCode varchar(10), IsDeleted bit not null default 0);" +
                    "Create TABLE if not exists StudentDetail(Id varchar(50) Primary Key, MatricNo varchar(50) not null, Firstname varchar(50) not null, Othername varchar(50), Lastname varchar(50) not null, Email varchar(150), DepartmentId varchar(50) not null, PhoneNo varchar(11),  IsGraduated bit not null default 0, IsDeleted bit not null default 0);" +
                    "Create table if not exists StaffDetail(Id varchar(50) Primary Key, StaffNo varchar(50) not null, Firstname varchar(50) not null, Othername varchar(50), Lastname varchar(50) not null, Email varchar(150), PhoneNo varchar(11), DepartmentId varchar(50), TitleId varchar(50), Password varchar(50) not null, IsAdmin bit not null, PasswordChanged bit not null default 0, IsSuperAdmin bit not null default 0, IsDeleted bit not null default 0);" +
                    "Create Table if not exists Course(Id varchar(50) Primary Key, DepartmentId varchar(50) not null, LevelId varchar(50) not null, CourseTitle varchar(200), CourseCode varchar(10), IsDeleted bit not null default 0);" +
                    "Create Table if not exists SessionSemester(Id varchar(50) Primary Key,  Session varchar(50), Semester varchar(50), IsActive bit not null default 0, IsDeleted bit not null default 0 ); " +
                    "Create Table if not exists StudentFinger(Id varchar(50) Primary Key, StudentId varchar(50) not null, FingerTemplate BLOB);" +
                    "Create Table if not exists CourseRegistration(Id varchar(50) Primary Key, SessionSemesterId varchar(50) not null, StudentId varchar(50) not null, CourseId varchar(50) not null, LevelId varchar(50) not null, RegisteredBy varchar(50) not null, DateRegistered datetime); " +
                    "Create Table if not exists Attendance(Id varchar(50) Primary Key, CourseRegistrationId varchar(50) not null, MarkedBy varchar(50) not null, DateMarked datetime); " +
                    "Create Table if not exists SystemSetting(Id varchar(50) Primary Key, NoOfFinger int not null, SuperAdminLastname varchar(50) not null,  SuperAdminFirstname varchar(50) not null,  SuperAdminEmail varchar(150) not null,  SuperAdminPassword varchar(500) not null, SuperAdminNo varchar(50) not null); ";

                var cmd = new SQLiteCommand(tablesSql, con)
                {
                    CommandType = CommandType.Text,
                    CommandTimeout = 0
                };
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("An error has occured while creating the database tables. " + ex.Message + " Inner exception: " + ex.InnerException);
            }
            finally
            {
                if (conn != null)
                {
                    con.Close();
                    conn.Close();
                }
            }
        }

         public static void SeedData()
        {
            try
            {
                var cmd = new SQLiteCommand("select count(Id) from SystemSetting ", con)
                {
                    CommandType = CommandType.Text,
                    CommandTimeout = 0
                };
                con.Open();
                var ret = int.Parse(cmd.ExecuteScalar().ToString());
                if(ret < 1)
                {                    
                    var encryptPwd = PasswordHash.sha256(Constants.SuperAdminPassword);
                    var seedQuery = $"insert into SystemSetting(Id, NoOfFinger, SuperAdminLastname, SuperAdminFirstname, SuperAdminEmail, SuperAdminPassword, SuperAdminNo) values " +
                     $"('{Guid.NewGuid().ToString()}', '{Constants.NoOfFinger}','{Constants.SuperAdminLastname}', '{Constants.SuperAdminFirstname}', '{Constants.SuperAdminEmail}', '{encryptPwd}', {Constants.SuperAdminNo});";
                   
                    foreach (var item in Titles())
                    {
                        seedQuery += $"insert into PersonTitle(Id, Title) values ('{item.Id}', '{item.Title}');";
                    }

                    foreach (var item in Levels())
                    {
                        seedQuery += $"insert into StudentLevel(Id, Level) values ('{item.Id}', '{item.Level}');";
                    }

                    cmd = new SQLiteCommand(seedQuery, con)
                    {
                        CommandType = CommandType.Text,
                        CommandTimeout = 0
                    };
                    cmd.ExecuteNonQuery();
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception("An error has occured while saving seed data. " + ex.Message + " Inner exception: " + ex.InnerException);
            }
            finally
            {
                if (conn != null)
                {
                    con.Close();
                    conn.Close();
                }
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
    }
}
