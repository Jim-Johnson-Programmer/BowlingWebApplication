using System.Collections.Generic;
using BowlingWebApplication.Models;

namespace BowlingWebApplication.Services
{
    public interface IPartialKnockDownPinsService
    {
        int AvgPercentIsASplit { get; set; }
        int AvgPercentIsLessThanTen { get; set; }
        void CheckAndScoreFirstDelivery(List<PlayerFrame> inputPlayerFrames, int currentIndex);
        void CheckAndScoreSecondDelivery(List<PlayerFrame> inputPlayerFrames, int currentIndex);
    }
}