using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models;

public partial class TAuditLog
{
    public int FLogId { get; set; }

    public int FAdminUserId { get; set; }

    public int FTargetRecipeId { get; set; }

    public string FAction { get; set; } = null!;

    public string FReason { get; set; } = null!;

    public DateTime FExecutedAt { get; set; }

    public virtual TUser FAdminUser { get; set; } = null!;

    public virtual TRecipe FTargetRecipe { get; set; } = null!;
}
