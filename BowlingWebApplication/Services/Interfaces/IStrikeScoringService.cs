using System.Collections.Generic;
using BowlingWebApplication.Models;

namespace BowlingWebApplication.Services
{
    public interface IStrikeScoringService
    {
        int AvgPercentOfTimeTrue { get; set; }
        void CheckAndScoreFirstDelivery(List<PlayerFrame> inputPlayerFrames, int currentIndex);
    }
}