using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceLibrary.Model
{
    public class SystemSetting
    {
        [Key]
        public string Id { get; set; }
        public int NoOfFinger { get; set; }
        public string SuperAdminLastname { get; set; }
        public string SuperAdminFirstname { get; set; }
        public string SuperAdminEmail { get; set; }
        public string SuperAdminPassword { get; set; }
        public string SuperAdminNo { get; set; }
    }
}
