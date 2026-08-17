using System;
using System.Collections.Generic;

namespace prjMvcCoreMSIC173-04.Models;

public partial class TOrderDiscount
{
    public int FOrderDiscountId { get; set; }

    public long FOrderId { get; set; }

    public int FCouponId { get; set; }

    public string FDiscountName { get; set; } = null!;

    public string FDiscountScope { get; set; } = null!;

    public string FDiscountType { get; set; } = null!;

    public decimal FAppliedAmount { get; set; }

    public virtual TCoupon FCoupon { get; set; } = null!;

    public virtual TOrder FOrder { get; set; } = null!;
}
