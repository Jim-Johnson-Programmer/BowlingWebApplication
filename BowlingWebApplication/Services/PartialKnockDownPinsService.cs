using System;
using System.Collections.Generic;
using BowlingWebApplication.Models;

namespace BowlingWebApplication.Services
{
    public class PartialKnockDownPinsService : IPartialKnockDownPinsService
    {
        public int AvgPercentIsASplit { get; set; } = 60;

        private bool TestForSplit()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 100);
            return number < AvgPercentIsASplit ? true : false;
        }

        private int GetTotalPinsKnockedDown()
        {
            Random rnd = new Random();
            return rnd.Next(1, 10);
        }

        public void CheckAndScoreFirstDelivery(List<PlayerFrame> inputPlayerFrames, int currentIndex)
        {
            if (!inputPlayerFrames[currentIndex].IsFirstDeliveryCompleted &&
                !inputPlayerFrames[currentIndex].IsFirstDeliveryStrike &&
                !inputPlayerFrames[currentIndex].IsFirstDeliveryFoul)
            {
                inputPlayerFrames[currentIndex].FirstDeliveryScore = GetTotalPinsKnockedDown();

                if (TestForSplit() &&
                    inputPlayerFrames[currentIndex].FirstDeliveryScore<=8)//can't have split with one pin left 
                {
                    inputPlayerFrames[currentIndex].IsFirstDeliverySplit = true;
                }
            }
        }

        public void CheckAndScoreSecondDelivery(List<PlayerFrame> inputPlayerFrames, int currentIndex)
        {

        }
    }
}