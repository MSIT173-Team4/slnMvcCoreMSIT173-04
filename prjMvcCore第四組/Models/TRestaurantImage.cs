using System;
using System.Collections.Generic;

namespace prjMvcCoreMSIC173-04.Models;

public partial class TRestaurantImage
{
    public long FImageId { get; set; }

    public long FRestaurantId { get; set; }

    public string FImageUrl { get; set; } = null!;

    public string FImageType { get; set; } = null!;

    public virtual TRestaurant FRestaurant { get; set; } = null!;
}
