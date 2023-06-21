using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT.Data.Models
{
    public class Blog : BaseEntity
    {
            public string Name { get; set; }=string.Empty;

        public string Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; } = string.Empty;


    }
}
