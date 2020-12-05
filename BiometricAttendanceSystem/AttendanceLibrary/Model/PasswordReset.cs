using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttendanceLibrary.Model
{
    [Table("PasswordReset")]
    public class PasswordReset
    {
        [Key]
        public string Id { get; set; }
        public string UserId { get; set; }
        public string RequestingSystemId { get; set; }
        public DateTime DateRequested { get; set; }
        public bool IsReset { get; set; }
        public string ResetBy { get; set; }
        public DateTime DateReset { get; set; }
    }
}
