using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models
{

    public partial class ProductImage
    {
        public int ProductImageId { get; set; }

        public int ProductId { get; set; }

        public string ImageUrl { get; set; } = null!;

        public short SortOrder { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}