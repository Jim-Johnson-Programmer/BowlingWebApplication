using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingWebApplication.Models
{
    public class FullGameInfo
    {
        public List<UserGameInfo> GamePlayers { get; set; } = new List<UserGameInfo>();
    }
}
