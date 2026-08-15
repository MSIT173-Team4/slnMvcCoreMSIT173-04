using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models
{

    public partial class TMapFavorite
    {
        public long FFavoriteId { get; set; }

        public int FUsersId { get; set; }

        public long FRestaurantId { get; set; }

        public DateTime FCreatedTime { get; set; }

        public virtual TRestaurant FRestaurant { get; set; } = null!;

        public virtual TUser FUsers { get; set; } = null!;
    }
}