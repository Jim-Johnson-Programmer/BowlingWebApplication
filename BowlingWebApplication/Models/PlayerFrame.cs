namespace BowlingWebApplication.Models
{
    public class PlayerFrame
    {
        public int FirstTurnScore { get; set; }
        public string FirstTurnCode { get; set; } = string.Empty;
        public int SecondTurnScore { get; set; }
        public string SecondTurnCode { get; set; } = string.Empty;
        public int ExtraTurnScore { get; set; }
        public string ExtraTurnCode { get; set; } = string.Empty;
        public int CumulativeScore { get; set; }
    }
}