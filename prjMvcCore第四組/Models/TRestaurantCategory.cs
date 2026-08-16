using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models;

public partial class TRestaurantCategory
{
    public long FCategoryId { get; set; }

    public string FCategoryName { get; set; } = null!;

    public string? FDescription { get; set; }

    public DateTime FCreatedTime { get; set; }

    public virtual ICollection<TRestaurant> TRestaurants { get; set; } = new List<TRestaurant>();
}
