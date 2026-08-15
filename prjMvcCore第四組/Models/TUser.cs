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

        public virtual ICollection<TApply> TApplies { get; set; } = new List<TApply>();

        public virtual ICollection<TMapFavorite> TMapFavorites { get; set; } = new List<TMapFavorite>();

        public virtual ICollection<TMessageTable> TMessageTables { get; set; } = new List<TMessageTable>();

        public virtual ICollection<TPostTable> TPostTables { get; set; } = new List<TPostTable>();

        public virtual ICollection<TRecipeFavorite> TRecipeFavorites { get; set; } = new List<TRecipeFavorite>();

        public virtual ICollection<TSeller> TSellers { get; set; } = new List<TSeller>();

        public virtual ICollection<TTrip> TTrips { get; set; } = new List<TTrip>();
    }
}