using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Models
{
    public class TagComposition
    {
        public int TagId { get; set; }
        public Tag Tag { get; set; }

        public int CompositionId { get; set; }
        public Composition Composition { get; set; }
    }
}
