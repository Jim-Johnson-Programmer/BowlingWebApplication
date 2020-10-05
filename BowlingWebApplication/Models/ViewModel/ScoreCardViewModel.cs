using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingWebApplication.Models.ViewModel
{
    public class ScoreCardViewModel
    {
        public ScoreCardViewModel()
        {
            CurrentPlayerId = 1;
        }

        public int CurrentFrameId { get; set; }
        public int CurrentDeliveryInFrameCount { get; set; }
        public int CurrentPlayerId { get; set; }
        public int PreviousPinDownCount { get; set; }
        public int PreviousDeliveryType { get; set; }
        public int CurrentDeliveryType { get; set; }
        public int CurrentScoreCardRowIndex { get; set; }
        public List<ScoreCardRow> ScoreCardRows { get; set; } = new List<ScoreCardRow>();
    }

    public class ScoreCardRow
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PlayerId { get; set; }
        public int DeliveriesPerFrameCount { get; set; }
        public int CurrentScoreCardFrameIndex { get; set; }
        public List<ScoreCardFrame> ScoreCardFrames { get; set; }
    }

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
