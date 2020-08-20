﻿using AttendanceLibrary.BaseClass;
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
					var studentFingers = context.StudentFingers.Where(a => a.StudentId == data.StudentId);
					if (studentFingers.Count() < Constants.NoOfFinger)
                    {
                        data.Id = Guid.NewGuid().ToString();
						context.StudentFingers.Add(data);
						context.SaveChanges();
						return "Finger saved successfully";
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
				if (data.Count() != Constants.NoOfFinger)
					return "Fingers not equal to the required number of fingers";
				
				using (var context = new BASContext())
				{
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

					context.SaveChanges();
					
				}

				return "Fingers saved successfully";
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
