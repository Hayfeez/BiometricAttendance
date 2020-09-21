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
    public class LevelRepo : DisposeContext
    {
        private readonly AttendanceContext _context = Helper.GetDataContext();

        public string AddLevel(StudentLevel newLevel)
        {
            try
            {
               
                if (_context.Levels.Any(a => a.Level == newLevel.Level && !a.IsDeleted))
                    return "Level already exists";
                //if (_context.Levels.Any(a => a.LevelRank == newLevel.LevelRank && !a.IsDeleted))
                //    return "A Level already exist for this Level rank";

                newLevel.Id = Guid.NewGuid().ToString();
                _context.Levels.Add(newLevel);

                return _context.SaveChanges() > 0 ? "" : "Level could not be added";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteLevel(string levelId)
        {
           
            if (_context.CourseRegistrations.Any(a => a.LevelId == levelId))
                return "Level cannot be deleted because it is in use";

            var level = _context.Levels.SingleOrDefault(a => a.Id == levelId);
            if (level != null)
            {
                level.IsDeleted = true;
                return _context.SaveChanges() > 0 ? "" : "Level could not be deleted";
            }

            return "Level not found";
        }

        public List<StudentLevel> GetAllLevels()
        {
            try
            {
               
                return _context.Levels.Where(a => !a.IsDeleted).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public StudentLevel GetLevel(string levelId)
        {
            try
            {
               
                return _context.Levels.SingleOrDefault(a => a.Id == levelId && !a.IsDeleted);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetLevelId(string name)
        {
            try
            {
                return _context.Levels.SingleOrDefault(a => a.Level == name && !a.IsDeleted)?.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdateLevel(StudentLevel level)
        {
           
            var oldLevel = _context.Levels.SingleOrDefault(a => a.Id == level.Id && !a.IsDeleted);
            if (oldLevel == null)
                return "Level not found";

            if (_context.Levels.Any(a => a.Level == level.Level && !a.IsDeleted && a.Id != level.Id))
                return "Level already exist";
            //if (_context.Levels.Any(a => a.LevelRank == level.LevelRank && !a.IsDeleted && a.Id != level.Id))
            //    return "Rank already exist for another level";

            oldLevel.Level = level.Level;

            return _context.SaveChanges() > 0 ? "" : "Level could not be updated";
        }

        public List<StudentLevel> GetAllLevelsLocal()
        {
            try
            {
                using var context = Helper.GetDataContext(true);
                return _context.Levels.Where(a => !a.IsDeleted).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
