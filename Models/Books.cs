using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiberaryBK.Models
{
    public partial class Books
    {
        public Books()
        {
            Comments = new HashSet<Comments>();
            Rate = new HashSet<Rate>();
            ReadBook = new HashSet<ReadBook>();
        }
        public int BookId { get; set; }
        [Required, StringLength(30, MinimumLength = 3)]
        public string BookName { get; set; }
        public decimal? Price { get; set; }
        [Required]
        [ForeignKey("TypeF1Navigation")]
        public int TypeF1 { get; set; }
        [Required]
        public string BookPdf { get; set; }
        public string Description { get; set; }
        public string BookCover { get; set; }

        [Required]
        [ForeignKey("Userr")]
        public string Writer { get; set; }
        public virtual AppUser Userr { get; set; }
        public virtual Types TypeF1Navigation { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Rate> Rate { get; set; }
        public virtual ICollection<ReadBook> ReadBook { get; set; }
    }
}
