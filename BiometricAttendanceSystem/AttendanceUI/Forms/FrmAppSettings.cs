using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

using AttendanceLibrary.BaseClass;
using AttendanceLibrary.Model;
using AttendanceLibrary.Repository;

using AttendanceUI.BaseClass;

namespace AttendanceUI.Forms
{
    public partial class FrmAppSettings : Form
    {
        private readonly AppSettingsRepo _repo;
        private string _primaryColor = "";
        private string _secondaryColor = "";
        private string _logobase64 = "";

        public FrmAppSettings()
        {
            _repo = new AppSettingsRepo();
            InitializeComponent();
        }

        private void FrmAppSettings_Load(object sender, EventArgs e)
        {
            try
            {
                var setting = _repo.GetSetting();

                _primaryColor = setting?.PrimaryColor ?? Helper.PrimaryColor;
                _secondaryColor = setting?.SecondaryColor ?? Helper.SecondaryColor;
                _logobase64 = setting?.LogoBase64 ?? "";

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ValidateForm()
        {
            if (txtApplication.Text == "")
                return "Application Name is required";

            if (txtMainTitle.Text == "")
                return "Main Title is required";

            if (txtSubTitle.Text == "")
                return "Sub Title is required";

            if (_logobase64 == "")
                return "Choose a Logo";

            return "";
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var validate = ValidateForm();
                if (validate == string.Empty)
                {
                    var saveItem = _repo.UpdateSetting(new AppSetting
                    {
                        ApplicationName = txtApplication.Text.Trim().ToTitleCase(),
                        Title = txtMainTitle.Text.Trim().ToTitleCase(),
                        SubTitle = txtSubTitle.Text.Trim().ToTitleCase(),
                        LogoBase64 = _logobase64,
                        PrimaryColor = _primaryColor,
                        SecondaryColor = _secondaryColor
                    });

                    if (saveItem == string.Empty)
                    {
                        Base.ShowSuccess("Success", "Application settings saved successfully");
                        this.Close();
                    }
                    else
                    {
                        Base.ShowError("Failed", saveItem);
                    }
                }
                else
                {
                    Base.ShowInfo("Validation Failed", validate);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void iconExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrimaryColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnPrimaryColor.BackColor = colorDialog1.Color;
                _primaryColor = $"{(int) colorDialog1.Color.R},{(int) colorDialog1.Color.G},{(int) colorDialog1.Color.B}";
            }
        }

        private void btnSecondaryColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btnSecondaryColor.BackColor = colorDialog1.Color;
                _secondaryColor = $"{(int)colorDialog1.Color.R},{(int)colorDialog1.Color.G},{(int)colorDialog1.Color.B}";
            }
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
               var selectedFile = openFileDialog1.FileName;
                if (string.IsNullOrEmpty(selectedFile) || selectedFile.Contains(".lnk"))
                {
                    Base.ShowInfo("", "Please select a valid image File");
                    return;
                }

                var imgBitmap = new Bitmap(selectedFile);
                MemoryStream imageStream = new MemoryStream();
                imgBitmap.Save(imageStream, ImageFormat.Png);
                picLogo.Image = imgBitmap;

               // logobase64 = Convert.ToBase64String(imageStream.ToArray());
                _logobase64 = Convert.ToBase64String(imageStream.GetBuffer());
            }
        }

     
    }
}
