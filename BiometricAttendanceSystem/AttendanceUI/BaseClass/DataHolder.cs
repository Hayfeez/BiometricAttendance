using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceUI.BaseClass
{
    public class DataHolder
    {
        public long StudentId { get; set; }
        public string FullName { get; set; }
        public string MatricNo { get; set; }
        public string Email { get; set; }
        public Bitmap[] Fingers { get; set; }
        public Bitmap[] ConfirmFingers { get; set; }

        public Bitmap Passport { get; set; }
        public Bitmap LeftFinger { get; set; }
        public Bitmap RightFinger { get; set; }
        public Bitmap LeftFingerConfirm { get; set; }
        public Bitmap RightFingerConfirm { get; set; }
        public int Mode { get; set; } = 1;
    }
}
