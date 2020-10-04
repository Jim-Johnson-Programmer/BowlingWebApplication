using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BowlingWebApplication.Models.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BowlingWebApplication.Services
{
    public class DeliveryService
    {

        public DeliveryService()
        {
            
        }

        public void InitialLoadDeliveryViewModel(FullGameModel fullGameModel, DeliveryInputViewModel deliveryInputViewModel)
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
                o => new SelectListItem()
                {
                    Text = o.FirstName + " " + o.LastName,
                    Value = o.UserId.ToString()
                }).ToList();
        }

        public void SaveDelivery(FullGameModel fullGameModel, DeliveryInputViewModel deliveryInputViewModel)
        {
            //if(fullGameModel.)
            //{ }
            //else if (deliveryInputViewModel.DeliveryCount==1)
            //{
                
            //}
        }
    }

}
