namespace BowlingWebApplication.Models.ViewModel
{
    public class ScoreCardFrame
    {
        public string FirstDeliveryMark { get; set; }
        public int FirstDeliveryScore { get; set; }
        public string SecondDeliveryMark { get; set; }
        public int SecondDeliveryScore { get; set; }
        public int FrameCumulativeScore { get; set; }
        public int FrameId { get; set; }
    }
}