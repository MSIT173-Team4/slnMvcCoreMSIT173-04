using System;
using System.Collections.Generic;

namespace prjMvcCoreMSIC173-04.Models;

public partial class TProductImage
{
    public int FProductImageId { get; set; }

    public int FProductId { get; set; }

    public string FImageUrl { get; set; } = null!;

    public short FSortOrder { get; set; }

    public DateTime FCreatedDate { get; set; }

    public virtual TProduct FProduct { get; set; } = null!;
}
