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
        private string _FullName;

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

        [NotMapped]
        public string Fullname
        {
            get => _FullName;
            set => _FullName = $"{Lastname}, {Firstname} {Othername}";
        }

        //public string Fullname()
        //{
        //    return $"{Lastname}, {Firstname} {Othername}";
        //}
    }
}
