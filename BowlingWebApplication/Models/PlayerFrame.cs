﻿using System.Collections.Generic;

namespace BowlingWebApplication.Models
{
    public class PlayerFrame
    {
        public int FrameId { get; set; }
        public bool IsFirstDeliveryStrike { get; set; } 
        public bool IsSpare { get; set; }
        public bool IsSplit { get; set; }
        public bool FirstDeliveryCompleted { get; set; } 
        public int FirstDeliveryScore { get; set; }
        public bool IsFoulFirstDelivery { get; set; } 
        public string FirstDeliveryMark { get; set; } = string.Empty;
        public bool SecondDeliveryCompleted { get; set; } = false;
        public int SecondDeliveryScore { get; set; }
        public bool IsFoulSecondDelivery { get; set; }
        public string SecondDeliveryMark { get; set; } = string.Empty;
        public bool IsTenthFrameThirdDeliveryEligible { get; set; }
        public int CumulativeScore { get; set; }
        public string CumulativeStatus { get; set; } = string.Empty;
    }
}