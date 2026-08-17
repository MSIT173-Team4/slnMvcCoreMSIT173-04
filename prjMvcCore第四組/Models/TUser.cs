using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models;

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

    public virtual ICollection<TAuditLog> TAuditLogs { get; set; } = new List<TAuditLog>();

    public virtual ICollection<TMapFavorite> TMapFavorites { get; set; } = new List<TMapFavorite>();

    public virtual ICollection<TMessageTable> TMessageTables { get; set; } = new List<TMessageTable>();

    public virtual ICollection<TOrder> TOrders { get; set; } = new List<TOrder>();

    public virtual ICollection<TPostTable> TPostTables { get; set; } = new List<TPostTable>();

    public virtual ICollection<TProductFavorite> TProductFavorites { get; set; } = new List<TProductFavorite>();

    public virtual ICollection<TProductReview> TProductReviews { get; set; } = new List<TProductReview>();

    public virtual ICollection<TRecipeFavorite> TRecipeFavorites { get; set; } = new List<TRecipeFavorite>();

    public virtual ICollection<TRecipeLike> TRecipeLikes { get; set; } = new List<TRecipeLike>();

    public virtual ICollection<TRecipeRecreation> TRecipeRecreations { get; set; } = new List<TRecipeRecreation>();

    public virtual ICollection<TRecipe> TRecipes { get; set; } = new List<TRecipe>();

    public virtual ICollection<TSeller> TSellers { get; set; } = new List<TSeller>();

    public virtual ICollection<TShoppingCart> TShoppingCarts { get; set; } = new List<TShoppingCart>();

    public virtual ICollection<TTrip> TTrips { get; set; } = new List<TTrip>();

    public virtual ICollection<TUserFollow> TUserFollowFFollowees { get; set; } = new List<TUserFollow>();

    public virtual ICollection<TUserFollow> TUserFollowFFollowers { get; set; } = new List<TUserFollow>();

    public virtual ICollection<TUserPantry> TUserPantries { get; set; } = new List<TUserPantry>();
}
