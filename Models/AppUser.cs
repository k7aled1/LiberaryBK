using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LiberaryBK.Models
{
    public class AppUser:IdentityUser
    {
        public AppUser():base()
        {
            Bookss = new HashSet<Books>();
            Commentsu = new HashSet<Comments>();
            Ratesu = new HashSet<Rate>();

            FollowerFIdUNavigation = new HashSet<Followers>();
            FollowerFollowUNavigation = new HashSet<Followers>();
        }
        public string Name { get; set; }
        public string Photo { get; set; }

        public virtual ICollection<Books> Bookss { get; set; }
        public virtual ICollection<Comments> Commentsu { get; set; }
        public virtual ICollection<Rate> Ratesu { get; set; }

        public ICollection<Followers> FollowerFIdUNavigation { get; set; }
        public ICollection<Followers> FollowerFollowUNavigation { get; set; }
    }
}
