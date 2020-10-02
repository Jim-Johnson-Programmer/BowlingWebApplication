using System.Collections.Generic;
using BowlingWebApplication.Models;

namespace BowlingWebApplication.Services
{
    public interface ISplitScoringService
    {
        int AvgPercentOfTimeTrue { get; set; }
        void CheckAndScoreFirstDelivery(List<PlayerFrame> inputPlayerFrames, int currentIndex);
    }
}