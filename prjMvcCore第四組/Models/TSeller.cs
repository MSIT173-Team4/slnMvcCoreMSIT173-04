using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prjMvcCoreMSIC173-04.Models;

public partial class TSeller
{
    [Key]
    public int FId { get; set; }

    public int FUserId { get; set; }

    public string FName { get; set; } = null!;

    public string? FDescription { get; set; }

    public int FStatus { get; set; }

    public DateTime FApplyDate { get; set; }

    public virtual TStatus FStatusNavigation { get; set; } = null!;

    public virtual TUser FUser { get; set; } = null!;

    public virtual ICollection<TCoupon> TCoupons { get; set; } = new List<TCoupon>();

    public virtual ICollection<TOrder> TOrders { get; set; } = new List<TOrder>();

    public virtual ICollection<TProduct> TProducts { get; set; } = new List<TProduct>();

    public virtual ICollection<TShoppingCart> TShoppingCarts { get; set; } = new List<TShoppingCart>();
}
