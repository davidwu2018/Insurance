using Insurance.Data;
using Insurance.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insurance.Service.RenterContent
{
    public class ContentCategoryService : IContentCategoryService
    {
        public void Add(ContentCategory contentCategory)
        {
            using var context = new InsuranceContext();
            var entity = context.ContentCategory.Add(contentCategory);
            entity.State = EntityState.Added;

            context.SaveChanges();
        }

        public static void Edit(ContentCategory contentCategory)
        {
            using var context = new InsuranceContext();
            var entity = context.ContentCategory.Update(contentCategory);
            entity.State = EntityState.Modified;

            context.SaveChanges();
        }

        public static void Delete(ContentCategory contentCategory)
        {
            using var context = new InsuranceContext();
            var entity = context.ContentCategory.Remove(contentCategory);
            entity.State = EntityState.Deleted;

            context.SaveChanges();
        }

        public List<ContentCategory> GetContentCategoryAll()
        {
            using var context = new InsuranceContext();

            return context.ContentCategory.ToList();

        }

        public static ContentCategory GetCatById(int catId)
        {
            using var context = new InsuranceContext();

            var cat = context.ContentCategory.Find(catId);
            Console.WriteLine($"{cat.CategoryName}");

            return cat;
        }

    }
}
