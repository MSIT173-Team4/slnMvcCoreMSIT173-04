using System;
using System.Collections.Generic;
namespace prjMvcCore第四組.Models
{
    public partial class TSeller
    {
        public int FId { get; set; }

        public int FUserId { get; set; }

        public string FName { get; set; } = null!;

        public string? FDescription { get; set; }

        public int FStatus { get; set; }

        public DateTime FApplyDate { get; set; }

        public virtual TStatus FStatusNavigation { get; set; } = null!;

        public virtual TUser FUser { get; set; } = null!;
    }
}