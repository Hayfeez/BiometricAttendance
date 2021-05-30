using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceLibrary.Model
{
    [Table("User")]
    public class StaffDetail
    {
        [Key]
        public string Id { get; set; }

        public string StaffNo { get; set; }
        public string Firstname { get; set; }
        public string Othername { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string DepartmentId { get; set; }
        public string TitleId { get; set; }
        public string PhoneNo { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool PasswordChanged { get; set; }
        public bool IsSuperAdmin { get; set; }
        public bool IsDeleted { get; set; }

        [NotMapped] public string Fullname => $"{Lastname}, {Firstname} {Othername}";
       
    }
}
