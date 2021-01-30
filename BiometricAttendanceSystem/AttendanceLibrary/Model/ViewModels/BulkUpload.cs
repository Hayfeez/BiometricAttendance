using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceLibrary.Model.ViewModels
{
    public class BulkStudent
    {
        public string MatricNumber { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Othername { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
    }

    public class BulkStaff
    {
        public string StaffNumber { get; set; }
        public string Title { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Othername { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
    }

    public class BulkStudentCourseReg
    {
        public string MatricNumber { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Othername { get; set; }
        public string Level { get; set; }
    }

    public class BulkGraduateStudent
    {
        public string MatricNumber { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Othername { get; set; }
    }
}
