using System;
using System.Collections.Generic;

namespace prjMvcCore第四組.Models
{

    public partial class TStatus
    {
        public int FId { get; set; }

        public string FName { get; set; } = null!;

        public virtual ICollection<TSeller> TSellers { get; set; } = new List<TSeller>();
    }
}