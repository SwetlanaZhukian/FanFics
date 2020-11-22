using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Models.ViewModels
{
    public class CompositionViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Your rating")]
        public float CurrentUserRating { get; set; }
        [DisplayName("Average rating")]
        public float Rating  { get; set; }
        [DisplayName("Author")]
        public string AuthorName { get; set; }
      
        public List<Tag> Tags { get; set; }
        [Required(ErrorMessage = "The Tags field is required.")]
        public string TagsForEdit { get; set; }
        public Genre Genre { get; set; }
        [DisplayName("Date of creation")]
        public string DateOfCreation { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string Description { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Chapter> Chapters { get; set; }
    }
}
