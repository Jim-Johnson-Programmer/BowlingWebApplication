using System;
using System.Collections.Generic;
using BowlingWebApplication.Models;

namespace BowlingWebApplication.Services
{
    public class PartialKnockDownPinsService : IPartialKnockDownPinsService
    {
        private int GetTotalPinsKnockedDown()
        {
            Random rnd = new Random();
            return rnd.Next(1, 11);
        }

        public void CheckAndScoreFirstDelivery(List<PlayerFrame> inputPlayerFrames, int currentIndex)
        {
            if (!inputPlayerFrames[currentIndex].IsFirstDeliveryCompleted &&
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