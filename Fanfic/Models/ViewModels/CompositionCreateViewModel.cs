using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Models.ViewModels
{
    public class CompositionCreateViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public Genre Genre { get; set; }
        [Required]
        public string Tags { get; set; }
        [Required]
        public string Description { get; set; }

    }
}
