using System;
using System.Collections.Generic;
using System.Media;
using BowlingWebApplication.Models;

namespace BowlingWebApplication.Services
{
    public class FoulScoringService : IFoulScoringService
    {
        public int AvgPercentOfTimeTrue { get; set; } = 5;

        private bool TestForFoul()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 100);
            return number < AvgPercentOfTimeTrue ? true : false;
        }

        public void CheckAndScoreFirstDelivery(List<PlayerFrame> inputPlayerFrames, int currentIndex)
        {
            if (TestForFoul())
            {
                inputPlayerFrames[currentIndex].IsFoulFirstDelivery = true;
                inputPlayerFrames[currentIndex].FirstDeliveryScore = 0;
                //inputPlayerFrames[currentIndex].FirstDeliveryMark = "F";
                inputPlayerFrames[currentIndex].FirstDeliveryCompleted = true;
            }
        }

        public void CheckAndScoreSecondDelivery(List<PlayerFrame> inputPlayerFrames, int currentIndex)
        {
            if (TestForFoul())
            {
                inputPlayerFrames[currentIndex].IsFoulSecondDelivery = true;
                inputPlayerFrames[currentIndex].SecondDeliveryScore = 0;
                inputPlayerFrames[currentIndex].SecondDeliveryMark = "F";
            }
        }
    }
}