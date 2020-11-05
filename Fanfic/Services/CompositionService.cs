using Fanfic.Models;
using Fanfic.Models.Context;
using Fanfic.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Services
{
    public class CompositionService
    {
        private readonly ApplicationContext context;
        private readonly UserManager<User> userManager;
        public CompositionService(ApplicationContext context, UserManager<User> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public Composition CreateComposition(CompositionCreateViewModel viewModel, IdentityUser user)
        {
            Composition composition = new Composition()
            {
                Name = viewModel.Name,
                GenreOfComposition = viewModel.Genre,
                Description = viewModel.Description,
                User = user as User,
                DateOfCreation = DateTime.Now

            };
            context.Compositions.Add(composition);
            context.SaveChanges();
            object[] tags = viewModel.Tags.Split(",");
            foreach (var tag in tags)
            {
                if (!(context.Tags.Select(p => p.Name).Contains(tag.ToString())))
                {
                    Tag tagNew = CreateTag(tag);
                    CreateTagComposition(tagNew, composition);
                }
                else
                {
                    var tagExisting = context.Tags.FirstOrDefault(p => p.Name == tag.ToString());
                    CreateTagComposition(tagExisting, composition);
                }
            }
            return composition;
        }
        public Tag CreateTag(object tagFromView)
        {

            Tag tag = new Tag
            {
                Name = tagFromView.ToString()
            };
            context.Tags.Add(tag);
            context.SaveChanges();

            return tag;

        }

        public void CreateTagComposition(Tag tag, Composition composition)
        {
            TagComposition tagComposition = new TagComposition
            {
                CompositionId = composition.Id,
                TagId = tag.Id
            };
            context.TagCompositions.Add(tagComposition);
            context.SaveChanges();
        }

        public string GetTags()
        { 
            return string.Join(",", context.Tags.Select(x => x.Name).ToList());
        }

        public Composition FindComposition(int id)
        {
            var composition = context.Compositions.FirstOrDefault(x => x.Id == id);
            return composition;
        }
        public void CreateChapter(ChapterCreateViewModel model, Composition composition)
        {
            Chapter chapter = new Chapter
            {
                Name = model.Name,
                Content = model.Content,
                Composition = composition,
                CompositionId = composition.Id,
                DateOfCreation = DateTime.Now    
            };
            context.Chapters.Add(chapter);
            context.SaveChanges();
        }
    }
}
