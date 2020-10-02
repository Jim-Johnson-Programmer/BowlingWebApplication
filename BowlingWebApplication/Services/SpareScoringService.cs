using System;
using System.Collections.Generic;
using BowlingWebApplication.Models;

namespace BowlingWebApplication.Services
{
    public class SpareScoringService : ISpareScoringService
    {
        public int AvgPercentOfTimeTrue { get; set; } = 30;
        private bool TestForSpare()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 100);
            return number < AvgPercentOfTimeTrue  ? true : false;
        }

        public void ScoreSecondDeliverySpare(List<PlayerFrame> inputPlayerFrames, int currentIndex)
        {
            if (TestForSpare())
            {
                inputPlayerFrames[currentIndex].IsSecondDeliverySpare = true;
                inputPlayerFrames[currentIndex].SecondDeliveryMark = "/";
                inputPlayerFrames[currentIndex].SecondDeliveryScore =
                    10 - inputPlayerFrames[currentIndex].FirstDeliveryScore;
            }
        }
    }
}