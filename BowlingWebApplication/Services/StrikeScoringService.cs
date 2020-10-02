using System;
using System.Collections.Generic;
using BowlingWebApplication.Models;

namespace BowlingWebApplication.Services
{
    public class StrikeScoringService : IStrikeScoringService
    {
        public int AvgPercentOfTimeTrue { get; set; } = 20;
        public bool TestForStrike()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 100);
            return number < AvgPercentOfTimeTrue ? true : false;
        }

        public void CheckAndScoreFirstDelivery(List<PlayerFrame> inputPlayerFrames, int currentIndex)
        {
            if (TestForStrike())
            {
                inputPlayerFrames[currentIndex].IsFirstDeliveryStrike = true;
                inputPlayerFrames[currentIndex].FirstDeliveryScore = 10;
                inputPlayerFrames[currentIndex].FirstDeliveryMark = "X";
                inputPlayerFrames[currentIndex].IsFirstDeliveryCompleted = true;
            }
        }
    }
}