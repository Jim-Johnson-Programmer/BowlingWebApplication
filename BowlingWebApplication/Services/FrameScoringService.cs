using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BowlingWebApplication.Models;

namespace BowlingWebApplication.Services
{
    public class FrameScoringService : IFrameScoringService
    {
        private readonly IFoulScoringService _foulService;
        private readonly IStrikeScoringService _strikeService;
        private readonly ISpareScoringService _spareService;
        private readonly IAllPinsMissedService _allPinsMissedService;

        public FrameScoringService(IFoulScoringService foulService,
                                IStrikeScoringService strikeService,
                                ISpareScoringService spareService,
                                IAllPinsMissedService allPinsMissedService)
        {
            _foulService = foulService;
            _strikeService = strikeService;
            _spareService = spareService;
            _allPinsMissedService = allPinsMissedService;
        }

        public void FirstDelivery(UserGameInfo inputUserGameInfo)
        {
            _foulService.CheckAndScoreFirstDelivery(inputUserGameInfo.DeliveryFrames, 
                inputUserGameInfo.CurrentFrameCount);

            _allPinsMissedService.CheckAndScoreFirstDelivery(inputUserGameInfo.DeliveryFrames, 
                inputUserGameInfo.CurrentFrameCount);

            //if not all pins missed, try split service 

        }

        public void SecondDelivery(UserGameInfo inputUserGameInfo)
        {
            //second can be strike, spare, foul, all pins missed
        }

        public void FirstExtraDelivery()
        { }

        public void SecondExtraDelivery()
        { }
    }
}
