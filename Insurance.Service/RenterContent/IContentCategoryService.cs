using Insurance.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Service.RenterContent
{
    public interface IContentCategoryService
    {
        List<ContentCategory> GetContentCategoryAll();

    }
}
