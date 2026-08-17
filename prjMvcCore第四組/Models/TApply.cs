using System;
using System.Collections.Generic;

namespace prjMvcCoreMSIC173-04.Models;

public partial class TApply
{
    public int FId { get; set; }

    public int FUserId { get; set; }

    public string FStoreName { get; set; } = null!;

    public string FStoreDescription { get; set; } = null!;

    public string FIdNum { get; set; } = null!;

    public string FIdCard { get; set; } = null!;

    public int FStatus { get; set; }

    public DateTime FApplyDate { get; set; }

    public virtual TUser FUser { get; set; } = null!;
}
