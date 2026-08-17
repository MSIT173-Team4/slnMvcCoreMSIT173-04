using System;
using System.Collections.Generic;

namespace prjMvcCoreMSIC173-04.Models;

public partial class TRecipeFavorite
{
    public int FUserId { get; set; }

    public int FRecipeId { get; set; }

    public DateTime FCreatedAt { get; set; }

    public virtual TRecipe FRecipe { get; set; } = null!;

    public virtual TUser FUser { get; set; } = null!;
}
