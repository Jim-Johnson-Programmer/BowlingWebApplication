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
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;

namespace BowlingWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFrameScoringService _frameScoringService;
        private readonly IUserService _userService;
        private readonly IDeliveryService _deliveryService;

        public HomeController(ILogger<HomeController> logger, 
            IFrameScoringService frameScoringService,
            IUserService userService,
            IDeliveryService deliveryService)
        {
            _logger = logger;
            _frameScoringService = frameScoringService;
            _userService = userService;
            _deliveryService = deliveryService;
        }

        public IActionResult Index()
        {
            ScoreCardViewModel scoreCardViewModel = new ScoreCardViewModel();
            HttpContext.Session.SetString("GameFullData", JsonConvert.SerializeObject(scoreCardViewModel));

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
            ScoreCardViewModel scoreCardViewModel = JsonConvert.DeserializeObject<ScoreCardViewModel>(HttpContext.Session.GetString("GameFullData"));

            return View(scoreCardViewModel);
        }


        [HttpGet]
        public IActionResult BowlingDeliveryInput(int playerId, int currRowIndex, int currFrameId, int currDeliveryInFrameCt, int prevDeliveryType, int prevPinsDown)
        {
            ScoreCardViewModel scoreCardViewModel = JsonConvert.DeserializeObject<ScoreCardViewModel>(HttpContext.Session.GetString("GameFullData"));
            scoreCardViewModel.CurrentFrameId = currFrameId;

            DeliveryInputViewModel deliveryInputViewModel = new DeliveryInputViewModel();
            deliveryInputViewModel.DeliveryTypes = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "Split", Value = ((int)FrameStatusEnum.Split).ToString()},
                new SelectListItem(){Text = "Missed Pins", Value = ((int)FrameStatusEnum.OpenFrame).ToString()},
                new SelectListItem(){Text = "Foul", Value = ((int)FrameStatusEnum.Foul).ToString()},
                new SelectListItem(){Text = "Standard Roll", Value = ((int)FrameStatusEnum.StandardRoll).ToString()}
            };

            if (prevDeliveryType == 0)
            {
                deliveryInputViewModel.DeliveryTypes.Add(new SelectListItem() { Text = "Strike", Value = ((int)FrameStatusEnum.Strike).ToString() });
            }
            else if (prevDeliveryType!=0)
            {
                deliveryInputViewModel.DeliveryTypes.Add(new SelectListItem() { Text = "Spare", Value = ((int)FrameStatusEnum.Spare).ToString() });
            }

            deliveryInputViewModel.CountOfPinsAvailable = new List<SelectListItem>();
            for (int i = 1; i <= 10-prevPinsDown; i++)
            {
                deliveryInputViewModel.CountOfPinsAvailable.Add(new SelectListItem(){Text = i.ToString(), Value = i.ToString()});
            }

            deliveryInputViewModel.PreviousDeliveryPinsDown = prevPinsDown;
            deliveryInputViewModel.PreviousDeliveryTypeText = _deliveryService.GetDeliveryStatusText(prevDeliveryType);
            deliveryInputViewModel.FirstName = scoreCardViewModel.ScoreCardRows[currRowIndex].FirstName;
            deliveryInputViewModel.LastName = scoreCardViewModel.ScoreCardRows[currRowIndex].LastName;

            if (currFrameId<10)
            {
                deliveryInputViewModel.CurrDeliveryInFrameIndex = currDeliveryInFrameCt;
                deliveryInputViewModel.CurrDeliveryInFrameCount = currDeliveryInFrameCt==0?1:2;
            }
            else
            {
                //10th frame stuff here 
            }

            return View(deliveryInputViewModel);
        }

        [HttpPost]
        public IActionResult BowlingDeliveryInput(DeliveryInputViewModel inputViewModel)
        {
            //using session state in place of database for small demo and persistence between pages.
            ScoreCardViewModel scoreCardviewModel = JsonConvert.DeserializeObject<ScoreCardViewModel>(HttpContext.Session.GetString("GameFullData"));

            scoreCardviewModel.CurrentDeliveryInFrameCount = inputViewModel.CurrDeliveryInFrameIndex;

            _deliveryService.SaveDelivery(scoreCardviewModel, inputViewModel);

            //run scoring service

            HttpContext.Session.SetString("GameFullData", JsonConvert.SerializeObject(scoreCardviewModel));

            return RedirectToAction("BowlingGame");
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

            ScoreCardViewModel scoreCardViewModel = JsonConvert.DeserializeObject<ScoreCardViewModel>(HttpContext.Session.GetString("GameFullData"));

            _userService.CreateUser(scoreCardViewModel, userViewModel);            

            HttpContext.Session.SetString("GameFullData", JsonConvert.SerializeObject(scoreCardViewModel));
            return View("BowlingGame", scoreCardViewModel);
        }
    }
}
