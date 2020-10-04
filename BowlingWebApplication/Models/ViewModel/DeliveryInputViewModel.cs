using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BowlingWebApplication.Models.ViewModel
{
    public class DeliveryInputViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FrameCount { get; set; }
        public int DeliveryCount { get; set; }
        public List<SelectListItem> Players { get; set; }
        public string SelectedPlayerId { get; set; }
        public List<SelectListItem> DeliveryTypes { get; set; }
        public string SelectedDeliveryType { get; set; }
        public List<SelectListItem> CountOfPinsAvailable { get; set; }
        public int SelectedPinCount { get; set; }
        public string PreviousDeliveryCount { get; set; }
        public string PreviousDeliveryType { get; set; }
    }
}
