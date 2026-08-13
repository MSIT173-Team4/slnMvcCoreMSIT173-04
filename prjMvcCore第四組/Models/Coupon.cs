using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models
{

    public partial class Coupon
    {
        public int CouponId { get; set; }

        public int? SellerId { get; set; }

        public string Name { get; set; } = null!;

        public string? Code { get; set; }

        public string ScopeType { get; set; } = null!;

        public string DiscountType { get; set; } = null!;

        public decimal DiscountValue { get; set; }

        public decimal? MinPurchaseAmount { get; set; }

        public decimal? MaxDiscountAmount { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool? IsActive { get; set; }

        public virtual ICollection<OrderDiscount> OrderDiscounts { get; set; } = new List<OrderDiscount>();
    }

}