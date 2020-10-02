using System;

namespace BowlingWebApplication.Services
{
    public class SpareService : ISpareService
    {
        public int AvgPercentOfTimeTrue { get; set; } = 30;
        public bool TestForSpare()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 100);
            return number < AvgPercentOfTimeTrue  ? true : false;
        }
    }
}