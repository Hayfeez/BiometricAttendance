using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendanceLibrary.Model
{
    [Table("StudentDetail")]
    public class StudentDetail
    {
        [Key]
        public string Id { get; set; }
        public string MatricNo { get; set; }
        public string Firstname { get; set; }
        public string Othername { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string DepartmentId { get; set; }
        public string PhoneNo { get; set; }
        public string GraduatedSessionId { get; set; }
        public bool IsGraduated { get; set; }
        public DateTime DateGraduated { get; set; }

        public bool IsDeleted { get; set; }

        [NotMapped] public string Fullname => $"{Lastname}, {Firstname} {Othername}";
    }
}
