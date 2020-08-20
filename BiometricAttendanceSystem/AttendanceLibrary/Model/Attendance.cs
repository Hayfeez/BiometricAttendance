using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceLibrary.Model
{
    [Table("Attendance")]
    public class Attendance
    {
       [Key]
        public string Id { get; set; }
        public string CourseRegistrationId { get; set; }        
        public string MarkedBy { get; set; }
        public DateTime DateMarked { get; set; }


    }
}
