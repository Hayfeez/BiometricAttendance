﻿using System.ComponentModel.DataAnnotations;

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
