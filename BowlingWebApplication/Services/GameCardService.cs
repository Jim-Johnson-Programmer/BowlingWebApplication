using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BowlingWebApplication.Models.ViewModel;

namespace BowlingWebApplication.Services
{
    public class GameCardService
    {
        public ScoreCardViewModel LoadScoreCard(FullGameModel fullGameModel)
        {
            ScoreCardViewModel viewModel = new ScoreCardViewModel();
            foreach (var player in fullGameModel.GamePlayers)
            {
                //viewModel.
            }

            return viewModel;
        }
    }
}
