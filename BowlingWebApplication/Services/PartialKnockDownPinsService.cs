using System;
using System.Collections.Generic;
using BowlingWebApplication.Models;

namespace BowlingWebApplication.Services
{
    public class PartialKnockDownPinsService : IPartialKnockDownPinsService
    {
        //public int AvgPercentOfTimeTrue { get; set; } = 60;

        //private bool TestForSplit()
        //{
        //    Random rnd = new Random();
        //    int number = rnd.Next(1, 100);
        //    return number < AvgPercentOfTimeTrue ? true : false;
        //}

        private int GetTotalPinsKnockedDown()
        {
            Random rnd = new Random();
            return rnd.Next(1, 11);
        }

        public void CheckAndScoreFirstDelivery(List<PlayerFrame> inputPlayerFrames, int currentIndex)
        {
            if (!inputPlayerFrames[currentIndex].FirstDeliveryCompleted &&
                !inputPlayerFrames[currentIndex].IsFirstDeliveryStrike &&
                !inputPlayerFrames[currentIndex].IsFoulFirstDelivery)
            {
                inputPlayerFrames[currentIndex].FirstDeliveryScore = GetTotalPinsKnockedDown();
            }
        }

        public void CheckAndScoreSecondDelivery(List<PlayerFrame> inputPlayerFrames, int currentIndex)
        {

        }
    }
}