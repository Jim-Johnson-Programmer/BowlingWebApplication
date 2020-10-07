using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BowlingWebApplication.Models.ViewModel
{
    public class DeliveryInputViewModel
    {
        public int CurrentRowIndex { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int FrameIndex { get; set; }
        public int CurrDeliveryInFrameIndex { get; set; }
        public int PlayerId { get; set; }
        public List<SelectListItem> DeliveryTypes { get; set; }
        [Required (ErrorMessage = "Please select a delivery code")]
        public int SelectedDeliveryCode { get; set; }
        public List<SelectListItem> CountOfPinsAvailable { get; set; }
        [Required (ErrorMessage = "Please select how many pins will go down")]
        public int SelectedPinsDownCount { get; set; }
        public int PreviousDeliveryPinsDown { get; set; }
        public string PreviousDeliveryTypeText { get; set; }
        public int PreviousDeliveryTypeCode { get; set; }
    }
}
