using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace AttendanceLibrary.DataContext
{
    public class SqlServerContext : AttendanceContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Properties.Settings.Default.SqlServerConnectionString);
            //          @"Server=(localdb)\mssqllocaldb;Database=SchoolAttendanceDb;Integrated Security=True");
           // @"Data Source=192.168.0.137;Initial Catalog=SchoolAttendanceDb;User Id=attendanceLogin;Password=Password@123");
        }
        //Network Library=DBMSSOCN;
    }
}
