using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceLibrary.Model.ViewModels
{
    public class StaffCourseList
    {
        public string Id { get; set; }
        public string CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string Fullname { get; set; }
        public string Title { get; set; }

        public DateTime DateAssigned { get; set; }
    }
}
