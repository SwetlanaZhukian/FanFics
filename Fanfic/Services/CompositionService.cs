using Fanfic.Configuration;
using Fanfic.Models;
using Fanfic.Models.Context;
using Fanfic.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Services
{
    public class CompositionService
    {
        private readonly ApplicationContext context;
        private readonly IOptions<BlobConfig> options;
        public CompositionService(ApplicationContext context, IOptions<BlobConfig> blobOptions)
        {
            this.context = context;
            options = blobOptions;
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
            var composition = context.Compositions.Include(p=>p.User).Include(x=>x.Tags).Include(k=>k.Chapters).FirstOrDefault(x => x.Id == id);
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

            BlobStorageService objBlobService = new BlobStorageService(options);
            byte[] fileData = new byte[model.File.Length];
            string mimeType = model.File.ContentType;
            using (var target = new MemoryStream())
            {
                model.File.CopyTo(target);
                fileData = target.ToArray();
            }  
            chapter.Image = objBlobService.UploadFileToBlob(model.File.FileName, fileData, mimeType);
            context.Chapters.Add(chapter);
            context.SaveChanges();
        }

        public CompositionViewModel GetCompositionViewModel(Composition composition)
        {
            List<Tag> tags = GetTagsForComposition(composition);
            CompositionViewModel compositionViewModel = new CompositionViewModel
            {
                Name = composition.Name,
                AuthorName = composition.User.Name,
                Genre = composition.GenreOfComposition,
                Description = composition.Description,
                DateOfCreation = composition.DateOfCreation.ToString("dd.MM.yyyy "),
                Tags=tags,
                Chapters=composition.Chapters

            };
            return compositionViewModel;
        }
        public void DeleteComposition(Composition composition)
        {
            context.Compositions.Remove(composition);
            context.SaveChanges();
        }
        public List<Tag> GetTagsForComposition(Composition composition)
        {
            List<Tag> tags = new List<Tag>();
            foreach (var tagComposition in composition.Tags)
            {
                var tag = context.Tags.FirstOrDefault(p => p.Id == tagComposition.TagId);
                tags.Add(tag);
            }
            return tags;
        }
        public Chapter GetChapter(int id)
        {
            var chapter = context.Chapters.FirstOrDefault(x => x.Id == id);
            return chapter;
        }
        
    }
}
