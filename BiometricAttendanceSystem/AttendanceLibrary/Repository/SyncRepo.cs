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
    public class SyncRepo
    {
        public void SaveSync(AppSync sync)
        {
            using (var context = new SqliteContext())
            {
                sync.Id = Guid.NewGuid().ToString();
                context.AppSyncs.Add(sync);
                context.SaveChanges();
            }
        }

        public void DeleteOldSync()
        {
            using (var context = new SqliteContext())
            {
                var cutOffDate = DateTime.Now.AddDays(-7);
                var oldSyncs = context.AppSyncs.Where(x => x.SyncDate <= cutOffDate).ToList();
                context.AppSyncs.RemoveRange(oldSyncs);
                context.SaveChanges();
            }
        }
    }
}
