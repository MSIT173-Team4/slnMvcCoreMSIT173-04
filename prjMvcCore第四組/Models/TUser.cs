using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models
{
    public partial class TUser
    {
        public int FId { get; set; }

        public string FUsername { get; set; } = null!;

        public string? FNickname { get; set; }

        public byte[] FPassword { get; set; } = null!;

        public string FEmail { get; set; } = null!;

        public string FIdNum { get; set; } = null!;

        public string FPhone { get; set; } = null!;

        public bool FGender { get; set; }

        public string FAddress { get; set; } = null!;

        public string? FProfileImg { get; set; }

        public bool FIsActive { get; set; }

        public DateTime FCreateDate { get; set; }

        public DateTime? FLastLogin { get; set; }

        public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

        public virtual ICollection<MapFavorite> MapFavorites { get; set; } = new List<MapFavorite>();

        public virtual ICollection<MessageTable> MessageTables { get; set; } = new List<MessageTable>();

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public virtual ICollection<PostTable> PostTables { get; set; } = new List<PostTable>();

        public virtual ICollection<ProductReview> ProductReviews { get; set; } = new List<ProductReview>();

        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();

        public virtual ICollection<TApply> TApplies { get; set; } = new List<TApply>();

        public virtual ICollection<TSeller> TSellers { get; set; } = new List<TSeller>();

        public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
    }
}