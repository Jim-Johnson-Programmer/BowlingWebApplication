using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingWebApplication.Models.ViewModel
{
    public class ScoreCardViewModel
    {
        public int CurrentFrameId { get; set; }
        public string Name { get; set; }
        public List<ScoreCardFrame> Frames { get; set; } = new List<ScoreCardFrame>();
    }

    public class ScoreCardFrame
    {
        public string FirstDeliveryMark { get; set; }
        public string SecondDeliveryMark { get; set; }
        public int FrameCumulativeScore { get; set; }
    }
}
