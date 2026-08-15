using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models
{

    public partial class TTripRestaurant
    {
        public long FTripRestaurantId { get; set; }

        public long FTripId { get; set; }

        public long FRestaurantId { get; set; }

        public int FSortOrder { get; set; }

        public TimeOnly? FVisitTime { get; set; }

        public int? FStayMinutes { get; set; }

        public string? FNote { get; set; }

        public DateTime FCreatedTime { get; set; }

        public virtual TRestaurant FRestaurant { get; set; } = null!;

        public virtual TTrip FTrip { get; set; } = null!;
    }
}