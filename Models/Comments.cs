using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiberaryBK.Models
{
    public partial class Comments
    {
        public int ComntId { get; set; }
        public string ComntText { get; set; }
        [Required]
        [ForeignKey("Userc")]
        public string UserF4 { get; set; }
        [Required]
        [ForeignKey("BookF3Navigation")]
        public int BookF3 { get; set; }
        public string ComntPic { get; set; }

        public virtual AppUser Userc { get; set; }
        public virtual Books BookF3Navigation { get; set; }
    }
}
