using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Models.ViewModels
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Tag> tags, Genre genre, int? tag,  string name)
        {
           
            tags.Insert(0, new Tag { Name = "All", Id=0});
            Tags = new SelectList(tags, "Id", "Name", tag);
            SelectedTag = tag;
            SelectedName = name;
            SelectedGenre = genre;
            
        }
        public SelectList Tags { get; private set; } 
        public int? SelectedTag { get; private set; }   
        public string SelectedName { get; private set; }
        public Genre SelectedGenre { get; private set; }
    }
}
