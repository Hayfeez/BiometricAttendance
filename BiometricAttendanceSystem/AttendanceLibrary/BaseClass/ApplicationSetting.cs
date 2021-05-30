using AttendanceLibrary.Model;

namespace AttendanceLibrary.BaseClass
{
    public static class ApplicationSetting
    {
        public static string ApplicationName { get; set; }
        public static string Title { get; set; }
        public static string SubTitle { get; set; }
        public static byte[] LogoBytes { get; set; }
        public static int PrimaryColorRed { get; set; }
        public static int PrimaryColorGreen { get; set; }
        public static int PrimaryColorBlue { get; set; }
        public static int SecondaryColorRed { get; set; }
        public static int SecondaryColorGreen { get; set; }
        public static int SecondaryColorBlue { get; set; }


        public static string DatabaseName { get; set; }
        public static string DatabaseServer { get; set; }
        public static string DbUsername { get; set; }
        public static string DbPassword { get; set; }
    }
}
