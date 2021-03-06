﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Models
{
    public enum Genre
    {
        Biography=1,
        Classic,
        Detective,
        FairyTale,
        Fantasy,
        Horror,  
        Humor,
        Thriller,
        Western
    }
    public class Composition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Genre GenreOfComposition { get; set; }
        public string Image { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public IEnumerable<Chapter> Chapters { get; set; }
        public IEnumerable<TagComposition> Tags { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<Comment> Comments{ get; set; }


        public Composition()
        {
            Chapters = new HashSet<Chapter>();
            Tags = new HashSet<TagComposition>();
            Ratings = new List<Rating>();
            Comments = new List<Comment>();
        }

    }
    }
