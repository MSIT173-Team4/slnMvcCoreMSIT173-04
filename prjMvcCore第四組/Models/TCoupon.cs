using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models;

public partial class TCoupon
{
    public int FCouponId { get; set; }

    public int? FSellerId { get; set; }

    public string FName { get; set; } = null!;

    public string? FCode { get; set; }

    public string FScopeType { get; set; } = null!;

    public string FDiscountType { get; set; } = null!;

    public decimal FDiscountValue { get; set; }

    public decimal? FMinPurchaseAmount { get; set; }

    public decimal? FMaxDiscountAmount { get; set; }

    public DateTime FStartDate { get; set; }

    public DateTime? FEndDate { get; set; }

    public bool? FIsActive { get; set; }

    public virtual TSeller? FSeller { get; set; }

    public virtual ICollection<TOrderDiscount> TOrderDiscounts { get; set; } = new List<TOrderDiscount>();
}
