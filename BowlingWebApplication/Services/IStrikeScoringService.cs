namespace BowlingWebApplication.Services
{
    public interface IStrikeScoringService
    {
        int AvgPercentOfTimeTrue { get; set; }
        bool TestForStrike();
    }
}