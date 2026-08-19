using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models;

public partial class TUserFollow
{
    public int FFollowerId { get; set; }

    public int FFolloweeId { get; set; }

    public DateTime FCreatedAt { get; set; }

    public virtual TUser FFollowee { get; set; } = null!;

    public virtual TUser FFollower { get; set; } = null!;
}
