using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BowlingWebApplication.Models;
using BowlingWebApplication.Models.ViewModel;
using BowlingWebApplication.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            FullGameInfo fullGameInfo = GameDataFactory.RegisterPlayersIntoGame();
            _frameScoringService.AllPlayersBowlNextFrame(fullGameInfo.GamePlayers);
            //BowlingGameViewModel viewModel = new BowlingGameViewModel(fullGameInfo);

            return View(fullGameInfo);
        }

        public IActionResult BowlingDeliveryInput()
        {
            DeliveryInputViewModel viewModel = new DeliveryInputViewModel();
            viewModel.DeliveryTypes = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "Strike", Value = "Strike"},
                new SelectListItem(){Text = "Spare", Value = "Strike"},
                new SelectListItem(){Text = "Split", Value = "Strike"},
                new SelectListItem(){Text = "Open", Value = "Open"},
                new SelectListItem(){Text = "Foul", Value = "Foul"}
            };


            return View(viewModel);
        }
    }
}
