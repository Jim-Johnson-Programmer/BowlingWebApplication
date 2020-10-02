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