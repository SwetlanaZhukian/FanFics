using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Message { get; set; }

        public string UserName{ get; set; }
        public int CompositionId { get; set; }

        [ForeignKey("CompositionId")]
        public Composition Composition { get; set; }

    }
}
