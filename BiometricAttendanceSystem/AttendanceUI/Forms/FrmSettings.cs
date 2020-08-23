using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AttendanceLibrary.BaseClass;
using AttendanceLibrary.Model;
using AttendanceLibrary.Repository;

using AttendanceUI.BaseClass;

namespace AttendanceUI.Forms
{
    public partial class FrmSettings : Form
    {
        private readonly LevelRepo _levelRepo;
        private readonly TitleRepo _titleRepo;
        private readonly SettingsRepo _settingsRepo;

        private string _id;
        private bool _noItems;

        private void LoadTitle()
        {
            try
            {
                var data = _titleRepo.GetAllTitles();
                if (data != null && data.Count > 0)
                {
                    dataGridTitle.DataSource = data;
                    dataGridTitle.Columns["Id"].Visible = false;
                    dataGridTitle.Columns["IsDeleted"].Visible = false;
                }
                else
                {
                    _noItems = true;
                    var dt = new DataTable();
                    dataGridTitle.Columns.Clear();
                    dt.Columns.Add("Message", typeof(string));
                    dt.Rows.Add("No items found");
                    dataGridTitle.DataSource = dt;
                }

                Base.AddEditDeleteToGrid(ref dataGridTitle, _noItems); //add edit,delete icon

            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLevel()
        {
            try
            {
                var data = _levelRepo.GetAllLevels();
                if (data != null && data.Count > 0)
                {
                    dataGridLevel.DataSource = data;
                    dataGridLevel.Columns["Id"].Visible = false;
                    dataGridLevel.Columns["IsDeleted"].Visible = false;
                }
                else
                {
                    _noItems = true;
                    var dt = new DataTable();
                    dataGridLevel.Columns.Clear();
                    dt.Columns.Add("Message", typeof(string));
                    dt.Rows.Add("No items found");
                    dataGridLevel.DataSource = dt;
                }

                Base.AddEditDeleteToGrid(ref dataGridLevel, _noItems); //add edit,delete icon

            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ValidateSettingsForm()
        {
            if (txtAdminLastname.Text == "")
                return "Lastname is required";

            if (txtAdminFirstname.Text == "")
                return "Firstname is required";

            if (txtAdminEmail.Text == "")
                return "Email is required";

            if (txtAdminPassword.Text == "")
                return "Admin Password is required";

            if (txtUserDefaultPassword.Text == "")
                return "User default password is required";
            
            return "";
        }

        private void GetSetting()
        {
            var item = _settingsRepo.GetSetting();
            if (item == null)
            {
                Base.ShowError("Not Found", "Not Found");
                this.Close();
            }
            else
            {
                _id = item.Id;
                txtAdminEmail.Text = item.SuperAdminEmail;
                txtAdminLastname.Text = item.SuperAdminLastname;
                txtAdminFirstname.Text = item.SuperAdminFirstname;
                txtNoOfFinger.Text = item.NoOfFinger.ToString();
            }
        }

       
        public FrmSettings()
        {
            InitializeComponent();
            _titleRepo = new TitleRepo();
            _levelRepo = new LevelRepo();
            _settingsRepo = new SettingsRepo();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            var validate = ValidateSettingsForm();
            if (validate == string.Empty)
            {
                var result = Base.ShowDialog(MessageBoxButtons.YesNo, "", "Are you sure you want to update the system settings?");
                if (result == DialogResult.Yes)
                {
                    var item = new SystemSetting
                    {
                        Id = _id,
                        SuperAdminEmail = txtAdminEmail.Text.ToLower(),
                        SuperAdminFirstname = txtAdminFirstname.Text.ToTitleCase(),
                        SuperAdminLastname = txtAdminLastname.Text.ToTitleCase(),
                        SuperAdminPassword = txtAdminPassword.Text,
                        UserDefaultPassword = txtUserDefaultPassword.Text,
                        NoOfFinger = int.Parse(txtNoOfFinger.Text)
                    };

                    var saveItem = _settingsRepo.UpdateSetting(item);

                    if (saveItem == string.Empty)
                    {
                        Base.ShowSuccess("Success", "Settings updated successfully");
                        this.Close();
                    }

                    else
                        Base.ShowError("Failed", saveItem);
                }
               
            }
            else
            {
                Base.ShowInfo("Validation Failed", validate);
            }
        }

        private void iconExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddLevel_Click(object sender, EventArgs e)
        {
            var levelForm = new FrmLevel();
            levelForm.ShowDialog();
            LoadLevel();
        }

        private void btnAddTitle_Click(object sender, EventArgs e)
        {
            var titleForm = new FrmTitle();
            titleForm.ShowDialog();
            LoadTitle();
        }

        private void checkPwd_CheckedStateChanged(object sender, EventArgs e)
        {
            txtAdminPassword.UseSystemPasswordChar = !checkPwd.Checked;
            txtUserDefaultPassword.UseSystemPasswordChar = !checkPwd.Checked;
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            LoadLevel();
            LoadTitle();
            GetSetting();
        }

        private void dataGridLevel_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //edit column 
                if (e.ColumnIndex == 0)
                {
                    var id = dataGridLevel.Rows[e.RowIndex].Cells["id"].Value.ToString();
                    var item = _levelRepo.GetLevel(id);
                    if (item != null)
                    {
                        var updateForm = new FrmLevel(item.Id);
                        updateForm.ShowDialog();
                        LoadLevel();
                    }

                }

                //delete column
                if (e.ColumnIndex == 1)
                {
                    var result = Base.ShowDialog(MessageBoxButtons.YesNo, "Confirm Delete", "Are you sure you want to delete this record?");
                    if (result == DialogResult.Yes)
                    {
                        var id = dataGridLevel.Rows[e.RowIndex].Cells["id"].Value.ToString();
                        var response = _levelRepo.DeleteLevel(id);

                        if (response == string.Empty)
                        {
                            Base.ShowInfo("Success", "Level deleted successfully");
                            LoadLevel();
                        }
                        else
                            Base.ShowError("Failed", response);

                    }
                }

            }
            catch (Exception ex)
            {
                Base.ShowError("Error occured", ex.Message);
            }
        }

        private void dataGridTitle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //edit column 
                if (e.ColumnIndex == 0)
                {
                    var id = dataGridTitle.Rows[e.RowIndex].Cells["id"].Value.ToString();
                    var item = _titleRepo.GetTitle(id);
                    if (item != null)
                    {
                        var updateForm = new FrmTitle(item.Id);
                        updateForm.ShowDialog();
                        LoadTitle();
                    }

                }

                //delete column
                if (e.ColumnIndex == 1)
                {
                    var result = Base.ShowDialog(MessageBoxButtons.YesNo, "Confirm Delete", "Are you sure you want to delete this record?");
                    if (result == DialogResult.Yes)
                    {
                        var id = dataGridTitle.Rows[e.RowIndex].Cells["id"].Value.ToString();
                        var response = _titleRepo.DeleteTitle(id);

                        if (response == string.Empty)
                        {
                            Base.ShowInfo("Success", "Title deleted successfully");
                            LoadTitle();
                        }

                        else
                            Base.ShowError("Failed", response);
                        
                    }
                }

            }
            catch (Exception ex)
            {
                Base.ShowError("Error occured", ex.Message);
            }
        }
    }
}
