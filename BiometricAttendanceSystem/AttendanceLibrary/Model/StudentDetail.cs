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
        private string _FullName;

        [Key]
        public int Id { get; set; }
        public string MatricNo { get; set; }
        public string Firstname { get; set; }
        public string Othername { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public string PhoneNo { get; set; }
        public bool IsGraduated { get; set; }
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
