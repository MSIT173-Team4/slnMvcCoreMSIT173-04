using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models
{
    public partial class Brand
    {
        public int BrandId { get; set; }

        public string BrandName { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}