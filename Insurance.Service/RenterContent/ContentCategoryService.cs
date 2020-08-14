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

        public List<ContentCategory> GetContentCategoryAll()
        {
            using var context = new InsuranceContext();

            return context.ContentCategory.ToList();

        }

    }
}
