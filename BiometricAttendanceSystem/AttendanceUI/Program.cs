using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using AttendanceLibrary.BaseClass;
using AttendanceLibrary.Model;

using AttendanceUI.BaseClass;
using AttendanceUI.Forms;

namespace AttendanceUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Helper.SeedData();
                Application.Run(new FrmLogin());
               // Application.Run(new SplashScreen());
            }
            catch (Exception ex)
            {
                Base.ShowError("ERROR", "An error has occured" + ex.Message + " Inner exception: " + ex.InnerException);
            }
        }
    }
}
