using AttendanceLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AttendanceLibrary.DataContext;

namespace AttendanceLibrary.Repository
{
    public class LevelRepo
    {
        public string AddLevel(StudentLevel newLevel)
        {
            try
            {
                using (var context = new SqliteContext())
                {
                    if (context.Levels.Any(a => a.Level == newLevel.Level && !a.IsDeleted))
                        return "Level already exists";
                    //if (context.Levels.Any(a => a.LevelRank == newLevel.LevelRank && !a.IsDeleted))
                    //    return "A Level already exist for this Level rank";

                    newLevel.Id = Guid.NewGuid().ToString();
                    context.Levels.Add(newLevel);

                    return context.SaveChanges() > 0 ? "" : "Level could not be added";

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteLevel(string levelId)
        {
            using (var context = new SqliteContext())
            {
                if (context.CourseRegistrations.Any(a => a.LevelId == levelId))
                    return "Level cannot be deleted because it is in use";

                var level = context.Levels.SingleOrDefault(a => a.Id == levelId);
                if (level != null)
                {
                    level.IsDeleted = true;
                    return context.SaveChanges() > 0 ? "" : "Level could not be deleted";
                }

                return "Level not found";
            }

        }

        public List<StudentLevel> GetAllLevels()
        {
            try
            {
                using (var context = new SqliteContext())
                {
                    return context.Levels.Where(a => !a.IsDeleted).ToList();
                }
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
                using (var context = new SqliteContext())
                {
                    return context.Levels.SingleOrDefault(a => a.Id == levelId && !a.IsDeleted);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public StudentLevel GetLevelByName(string name)
        {
            try
            {
                using (var context = new SqliteContext())
                {
                    return context.Levels.SingleOrDefault(a => a.Level == name && !a.IsDeleted);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdateLevel(StudentLevel level)
        {
            using (var context = new SqliteContext())
            {
                var oldLevel = context.Levels.SingleOrDefault(a => a.Id == level.Id && !a.IsDeleted);
                if (oldLevel == null)
                    return "Level not found";

                if (context.Levels.Any(a => a.Level == level.Level && !a.IsDeleted && a.Id != level.Id))
                    return "Level already exist";
                //if (context.Levels.Any(a => a.LevelRank == level.LevelRank && !a.IsDeleted && a.Id != level.Id))
                //    return "Rank already exist for another level";

                oldLevel.Level = level.Level;

                return context.SaveChanges() > 0 ? "" : "Level could not be updated";

            }
        }
    }
}
