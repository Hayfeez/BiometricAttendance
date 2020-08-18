using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceUI.BaseClass
{
   public static class Base
    {

        public static void ShowInfo(string caption, string text)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowError(string caption, string text)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowSuccess(string caption, string text)
        {
            MessageBox.Show(text, caption, MessageBoxButtons.OK);
        }

        public static DialogResult ShowDialog (MessageBoxButtons buttons, string  caption, string text)
        {
            return MessageBox.Show(text, caption, buttons, MessageBoxIcon.Warning);
        }
   
    }
}
