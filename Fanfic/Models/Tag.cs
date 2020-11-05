using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<TagComposition> Compositions { get; set; }

        public Tag()
        {
            Compositions = new HashSet<TagComposition>();
        }
    }
}
