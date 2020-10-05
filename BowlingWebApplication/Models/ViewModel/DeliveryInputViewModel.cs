﻿using System;
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
        public int FrameIndex { get; set; }
        public int CurrDeliveryInFrameCount { get; set; }
        public int CurrDeliveryInFrameIndex { get; set; }
        public int PlayerId { get; set; }
        public List<SelectListItem> DeliveryTypes { get; set; }
        public int SelectedDeliveryCode { get; set; }
        public List<SelectListItem> CountOfPinsAvailable { get; set; }
        public int SelectedPinsDownCount { get; set; }
        public int PreviousDeliveryPinsDown { get; set; }
        public string PreviousDeliveryTypeText { get; set; }
        public int PreviousDeliveryTypeCode { get; set; }
    }
}
