using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models;

public partial class TProductFavorite
{
    public int FFavoriteId { get; set; }

    public int FUsersId { get; set; }

    public int FProductId { get; set; }

    public DateTime FCreatedDate { get; set; }

    public virtual TProduct FProduct { get; set; } = null!;

    public virtual TUser FUsers { get; set; } = null!;
}
