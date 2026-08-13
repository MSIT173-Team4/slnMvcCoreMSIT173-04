using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models
{

    public partial class ProductReview
    {
        public int ReviewId { get; set; }

        public int OrderDetailsId { get; set; }

        public int ProductId { get; set; }

        public int UsersId { get; set; }

        public byte Rating { get; set; }

        public string? Comment { get; set; }

        public DateTime CreatedDate { get; set; }

        public virtual OrderDetail OrderDetails { get; set; } = null!;

        public virtual Product Product { get; set; } = null!;

        public virtual TUser Users { get; set; } = null!;
    }
}