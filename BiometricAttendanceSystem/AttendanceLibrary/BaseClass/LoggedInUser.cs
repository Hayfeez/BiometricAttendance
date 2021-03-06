﻿using AttendanceLibrary.Model;

namespace AttendanceLibrary.BaseClass
{
    public static class LoggedInUser
    {
        public static string UserId { get; set; }
        public static string Fullname { get; set; }
        public static string Email { get; set; }
        public static string Department { get; set; }
        public static bool IsAdmin { get; set; }
        public static bool PasswordChanged { get; set; }
        public static bool IsSuperAdmin { get; set; }

        public static SessionSemester ActiveSession { get; set; }
        
    }
}
