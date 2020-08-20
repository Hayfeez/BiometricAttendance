﻿using AttendanceLibrary.Model;
using AttendanceLibrary.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AttendanceLibrary.BaseClass;

namespace AttendanceLibrary.Repository
{
    public class StudentRepo
    {
        public string AddStudent(StudentDetail newStudent)
        {
            try
            {
                using (var context = new BASContext())
                {
                    if (context.Students.Any(a => a.MatricNo == newStudent.MatricNo || a.Email == newStudent.Email && !a.IsDeleted))
                        return "Student with this Matric number or Email address exists";

                    newStudent.Id = Guid.NewGuid().ToString();
                    context.Students.Add(newStudent);
                    return context.SaveChanges() > 0 ? "Student added successfully" : "";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string AddBulkStudent(List<BulkStudent> data, string levelId)
        {
            try
            {
                using (var context = new BASContext())
                {
                    return "";

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteStudent(string studentId)
        {
            using (var context = new BASContext())
            {
                if (context.CourseRegistrations.Any(a => a.StudentId == studentId))
                    return "Student cannot be deleted because (s)he has registered for a course";

                var student = context.Students.SingleOrDefault(a => a.Id == studentId);
                if (student != null)
                {
                    student.IsDeleted = true;
                    return context.SaveChanges() > 0 ? "Student deleted successfully" : "";
                }

                return "Student not found";
            }

        }

        public string GraduateStudent(string studentId)
        {
            using (var context = new BASContext())
            {
                
                var student = context.Students.SingleOrDefault(a => a.Id == studentId);
                if (student != null)
                {
                    student.IsGraduated = true;
                    return context.SaveChanges() > 0 ? "Student has been marked graduated successfully" : "";
                 
                }

                return "Student not found";
            }

        }

        public List<StudentDetail> GetAllStudents(bool isGraduate = false)
        {
            try
            {
                using (var context = new BASContext())
                {
                    return context.Students.Where(a => !a.IsDeleted && a.IsGraduated == isGraduate).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StudentDetail> GetAllDepartmentStudents(string departmentId, bool isGraduate = false)
        {
            try
            {
                using (var context = new BASContext())
                {
                    return context.Students.Where(a => !a.IsDeleted && a.DepartmentId == departmentId && a.IsGraduated == isGraduate).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public StudentDetail GetStudent(string studentId)
        {
            try
            {
                using (var context = new BASContext())
                {
                    return context.Students.SingleOrDefault(a => a.Id == studentId && !a.IsDeleted);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdateStudent(StudentDetail student)
        {
            using (var context = new BASContext())
            {
                var oldStudent = context.Students.SingleOrDefault(a => a.Id == student.Id && !a.IsDeleted);
                if (oldStudent == null)
                    return "Student not found";

                if (context.Students.Any(a => a.MatricNo == student.MatricNo || a.Email == student.Email && !a.IsDeleted && a.Id != student.Id))
                    return "Student with this Matric number or Email address exists";

                oldStudent.Email = student.Email.ToLower();
                oldStudent.Firstname = student.Firstname.ToTitleCase();
                oldStudent.Lastname = student.Lastname.ToTitleCase();
                oldStudent.Othername = student.Othername.ToTitleCase();
                oldStudent.MatricNo = student.MatricNo.ToUpper();
                oldStudent.PhoneNo = student.PhoneNo;
                oldStudent.DepartmentId = student.DepartmentId;

                return context.SaveChanges() > 0 ? "Student updated successfully" : "";
            }
        }
    }
}
