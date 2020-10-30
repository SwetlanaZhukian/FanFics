using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Fanfic.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Fanfic.Models;
using Fanfic.Models.Context;
using Org.BouncyCastle.Crypto;

namespace Fanfic.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministratorController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<User> signInManager;
        private readonly ApplicationContext context;
        public AdministratorController(UserManager<User> _userManager, RoleManager<IdentityRole> _roleManager, ApplicationContext _context, SignInManager<User> _signInManager)
        {
            userManager = _userManager;
            roleManager = _roleManager;
            context = _context;
            signInManager = _signInManager;
        }
        public async Task<IActionResult> Index(int page = 1)
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

            return View(usersWithPaginationViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await FindUser(id);
            if (user == null)
            {
                return RedirectToAction("Error");
            }
            else
            {
                var result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View("Index");
            }

        }
        [HttpPost]
        public async Task<IActionResult> Blocked(string id)
        {
            var user = await FindUser(id);
            if (user == null)
            {
                return RedirectToAction("Error");
            }
            else
            {
                user.Block = true;
            }
            context.Users.Update(user);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> UnBlocked(string id)
        {
            var user = await FindUser(id);
            if (user == null)
            {
                return RedirectToAction("Error");
            }
            else
            {
                user.Block = false;
            }
            context.Users.Update(user);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAdminRole(string id)
        {
            var user = await FindUser(id);
            if (user == null)
            {
               
                return RedirectToAction("Error");
            }
            else
            {
                await userManager.RemoveFromRoleAsync(user, "Admin");
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public async Task<IActionResult> AddAdminRole(string id)
        {
            var user = await FindUser(id);
            if (user == null)
            {
                return RedirectToAction("Error");
            }
            else
            {
                await userManager.AddToRoleAsync(user, "Admin");
                return RedirectToAction("Index");
            }

        }

        public IActionResult Error()
        {
            ViewBag.ErrorMessage = "User cannot be found";
            return View("NotFound");
        }

        public async Task<User> FindUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            return user;
        }


    }
}
