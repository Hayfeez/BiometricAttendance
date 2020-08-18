﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceLibrary.BaseClass
{
    public class SQLiteHandler
    {
        public static SQLiteConnection conn;
        static readonly string DataFolder = @"C:\BAS3196D-621C-478A-81F7-39J16EF4A"; // AppDomain.CurrentDomain.BaseDirectory; //;
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
                string tablesSql = "Create TABLE if not exists PersonTitle(Id integer Primary Key autoincrement, Title varchar(50) not null, IsDeleted bit not null default 0); " +
                    "Create TABLE IF NOT EXISTS StudentLevel(Id integer Primary Key autoincrement, Level varchar(5) not null, IsDeleted bit not null default 0);" +
                    "Create Table if not exists Department(Id integer Primary Key autoincrement,  DepartmentName varchar(200), DepartmentCode varchar(10), IsDeleted bit not null default 0);" +
                    "Create TABLE if not exists StudentDetail(Id integer Primary Key autoincrement, MatricNo varchar(50) not null, Firstname varchar(50) not null, Othername varchar(50), Lastname varchar(50) not null, Email varchar(150), DepartmentId int not null, PhoneNo varchar(11),  IsGraduated bit not null default 0, IsDeleted bit not null default 0);" +
                    "Create table if not exists StaffDetail(Id integer Primary Key autoincrement, StaffNo varchar(50) not null, Firstname varchar(50) not null, Othername varchar(50), Lastname varchar(50) not null, Email varchar(150), DepartmentId int, TitleId int, Password varchar(50) not null, IsAdmin bit not null, PasswordChanged bit not null default 0, IsSuperAdmin bit not null default 0, IsDeleted bit not null default 0);" +
                    "Create Table if not exists Course(Id integer Primary Key autoincrement, DepartmentId int not null,  CourseTitle varchar(200), CourseCode varchar(10), IsDeleted bit not null default 0);" +
                    "Create Table if not exists SessionSemester(Id integer Primary Key autoincrement,  Session varchar(50), Semester varchar(50), IsActive bit not null default 0, IsDeleted bit not null default 0 ); " +
                    "Create Table if not exists StudentFinger(Id integer Primary Key autoincrement, StudentId int not null, FingerTemplate BLOB);" +
                    "Create Table if not exists CourseRegistration(Id integer Primary Key autoincrement, SessionSemesterId int not null, StudentId int not null, CourseId int not null, LevelId int not null, RegisteredBy int not null, DateRegistered datetime); " +
                    "Create Table if not exists Attendance(Id integer Primary Key autoincrement, CourseRegistrationId int not null, MarkedBy int not null, DateMarked datetime); " +
                    "Create Table if not exists SystemSetting(Id integer Primary Key autoincrement, NoOfFinger int not null, SuperAdminLastname varchar(50) not null,  SuperAdminFirstname varchar(50) not null,  SuperAdminEmail varchar(150) not null,  SuperAdminPassword varchar(500) not null, SuperAdminNo varchar(50) not null); ";
                   
                SQLiteCommand cmd = new SQLiteCommand(tablesSql, con);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0; 
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
                int ret = int.Parse(cmd.ExecuteScalar().ToString());
                if(ret < 1)
                {                    
                    var encryptPwd = PasswordHash.sha256(Constants.SuperAdminPassword);
                    var seedQuery = $"insert into SystemSetting(NoOfFinger, SuperAdminLastname, SuperAdminFirstname, SuperAdminEmail, SuperAdminPassword, SuperAdminNo) values " +
                     $"('{Constants.NoOfFinger}','{Constants.SuperAdminLastname}', '{Constants.SuperAdminFirstname}', '{Constants.SuperAdminEmail}', '{encryptPwd}', {Constants.SuperAdminNo});";
                   
                    foreach (var item in Titles())
                    {
                        seedQuery += $"insert into PersonTitle(Title) values ('{item}');";
                    }

                    foreach (var item in Levels())
                    {
                        seedQuery += $"insert into StudentLevel(Level) values ('{item}');";
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

         private static List<string> Titles()
         {
            var titles = new List<string>
            {
                "Mr.",
                "Dr.",
                "Miss",
                "Mrs",
                "Dr.(Miss)",
                "Dr.(Mrs)",
                "Prof.",
                "Prof.(Mrs)"
            };

            return titles;
         }

         private static List<string> Levels()
         {
            var levels = new List<string>
            {
                "100",
                "200",
                "300",
                "400",
                "500",
                "600"
            };

            return levels;
         }
    }
}
