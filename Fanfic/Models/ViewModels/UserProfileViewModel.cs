using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Models.ViewModels
{
    public enum SortState
    {
        NameAsc,  
        NameDesc,
        DescriptionAsc,
        DescriptionDesc,
        GenreAsc,
        GenreDesc,
        DateOfCreationAsc,
        DateOfCreationDesc,
        NumberOfChaptersAsc,
        NumberOfChaptersDesc

    }
    public class UserProfileViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public List<Tag> Tags { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int  NumberOfChapters { get; set; }
    }
}
