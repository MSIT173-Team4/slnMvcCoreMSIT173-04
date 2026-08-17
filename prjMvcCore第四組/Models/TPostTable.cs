using System;
using System.Collections.Generic;

namespace prjMvcCoreMSIC173-04.Models;

public partial class TPostTable
{
    public int FPostId { get; set; }

    public int FUserId { get; set; }

    public string FTitle { get; set; } = null!;

    public string FPostContent { get; set; } = null!;

    public int FLikes { get; set; }

    public int FViews { get; set; }

    public DateTime FPostDate { get; set; }

    public byte FPostState { get; set; }

    public virtual TUser FUser { get; set; } = null!;

    public virtual ICollection<TMessageTable> TMessageTables { get; set; } = new List<TMessageTable>();
}
