using AttendanceLibrary.BaseClass;
using AttendanceLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AttendanceLibrary.DataContext;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace AttendanceLibrary.Repository
{
    public class BiometricsRepo
    {
        
		public string SaveStudentFingers(List<StudentFinger> data)
		{
			try
			{
                using var context = new SqliteContext();
                var fingerCount = context.SystemSettings.First().NoOfFinger;
                if (data.Count() != fingerCount)
                    return "Fingers not equal to the required number of fingers";

                foreach (var d in data)
                {
                    if (context.StudentFingers.Any(x => x.FingerTemplate == d.FingerTemplate))
                        return "This fingerprint has been used for another student";
                }
               
                var studentFingers = context.StudentFingers.Where(a => a.StudentId == data[0].StudentId);
                foreach (var item in studentFingers)
                {
                    context.StudentFingers.Remove(item);
                }

                //foreach (var item in data)
                
                //    item.Id = Guid.NewGuid().ToString();
                //    context.StudentFingers.Add(item);
                //}
                context.StudentFingers.AddRange(data);

                return context.SaveChanges() > 0 ? "" : "Finger could not be saved";

            }
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public string DeleteStudentFingers(string id)
        {
            try
            {
                using var context = new SqliteContext();
                var studentFingers = context.StudentFingers.Where(a => a.StudentId == id).ToList();
                if (studentFingers.Count < 1)
                    return "No Fingerprints enrolled";

                foreach (var item in studentFingers)
                {
                    context.StudentFingers.Remove(item);
                }
                
                return context.SaveChanges() > 0 ? "" : "Fingers could not be deleted";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StudentFinger> GetStudentFingers(string id = "")
		{
			try
            {
                using var context = new SqliteContext();
                return context.StudentFingers.Where(x=>x.StudentId == id || id == "").ToList();
            }
			catch (Exception ex)
			{
				throw ex;
			}
		}

        public List<StudentFinger> GetFingersOfCourseStudents(string courseId)
        {
            try
            {
                using var context = new SqliteContext();
                var activeSemesterId = context.SessionSemesters.SingleOrDefault(x => x.IsActive)?.Id;
                if (activeSemesterId == null)
                    return null;

                var d = (from c in context.CourseRegistrations
                         where c.CourseId == courseId && c.SessionSemesterId == activeSemesterId
                         // let studentId = c.StudentId
                         join st in context.StudentFingers on c.StudentId equals st.StudentId into studentFingers
                         from fings in studentFingers
                         join s in context.Students on fings.StudentId equals s.Id
                         select new StudentFinger
                         {
                             FingerTemplate = fings.FingerTemplate,
                             Id = fings.Id,
                             StudentId = fings.StudentId,
                             MatricNo = s.MatricNo
                         }).ToList();

                return d;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StaffFingerprint> GetStaffFingers(string id = "")
        {
            try
            {
                using var context = new SqliteContext();
                return context.StaffFingers.Where(x=>x.StaffId == id || id == "").ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string SaveStaffFingers(List<StaffFingerprint> data)
        {
            try
            {
                using var context = new SqliteContext();
                foreach (var d in data)
                {
                    if (context.StaffFingers.Any(x => x.Fingerprint == d.Fingerprint))
                        return "This fingerprint has been used for another staff";
                }

                var staffFingers = context.StaffFingers.Where(a => a.StaffId == data[0].StaffId);
                foreach (var item in staffFingers)
                {
                    context.StaffFingers.Remove(item);
                }

                //foreach (var item in data)
                //{
                //    item.Id = Guid.NewGuid().ToString();
                //    context.StaffFingers.Add(item);
                //}

                context.StaffFingers.AddRange(data);
                return context.SaveChanges() > 0 ? "" : "Finger could not be saved";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteStaffFingers(string id)
        {
            try
            {
                using var context = new SqliteContext();
                var staff = context.StaffFingers.Where(a => a.StaffId == id).ToList();
                if (staff.Count < 1)
                    return "No Fingerprints enrolled";

                foreach (var item in staff)
                {
                    context.StaffFingers.Remove(item);
                }

                return context.SaveChanges() > 0 ? "" : "Fingers could not be deleted";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
