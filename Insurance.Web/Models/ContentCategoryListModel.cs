using Insurance.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Web.Models
{
    public class ContentCategoryListModel
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public IEnumerable<Content> Contents { get; set; }

        public int ContentTotal { get; set; }

    }
}
