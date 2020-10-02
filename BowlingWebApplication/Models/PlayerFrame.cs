using System.Collections.Generic;

namespace BowlingWebApplication.Models
{
    public class PlayerFrame
    {
        public int FrameCounter { get; set; }
        public bool IsStrike { get; set; } 
        public bool IsSpare { get; set; } 
        public bool FirstDeliveryCompleted { get; set; } 
        public int FirstDeliveryScore { get; set; }
        public bool FirstDeliveryIsFoul { get; set; } 
        public string FirstDeliveryMark { get; set; } = string.Empty;
        public bool SecondDeliveryCompleted { get; set; } = false;
        public int SecondDeliveryScore { get; set; }
        public int SecondDeliveryIsFoul { get; set; }
        public string SecondDeliveryMark { get; set; } = string.Empty;
        public bool IsTenthFrameThirdDeliveryEligible { get; set; }
        public int CumulativeScore { get; set; }
        public string CumulativeStatus { get; set; } = string.Empty;
        public List<bool> BowlingPins { get; set; } = new List<bool>(10);
    }
}