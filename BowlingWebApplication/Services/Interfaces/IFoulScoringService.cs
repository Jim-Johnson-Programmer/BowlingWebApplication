using System.Collections.Generic;
using BowlingWebApplication.Models;

namespace BowlingWebApplication.Services.Interfaces
{
    public interface IFoulScoringService
    {
        int AvgPercentOfTimeTrue { get; set; }
        void CheckAndScoreFirstDelivery(List<PlayerFrame> inputPlayerFrames, int currentIndex);
        void CheckAndScoreSecondDelivery(List<PlayerFrame> inputPlayerFrames, int currentIndex);
    }
}