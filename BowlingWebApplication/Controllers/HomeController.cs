using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BowlingWebApplication.Models;
using BowlingWebApplication.Models.ViewModel;
using BowlingWebApplication.Services;

namespace BowlingWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFrameScoringService _frameScoringService;

        public HomeController(ILogger<HomeController> logger, IFrameScoringService frameScoringService)
        {
            _logger = logger;
            _frameScoringService = frameScoringService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult BowlingGame()
        {
            BowlingGameViewModel viewModel = new BowlingGameViewModel();
            _frameScoringService.

            return View();
        }
    }
}
