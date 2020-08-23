﻿using AttendanceLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AttendanceLibrary.BaseClass;
using AttendanceLibrary.DataContext;

namespace AttendanceLibrary.Repository
{
   public class SessionSemesterRepo
    {
        public string AddSessionSemester(SessionSemester newSem)
        {
            try
            {
                using (var context = new SqliteContext())
                {
                    if (context.SessionSemesters.Any(a => a.Session == newSem.Session && a.Semester == newSem.Semester && !a.IsDeleted))
                        return "Session and Semester already exist";

                    if (newSem.IsActive)
                    {
                        var allsems = context.SessionSemesters.Where(a => !a.IsDeleted).ToList();
                        foreach (var item in allsems)
                        {
                            item.IsActive = false;
                        }
                    }

                    newSem.Id = Guid.NewGuid().ToString();
                    context.SessionSemesters.Add(newSem);

                    if(newSem.IsActive)
                        LoggedInUser.ActiveSession = newSem;

                    return context.SaveChanges() > 0 ? "" : "Session/Semester could not be added";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteSessionSemester(string semId)
        {
            using (var context = new SqliteContext())
            {
                if (context.CourseRegistrations.Any(a => a.SessionSemesterId == semId))
                    return "Session Semester cannot be deleted because it has course registration records";

                var SessionSemester = context.SessionSemesters.SingleOrDefault(a => a.Id == semId);
                if (SessionSemester != null)
                {
                    if (SessionSemester.IsActive)
                        return "You cannot delete the active semester";

                    SessionSemester.IsDeleted = true;
                    return context.SaveChanges() > 0 ? "" : "Session/Semester could not be deleted";
                }

                return "Session/Semester not found";
            }

        }

        public List<SessionSemester> GetAllSessionSemesters()
        {
            try
            {
                using (var context = new SqliteContext())
                {
                    return context.SessionSemesters.Where(a => !a.IsDeleted).ToList();
                }
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
                using (var context = new SqliteContext())
                {
                    return context.SessionSemesters.SingleOrDefault(a => a.Id == semId && !a.IsDeleted);
                }
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
                using (var context = new SqliteContext())
                {
                    return context.SessionSemesters.SingleOrDefault(a => a.IsActive && !a.IsDeleted);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdateSessionSemester(SessionSemester sem)
        {
            using (var context = new SqliteContext())
            {
                var oldSem = context.SessionSemesters.SingleOrDefault(a => a.Id == sem.Id && !a.IsDeleted);
                if (oldSem == null)
                    return "Session Semester not found";

                if (context.SessionSemesters.Any(a => a.Session == sem.Session && a.Semester == sem.Semester && !a.IsDeleted && a.Id != sem.Id))
                    return "Session Semester already exist";

                oldSem.Session = sem.Session;
                oldSem.Semester = sem.Semester;
                oldSem.IsActive = sem.IsActive;

                if(sem.IsActive)
                {
                    LoggedInUser.ActiveSession = sem;
                    var allsems = context.SessionSemesters.Where(a => !a.IsDeleted && a.Id != oldSem.Id ).ToList();
                    foreach (var item in allsems)
                    {
                        item.IsActive = false;
                    }
                }

                return context.SaveChanges() > 0 ? "" : "Session/Semester could not be updated";
            }
        }
    }
}
