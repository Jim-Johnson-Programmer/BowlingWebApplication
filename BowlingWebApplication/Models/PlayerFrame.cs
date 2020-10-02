using System.Collections.Generic;

namespace BowlingWebApplication.Models
{
    public class PlayerFrame
    {
        public int FrameId { get; set; }
        public bool IsFirstDeliveryStrike { get; set; } 
        public bool IsSecondDeliverySpare { get; set; }
        public bool IsFirstDeliverySplit { get; set; }
        public bool IsFirstDeliveryCompleted { get; set; } 
        public int FirstDeliveryScore { get; set; }
        public bool IsFirstDeliveryFoul { get; set; } 
        //prevent nulls on nullable types w default value.
        public string FirstDeliveryMark { get; set; } = string.Empty;
        public bool IsSecondDeliveryCompleted { get; set; }
        public int SecondDeliveryScore { get; set; }
        public bool IsSecondDeliveryFoul { get; set; }
        public string SecondDeliveryMark { get; set; } = string.Empty;
        public bool IsSecondDeliveryStrikeInTenthFrame { get; set; }
        public bool IsThirdDeliveryStrikeInTenthFrame { get; set; }
        public int TenthFrameThirdDeliveryScore { get; set; }
        public string TenthFrameThirdDeliveryMark { get; set; } = string.Empty;
        public bool IsTenthFrameThirdDeliveryEligible { get; set; }
        public int CumulativeScore { get; set; }
        public string CumulativeStatus { get; set; } = string.Empty;
    }
}