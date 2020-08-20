using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceLibrary.Model
{
    [Table("CourseRegistration")]
    public class CourseRegistration
    {
        [Key]
        public string Id { get; set; }
        public string SessionSemesterId { get; set; }
        public string StudentId { get; set; }
        public string LevelId { get; set; }
        public string CourseId { get; set; }
        public string RegisteredBy { get; set; }
        public DateTime DateRegistered { get; set; }
    }
}
