using AttendanceLibrary.Model;
using AttendanceLibrary.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AttendanceLibrary.BaseClass;
using AttendanceLibrary.DataContext;

namespace AttendanceLibrary.Repository
{
    public class StudentRepo : DisposeContext
    {
        private readonly AttendanceContext _context = Helper.GetDataContext();

        public string AddStudent(StudentDetail newStudent)
        {
            try
            {
               
                if (_context.Students.Any(a => a.MatricNo == newStudent.MatricNo || a.Email == newStudent.Email && !a.IsDeleted))
                    return "Student with this Matric number or Email address exists";

                newStudent.Id = Guid.NewGuid().ToString();
                _context.Students.Add(newStudent);
                return _context.SaveChanges() > 0 ? "" : "Student could not be added";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string AddBulkStudent(List<BulkStudent> data, string deptId)
        {
            try
            {
                var existing = _context.Students.Where(x => x.Email != string.Empty)
                    .Select(x => new
                    {
                        x.MatricNo,
                        x.Email
                    })
                    .ToHashSet();

                var existingMatricNos = existing.Select(x => x.MatricNo).ToHashSet();
                var existingEmails = existing.Select(x => x.Email).ToHashSet();

                var toAdd = new List<StudentDetail>();
                foreach (var item in data)
                {
                    if ((string.IsNullOrEmpty(item.Email) || !existingEmails.Contains(item.Email)) && !existingMatricNos.Contains(item.MatricNumber))
                    {
                        toAdd.Add(new StudentDetail
                        {
                            Id = Guid.NewGuid().ToString(),
                            MatricNo = item.MatricNumber,
                            Lastname = item.Lastname,
                            Firstname = item.Firstname,
                            Othername = item.Othername,
                            Email = item.Email,
                            PhoneNo = item.PhoneNo,
                            DepartmentId = deptId
                        });
                    }
                }

                _context.Students.AddRange(toAdd);
                return _context.SaveChanges() > 0 ? "" : "No new student added";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteStudent(string studentId)
        {
           
            if (_context.CourseRegistrations.Any(a => a.StudentId == studentId))
                return "Student cannot be deleted because (s)he has registered for a course";

            var student = _context.Students.SingleOrDefault(a => a.Id == studentId);
            if (student != null)
            {
                student.IsDeleted = true;
                return _context.SaveChanges() > 0 ? "" : "Student could not be deleted";
            }

            return "Student not found";
        }

        public string GraduateStudent(List<BulkGraduateStudent> model, string sessionId)
        {
            try
            {
                var matricNos = model.Select(x => x.MatricNumber).ToHashSet();
                var students = GetStudentByMatricNos(matricNos);

                if (students.Count < model.Count)
                {
                    return "No record processed. At least one student does not exist";
                }

                foreach (var item in students)
                {
                    item.IsGraduated = true;
                    item.GraduatedSessionId = sessionId;
                    item.DateGraduated = DateTime.Now.Date;
                }

                return _context.SaveChanges() > 0 ? "" : "No record saved";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public List<StudentDetail> GetAllStudents(bool isGraduate = false)
        {
            try
            {
                return _context.Students.Where(a => !a.IsDeleted && a.IsGraduated == isGraduate).OrderBy(x => x.MatricNo).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StudentDetail> GetDepartmentStudentsSlim(string departmentId, string levelId, bool isGraduate = false)
        {
            try
            {
                //TODO: get student level id from current session and courseregistration
               
                return _context.Students.Where(a => !a.IsDeleted && a.DepartmentId == departmentId && a.IsGraduated == isGraduate)
                    .OrderBy(x => x.MatricNo).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StudentList> GetDepartmentStudents(string departmentId, string levelId, bool isGraduate = false)
        {
            try
            {
                //TODO: get student level id from current session and courseregistration
               
                var dt = (_context.Students
                    .Join(_context.Departments, st => st.DepartmentId, dep => dep.Id, (st, dep) => new
                    {
                        st,
                        dep
                    })
                    .Where(x => (departmentId == "" || x.st.DepartmentId == departmentId) && x.st.IsGraduated == isGraduate && !x.st.IsDeleted)
                    .Select(x => new StudentList
                    {
                        Id = x.st.Id,
                        Department = x.dep.DepartmentName,
                        Email = x.st.Email,
                        PhoneNo = x.st.PhoneNo,
                        MatricNo = x.st.MatricNo,
                        Fullname = x.st.Lastname + ", " + x.st.Firstname + " " + x.st.Othername
                    })).OrderBy(x => x.MatricNo).ToList();

                return dt;
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
                return _context.Students.SingleOrDefault(a => a.Id == studentId && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public StudentDetail GetStudentByMatricNo(string matricNo)
        {
            try
            {
               
                return _context.Students.SingleOrDefault(a => a.MatricNo == matricNo && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StudentDetail> GetStudentByMatricNos(HashSet<string> matricNos)
        {
            try
            {
                return _context.Students.Where(a => matricNos.Contains(a.MatricNo) && !a.IsDeleted).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdateStudent(StudentDetail student)
        {
           
            var oldStudent = _context.Students.SingleOrDefault(a => a.Id == student.Id && !a.IsDeleted);
            if (oldStudent == null)
                return "Student not found";

            if (_context.Students.Any(a => a.MatricNo == student.MatricNo || a.Email == student.Email && !a.IsDeleted && a.Id != student.Id))
                return "Student with this Matric number or Email address exists";

            oldStudent.Email = student.Email.ToLower();
            oldStudent.Firstname = student.Firstname.ToTitleCase();
            oldStudent.Lastname = student.Lastname.ToTitleCase();
            oldStudent.Othername = student.Othername.ToTitleCase();
            oldStudent.MatricNo = student.MatricNo.ToUpper();
            oldStudent.PhoneNo = student.PhoneNo;
            oldStudent.DepartmentId = student.DepartmentId;

            return _context.SaveChanges() > 0 ? "" : "Student could not be updated";
        }
    }
}
