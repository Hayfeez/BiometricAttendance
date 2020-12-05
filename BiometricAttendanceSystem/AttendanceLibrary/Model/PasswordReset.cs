using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
