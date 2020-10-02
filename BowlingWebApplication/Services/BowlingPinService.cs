using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BowlingWebApplication.Models;

namespace BowlingWebApplication.Services
{
    public class BowlingPinService
    {
        private readonly IFoulService _foulService;
        private readonly IStrikeService _strikeService;
        private readonly ISpareService _spareService;

        public BowlingPinService(IFoulService foulService, 
                                IStrikeService strikeService, 
                                ISpareService spareService)
        {
            _foulService = foulService;
            _strikeService = strikeService;
            _spareService = spareService;
        }

        public void PlayerFirstBallDelivery(PlayerFrame inputPlayerFrame)
        {
            if (_foulService.TestForFoul())
            {
                inputPlayerFrame.FirstDeliveryCompleted = true;
                inputPlayerFrame.FirstDeliveryIsFoul = true;
                //inputPlayerFrame.FirstDeliveryMark
            }

            if (_strikeService.TestForStrike())
            {

            }
        }

        public void PlayerSecondBallDelivery(PlayerFrame inputPlayerFrame)
        {

        }

        public void PlayerFirstExtraDelivery()
        { }

        public void PlayerSecondExtraBallDelivery()
        { }
    }
}
