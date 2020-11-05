using System.ComponentModel.DataAnnotations;


namespace Fanfic.Models.ViewModels
{
    public class ChapterCreateViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
