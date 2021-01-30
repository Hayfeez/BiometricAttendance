using AttendanceLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AttendanceLibrary.BaseClass;
using AttendanceLibrary.DataContext;

namespace AttendanceLibrary.Repository
{
   public class SessionSemesterRepo : DisposeContext
    {
        private readonly AttendanceContext _context = Helper.GetDataContext();
        private readonly AttendanceContext _localContext = Helper.GetDataContext(true);

        public string AddSessionSemester(SessionSemester newSem)
        {
            try
            {
               
                if (_context.SessionSemesters.Any(a => a.Session == newSem.Session && a.Semester == newSem.Semester && !a.IsDeleted))
                    return "Session and Semester already exist";

                if (newSem.IsActive)
                {
                    var allsems = _context.SessionSemesters.Where(a => !a.IsDeleted).ToList();
                    foreach (var item in allsems)
                    {
                        item.IsActive = false;
                    }
                }

                newSem.Id = Guid.NewGuid().ToString();
                _context.SessionSemesters.Add(newSem);


                if (_context.SaveChanges() > 0)
                {
                    if (newSem.IsActive)  //change the active semester on local sqlite
                    {
                        LoggedInUser.ActiveSession = newSem;
                        var localSems = _localContext.SessionSemesters.Where(a => !a.IsDeleted).ToList();
                        foreach (var item in localSems)
                        {
                            item.IsActive = false;
                        }

                        _localContext.SaveChanges();
                    }

                    return "";
                }
                else
                {
                    return "Session/Semester could not be added";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteSessionSemester(string semId)
        {
           
            if (_context.CourseRegistrations.Any(a => a.SessionSemesterId == semId))
                return "Session Semester cannot be deleted because it has course registration records";

            var sessionSemester = _context.SessionSemesters.SingleOrDefault(a => a.Id == semId);
            if (sessionSemester != null)
            {
                if (sessionSemester.IsActive)
                    return "You cannot delete the active semester";

                sessionSemester.IsDeleted = true;
                return _context.SaveChanges() > 0 ? "" : "Session/Semester could not be deleted";
            }

            return "Session/Semester not found";
        }

        public List<SessionSemester> GetAllSessionSemesters()
        {
            try
            {
               
                return _context.SessionSemesters.Where(a => !a.IsDeleted)
                    .OrderBy(x => x.Session).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SessionSemester GetSessionSemester(string semId)
        {
            try
            {
               
                return _context.SessionSemesters.SingleOrDefault(a => a.Id == semId && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SessionSemester GetActiveSessionSemester()
        {
            try
            {
               
                return _context.SessionSemesters.SingleOrDefault(a => a.IsActive && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdateSessionSemester(SessionSemester sem)
        {
           
            var oldSem = _context.SessionSemesters.SingleOrDefault(a => a.Id == sem.Id && !a.IsDeleted);
            if (oldSem == null)
                return "Session Semester not found";

            if (_context.SessionSemesters.Any(a => a.Session == sem.Session && a.Semester == sem.Semester && !a.IsDeleted && a.Id != sem.Id))
                return "Session Semester already exist";

            oldSem.Session = sem.Session;
            oldSem.Semester = sem.Semester;
            oldSem.IsActive = sem.IsActive;

            if(sem.IsActive)
            {
                var allsems = _context.SessionSemesters.Where(a => !a.IsDeleted && a.Id != oldSem.Id ).ToList();
                foreach (var item in allsems)
                {
                    item.IsActive = false;
                }
            }

            if (_context.SaveChanges() > 0)
            {
                if (sem.IsActive)  //change the active semester on local sqlite
                {
                    LoggedInUser.ActiveSession = sem;
                    var localSems = _localContext.SessionSemesters.Where(a => !a.IsDeleted && a.Id != oldSem.Id).ToList();
                    foreach (var item in localSems)
                    {
                        item.IsActive = false;
                    }
                   
                    _localContext.SaveChanges();
                }

                return "";
            }
            else
            {
                return "Session/Semester could not be updated";
            }
        }

        public SessionSemester GetActiveSessionSemesterLocal()
        {
            try
            {
                return _localContext.SessionSemesters.SingleOrDefault(a => a.IsActive && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
