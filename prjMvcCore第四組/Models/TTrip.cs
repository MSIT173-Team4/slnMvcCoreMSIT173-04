using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models;

public partial class TTrip
{
    public long FTripId { get; set; }

    public int FUsersId { get; set; }

    public string FTripName { get; set; } = null!;

    public DateOnly FTripDate { get; set; }

    public TimeOnly? FStartTime { get; set; }

    public string? FDescription { get; set; }

    public string FStatus { get; set; } = null!;

    public DateTime FCreatedTime { get; set; }

    public DateTime? FUpdatedTime { get; set; }

    public virtual TUser FUsers { get; set; } = null!;

    public virtual ICollection<TTripRestaurant> TTripRestaurants { get; set; } = new List<TTripRestaurant>();
}
