using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AttendanceLibrary.BaseClass;
using AttendanceLibrary.Model;

using Microsoft.EntityFrameworkCore;

namespace AttendanceLibrary.DataContext
{
    public class SqlServerContext : AttendanceContext
    {
        public DbSet<PasswordReset> PasswordResets { get; set; }

        //public SqlServerContext()
        //{
        //    if (string.IsNullOrEmpty(Helper.RemoteServerConnectionString))
        //    {
        //        //saving the remote server connection in the db
        //        var localContext = new SqliteContext();
        //        Helper.RemoteServerConnectionString = conString;
        //    }   
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Helper.GetRemoteConnectionString());
            //          @"Server=(localdb)\mssqllocaldb;Database=SchoolAttendanceDb;Integrated Security=True");
           // @"Data Source=192.168.0.137;Initial Catalog=SchoolAttendanceDb;User Id=attendanceLogin;Password=Password@123");
        }
        //Network Library=DBMSSOCN;
    }
}
