using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Models
{
    public enum Genre
    {
        Fantasy,
        Western,
        Horror,
        Classic,
        FairyTale,
        Humor,
        Thriller,
        Biograpy,
        Detective
    }
    public class Composition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Genre GenreOfComposition { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public List<Chapter> Chapters { get; set; }
        public List<TagComposition> Tags { get; set; }


        public Composition()
        {
            Chapters = new List<Chapter>();
            Tags = new List<TagComposition>();
        }

    }
    }
