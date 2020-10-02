using System;

namespace BowlingWebApplication.Services
{
    public class FoulService : IFoulService
    {
        public int AvgPercentOfTimeTrue { get; set; } = 5;
        public bool TestForFoul()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 100);
            return number < AvgPercentOfTimeTrue ? true : false;
        }
    }
}