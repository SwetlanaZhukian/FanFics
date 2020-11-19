using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Models
{
    public class Rating
    {
        public float RatingValue { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int CompositionId { get; set; }
        public Composition Composition { get; set; }
    }
}
