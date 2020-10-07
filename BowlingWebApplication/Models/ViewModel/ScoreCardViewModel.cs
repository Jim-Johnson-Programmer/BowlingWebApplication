using System.Collections.Generic;

namespace BowlingWebApplication.Models.ViewModel
{
    public class ScoreCardViewModel
    {
        public ScoreCardViewModel()
        {
            CurrentPlayerId = 1;
        }

        public int CurrentFrameId { get; set; }
        public bool IsUserGameComplete { get; set; }
        public int CurrentDeliveryInFrameIndex { get; set; }
        public int CurrentPlayerId { get; set; }
        public int PreviousPinDownCount { get; set; }
        public int PreviousDeliveryType { get; set; }
        public int CurrentDeliveryType { get; set; }
        public int CurrentScoreCardRowIndex { get; set; }
        public List<ScoreCardRow> ScoreCardRows { get; set; } = new List<ScoreCardRow>();
    }
}
