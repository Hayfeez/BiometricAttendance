﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceLibrary.Model
{
    [Table("PersonTitle")]
    public class PersonTitle
    {
        [Key]
        public string Id { get; set; }
        public string Title { get; set; }
        public bool IsDeleted { get; set; }
    }
}
