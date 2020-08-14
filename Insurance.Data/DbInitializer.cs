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
            DeleteContentAll();
            DeleteContentCategoryAll();

            AddContentCategoryAll();
            AddContentAll();
        }

        private static void DeleteContentAll()
        {
            using var context = new InsuranceContext();

            var contents = context.Content.ToList();

            if (contents.Count > 0)
            {
                foreach (var content in contents)
                {
                    var entity = context.Content.Remove(content);
                    entity.State = EntityState.Deleted;
                }

                context.SaveChanges();
            }

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

        private static void AddContentAll()
        {
            using var context = new InsuranceContext();

            var contents = new Content[]
                 {
                    new Content { Id = 1, ContentCategoryId = 1, ContentName = "TV", Value = 2000},
                    new Content { Id = 2, ContentCategoryId = 1, ContentName = "Playstation", Value = 400},
                    new Content { Id = 3, ContentCategoryId = 1, ContentName = "Stereo", Value = 1600},
                    new Content { Id = 4, ContentCategoryId = 2, ContentName = "Shirts", Value = 1100},
                    new Content { Id = 5, ContentCategoryId = 2, ContentName = "Jeans", Value = 1100},
                    new Content { Id = 6, ContentCategoryId = 3, ContentName = "Pots and Pans", Value = 3000},
                    new Content { Id = 7, ContentCategoryId = 3, ContentName = "Flatware", Value = 500},
                    new Content { Id = 8, ContentCategoryId = 3, ContentName = "Knife Set", Value = 500},
                    new Content { Id = 9, ContentCategoryId = 3, ContentName = "Misc", Value = 1000},
                 };

            foreach (var content in contents)
            {
                var entity = context.Content.Add(content);
                entity.State = EntityState.Added;
            }

            context.SaveChanges();
        }

    }
}