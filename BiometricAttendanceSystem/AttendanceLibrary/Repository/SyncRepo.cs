using AttendanceLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AttendanceLibrary.BaseClass;

namespace AttendanceLibrary.Repository
{
    public class SyncRepo
    {
        public void SaveSync(AppSync sync)
        {
            using (var context = new BASContext())
            {
                sync.Id = Guid.NewGuid().ToString();
                context.AppSyncs.Add(sync);
                context.SaveChanges();
            }
        }

        public void DeleteOldSync()
        {
            using (var context = new BASContext())
            {
                var cutOffDate = DateTime.Now.AddDays(-7);
                var oldSyncs = context.AppSyncs.Where(x => x.SyncDate <= cutOffDate).ToList();
                context.AppSyncs.RemoveRange(oldSyncs);
                context.SaveChanges();
            }
        }
    }
}
