using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AttendanceLibrary.Model;

using Microsoft.EntityFrameworkCore;

namespace AttendanceLibrary.DataContext
{
    public class AttendanceContext : DbContext
    {
        public DbSet<StaffDetail> Staff { get; set; }
        public DbSet<StudentDetail> Students { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseRegistration> CourseRegistrations { get; set; }
        public DbSet<PersonTitle> Titles { get; set; }
        public DbSet<SessionSemester> SessionSemesters { get; set; }
        public DbSet<StudentFinger> StudentFingers { get; set; }
        public DbSet<StudentLevel> Levels { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<SystemSetting> SystemSettings { get; set; }
        public DbSet<AppSync> AppSyncs { get; set; }
        public DbSet<StaffCourse> StaffCourses { get; set; }
        public DbSet<StaffFinger> StaffFingers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
    }
}
