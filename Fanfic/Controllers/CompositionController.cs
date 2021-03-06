﻿using Fanfic.Configuration;
using Fanfic.Filters;
using Fanfic.Models;
using Fanfic.Models.Context;
using Fanfic.Models.ViewModels;
using Fanfic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Fanfic.Controllers
{
    public class CompositionController : Controller
    {
        private readonly CompositionService compositionService;
        private readonly UserManager<User> userManager;
        SignInManager<User> signInManager;



        public CompositionController(CompositionService service, UserManager<User> _userManager, SignInManager<User> signInManager)
        {
            compositionService = service;
            userManager = _userManager;
            this.signInManager = signInManager;
           
        }
        [Authorize]
        [DeletedUserFilter]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [DeletedUserFilter]
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
        [Authorize]
        [DeletedUserFilter]
        [HttpGet]
        public IActionResult CreateChapter(int id)
        {
            ChapterCreateViewModel chapterCreateViewModel = new ChapterCreateViewModel { CompositionId = id };
            return View(chapterCreateViewModel);
        }

        [Authorize]
        [DeletedUserFilter]
        [HttpPost]
        public IActionResult CreateChapter(ChapterCreateViewModel chapterCreateViewModel)
        {

            var composition = compositionService.FindComposition(chapterCreateViewModel.CompositionId);
            if (composition == null)
            {
                return RedirectToAction("Error");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    compositionService.CreateChapter(chapterCreateViewModel, composition);
                    return RedirectToAction("EditComposition", new { id = composition.Id });
                }
            }

            return View(chapterCreateViewModel);
        }
        [Authorize]
        [DeletedUserFilter]
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
            var userId = FindUserId();
            var composition = compositionService.FindComposition(id);
            if (composition == null)
            {
                return RedirectToAction("Error");
            }
            var compositionViewModel = compositionService.GetCompositionViewModel(composition, userId);
            return View(compositionViewModel);
        }
        public ActionResult GetTag()
        {
            var token = compositionService.GetTags();
            return Json(new { data = token.Split(',') });

        }

        [HttpGet]
        public IActionResult ReadChapter(int compositionId, int chapterIndex)
        {
            var userId = FindUserId();
            var composition = compositionService.FindComposition(compositionId);
            CompositionViewModel model = compositionService.GetCompositionViewModel(composition,userId);

            ViewData["PreviousIndex"] = null;
            ViewData["NextIndex"] = null;
            ViewData["Index"] = chapterIndex;
            ViewData["IsLast"] = false;
            ViewData["IsFirst"] = false;

            if (chapterIndex == 0)
            {
                ViewData["IsFirst"] = true;
            }

            if (chapterIndex == (model.Chapters.Count() - 1))
            {
                ViewData["IsLast"] = true;
            }

            if (model.Chapters.Count() - 1 > chapterIndex)
            {
                ViewData["NextIndex"] = chapterIndex + 1;
            }

            if (chapterIndex > 0)
            {
                ViewData["PreviousIndex"] = chapterIndex - 1;
            }

            return View(model);
        }


        [Authorize]
        [DeletedUserFilter]
        public IActionResult EditComposition(int id)
        {
            var userId = FindUserId();
            var composition = compositionService.FindComposition(id);
            if (composition == null)
            {
                return RedirectToAction("Error");
            }
            var compositionViewModel = compositionService.GetCompositionViewModel(composition,userId);
            return View(compositionViewModel);

        }
        [Authorize]
        [DeletedUserFilter]
        [HttpPost]
        public IActionResult EditComposition(CompositionViewModel compositionView)
        {
            if (ModelState.IsValid)
            {
                compositionService.EditComposition(compositionView);
                return RedirectToAction("Index", "User");
            }
            return View(compositionView);
        }

        [Authorize]
        [DeletedUserFilter]
        public IActionResult EditChapter(int chapterId, int compositionId)
        {
            var chapter = compositionService.GetChapter(chapterId);
            if (chapter == null)
            {
                ViewBag.ErrorMessage = "Chapter cannot be found";
                return View("NotFound");
            }
            EditChapterViewModel editChapterViewModel = compositionService.GetEditChapterViewModel(chapter);
            editChapterViewModel.CompositionId = compositionId;
            return View(editChapterViewModel);
        }
        [Authorize]
        [DeletedUserFilter]
        [HttpPost]
        public IActionResult EditChapter(EditChapterViewModel editChapterViewModel)
        {
            if (ModelState.IsValid)
            {
                compositionService.EditChapter(editChapterViewModel);
                return RedirectToAction("EditComposition", new { id = editChapterViewModel.CompositionId });
            }
            return View(editChapterViewModel);
        }
        [Authorize]
        [DeletedUserFilter]
        [HttpPost]
        public IActionResult DeleteChapter(int chapterId, int compositionId)
        {
            var chapter = compositionService.GetChapter(chapterId);
            if (chapter == null)
            {
                ViewBag.ErrorMessage = "Chapter cannot be found";
                return View("NotFound");
            }
            compositionService.DeleteChapter(chapter);
            return RedirectToAction("EditComposition", new { id = compositionId });
        }

        public IActionResult Error()
        {
            ViewBag.ErrorMessage = "Composition cannot be found";
            return View("NotFound");
        }
        [Authorize]
        [DeletedUserFilter]
        [HttpPost]
        public async Task Rate(float stars, int id)
        {
            var userId = FindUserId();
            await compositionService.CreateRating(stars, id, userId);
       
        }
        [Authorize]
        [DeletedUserFilter]
        [HttpPost]
        public void DeleteRating( int id)
        {
            var userId = FindUserId();
            compositionService.RemoveRating(  userId, id);

        }
        public string FindUserId()
        {
            var userId = userManager.GetUserId(HttpContext.User);
            return userId;
        }

        
    }
}
