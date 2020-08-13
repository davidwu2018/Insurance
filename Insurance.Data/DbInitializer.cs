using Insurance.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insurance.Data
{
    public static class DbInitializer
    {
        public static void Initialize()
        {
            DeleteContentCategoryAll();

            AddContentCategoryAll();
        }

        private static void DeleteContentCategoryAll()
        {
            using var context = new InsuranceContext();

            var contentCategories = context.ContentCategory.ToList();

            if (contentCategories.Count > 0)
            {
                foreach (var contentCategory in contentCategories)
                {
                    var entity = context.ContentCategory.Remove(contentCategory);
                    entity.State = EntityState.Deleted;
                }

                context.SaveChanges();
            }

        }

        private static void AddContentCategoryAll()
        {
            using var context = new InsuranceContext();

            var categories = new ContentCategory[]
                 {
                    new ContentCategory { Id = 1, CategoryName = "Electronics"},
                    new ContentCategory { Id = 2, CategoryName = "Clothing"},
                    new ContentCategory { Id = 3, CategoryName = "Kitchen"},
                 };

            foreach (var category in categories)
            {
                var entity = context.ContentCategory.Add(category);
                entity.State = EntityState.Added;
            }

            context.SaveChanges();
        }
    }
}