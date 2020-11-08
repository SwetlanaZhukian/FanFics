using Fanfic.Models;
using Fanfic.Models.Context;
using Fanfic.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Services
{
    public class UserService
    {
        private readonly ApplicationContext context;
        public UserService(ApplicationContext applicationContext)
        {
            context = applicationContext;
        }
        public List<UserProfileViewModel> GetUserCompositions(User user)
        {
            List<UserProfileViewModel> userProfileViewModels = new List<UserProfileViewModel>();
            var compositions= context.Compositions.Where(p => p.UserId == user.Id).Include(x=>x.Tags).Include(t=>t.Chapters).ToList();
            foreach (var item in compositions)
            {
                List<Tag> tags = new List<Tag>();
                foreach (var tagComposition in item.Tags)
                {
                    var tag = context.Tags.FirstOrDefault(x => x.Id == tagComposition.TagId);
                    tags.Add(tag);
                }
                UserProfileViewModel userProfileViewModel = new UserProfileViewModel
                {
                    Name = item.Name,
                    Description = item.Description,
                    DateOfCreation = item.DateOfCreation,
                    Tags =tags,
                    Genre=item.GenreOfComposition,
                    NumberOfChapters=item.Chapters.Count()

                };
                userProfileViewModels.Add(userProfileViewModel);

            }
            return userProfileViewModels;
        }
        public UserProfileWithPaginationViewModel GetProfileWithPaginationView(int? tag,  string name ,List<UserProfileViewModel> model, SortState sortOrder,int page)
        {
            int pageSize = 10;
            model = SortUserProfileViewModel(model, sortOrder);
            var count = model.Count();
            var items = model.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            UserProfileWithPaginationViewModel userProfileWithPaginationViewModel = new UserProfileWithPaginationViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                ProfileViewModels = items,
                FilterViewModel = new FilterViewModel(context.Tags.ToList(), tag, name),
            };
            return userProfileWithPaginationViewModel;
        }
        public List<UserProfileViewModel> SortUserProfileViewModel(List<UserProfileViewModel> model, SortState sortOrder)
        {
            model = sortOrder switch
            {
                SortState.NameDesc => model.OrderByDescending(s => s.Name).ToList(),
                SortState.DescriptionAsc => model.OrderBy(s => s.Description).ToList(),
                SortState.DescriptionDesc => model.OrderByDescending(s => s.Description).ToList(),
                SortState.GenreAsc => model.OrderBy(s => s.Genre).ToList(),
                SortState.GenreDesc => model.OrderByDescending(s => s.Genre).ToList(),
                SortState.DateOfCreationAsc => model.OrderBy(s => s.DateOfCreation).ToList(),
                SortState.DateOfCreationDesc => model.OrderByDescending(s => s.DateOfCreation).ToList(),
                SortState.NumberOfChaptersAsc => model.OrderBy(s => s.NumberOfChapters).ToList(),
                SortState.NumberOfChaptersDesc => model.OrderByDescending(s => s.NumberOfChapters).ToList(),
                _ => model.OrderBy(s => s.Name).ToList()
            };
            return model;
        }
    }
}
