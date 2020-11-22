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
            AddTagToComposition(viewModel.Tags, composition);
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
            var composition = context.Compositions
                .Include(p => p.User)
                .Include(x => x.Tags)
                .Include(k => k.Chapters)
                .Include(r => r.Ratings)
                .Include(c=>c.Comments)
                .FirstOrDefault(x => x.Id == id);
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

            chapter.Image = SaveImage(model.File);
            context.Chapters.Add(chapter);
            context.SaveChanges();
        }

        public string SaveImage(IFormFile file)
        {
            BlobStorageService objBlobService = new BlobStorageService(options);
            byte[] fileData = new byte[file.Length];
            string mimeType = file.ContentType;
            using (var target = new MemoryStream())
            {
                file.CopyTo(target);
                fileData = target.ToArray();
            }
            string imagePath = objBlobService.UploadFileToBlob(file.FileName, fileData, mimeType);
            return imagePath;
        }

        public CompositionViewModel GetCompositionViewModel(Composition composition, string userId)
        {
            List<Tag> tags = GetTagsForComposition(composition);
            CompositionViewModel compositionViewModel = new CompositionViewModel
            {
                Id = composition.Id,
                Name = composition.Name,
                AuthorName = composition.User.Name,
                Genre = composition.GenreOfComposition,
                Description = composition.Description,
                DateOfCreation = composition.DateOfCreation.ToString("dd.MM.yyyy "),
                Date = composition.DateOfCreation,
                Tags = tags,
                Comments=composition.Comments,
                Chapters = composition.Chapters,
                TagsForEdit = string.Join(",", tags.Select(x => x.Name)),

            };
            compositionViewModel.Rating = composition.Ratings.Count > 0 ? composition.Ratings.Average(r => r.RatingValue) : 0;

            var rating = FindRatingForCompositionFromUser(composition.Id, userId);
            if (rating != null)
            {
                compositionViewModel.CurrentUserRating = rating.RatingValue;
            }
            else
            {
                compositionViewModel.CurrentUserRating = 0;
            }
            return compositionViewModel;
        }
        public Rating FindRatingForCompositionFromUser(int compositionId, string userId)
        {
            return context.Ratings.FirstOrDefault(u => u.UserId == userId && u.CompositionId == compositionId);
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
        public void EditComposition(CompositionViewModel compositionViewModel)
        {
            var composition = FindComposition(compositionViewModel.Id);
            RemoveTagComposition(composition);

            composition.Name = compositionViewModel.Name;
            composition.GenreOfComposition = compositionViewModel.Genre;
            composition.Description = compositionViewModel.Description;

            AddTagToComposition(compositionViewModel.TagsForEdit, composition);

            context.Compositions.Update(composition);
            context.SaveChanges();
        }
        public void AddTagToComposition(string tagsFromViewModel, Composition composition)
        {
            var tagsWithoutSpaces = String.Join("", tagsFromViewModel.Where(c => !char.IsWhiteSpace(c)));
            string[] tags = tagsWithoutSpaces.Split(",");
            foreach (var tag in tags)
            {
                if (!(context.Tags.Select(p => p.Name).Contains(tag)))
                {
                    Tag tagNew = CreateTag(tag);
                    CreateTagComposition(tagNew, composition);
                }
                else
                {
                    var tagExisting = context.Tags.FirstOrDefault(p => p.Name == tag);

                    CreateTagComposition(tagExisting, composition);
                }

            }
        }

        public void RemoveTagComposition(Composition composition)
        {
            var tagComposition = context.TagCompositions.Where(p => p.CompositionId == composition.Id);
            context.RemoveRange(tagComposition);
            context.SaveChanges();
        }
        public EditChapterViewModel GetEditChapterViewModel(Chapter chapter)
        {
            EditChapterViewModel editChapterViewModel = new EditChapterViewModel
            {
                ChapterId = chapter.Id,
                Name = chapter.Name,
                Content = chapter.Content
            };
            return editChapterViewModel;
        }
        public void EditChapter(EditChapterViewModel editChapterViewModel)
        {
            var chapter = GetChapter(editChapterViewModel.ChapterId);
            chapter.CompositionId = editChapterViewModel.CompositionId;
            chapter.Name = editChapterViewModel.Name;
            chapter.Content = editChapterViewModel.Content;
            chapter.DateOfUpdate = DateTime.Now;
            if (editChapterViewModel.File != null)
            {
                chapter.Image = SaveImage(editChapterViewModel.File);
            }

            context.Chapters.Update(chapter);
            context.SaveChanges();

        }
        public void DeleteChapter(Chapter chapter)
        {
            context.Chapters.Remove(chapter);
            context.SaveChanges();
        }
        public ChaptersWhithPaginationViewModel GetChaptersWhithPaginationView(int page, int compositionId)
        {
            int pageSize = 1;
            var composition = FindComposition(compositionId);
            PageViewModel pageViewModel = new PageViewModel(composition.Chapters.Count(), page, pageSize);
            ChaptersWhithPaginationViewModel chaptersWhithPaginationViewModel = new ChaptersWhithPaginationViewModel
            {
                PageViewModel = pageViewModel,
                Chapters = composition.Chapters
            };

            return chaptersWhithPaginationViewModel;
        }
        public async Task CreateRating(float stars, int compositionId, string userId)
        {
            var rating = new Rating
            {
                CompositionId = compositionId,
                UserId = userId,
                RatingValue = stars


            };
            if (context.Ratings.Any(x => x.UserId == userId && x.CompositionId == compositionId))
            {
                context.Ratings.Update(rating);
            }
            else
            {
                await context.Ratings.AddAsync(rating);
            }


            await context.SaveChangesAsync();
        }
        public void RemoveRating(string userId, int compositionId)
        {
            var rating = FindRatingForCompositionFromUser(compositionId, userId);
            context.Ratings.Remove(rating);
            context.SaveChanges();
        }

        public List<CompositionViewModel> GetAllNotEmptyCompositions(string userId)
        {
            var compositions = context.Compositions.Include(p => p.User)
                .Include(x => x.Tags)
                .Include(k => k.Chapters)
                .Include(r => r.Ratings).Where(p => p.Chapters.Count() > 0).ToList();
            List<CompositionViewModel> compositionViewModels = new List<CompositionViewModel>();
            foreach (var composition in compositions)
            {
                var model = GetCompositionViewModel(composition, userId);
                compositionViewModels.Add(model);
            }
            return compositionViewModels;
        }
        public List<CompositionViewModel> GetCompositionViewModelByTagName(List<CompositionViewModel> models, string tagName)
        {
            return models.Where(p => p.Tags.Select(p => p.Name).Contains(tagName)).ToList();
        }

        public List<CompositionViewModel> FiltrCompositionViewModelByRatingAndDate(List<CompositionViewModel> models)
        {
            return models.Where(p => p.Rating >= 4.0 | p.Date > DateTime.Now.AddDays(-2)).OrderByDescending(p => p.Rating).ToList();
        }
        public async Task SaveComment(int compositionId, string message, string userName)
        {
            var user = context.Users.FirstOrDefault(p => p.UserName == userName);
            Comment comment = new Comment
            {
                Message = message,
                CompositionId = compositionId,
                UserId = user.Id

            };
            await context.Comments.AddAsync(comment);
            await context.SaveChangesAsync();

        }
    }

}

