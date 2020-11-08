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
        private readonly ApplicationContext context;
        private readonly UserService userService;
        public UserController(UserManager<User> manager, ApplicationContext applicationContext, UserService service)
        {
            userManager = manager;
            context = applicationContext;
            userService = service;
        }
        public async Task<IActionResult> Index(int? tag, string name,int page= 1,SortState sortOrder = SortState.NameAsc)
        {
        
            IdentityUser user = await userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            var model = userService.GetUserCompositions((User)user);
            //if (tag != null )
            //{
              
            //    model = model.Where(p=>p.Tags.FirstOrDefault(p=>p.Id==tag));
            //}
            if (!String.IsNullOrEmpty(name))
            {
                model = model.Where(p => p.Name.Contains(name)).ToList();
            }
            var userProfileWithPaginationViewModel = userService.GetProfileWithPaginationView(tag, name,model, sortOrder, page);
            return View(userProfileWithPaginationViewModel);

        }
    }
}
