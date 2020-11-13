using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Models.ViewModels
{
    public class CompositionViewModel
    {
        public  int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Author")]
        public string AuthorName { get; set; }
        public List<Tag> Tags  { get; set; }
        public Genre  Genre{ get; set; }
        [DisplayName("Date of creation")]
        public string DateOfCreation { get; set; }
        public string  Description { get; set; }
        public IEnumerable<Chapter> Chapters { get; set; }
    }
}
