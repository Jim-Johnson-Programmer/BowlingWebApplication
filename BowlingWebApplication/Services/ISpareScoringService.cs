namespace BowlingWebApplication.Services
{
    public interface ISpareScoringService
    {
        int AvgPercentOfTimeTrue { get; set; }
        bool TestForSpare();
    }
}