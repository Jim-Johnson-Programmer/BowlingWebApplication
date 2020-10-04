using System.Collections.Generic;
using BowlingWebApplication.Models;

namespace BowlingWebApplication.Services.Interfaces
{
    public interface IAllPinsMissedService
    {
        int FirstDeliveryAverage { get; set; }
        int SecondDeliveryAverage { get; set; }
        void CheckAndScoreFirstDelivery(List<PlayerFrame> inputPlayerFrames, int currentIndex);
        void CheckAndScoreSecondDelivery(List<PlayerFrame> inputPlayerFrames, int currentIndex);
    }
}