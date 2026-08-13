using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models
{

    public partial class OrderDetail
    {
        public int OrderDetailsId { get; set; }

        public long OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public virtual Order Order { get; set; } = null!;

        public virtual Product Product { get; set; } = null!;

        public virtual ProductReview? ProductReview { get; set; }
    }
}