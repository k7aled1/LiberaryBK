using System;
using System.Collections.Generic;

namespace LiberaryBK.Models
{
    public partial class Types
    {
        public Types()
        {
            Bookss = new HashSet<Books>();
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Books> Bookss { get; set; }
    }
}
