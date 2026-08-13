using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models
{

    public partial class MapFavorite
    {
        public long FavoriteId { get; set; }

        public int UsersId { get; set; }

        public long RestaurantId { get; set; }

        public DateTime CreatedTime { get; set; }

        public virtual Restaurant Restaurant { get; set; } = null!;

        public virtual TUser Users { get; set; } = null!;
    }
}