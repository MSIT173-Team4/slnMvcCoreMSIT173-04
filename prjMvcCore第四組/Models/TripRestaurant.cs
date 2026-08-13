using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models
{

    public partial class TripRestaurant
    {
        public long TripRestaurantId { get; set; }

        public long TripId { get; set; }

        public long RestaurantId { get; set; }

        public int SortOrder { get; set; }

        public TimeOnly? VisitTime { get; set; }

        public int? StayMinutes { get; set; }

        public string? Note { get; set; }

        public DateTime CreatedTime { get; set; }

        public virtual Restaurant Restaurant { get; set; } = null!;

        public virtual Trip Trip { get; set; } = null!;
    }
}