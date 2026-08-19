using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models;

public partial class TBrand
{
    public int FBrandId { get; set; }

    public string FBrandName { get; set; } = null!;

    public virtual ICollection<TProduct> TProducts { get; set; } = new List<TProduct>();
}
