using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceLibrary.Model
{
    [Table("StaffCourse")]
    public class StaffCourse
    {
        [Key]
        public string Id { get; set; }
        public string StaffId { get; set; }
        public string CourseId { get; set; }
        public DateTime DateAssigned { get; set; }
    }
}
