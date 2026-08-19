using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models;

public partial class TProductsCategory
{
    public int FCategoryId { get; set; }

    public string FCategoriesName { get; set; } = null!;

    public int? FParentCategoryId { get; set; }

    public virtual TProductsCategory? FParentCategory { get; set; }

    public virtual ICollection<TProductsCategory> InverseFParentCategory { get; set; } = new List<TProductsCategory>();

    public virtual ICollection<TProduct> TProducts { get; set; } = new List<TProduct>();
}
