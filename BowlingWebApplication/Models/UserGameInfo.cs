using System.Collections.Generic;

namespace BowlingWebApplication.Models
{
    public class UserGameInfo
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public List<PlayerFrame> UserScoring { get; set; } = new List<PlayerFrame>(10);
    }
}