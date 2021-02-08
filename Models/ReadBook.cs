using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiberaryBK.Models
{
    public partial class ReadBook
    {
        [Required]
        [ForeignKey("UserRB")]
        public string UserF2 { get; set; }
        public int BookF1 { get; set; }
        public int ReadId { get; set; }

        public virtual Books BookF1Navigation { get; set; }
        public virtual AppUser UserRB { get; set; }
    }
}
