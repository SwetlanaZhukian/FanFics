﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Fanfic.Models.ViewModels
{
    public class ChapterCreateViewModel
    {
        public int CompositionId { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string Content { get; set; }
        
        [DisplayName("Image")]
        public IFormFile File { get; set; }
       
    }
}
