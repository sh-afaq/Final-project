﻿

using IT.Data.Models;

namespace IT.Business.Models
{
    public class BlogModel : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; }=string.Empty;
        public string ImageUrl { get; set; }
    }
}
