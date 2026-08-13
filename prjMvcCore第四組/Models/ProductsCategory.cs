using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models
{

    public partial class ProductsCategory
    {
        public int CategoryId { get; set; }

        public string CategoriesName { get; set; } = null!;

        public int? ParentCategoryId { get; set; }

        public virtual ICollection<ProductsCategory> InverseParentCategory { get; set; } = new List<ProductsCategory>();

        public virtual ProductsCategory? ParentCategory { get; set; }

        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}