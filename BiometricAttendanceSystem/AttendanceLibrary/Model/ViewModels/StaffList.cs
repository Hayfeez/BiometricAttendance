using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceLibrary.Model.ViewModels
{
    public class StaffList
    {
        public string Id { get; set; }
        public string StaffNo { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Title { get; set; }
        public string PhoneNo { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsSuperAdmin { get; set; }
        
    }
}
