using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public bool Block { get; set; }
        public List<Composition> Compositions { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public User()
        {
            Compositions = new List<Composition>();
            Ratings = new List<Rating>();
           
        }
    }
}
