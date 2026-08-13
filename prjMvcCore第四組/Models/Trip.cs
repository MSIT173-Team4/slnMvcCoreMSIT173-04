using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models
{

    public partial class Trip
    {
        public long TripId { get; set; }

        public int UsersId { get; set; }

        public string TripName { get; set; } = null!;

        public DateOnly TripDate { get; set; }

        public TimeOnly? StartTime { get; set; }

        public string? Description { get; set; }

        public string Status { get; set; } = null!;

        public DateTime CreatedTime { get; set; }

        public DateTime? UpdatedTime { get; set; }

        public virtual ICollection<TripRestaurant> TripRestaurants { get; set; } = new List<TripRestaurant>();

        public virtual TUser Users { get; set; } = null!;
    }
}