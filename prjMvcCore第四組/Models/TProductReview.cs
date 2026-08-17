using System;
using System.Collections.Generic;

namespace prjMvcCoreMSIC173-04.Models;

public partial class TProductReview
{
    public int FReviewId { get; set; }

    public int FOrderDetailsId { get; set; }

    public int FProductId { get; set; }

    public int FUsersId { get; set; }

    public byte FRating { get; set; }

    public string? FComment { get; set; }

    public DateTime FCreatedDate { get; set; }

    public virtual TOrderDetail FOrderDetails { get; set; } = null!;

    public virtual TProduct FProduct { get; set; } = null!;

    public virtual TUser FUsers { get; set; } = null!;
}
