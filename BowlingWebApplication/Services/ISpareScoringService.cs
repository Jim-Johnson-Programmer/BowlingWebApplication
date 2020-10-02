using System.Collections.Generic;
using BowlingWebApplication.Models;

namespace BowlingWebApplication.Services
{
    public interface ISpareScoringService
    {
        int AvgPercentOfTimeTrue { get; set; }

        void ScoreSecondDeliverySpare(List<PlayerFrame> inputPlayerFrames, int currentIndex);
    }
}