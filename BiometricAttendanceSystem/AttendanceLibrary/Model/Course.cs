using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendanceLibrary.Model
{
    [Table("Course")]
    public class Course
    {
        [Key]
        public string Id { get; set; }
        public string DepartmentId { get; set; }
        public string LevelId { get; set; }
        public string CourseTitle { get; set; }
        public string CourseCode { get; set; }
        public bool IsDeleted { get; set; }

        [NotMapped] public string Fullname => $"{CourseCode} - {CourseTitle}";
    }
}
