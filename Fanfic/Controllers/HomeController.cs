using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Fanfic.Models;
using Fanfic.Services;
using Microsoft.AspNetCore.Identity;
using Fanfic.Models.Context;
using Microsoft.EntityFrameworkCore;
using Fanfic.Models.ViewModels;

namespace Fanfic.Controllers
{
    public class HomeController : Controller
    {
        private readonly CompositionService compositionService;
        private readonly UserManager<User> userManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, CompositionService service, UserManager<User> manager)
        {
            _logger = logger;
            compositionService = service;
            userManager = manager;
           
        }

        public IActionResult Index()
        {
            List<CompositionViewModel> compositionViewModels = GetCompositionViewModels();
            compositionViewModels = compositionService.FiltrCompositionViewModelByRatingAndDate(compositionViewModels);
            return View(compositionViewModels);
        }
        
        public IActionResult GetAllCompositions(string tagName)
        {
            List<CompositionViewModel> compositionViewModels = GetCompositionViewModels();
            if (!String.IsNullOrEmpty(tagName))
            {
                compositionViewModels = compositionService.GetCompositionViewModelByTagName(compositionViewModels,tagName);
            }
            if (compositionViewModels.Count == 0)
            {
                ViewBag.Message = "There are no results for this request";
            }
            return View(compositionViewModels);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public List<CompositionViewModel> GetCompositionViewModels()
        {
            var userId = userManager.GetUserId(HttpContext.User);
            List<CompositionViewModel> compositionViewModels = compositionService.GetAllNotEmptyCompositions(userId);
            return compositionViewModels;
        }
    }
}
