using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceLibrary.Model
{
    public class AppSync
    {
        [Key]
        public string Id { get; set; }
        public string SystemId { get; set; }
        public string StaffId { get; set; }
        public DateTime SyncDate { get; set; }


    }
}
