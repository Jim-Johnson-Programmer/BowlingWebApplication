using System;
using System.Collections.Generic;
using BowlingWebApplication.Models;

namespace BowlingWebApplication.Services
{
    public class AllPinsMissedService : IAllPinsMissedService
    {
        public int FirstDeliveryAverage { get; set; } = 5;
        public int SecondDeliveryAverage { get; set; } = 60;

        private bool TestFirstDelivery()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 100);
            return number < FirstDeliveryAverage ? true : false;
        }

        private bool TestSecondDelivery()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 100);
            return number < SecondDeliveryAverage ? true : false;
        }

        public void CheckAndScoreFirstDelivery(List<PlayerFrame> inputPlayerFrames, int currentIndex)
        {
            if (TestFirstDelivery())
            {
                inputPlayerFrames[currentIndex].IsFirstDeliveryCompleted = true;
                inputPlayerFrames[currentIndex].FirstDeliveryMark = "-";
                inputPlayerFrames[currentIndex].FirstDeliveryScore = 0;
            }
        }

        public void CheckAndScoreSecondDelivery(List<PlayerFrame> inputPlayerFrames, int currentIndex)
        {
            if (TestSecondDelivery())
            {
                inputPlayerFrames[currentIndex].IsSecondDeliveryCompleted = true;
                inputPlayerFrames[currentIndex].SecondDeliveryMark = "-";
                inputPlayerFrames[currentIndex].SecondDeliveryScore = 0;
            }
        }
    }
}