using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiberaryBK.Models
{
    public partial class Rate
    {

        [Required]
        [ForeignKey("UserRate")]
        public string UserF3 { get; set; }
        public int BookF2 { get; set; }
        public int Stars { get; set; }
        public int RateId { get; set; }

        public virtual Books BookF2Navigation { get; set; }
        public virtual AppUser UserRate { get; set; }
    }
}
