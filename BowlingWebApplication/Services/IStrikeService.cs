namespace BowlingWebApplication.Services
{
    public interface IStrikeService
    {
        int AvgPercentOfTimeTrue { get; set; }
        bool TestForStrike();
    }
}