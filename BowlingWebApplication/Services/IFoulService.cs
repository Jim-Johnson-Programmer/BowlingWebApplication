namespace BowlingWebApplication.Services
{
    public interface IFoulService
    {
        int AvgPercentOfTimeTrue { get; set; }
        bool TestForFoul();
    }
}