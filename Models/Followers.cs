using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LiberaryBK.Models
{
    public class Followers
    {
        [Required]
        public string FIdU { get; set; }
        [Required]
        public string FollowU { get; set; }
        public int FllId { get; set; }

        public AppUser FIdUNavigation { get; set; }
        public AppUser FollowUNavigation { get; set; }
    }
}
