﻿using AttendanceLibrary.Model;
using AttendanceLibrary.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AttendanceLibrary.DataContext;

namespace AttendanceLibrary.Repository
{   
   public class AttendanceRepo
    {
        public string SaveAttendance(string courseId, string studentId, string semesterId, string markedBy)
        {
            try
            {
                using var context = new SqliteContext();
                var dateMarked = DateTime.Now;

                var courseRegId = context.CourseRegistrations.SingleOrDefault(a => a.CourseId == courseId && a.SessionSemesterId == semesterId && a.StudentId == studentId)?.Id;

                if (courseRegId == null)
                    return "You are not registered for this course this semester";

                if (context.Attendances.Any(a => a.CourseRegistrationId == courseRegId && a.DateMarked.Date == dateMarked.Date))
                    return "You have marked attendance for this course today";

                context.Attendances.Add(new Attendance
                {
                    Id = Guid.NewGuid().ToString(),
                    CourseRegistrationId = courseRegId,
                    DateMarked = dateMarked,
                    MarkedBy = markedBy
                });

                return context.SaveChanges() > 0 ? "" : "Attendance could not be saved";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AttendanceList> GetAttendanceByCourse(string courseId)
        {
            try
            {
                using var context = new SqliteContext();
                var dt = (from att in context.Attendances
                          join reg in context.CourseRegistrations on att.CourseRegistrationId equals reg.Id
                          join st in context.Students on reg.StudentId equals st.Id
                          join c in context.Courses on reg.CourseId equals c.Id
                          join s in context.SessionSemesters on reg.SessionSemesterId equals s.Id
                          join le in context.Levels on reg.LevelId equals le.Id
                          join dep in context.Departments on st.DepartmentId equals dep.Id
                          join l in context.Staff on att.MarkedBy equals l.Id
                          where reg.CourseId == courseId
                          select new AttendanceList
                          {
                              Id = att.Id,
                              StudentMatricNo = st.MatricNo,
                              StudentName = st.Lastname + ", " + st.Firstname + " " + st.Othername,
                              StudentLevel = le.Level,
                              Course = c.CourseCode + " - " + c.CourseTitle ,
                              DateMarked = att.DateMarked.Date,
                              MarkedBy = l.Lastname + ", " + l.Firstname + " " + l.Othername,
                              SessionSemester = s.Session + " - " + s.Semester,
                              DepartmentName = dep.DepartmentName,
                              TimeIn = att.DateMarked.ToShortTimeString()
                          }
                    ).ToList();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AttendanceList> GetTodayAttendanceByCourse(string courseId)
        {
            try
            {
                var dateNow = DateTime.Now.Date;
                using var context = new SqliteContext();
                var dt = (from att in context.Attendances
                          join reg in context.CourseRegistrations on att.CourseRegistrationId equals reg.Id
                          join st in context.Students on reg.StudentId equals st.Id
                          where reg.CourseId == courseId  && att.DateMarked.Date == dateNow
                          select new AttendanceList
                          {
                              Id = att.Id,
                              StudentMatricNo = st.MatricNo,
                              StudentName = st.Lastname + ", " + st.Firstname + " " + st.Othername,
                              DateMarked = att.DateMarked.Date,
                              TimeIn = att.DateMarked.ToShortTimeString()
                          }
                    ).ToList();

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<AttendanceList> GetAttendanceByStudent(string studentId)
        {
            try
            {
                using var context = new SqliteContext();
                var dt = (from att in context.Attendances
                          join reg in context.CourseRegistrations on att.CourseRegistrationId equals reg.Id
                          join st in context.Students on reg.StudentId equals st.Id
                          join c in context.Courses on reg.CourseId equals c.Id
                          join s in context.SessionSemesters on reg.SessionSemesterId equals s.Id
                          join le in context.Levels on reg.LevelId equals le.Id
                          join dep in context.Departments on st.DepartmentId equals dep.Id
                          join l in context.Staff on att.MarkedBy equals l.Id
                          where reg.StudentId == studentId
                          select new AttendanceList
                          {
                              Id = att.Id,
                              StudentMatricNo = st.MatricNo,
                              StudentName = st.Lastname + ", " + st.Firstname + " " + st.Othername,
                              StudentLevel = le.Level,
                              Course = c.CourseCode + " - " + c.CourseTitle,
                              DateMarked = att.DateMarked.Date,
                              MarkedBy = l.Lastname + ", " + l.Firstname + " " + l.Othername,
                              SessionSemester = s.Session + " - " + s.Semester,
                              DepartmentName = dep.DepartmentName,
                              TimeIn = att.DateMarked.ToShortTimeString()
                          }
                    ).ToList();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AttendanceList> GetAttendanceByStudentForCourse(string studentId, string courseId)
        {
            try
            {
                using var context = new SqliteContext();
                var dt = (from att in context.Attendances
                          join reg in context.CourseRegistrations on att.CourseRegistrationId equals reg.Id
                          join st in context.Students on reg.StudentId equals st.Id
                          join c in context.Courses on reg.CourseId equals c.Id
                          join s in context.SessionSemesters on reg.SessionSemesterId equals s.Id
                          join le in context.Levels on reg.LevelId equals le.Id
                          join dep in context.Departments on st.DepartmentId equals dep.Id
                          join l in context.Staff on att.MarkedBy equals l.Id
                          where reg.StudentId == studentId && reg.CourseId == courseId
                          select new AttendanceList
                          {
                              Id = att.Id,
                              StudentMatricNo = st.MatricNo,
                              StudentName = st.Lastname + ", " + st.Firstname + " " + st.Othername,
                              StudentLevel = le.Level,
                              Course = c.CourseCode + " - " + c.CourseTitle,
                              DateMarked = att.DateMarked.Date,
                              MarkedBy = l.Lastname + ", " + l.Firstname + " " + l.Othername,
                              SessionSemester = s.Session + " - " + s.Semester,
                              DepartmentName = dep.DepartmentName,
                              TimeIn = att.DateMarked.ToShortTimeString()
                          }
                    ).ToList();
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
