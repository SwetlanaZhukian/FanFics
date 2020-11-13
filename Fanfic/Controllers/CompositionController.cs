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
        ApplicationContext context;

        public CompositionController(CompositionService service, UserManager<User> _userManager, ApplicationContext context)
        {
            compositionService = service;
            userManager = _userManager;
            this.context = context;
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
                return RedirectToAction("Error");
            }

            return View(composition);
        }

        public IActionResult CreateChapter()
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
        [HttpPost]
        public IActionResult DeleteComposition(int id)
        {
            var composition = compositionService.FindComposition(id);
            if (composition == null)
            {
                return RedirectToAction("Error");
            }
            compositionService.DeleteComposition(composition);
            return RedirectToAction("Index", "User");
        }

        public IActionResult ReadComposition(int id)
        {
            var composition = compositionService.FindComposition(id);
            if (composition == null)
            {
                return RedirectToAction("Error");
            }
            var compositionViewModel = compositionService.GetCompositionViewModel(composition);
            return View(compositionViewModel);
        }
        public ActionResult GetTag()
        {
            var token = compositionService.GetTags();
            return Json(new { data = token.Split(',') });
         
        }
    
      
        public ActionResult ReadChapter(int id)
        {
            var chapter = compositionService.GetChapter(id);
            if (chapter == null)
            {
                ViewBag.ErrorMessage = "Chapter cannot be found";
                return View("NotFound");

            }

            return View(chapter);
        }

      
        public IActionResult EditComposition(int id)
        {
            var composition = compositionService.FindComposition(id);
            if (composition == null)
            {
                return RedirectToAction("Error");
            }
            var compositionViewModel = compositionService.GetCompositionViewModel(composition);
            return View(compositionViewModel);
           
        }
        [HttpPost]
        public IActionResult EditComposition(CompositionViewModel compositionView)
        {
            return View();
        }
        public IActionResult Error()
        {
            ViewBag.ErrorMessage = "Composition cannot be found";
            return View("NotFound");
        }

    }
}
