using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using AttendanceLibrary.BaseClass;
using AttendanceLibrary.Model;
using AttendanceLibrary.Model.ViewModels;
using AttendanceLibrary.Repository;

using AttendanceUI.BaseClass;

namespace AttendanceUI.Forms
{
    public partial class FrmFingerprintLogin : Form
    {
        private static AuthRepo _repo;

        private static DigitalPersonaLibrary _digitalPersona;
        private List<StaffFingerprint> _staffFingerprints;


        public FrmFingerprintLogin()
        {
            InitializeComponent();
            _repo = new AuthRepo();
            _staffFingerprints = _repo.GetStaffFingersForSignIn();

            comboScanner.Items.Clear();
            comboScanner.Items.Add("Digital Persona Scanner");
            comboScanner.SelectedIndex = 0;
            comboScanner.Enabled = true;

            this.ShowInTaskbar = false;
        }

        private void FrmAttendance_Load(object sender, EventArgs e)
        {
            //_digitalPersona = new DigitalPersonaLibrary(txtLog, PicAnalyzed, _staffFingerprints);
            //if (_digitalPersona.Capturer == null)
            //{
            //    Base.ShowError("No Scanner", "Fingerprint scanner is not connected");
            //}

            _digitalPersona.StartCapture();
            _digitalPersona.FingerBitmap = null;
        }

        private void comboScanner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboScanner.SelectedIndex == 0) //digital persona scanner
            {
                try
                {
                    _digitalPersona = new DigitalPersonaLibrary(txtLog, PicAnalyzed, _staffFingerprints);
                    if (_digitalPersona.Capturer == null)
                    {
                        Base.ShowError("No Scanner", "Fingerprint scanner is not connected");
                    }
                    else
                    {
                    }
                }
                catch (Exception exception)
                {
                    Base.ShowError("Error", exception.Message);
                }
            }
        }

        private void FrmAttendance_FormClosed(object sender, FormClosedEventArgs e)
        {
            _digitalPersona.StopCapture();
            _digitalPersona?.Dispose();
        }

        private void iconExit_Click(object sender, EventArgs e)
        {
            var frm = new FrmLogin(false);
            frm.Show();
            frm.ShowInTaskbar = true;
            this.Close();
        }

        private static void DoNothing()
        {

        }

        public static void Login(VerifiedData data)
        {
            try
            {
                var login = _repo.StaffLoginWithFingerPrint(data.Id);
                if (login)
                {
                    _digitalPersona.StopCapture();
                    _digitalPersona?.Dispose();

                    var t = new Thread(new ThreadStart(DoNothing));
                    t.Start();
                    Thread.Sleep(2500);
                    t.Abort();
                    
                    var dashboard = new FrmContainer();
                    dashboard.Show();

                    foreach (var form in Application.OpenForms.OfType<FrmFingerprintLogin>().ToList())
                    {
                        form.Close();
                    }
                }
                else
                {
                    Base.ShowInfo("", "Login failed. Try again");
                }
            }
            catch (Exception e)
            {
                Base.ShowError("Error", e.Message);
            }
        }
    }
}
