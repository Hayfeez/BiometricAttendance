
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
    public class DepartmentRepo
    {
        public string AddDepartment(Department newDepartment)
        {
            try
            {
                using var context = new SqliteContext();
                if (context.Departments.Any(a => a.DepartmentCode == newDepartment.DepartmentCode || a.DepartmentName == newDepartment.DepartmentName  && !a.IsDeleted))
                    return "Department with this name or Department Code exists";

                newDepartment.Id = Guid.NewGuid().ToString();
                context.Departments.Add(newDepartment);
                return context.SaveChanges() > 0 ? "" : "Department could not be added";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteDepartment(string departmentId)
        {
            using var context = new SqliteContext();
            if (context.Courses.Any(a => a.DepartmentId == departmentId))
                return "Department cannot be deleted because it has courses";

            var department = context.Departments.SingleOrDefault(a => a.Id == departmentId);
            if (department != null)
            {
                department.IsDeleted = true;
                return context.SaveChanges() > 0 ? "" : "Department could not be deleted";
            }

            return "Department not found";
        }

        public List<Department> GetAllDepartments()
        {
            try
            {
                using var context = new SqliteContext();
                return context.Departments.Where(a => !a.IsDeleted).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Department GetDepartment(string departmentId)
        {
            try
            {
                using var context = new SqliteContext();
                return context.Departments.SingleOrDefault(a => a.Id == departmentId  && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       

        public string UpdateDepartment(Department department)
        {
            using var context = new SqliteContext();
            var oldDepartment = context.Departments.SingleOrDefault(a => a.Id == department.Id && !a.IsDeleted);
            if (oldDepartment == null)
                return "Department not found";

            if (context.Departments.Any(a => a.DepartmentName == department.DepartmentName || a.DepartmentCode == department.DepartmentCode  && !a.IsDeleted && a.Id != department.Id))
                return "Department with this Name or Department Code exists";

            oldDepartment.DepartmentCode = department.DepartmentCode;
            oldDepartment.DepartmentName = department.DepartmentName.ToTitleCase();

            return context.SaveChanges() > 0 ? "" : "Department could not be updated";
        }

    }
}
