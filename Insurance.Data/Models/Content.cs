using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Data.Models
{
    public class Content
    {
        public int Id { get; set; }

        public int ContentCategoryId { get; set; }

        public string ContentName { get; set; }

        public int Value { get; set; }

    }
}
