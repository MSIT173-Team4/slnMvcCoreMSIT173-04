using System;
using System.Collections.Generic;

namespace prjMvcCoreMSIC173-04.Models;

public partial class TShoppingCart
{
    public int FCartItemId { get; set; }

    public int FUsersId { get; set; }

    public int FSellerId { get; set; }

    public int FProductId { get; set; }

    public int FQuantity { get; set; }

    public DateTime FCreatedDate { get; set; }

    public virtual TProduct FProduct { get; set; } = null!;

    public virtual TSeller FSeller { get; set; } = null!;

    public virtual TUser FUsers { get; set; } = null!;
}
