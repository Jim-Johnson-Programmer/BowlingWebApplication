using System;

namespace BowlingWebApplication.Services
{
    public class StrikeScoringService : IStrikeScoringService
    {
        public int AvgPercentOfTimeTrue { get; set; } = 20;
        public bool TestForStrike()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 100);
            return number < AvgPercentOfTimeTrue ? true : false;
        }
    }
}