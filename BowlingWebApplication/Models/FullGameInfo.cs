using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingWebApplication.Models
{
    public class FullGameInfo
    {
        public List<UserGameInfo> GameUserScores { get; set; } = new List<UserGameInfo>();
    }
}
