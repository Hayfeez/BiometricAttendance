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
    public class TitleRepo : DisposeContext
    {
        private readonly AttendanceContext _context = Helper.GetDataContext();

        public string AddTitle(PersonTitle newTitle)
        {
            try
            {
               
                if (_context.Titles.Any(a => a.Title == newTitle.Title && !a.IsDeleted))
                    return "Title already exists";

                newTitle.Id = Guid.NewGuid().ToString();
                _context.Titles.Add(newTitle);
                return _context.SaveChanges() > 0 ? "" : "Title could not be added";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteTitle(string titleId)
        {
           
            if (_context.Staff.Any(a => a.TitleId == titleId))
                return "Title cannot be deleted because it is in use";

            var title = _context.Titles.SingleOrDefault(a => a.Id == titleId);
            if (title != null)
            {
                title.IsDeleted = true;
                return _context.SaveChanges() > 0 ? "" : "Title could not be deleted";
            }

            return "Title not found";
        }

        public List<PersonTitle> GetAllTitles()
        {
            try
            {
               
                return _context.Titles.Where(a => !a.IsDeleted).OrderBy(x => x.Title).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PersonTitle GetTitle(string titleId)
        {
            try
            {
               
                return _context.Titles.SingleOrDefault(a => a.Id == titleId && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetTitleId(string name)
        {
            try
            {
                return _context.Titles.SingleOrDefault(a => a.Title == name && !a.IsDeleted)?.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdateTitle(PersonTitle title)
        {
           
            var oldTitle = _context.Titles.SingleOrDefault(a => a.Id == title.Id && !a.IsDeleted);
            if (oldTitle == null)
                return "Title not found";

            if (_context.Titles.Any(a => a.Title == title.Title && !a.IsDeleted && a.Id != title.Id))
                return "Title already exist";

            oldTitle.Title = title.Title.ToTitleCase();
            return _context.SaveChanges() > 0 ? "" : "Title could not be updated";
        }
    }
}
