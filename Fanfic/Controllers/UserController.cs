using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fanfic.Models;
using Fanfic.Models.Context;
using Fanfic.Models.ViewModels;
using Fanfic.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Fanfic.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly UserService userService;
        public UserController(UserManager<User> manager, UserService service)
        {
            userManager = manager;
            userService = service;
        }
        public async Task<IActionResult> Index(int? tag, Genre genre, string name, int page = 1, SortState sortOrder = SortState.NameAsc)
        {

            IdentityUser user = await userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var model = userService.GetUserCompositions((User)user);
            if (tag != null && tag != 0)
            {
                model = userService.FilterByTag(model, tag);
            }
            if (!String.IsNullOrEmpty(name))
            {
                model = userService.FilterByName(model, name);
            }
            if (genre != 0)
            {
                model = userService.FilterByGenre(model, genre);
            }
            var userProfileWithPaginationViewModel = userService.GetProfileWithPaginationView(tag, genre, name, model, sortOrder, page);
            return View(userProfileWithPaginationViewModel);

        }
       
        
      
    }
}
