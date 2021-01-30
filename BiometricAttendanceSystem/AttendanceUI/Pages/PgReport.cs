using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AttendanceLibrary.BaseClass;
using AttendanceLibrary.Model.ViewModels;
using AttendanceLibrary.Repository;

using AttendanceUI.BaseClass;
using AttendanceUI.Forms;

namespace AttendanceUI.Pages
{
    public partial class PgReport :  UserControl
    {
        private DataTable _gridData;
        private readonly ReportRepo _repo;
        private string _deptId = "";
        private string _courseId = "";
        private string _semesterId = "";
        private string _reportType = "";

        

        private void LoadFilter()
        {
            DropdownControls.LoadReportType(ref comboReportType);
            DropdownControls.LoadDepartments(ref comboDept);
            DropdownControls.LoadSessions(ref comboSemester);

            if (LoggedInUser.ActiveSession != null)
                comboSemester.SelectedValue = LoggedInUser.ActiveSession.Id;
        }

        private void LoadData(bool isExport = false)
        {
            try
            {
                _courseId = comboCourse.SelectedValue.ToString() == Base.IdForSelect ? "" : comboCourse.SelectedValue.ToString();
                _deptId = comboDept.SelectedValue.ToString() == Base.IdForSelect ? "" : comboDept.SelectedValue.ToString();
                _reportType = comboReportType.SelectedValue.ToString() == "0" ? "" : comboReportType.SelectedValue.ToString();
                _semesterId = comboSemester.SelectedValue.ToString() == Base.IdForSelect ? "" : comboSemester.SelectedValue.ToString();

                if (_courseId == "" || _deptId == "" || _reportType == "" || _semesterId == "")
                {
                    return;
                }

                var startDt = startDate.Text == "" || !groupBoxDate.Visible 
                    ? DateTime.MinValue.Date : DateTime.Parse(startDate.Text).Date;

                var endDt = endDate.Text == "" || !groupBoxDate.Visible 
                    ? DateTime.Now.Date:  DateTime.Parse(endDate.Text).Date;

                if (startDt > endDt)
                {
                    Base.ShowError("", "Start date cannot be greater than End date");
                    return;
                }
                List<AttendanceReport> data = null;

                switch (int.Parse(_reportType))
                {
                    case (int) ReportType.studentAttendanceByCourse:
                        data = _repo.GetStudentAttendanceRecord(_semesterId, _courseId, "", startDt, endDt);
                        break;
                    
                    case (int)ReportType.staffAttendanceByCourse:
                        data = _repo.GetStaffAttendanceRecord(_semesterId, _courseId, startDt, endDt);
                        break;
                    
                    default:
                        break;
                }

                if (data != null && data.Count > 0)
                {
                    if (isExport)
                    {
                        var dt = data.ConvertToDataTable();
                        var reportname = _repo.GetReportDescription(int.Parse(_reportType));
                        reportname ??= "report";

                        reportname += DateTime.Now.ToShortDateString().Replace('/', '_');
                        foreach (var column in dt.Columns.Cast<DataColumn>().ToArray())
                        {
                            if (dt.AsEnumerable().All(dr => dr.IsNull(column)))
                                dt.Columns.Remove(column);
                        }
                        if (Base.SaveAsExcel(dt, reportname))
                        {
                            Base.ShowSuccess("", "File downloaded successfully");
                        }
                    }
                    else
                    {
                        dataGrid.DataSource = data;
                        txtSearch.Visible = true;
                        btnSearch.Visible = true;
                        _gridData = data.ConvertToDataTable();

                        dataGrid.Columns["StudentName"].HeaderText = "Student Name";
                        dataGrid.Columns["StudentMatricNo"].HeaderText = "Matric Number";
                        dataGrid.Columns["SessionSemester"].HeaderText = "Session - Semester";
                        dataGrid.Columns["StudentLevel"].HeaderText = "Level";
                        dataGrid.Columns["DepartmentName"].HeaderText = "Department";
                        dataGrid.Columns["Count"].HeaderText = "Attendance Count";
                        dataGrid.Columns["Dates"].HeaderText = "Attendance Dates";


                        dataGrid.Columns["DepartmentName"].Visible = false;
                        dataGrid.Columns["SessionSemester"].Visible = false;
                        dataGrid.Columns["Course"].Visible = false;
                        

                        switch (int.Parse(_reportType))
                        {
                            case (int)ReportType.studentAttendanceByCourse:
                                dataGrid.Columns["MarkedBy"].Visible = false;
                                break;

                            case (int)ReportType.staffAttendanceByCourse:
                                dataGrid.Columns["StudentLevel"].Visible = true;
                                dataGrid.Columns["StudentName"].Visible = true;
                                dataGrid.Columns["StudentMatricNo"].Visible = true;
                                dataGrid.Columns["MarkedBy"].HeaderText = "Staff Name";
                                dataGrid.Columns["MarkedBy"].Visible = true;
                                break;
                                
                            default:
                                break;
                        }
                        
                    }
                }
                else
                {
                    if (isExport)
                    {
                        Base.ShowError("No record", "No Record found");
                    }
                    else
                    {
                        txtSearch.Visible = false;
                        btnSearch.Visible = false;
                        var dt = new DataTable();
                        dataGrid.Columns.Clear();
                        dt.Columns.Add("Message", typeof(string));
                        dt.Rows.Add("No record found");
                        dataGrid.DataSource = dt;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Error occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public PgReport()
        {
            InitializeComponent();
            _repo = new ReportRepo();
            
            startDate.MaxDate = DateTime.Now;
            endDate.MaxDate = DateTime.Now;
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            var i = Base.SearchGrid(_gridData, txtSearch.Text.Trim());
            if (i != null)
            {
                dataGrid.DataSource = i;
                dataGrid.Refresh();
            }
            else
            {
                Base.ShowInfo("Not Found", "No record found");
            }
        }

        private void PgCourse_Load(object sender, EventArgs e)
        {
            LoadFilter();
            LoadData();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void comboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboDept.Items.Count > 0)
            {
                _deptId = comboDept.SelectedValue.ToString() == Base.IdForSelect ? "" : comboDept.SelectedValue.ToString();

                if (_deptId == "")
                    return;

                DropdownControls.LoadCourses(ref comboCourse, _deptId, "");
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            LoadData(true);
        }

        private void checkShowDate_CheckedStateChanged(object sender, EventArgs e)
        {
            groupBoxDate.Visible = checkShowDate.Checked;
        }
    }
}
