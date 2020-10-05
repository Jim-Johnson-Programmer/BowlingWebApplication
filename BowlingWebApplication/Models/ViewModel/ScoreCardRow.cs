using System.Collections.Generic;

namespace BowlingWebApplication.Models.ViewModel
{
    public class ScoreCardRow
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PlayerId { get; set; }
        public int DeliveriesPerFrameCount { get; set; }
        public int CurrentScoreCardFrameIndex { get; set; }
        public List<ScoreCardFrame> ScoreCardFrames { get; set; }
    }
}