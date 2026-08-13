using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models
{

    public partial class OrderDiscount
    {
        public int OrderDiscountId { get; set; }

        public long OrderId { get; set; }

        public int CouponId { get; set; }

        public string DiscountName { get; set; } = null!;

        public string DiscountScope { get; set; } = null!;

        public string DiscountType { get; set; } = null!;

        public decimal AppliedAmount { get; set; }

        public virtual Coupon Coupon { get; set; } = null!;

        public virtual Order Order { get; set; } = null!;
    }
}