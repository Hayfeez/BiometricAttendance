using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceLibrary.Model
{
    public class ServerSetting
    {
        [Key]
        public string Id { get; set; }
        public string DatabaseName { get; set; }
        public string ServerName { get; set; }
        public string Password { get; set; }
        
    }
}
