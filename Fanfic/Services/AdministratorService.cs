using Fanfic.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fanfic.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Fanfic.Models;
using Microsoft.EntityFrameworkCore;

namespace Fanfic.Services
{
    public class AdministratorService
    {
        private readonly ApplicationContext context;
        private readonly UserManager<User> userManager;
        public static Dictionary<string, string> DeletedUsers= new Dictionary<string, string>();
        public AdministratorService(ApplicationContext applicationContext, UserManager<User> user)
        {
            context = applicationContext;
            userManager = user;
        }

        public async Task<UsersWithPaginationViewModel> GetUsersWithPaginationView(int page)
        {
            int pageSize = 7;
            List<UsersViewModel> usersViewModels = new List<UsersViewModel>();
            var users = context.Users.ToList();

            foreach (var user in users)
            {
                UsersViewModel model = new UsersViewModel
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    EmailConfirmed = user.EmailConfirmed,
                    IsBlocked = user.Block,
                    Roles = await userManager.GetRolesAsync(user)
                };
                usersViewModels.Add(model);
            }
            PageViewModel pageViewModel = new PageViewModel(users.Count, page, pageSize);
            UsersWithPaginationViewModel usersWithPaginationViewModel = new UsersWithPaginationViewModel
            {
                PageViewModel = pageViewModel,
                Users = usersViewModels.Skip((page - 1) * pageSize).Take(pageSize)
            };
            return usersWithPaginationViewModel;
        }
        public async Task<User> FindUserAsync(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            return user;
        }
        public User FindUser(string id)
        {
            var user = context.Users.Include(c=>c.Compositions).FirstOrDefault(p => p.Id == id);
            return user;
        }
        public async Task<IdentityResult> DeleteAsync(User user)
        {
           
            return await userManager.DeleteAsync(user);
        }
        public void Block(User user)
        {
            user.Block = true;
            context.Users.Update(user);
            context.SaveChanges();
        }
        public void UnBlock(User user)
        {
            user.Block = false;
            context.Users.Update(user);
            context.SaveChanges();
        }
        public async Task DeleteRoleAsync(User user)
        {
            await userManager.RemoveFromRoleAsync(user, "Admin");
        }
        public async Task AddRoleAsync(User user)
        {
            await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}
