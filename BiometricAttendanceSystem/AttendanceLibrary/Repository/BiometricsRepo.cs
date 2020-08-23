using AttendanceLibrary.BaseClass;
using AttendanceLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceLibrary.Repository
{
    public class BiometricsRepo
    {

        public string SaveStudentFinger(StudentFinger data)
        {
			try
			{
				using (var context = new BASContext())
                {
                    var fingerCount = context.SystemSettings.First().NoOfFinger;
					var studentFingers = context.StudentFingers.Where(a => a.StudentId == data.StudentId);
					if (studentFingers.Count() < fingerCount)
                    {
                        data.Id = Guid.NewGuid().ToString();
						context.StudentFingers.Add(data);
                        return context.SaveChanges() > 0 ? "" : "Finger could not be saved";
					}
					else
						return "Required no of fingers already saved";
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
        }

		public string SaveStudentFingers(List<StudentFinger> data)
		{
			try
			{
               
				using (var context = new BASContext())
				{
                    var fingerCount = context.SystemSettings.First().NoOfFinger;
                    if (data.Count() != fingerCount)
                        return "Fingers not equal to the required number of fingers";

                    var studentFingers = context.StudentFingers.Where(a => a.StudentId == data[0].StudentId);
					foreach (var item in studentFingers)
					{
						context.StudentFingers.Remove(item);
					}

					foreach (var item in data)
                    {
                        item.Id = Guid.NewGuid().ToString();
						context.StudentFingers.Add(item);						
					}

                    return context.SaveChanges() > 0 ? "" : "Finger could not be saved";

				}

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public List<StudentFinger> GetFingers()
		{
			try
			{
                using (var context = new BASContext())
				{
					return context.StudentFingers.ToList();				

				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

	}
}
