using AttendanceLibrary.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

using AttendanceLibrary.BaseClass;
using AttendanceLibrary.DataContext;

using Microsoft.EntityFrameworkCore;

namespace AttendanceLibrary.Repository
{
    public class SyncRepo : DisposeContext
    {
        private readonly AttendanceContext _remoteContext = Helper.GetDataContext();
        private readonly AttendanceContext _localContext = Helper.GetDataContext(true);

        public void SaveSync(AppSync sync)
        {
            _remoteContext.AppSyncs.Add(sync);
            _remoteContext.SaveChanges();
        }

        public void DeleteOldSyncs()
        {
            var cutOffDate = DateTime.Now.AddDays(-30);
            var oldSyncs = _remoteContext.AppSyncs.Where(x => x.SyncDate <= cutOffDate).ToList();
            _remoteContext.AppSyncs.RemoveRange(oldSyncs);
            _remoteContext.SaveChanges();
        }

        public async Task<string> SyncAllData()
        {
            try
            {
                var remoteDept = _remoteContext.Departments.ToList();
                var remoteLevels = _remoteContext.Levels.ToList();
                var remoteStaffCourse = _remoteContext.StaffCourses.ToList();
                var remoteCourse = _remoteContext.Courses.ToList();
                var remoteTitle = _remoteContext.Titles.ToList();
                var remoteSemester = _remoteContext.SessionSemesters.ToList();
                var remoteStaff = _remoteContext.Staff.ToList();
                var remoteStudent = _remoteContext.Students.ToList();
                var remoteCourseReg = _remoteContext.CourseRegistrations.ToList();
                var remoteStudentFingers = _remoteContext.StudentFingers.ToList();
                var remoteStaffFingers = _remoteContext.StaffFingers.ToList();
                var remoteSetting = _remoteContext.SystemSettings.First();
                var appSetting = _remoteContext.AppSettings.First();

                //sqlite doesn't support truncate statement
               _localContext.Database.ExecuteSqlRaw("DELETE FROM Course");
               _localContext.Database.ExecuteSqlRaw("DELETE FROM CourseRegistration");
               _localContext.Database.ExecuteSqlRaw("DELETE FROM Department");
               _localContext.Database.ExecuteSqlRaw("DELETE FROM PersonTitle");
               _localContext.Database.ExecuteSqlRaw("DELETE FROM SessionSemester");
               _localContext.Database.ExecuteSqlRaw("DELETE FROM StaffCourse");
               _localContext.Database.ExecuteSqlRaw("DELETE FROM User");
               _localContext.Database.ExecuteSqlRaw("DELETE FROM StudentDetail");
               _localContext.Database.ExecuteSqlRaw("DELETE FROM StudentLevel");
               _localContext.Database.ExecuteSqlRaw("DELETE FROM StudentFinger");
               _localContext.Database.ExecuteSqlRaw("DELETE FROM StaffFingerprint");
               _localContext.Database.ExecuteSqlRaw("DELETE FROM SystemSettings");
               _localContext.Database.ExecuteSqlRaw("DELETE FROM AppSettings");

               _localContext.Courses.AddRange(remoteCourse);
               _localContext.CourseRegistrations.AddRange(remoteCourseReg);
               _localContext.Departments.AddRange(remoteDept);
               _localContext.Titles.AddRange(remoteTitle);
               _localContext.SessionSemesters.AddRange(remoteSemester);
               _localContext.StaffCourses.AddRange(remoteStaffCourse);
               _localContext.Staff.AddRange(remoteStaff);
               _localContext.Students.AddRange(remoteStudent);
               _localContext.Levels.AddRange(remoteLevels);
               _localContext.StudentFingers.AddRange(remoteStudentFingers);
               _localContext.StaffFingers.AddRange(remoteStaffFingers);
               _localContext.SystemSettings.Add(remoteSetting);
               _localContext.AppSettings.Add(appSetting);

               //var remoteAttendanceIds = _remoteContext.Attendances.Select(x => x.Id).ToHashSet();
               //var toUpload = _localContext.Attendances.Where(x => !remoteAttendanceIds.Contains(x.Id)).AsNoTracking().ToList();

               var localAttendanceIds = _localContext.Attendances.Select(x => x.Id).ToHashSet();
               var toDownload = _remoteContext.Attendances.Where(x => !localAttendanceIds.Contains(x.Id)).AsNoTracking().ToList();

              // await _remoteContext.Attendances.AddRangeAsync(toUpload);
                await _localContext.Attendances.AddRangeAsync(toDownload);

                var i = await _localContext.SaveChangesAsync();

                return i > 0 ? "" : "Synchronization failed. Try again";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<string> UploadAttendanceToRemote()
        {
            var remoteAttendanceIds = _remoteContext.Attendances.Select(x => x.Id).ToHashSet();
            var localAttendancesNotInRemote = _localContext.Attendances.Where(x=>!remoteAttendanceIds.Contains(x.Id)).AsNoTracking().ToList();

            if (localAttendancesNotInRemote.Count < 1)
                return "";

            await _remoteContext.Attendances.AddRangeAsync(localAttendancesNotInRemote);
            var i = await _remoteContext.SaveChangesAsync();

            return i > 0 ? "" : "Uploading local attendance record failed. Report cannot be generated";
        }
    }
}
