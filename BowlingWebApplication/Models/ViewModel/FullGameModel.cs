using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BowlingWebApplication.Models.ViewModel
{
    public class FullGameModel
    {
        public int CurrentFrameId { get; set; }
        public int CurrentDeliveryId { get; set; }
        public int CurrentUserId { get; set; }
        public List<UserGameInfo> GamePlayers { get; set; } = new List<UserGameInfo>();
    }
}
