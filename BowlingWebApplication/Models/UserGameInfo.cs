using System.Collections.Generic;

namespace BowlingWebApplication.Models
{
    public class UserGameInfo
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int CurrentFrameCount { get; set; }
        public bool IsExtraFramesQualified { get; set; }
        public List<PlayerFrame> UserFrames { get; set; } = new List<PlayerFrame>(10);
        public List<PlayerFrame> TenthFrameExtraFrames { get; set; } = new List<PlayerFrame>(2);
        public int PlayerFinalScore { get; set; }
        public bool IsWinner { get; set; }
    }
}