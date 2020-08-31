using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceLibrary.Model
{
    [Table("StaffFinger")]
    public class StaffFinger
    {
        [Key]
        public string Id { get; set; }
        public string StaffId { get; set; }
        public byte[] Fingerprint { get; set; }
     //   [NotMapped]
     //   public Bitmap FingerTemplateBitmap { get; set; }
    }
}
