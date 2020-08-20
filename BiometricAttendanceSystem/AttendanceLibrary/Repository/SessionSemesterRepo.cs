﻿using AttendanceLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceLibrary.Repository
{
   public class SessionSemesterRepo
    {
        public string AddSessionSemester(SessionSemester newSem)
        {
            try
            {
                using (var context = new BASContext())
                {
                    if (context.SessionSemesters.Any(a => a.Session == newSem.Session && a.Semester == newSem.Semester && !a.IsDeleted))
                        return "Session and Semester already exist";

                    if (newSem.IsActive)
                    {
                        var allsems = context.SessionSemesters.Where(a => !a.IsDeleted);
                        foreach (var item in allsems)
                        {
                            item.IsActive = false;
                        }
                    }

                    newSem.Id = Guid.NewGuid().ToString();
                    context.SessionSemesters.Add(newSem);
                    return context.SaveChanges() > 0 ? "Session/Semester added successfully" : "";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteSessionSemester(string semId)
        {
            using (var context = new BASContext())
            {
                if (context.CourseRegistrations.Any(a => a.SessionSemesterId == semId))
                    return "Session Semester cannot be deleted because it has course registration records";

                var SessionSemester = context.SessionSemesters.SingleOrDefault(a => a.Id == semId);
                if (SessionSemester != null)
                {
                    SessionSemester.IsDeleted = true;
                    return context.SaveChanges() > 0 ? "Session/Semester deleted successfully" : "";
                }

                return "Session/Semester not found";
            }

        }

        public List<SessionSemester> GetAllSessionSemesters()
        {
            try
            {
                using (var context = new BASContext())
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
                using (var context = new BASContext())
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
                using (var context = new BASContext())
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
            using (var context = new BASContext())
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
                    var allsems = context.SessionSemesters.Where(a => !a.IsDeleted);
                    foreach (var item in allsems)
                    {
                        item.IsActive = false;
                    }
                }

                return context.SaveChanges() > 0 ? "Session/Semester updated successfully" : "";
            }
        }
    }
}