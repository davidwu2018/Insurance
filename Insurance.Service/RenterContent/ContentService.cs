using Insurance.Data;
using Insurance.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Insurance.Service.RenterContent
{
    public class ContentService : IContentService
    {
        public void Add(Content content)
        {
            using var context = new InsuranceContext();
            var entity = context.Content.Add(content);
            entity.State = EntityState.Added;

            context.SaveChanges();
        }

        public List<Content> GetContentAll()
        {
            using var context = new InsuranceContext();

            return context.Content.ToList();

        }

        public Content GetContentById(int contentId)
        {
            using var context = new InsuranceContext();

            var content = context.Content.Find(contentId);

            return content;
        }


        public void Delete(Content content)
        {
            using var context = new InsuranceContext();
            var entity = context.Content.Remove(content);
            entity.State = EntityState.Deleted;

            context.SaveChanges();
        }

    }
}
