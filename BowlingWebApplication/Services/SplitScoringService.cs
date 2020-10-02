using System;
using System.Collections.Generic;
using BowlingWebApplication.Models;

namespace BowlingWebApplication.Services
{
    public class SplitScoringService : ISplitScoringService
    {
        public int AvgPercentOfTimeTrue { get; set; } = 60;

        private bool TestForSplit()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 100);
            return number < AvgPercentOfTimeTrue ? true : false;
        }

        private int GetTotalPinsKnockedDown()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 11);
            return number;
        }

        public void CheckAndScoreFirstDelivery(List<PlayerFrame> inputPlayerFrames, int currentIndex)
        {
            if (TestForSplit())
            {
                inputPlayerFrames[currentIndex].IsFirstDeliverySplit = true;
            }
        }
    }
}