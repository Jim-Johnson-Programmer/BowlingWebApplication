using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BowlingWebApplication.Models.ViewModel
{
    public class FullGameModel
    {
        public int CurrentPlayerId { get; set; }
        public int CurrentFrameId { get; set; } = 1;
        public int CurrentDeliveryId { get; set; }
        public int PreviousPinsDown { get; set; }
        public string PreviousDeliveryType { get; set; }
        public List<UserGameInfo> GamePlayers { get; set; } = new List<UserGameInfo>();
    }
}
