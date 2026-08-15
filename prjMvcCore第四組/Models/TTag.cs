using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models
{

    public partial class TTag
    {
        public int FTagId { get; set; }

        public string FTagName { get; set; } = null!;

        public string FCategory { get; set; } = null!;

        public virtual ICollection<TRecipe> FRecipes { get; set; } = new List<TRecipe>();
    }
}