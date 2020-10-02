using System;
using System.Collections.Generic;

namespace BowlingWebApplication.Models
{
    public class UserGameInfo
    {
        public UserGameInfo()
        {
            CurrentFrameCount = 1;
            FirstName = String.Empty;
            LastName = string.Empty;
            DeliveryFrames = new List<PlayerFrame>(10);
            for (int i = 0; i < 11; i++)
            {
                DeliveryFrames.Add(new PlayerFrame(){FrameId = i});
            }
            TenthFrameExtraFrames = new List<PlayerFrame>(2);
            TenthFrameExtraFrames.Add(new PlayerFrame(){FrameId = 1});
            TenthFrameExtraFrames.Add(new PlayerFrame() { FrameId = 2 });
        }

        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public int CurrentFrameCount { get; set; }
        public bool IsExtraFramesQualified { get; set; }
        public List<PlayerFrame> DeliveryFrames { get; set; } 
        public List<PlayerFrame> TenthFrameExtraFrames { get; set; } 
        public int PlayerFinalScore { get; set; }
        public bool IsWinner { get; set; }
    }
}