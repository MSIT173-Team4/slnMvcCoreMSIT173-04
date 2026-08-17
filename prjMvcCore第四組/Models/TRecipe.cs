using System;
using System.Collections.Generic;

namespace prjMvcCoreMSIC173-04.Models;

public partial class TRecipe
{
    public int FRecipeId { get; set; }

    public int FAuthorUserId { get; set; }

    public string FTitle { get; set; } = null!;

    public string? FDescription { get; set; }

    public int FDefaultServings { get; set; }

    public string? FCoverImageUrl { get; set; }

    public int FTotalCookingMinutes { get; set; }

    public int FViewCount { get; set; }

    public int FStatus { get; set; }

    public bool FIsAiGenerated { get; set; }

    public DateTime FCreatedAt { get; set; }

    public DateTime FUpdatedAt { get; set; }

    public virtual TUser FAuthorUser { get; set; } = null!;

    public virtual ICollection<TAuditLog> TAuditLogs { get; set; } = new List<TAuditLog>();

    public virtual ICollection<TRecipeFavorite> TRecipeFavorites { get; set; } = new List<TRecipeFavorite>();

    public virtual ICollection<TRecipeIngredient> TRecipeIngredients { get; set; } = new List<TRecipeIngredient>();

    public virtual ICollection<TRecipeLike> TRecipeLikes { get; set; } = new List<TRecipeLike>();

    public virtual ICollection<TRecipeRecreation> TRecipeRecreations { get; set; } = new List<TRecipeRecreation>();

    public virtual ICollection<TRecipeStep> TRecipeSteps { get; set; } = new List<TRecipeStep>();

    public virtual ICollection<TTag> FTags { get; set; } = new List<TTag>();
}
