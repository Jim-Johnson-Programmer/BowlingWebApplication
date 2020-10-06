namespace BowlingWebApplication.Models.ViewModel
{
    public class ScoreCardFrame
    {
        public string FirstDeliveryMark { get; set; } = string.Empty;
        public int FirstDeliveryScore { get; set; }
        public string SecondDeliveryMark { get; set; } = string.Empty;
        public int SecondDeliveryScore { get; set; }
        public int FrameCumulativeScore { get; set; }
        public bool IsBonusRoundAllowed { get; set; }
        public string BonusDeliveryMark { get; set; }
        public int BonusDeliveryScore { get; set; }
        public int FrameId { get; set; }
    }
}