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
    public class BiometricsRepo : DisposeContext
    {
        private readonly AttendanceContext _context = Helper.GetDataContext();

        public string SaveStudentFingers(List<StudentFinger> data)
		{
			try
			{
               
                var fingerCount = _context.SystemSettings.First().NoOfFinger;
                if (data.Count() != fingerCount)
                    return "Fingers not equal to the required number of fingers";

                foreach (var d in data)
                {
                    if (_context.StudentFingers.Any(x => x.FingerTemplate == d.FingerTemplate))
                        return "This fingerprint has been used for another student";
                }
               
                var studentFingers = _context.StudentFingers.Where(a => a.StudentId == data[0].StudentId);
                foreach (var item in studentFingers)
                {
                    _context.StudentFingers.Remove(item);
                }

                //foreach (var item in data)

                //    item.Id = Guid.NewGuid().ToString();
                //    context.StudentFingers.Add(item);
                //}
                _context.StudentFingers.AddRange(data);

                return _context.SaveChanges() > 0 ? "" : "Finger could not be saved";

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
               
                var studentFingers = _context.StudentFingers.Where(a => a.StudentId == id).ToList();
                if (studentFingers.Count < 1)
                    return "No Fingerprints enrolled";

                foreach (var item in studentFingers)
                {
                    _context.StudentFingers.Remove(item);
                }
                
                return _context.SaveChanges() > 0 ? "" : "Fingers could not be deleted";

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
               
                return _context.StudentFingers.Where(x=>x.StudentId == id || id == "").ToList();
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
                return _context.StaffFingers.Where(x=>x.StaffId == id || id == "").ToList();
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
               
                foreach (var d in data)
                {
                    if (_context.StaffFingers.Any(x => x.Fingerprint == d.Fingerprint))
                        return "This fingerprint has been used for another staff";
                }

                var staffFingers = _context.StaffFingers.Where(a => a.StaffId == data[0].StaffId);
                foreach (var item in staffFingers)
                {
                    _context.StaffFingers.Remove(item);
                }

                //foreach (var item in data)
                //{
                //    item.Id = Guid.NewGuid().ToString();
                //    context.StaffFingers.Add(item);
                //}

                _context.StaffFingers.AddRange(data);
                return _context.SaveChanges() > 0 ? "" : "Finger could not be saved";

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
                var staff = _context.StaffFingers.Where(a => a.StaffId == id).ToList();
                if (staff.Count < 1)
                    return "No Fingerprints enrolled";

                foreach (var item in staff)
                {
                    _context.StaffFingers.Remove(item);
                }

                return _context.SaveChanges() > 0 ? "" : "Fingers could not be deleted";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
