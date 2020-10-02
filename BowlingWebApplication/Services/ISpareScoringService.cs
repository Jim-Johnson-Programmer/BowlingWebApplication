using System.Collections.Generic;
using BowlingWebApplication.Models;

namespace BowlingWebApplication.Services
{
    public interface ISpareScoringService
    {
        int AvgPercentOfTimeTrue { get; set; }
        //bool TestForSpare();
        void ScoreSecondDeliverySpare(List<PlayerFrame> inputPlayerFrames, int currentIndex);
    }
}