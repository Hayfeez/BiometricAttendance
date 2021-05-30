using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AttendanceLibrary.BaseClass;

namespace AttendanceUI.Forms
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            lblAppName.Text = ApplicationSetting.ApplicationName;
            lblTitle.Text = ApplicationSetting.Title;
            lblSubTitle.Text = ApplicationSetting.SubTitle;

            //using (MemoryStream ms = new MemoryStream(ApplicationSetting.LogoBytes))
            //{
            //    pictureBox1.Image = Image.FromStream(ms);
            //}

        }
    }
}
