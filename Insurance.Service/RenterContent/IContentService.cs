using Insurance.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Service.RenterContent
{
    public interface IContentService
    {
        List<Content> GetContentAll();

        Content GetContentById(int contentId);

        void Add(Content content);

        void Delete(Content content);

    }
}
