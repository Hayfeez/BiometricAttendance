﻿using AttendanceLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AttendanceLibrary.BaseClass;

namespace AttendanceLibrary.Repository
{
    public class TitleRepo
    {
        public string AddTitle(PersonTitle newTitle)
        {
            try
            {
                using (var context = new BASContext())
                {
                    if (context.Titles.Any(a => a.Title == newTitle.Title && !a.IsDeleted))
                        return "Title already exists";

                    newTitle.Id = Guid.NewGuid().ToString();
                    context.Titles.Add(newTitle);
                    return context.SaveChanges() > 0 ? "Title added successfully" : "";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteTitle(string titleId)
        {
            using (var context = new BASContext())
            {
                if (context.Staff.Any(a => a.TitleId == titleId))
                    return "Title cannot be deleted because it is in use";

                var Title = context.Titles.SingleOrDefault(a => a.Id == titleId);
                if (Title != null)
                {
                    Title.IsDeleted = true;
                    return context.SaveChanges() > 0 ? "Title deleted successfully" : "";
                }

                return "Title not found";
            }

        }

        public List<PersonTitle> GetAllTitles()
        {
            try
            {
                using (var context = new BASContext())
                {
                    return context.Titles.Where(a => !a.IsDeleted).ToList();
                }
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
                using (var context = new BASContext())
                {
                    return context.Titles.SingleOrDefault(a => a.Id == titleId && !a.IsDeleted);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdateTitle(PersonTitle title)
        {
            using (var context = new BASContext())
            {
                var oldTitle = context.Titles.SingleOrDefault(a => a.Id == title.Id && !a.IsDeleted);
                if (oldTitle == null)
                    return "Title not found";

                if (context.Titles.Any(a => a.Title == title.Title && !a.IsDeleted && a.Id != title.Id))
                    return "Title already exist";

                oldTitle.Title = title.Title.ToTitleCase();
                return context.SaveChanges() > 0 ? "Title updated successfully" : "";
            }
        }
    }
}