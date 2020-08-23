using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public bool IsGraduated { get; set; }
        public bool IsDeleted { get; set; }

        [NotMapped] public string Fullname => $"{Lastname}, {Firstname} {Othername}";
    }
}
