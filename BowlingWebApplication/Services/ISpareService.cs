namespace BowlingWebApplication.Services
{
    public interface ISpareService
    {
        int AvgPercentOfTimeTrue { get; set; }
        bool TestForSpare();
    }
}