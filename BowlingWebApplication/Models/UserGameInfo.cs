using System;
using System.Collections.Generic;

namespace BowlingWebApplication.Models
{
    public class UserGameInfo
    {
        public UserGameInfo()
        {
            FirstName = String.Empty;
            LastName = string.Empty;
            DeliveryFrames = new List<PlayerFrame>(10);
            for (int i = 0; i <= 10; i++)
            {
                DeliveryFrames.Add(new PlayerFrame(){FrameId = i});
            }
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CurrentProcessingFrameIndex { get; set; }
        public List<PlayerFrame> DeliveryFrames { get; set; }
        public string CurrentStatus { get; set; }
        public int PlayerFinalScore { get; set; }
        public bool IsWinner { get; set; }
    }
}