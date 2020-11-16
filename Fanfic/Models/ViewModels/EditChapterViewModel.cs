using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Models.ViewModels
{
    public class EditChapterViewModel
    {

        public int CompositionId { get; set; }
        public int ChapterId { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Content { get; set; }
      
        [DisplayName("Image")]
        public IFormFile File { get; set; }
    }
}
