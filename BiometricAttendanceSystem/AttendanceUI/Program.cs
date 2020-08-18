using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using AttendanceLibrary.BaseClass;

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
                SQLiteHandler.CreateSqliteDb();
                SQLiteHandler.CreateTable();
                SQLiteHandler.SeedData();

                Application.Run(new FrmLogin());
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occured while initializing the database. " + ex.Message + " Inner exception: " + ex.InnerException, "Table Creation error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
