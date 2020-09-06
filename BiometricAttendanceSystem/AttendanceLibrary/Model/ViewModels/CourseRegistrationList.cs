using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceLibrary.Model.ViewModels
{
    public class CourseRegistrationList
    {
        public string Id { get; set; }
        public string StudentLevel { get; set; }
        public string StudentName { get; set; }
        public string StudentMatricNo { get; set; }
        public string CourseTitle { get; set; }
        public string Semester { get; set; }
        public string RegisteredBy { get; set; }
        public DateTime DateRegistered { get; set; }

    }

    public class StaffCourseRegCount
    {
        public string CourseTitle { get; set; }
        public string MarkedBy { get; set; }
        public int Count { get; set; }

    }
}
