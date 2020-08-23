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
    public partial class FrmUserProfile : Form
    {
        private readonly StaffCourseRepo _repo;
        private bool _noItems;

        private void LoadCourses()
        {
            try
            {
                var data = _repo.GetCoursesByStaff(LoggedInUser.UserId);
                if (data != null && data.Count > 0)
                {
                    dataGridCourses.DataSource = data;
                    dataGridCourses.Columns["Id"].Visible = false;
                }
                else
                {
                    _noItems = true;
                    var dt = new DataTable();
                    dataGridCourses.Columns.Clear();
                    dt.Columns.Add("Message", typeof(string));
                    dt.Rows.Add("No items found");
                    dataGridCourses.DataSource = dt;
                }

                Base.AddEditDeleteToGrid(ref dataGridCourses, _noItems);

            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetUserDetails()
        {
            lblName.Text = LoggedInUser.Fullname;
            lblDept.Text = "Department: " + LoggedInUser.Department;
        }

        public FrmUserProfile()
        {
            InitializeComponent();
            _repo = new StaffCourseRepo();

        }

      private void iconExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            GetUserDetails();
            LoadCourses();
        }

        private void dataGridTitle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                if (e.ColumnIndex == 0)
                {
                    
                    
                }

            }
            catch (Exception ex)
            {
                Base.ShowError("Error occured", ex.Message);
            }
        }

        private void btnChangePwd_Click(object sender, EventArgs e)
        {
            if (LoggedInUser.IsSuperAdmin)
            {
                Base.ShowInfo("", "Not available for a System Administrator");
                return;
            }

            var pwdForm = new FrmChangePassword(LoggedInUser.Email);
            pwdForm.ShowDialog();
            this.Close();
            
        }
    }
}
