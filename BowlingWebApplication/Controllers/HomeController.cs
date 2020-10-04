using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BowlingWebApplication.Models;
using BowlingWebApplication.Models.ViewModel;
using BowlingWebApplication.Services;
using BowlingWebApplication.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace BowlingWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFrameScoringService _frameScoringService;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, 
            IFrameScoringService frameScoringService,
            IUserService userService)
        {
            _logger = logger;
            _frameScoringService = frameScoringService;
            _userService = userService;}

        public IActionResult Index()
        {
            FullGameModel fullGameModel = new FullGameModel();
            HttpContext.Session.SetString("GameFullData", JsonConvert.SerializeObject(fullGameModel));

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


        [HttpGet]
        public IActionResult BowlingGame()
        {
            FullGameModel fullGameModel = JsonConvert.DeserializeObject<FullGameModel>(HttpContext.Session.GetString("GameFullData"));
            //ScoreCardViewModel viewModel = new ScoreCardViewModel();

            return View(fullGameModel);
        }


        [HttpGet]
        public IActionResult BowlingDeliveryInput()
        {
            FullGameModel fullGameModel = JsonConvert.DeserializeObject<FullGameModel>(HttpContext.Session.GetString("GameFullData"));

            DeliveryInputViewModel viewModel = new DeliveryInputViewModel();
            viewModel.DeliveryTypes = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "Strike", Value = "Strike"},
                new SelectListItem(){Text = "Spare", Value = "Strike"},
                new SelectListItem(){Text = "Split", Value = "Strike"},
                new SelectListItem(){Text = "Open", Value = "Open"},
                new SelectListItem(){Text = "Foul", Value = "Foul"}
            };
            viewModel.CountOfPinsAvailable = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "1", Value = "1"},
                new SelectListItem(){Text = "2", Value = "2"},
                new SelectListItem(){Text = "3", Value = "3"},
                new SelectListItem(){Text = "4", Value = "4"},
                new SelectListItem(){Text = "5", Value = "5"},
                new SelectListItem(){Text = "6", Value = "6"},
                new SelectListItem(){Text = "7", Value = "7"},
                new SelectListItem(){Text = "8", Value = "8"},
                new SelectListItem(){Text = "9", Value = "9"},
                new SelectListItem(){Text = "10", Value = "10"},
            };
            viewModel.Players = fullGameModel.GamePlayers.Select(
                    o => new SelectListItem() {Text = o.FirstName + " " + o.LastName, 
                        Value = o.UserId.ToString()}).ToList();


            return View(viewModel);
        }

        [HttpPost]
        public IActionResult BowlingDeliveryInput(DeliveryInputViewModel inputViewModel)
        {
            //using session state in place of database for small demo and persistence between pages.
            FullGameModel fullGameModel = JsonConvert.DeserializeObject<FullGameModel>(HttpContext.Session.GetString("GameFullData"));


            HttpContext.Session.SetString("GameFullData", JsonConvert.SerializeObject(fullGameModel));

            return View(inputViewModel);
        }


        public IActionResult CreateBowlingUser()
        {
            BowlingUserViewModel viewModel = new BowlingUserViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreateBowlingUser(BowlingUserViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            FullGameModel fullGameModel = JsonConvert.DeserializeObject<FullGameModel>(HttpContext.Session.GetString("GameFullData"));

            _userService.CreateUser(fullGameModel, userViewModel);            

            HttpContext.Session.SetString("GameFullData", JsonConvert.SerializeObject(fullGameModel));
            return View("BowlingGame", fullGameModel);
        }
    }
}
