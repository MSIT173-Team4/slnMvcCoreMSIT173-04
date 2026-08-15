using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models
{

    public partial class TOrderDetail
    {
        public int FOrderDetailsId { get; set; }

        public long FOrderId { get; set; }

        public int FProductId { get; set; }

        public int FQuantity { get; set; }

        public decimal FUnitPrice { get; set; }

        public virtual TOrder FOrder { get; set; } = null!;

        public virtual TProduct FProduct { get; set; } = null!;

        public virtual TProductReview? TProductReview { get; set; }
    }
}