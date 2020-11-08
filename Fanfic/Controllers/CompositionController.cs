using Fanfic.Configuration;
using Fanfic.Models;
using Fanfic.Models.Context;
using Fanfic.Models.ViewModels;
using Fanfic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Controllers
{
    public class CompositionController : Controller
    {
        private readonly CompositionService compositionService;
        private readonly UserManager<User> userManager;
       
        public CompositionController(CompositionService service, UserManager<User> _userManager)
        {
            compositionService = service;
            userManager = _userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CompositionCreateViewModel viewModel)
        {
            IdentityUser user = await userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            if (ModelState.IsValid)
            {
                var composition = compositionService.CreateComposition(viewModel, user);
                return RedirectToAction("SuccessfulCreate", new { composition.Id });
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult SuccessfulCreate(int id)
        {
            var composition = compositionService.FindComposition(id);
            if (composition == null)
            {
              return  RedirectToAction("Error");
            }

            return View(composition);
        }

        public IActionResult CreateChapter(int id )
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateChapter(ChapterCreateViewModel chapterCreateViewModel, int id)
        {
           
            var composition = compositionService.FindComposition(id);
            if (composition == null)
            {
                return RedirectToAction("Error");
            }
            else 
            {
                if (ModelState.IsValid)
                {
                    compositionService.CreateChapter(chapterCreateViewModel, composition);
                }
            }
     
            return View();
        }

        public ActionResult GetTag()
        {
            var token = compositionService.GetTags();
            return Json(new { data = token.Split(',') });
        }
        public IActionResult Error()
        {
            ViewBag.ErrorMessage = "Composition cannot be found";
            return View("NotFound");
        }

    }
}
