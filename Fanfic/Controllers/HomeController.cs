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
        ApplicationContext context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, CompositionService service, UserManager<User> manager, ApplicationContext _context)
        {
            _logger = logger;
            compositionService = service;
            userManager = manager;
            context = _context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllCompositions(string tagName)
        {

            var userId = userManager.GetUserId(HttpContext.User);
            List<CompositionViewModel> compositionViewModels = compositionService.GetAllNotEmptyCompositions(userId);
            if (!String.IsNullOrEmpty(tagName))
            {
                compositionViewModels = compositionViewModels.Where(p => p.Tags.Select(p => p.Name).Contains(tagName)).ToList();
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
    }
}
