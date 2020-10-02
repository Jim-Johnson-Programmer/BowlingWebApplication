using System;
using System.Collections.Generic;
using BowlingWebApplication.Models;

namespace BowlingWebApplication.Services
{
    public class PartialKnockDownPinsService : IPartialKnockDownPinsService
    {
        public int AvgPercentIsASplit { get; set; } = 60;
        public int AvgPercentIsLessThanTen { get; set; } = 60;

        private bool TestForSplit()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 100);
            return number < AvgPercentIsASplit ? true : false;
        }

        private bool TestForLessThanTen()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 100);
            return number < AvgPercentIsLessThanTen ? true : false;
        }

        //pins knocked down must be less than 10 for entire frame from either 9pins
        //or < than prev delivery... spare tested and rejected previously
        private int GetTotalPinsKnockedDown(int prevDeliveryScore = 10)
        {
            Random rnd = new Random();
            return rnd.Next(1, prevDeliveryScore);
        }

        public void CheckAndScoreFirstDelivery(List<PlayerFrame> inputPlayerFrames, int currentIndex)
        {
            if (TestForLessThanTen() && 
                !inputPlayerFrames[currentIndex].IsFirstDeliveryCompleted)
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
            if (TestForLessThanTen() &&
                !inputPlayerFrames[currentIndex].IsSecondDeliveryCompleted &&
                !inputPlayerFrames[currentIndex].IsFirstDeliveryStrike &&
                !inputPlayerFrames[currentIndex].IsSecondDeliverySpare)
            {
                inputPlayerFrames[currentIndex].SecondDeliveryScore = 
                    GetTotalPinsKnockedDown(inputPlayerFrames[currentIndex].FirstDeliveryScore);

            }
        }
    }
}