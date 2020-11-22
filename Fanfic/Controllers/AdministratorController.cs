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
using Fanfic.Services;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Bcpg;

namespace Fanfic.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministratorController : Controller
    {
     
        private readonly AdministratorService administratorService;
        public AdministratorController(AdministratorService service)
        {       
            administratorService = service;
        }
        public async Task<IActionResult> Index(int page = 1)
        {

            UsersWithPaginationViewModel usersWithPaginationViewModel = await administratorService.GetUsersWithPaginationView(page);
            return View(usersWithPaginationViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var user =  administratorService.FindUser(id);
           
            if (user == null)
            {
                return RedirectToAction("Error");
            }
            else
            {
                if (user.Compositions.Count > 0)
                {
                    ViewBag.ErrorMessage = "You cannot delete this user!";
                    return View("NotFound");
                }

                    if (!AdministratorService.DeletedUsers.ContainsKey(user.UserName))
                    {
                        AdministratorService.DeletedUsers.Add(user.UserName, user.Id);
                    }
                    var result = await administratorService.DeleteAsync(user);
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
            
            var user = await administratorService.FindUserAsync(id);
            if (user == null)
            {
                return RedirectToAction("Error");
            }
            else
            {
                if (!AdministratorService.DeletedUsers.ContainsKey(user.UserName))
                {
                    AdministratorService.DeletedUsers.Add(user.UserName, user.Id);
                }
                administratorService.Block(user);
                
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> UnBlocked(string id)
        {
            var user = await administratorService.FindUserAsync(id); ;
            if (user == null)
            {
                return RedirectToAction("Error");
            }
            else
            {
                AdministratorService.DeletedUsers.Remove(user.UserName);
                administratorService.UnBlock(user);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAdminRole(string id)
        {
            var user = await administratorService.FindUserAsync(id);
            if (user == null)
            {
               
                return RedirectToAction("Error");
            }
            else
            {
                await administratorService.DeleteRoleAsync(user);
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public async Task<IActionResult> AddAdminRole(string id)
        {
            var user = await administratorService.FindUserAsync(id);
            if (user == null)
            {
                return RedirectToAction("Error");
            }
            else
            {
                await administratorService.AddRoleAsync(user);
                return RedirectToAction("Index");
            }

        }

        public IActionResult Error()
        {
            ViewBag.ErrorMessage = "User cannot be found";
            return View("NotFound");
        }

       


    }
}
