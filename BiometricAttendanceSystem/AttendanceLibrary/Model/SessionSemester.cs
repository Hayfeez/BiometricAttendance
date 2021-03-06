﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceLibrary.Model
{
    [Table("SessionSemester")]
    public class SessionSemester
    {
        [Key]
        public string Id { get; set; }
        public string Session { get; set; }
        public string Semester { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        //[NotMapped] public string Fullname
        //{
        //    get => _fullName;
        //    set
        //    {
        //        _fullName = value;
        //        _fullName = $"{Session} / {Semester}";
        //    }
        //}

        [NotMapped] public string Fullname => $"{Session} - {Semester}";

    }
}
