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
        private readonly IPartialKnockDownPinsService _partialKnockDownPinsService;

        public FrameScoringService(IFoulScoringService foulService,
                                IStrikeScoringService strikeService,
                                ISpareScoringService spareService,
                                IAllPinsMissedService allPinsMissedService,
                                IPartialKnockDownPinsService partialKnockDownPinsService)
        {
            _foulService = foulService;
            _strikeService = strikeService;
            _spareService = spareService;
            _allPinsMissedService = allPinsMissedService;
            _partialKnockDownPinsService = partialKnockDownPinsService;
        }

        public void AllPlayersBowlAFrame(List<UserGameInfo> allUsersGameInfo)
        {
            foreach (UserGameInfo userGameInfo in allUsersGameInfo)
            { 
                FirstDelivery(userGameInfo);
                SecondDelivery(userGameInfo);
 
                //SetupFrameDeliveryMarks(userGameInfo.DeliveryFrames,
                //    userGameInfo.CurrentProcessingFrameIndex);

                //ScoreFrameTotal(userGameInfo.DeliveryFrames,
                //    userGameInfo.CurrentProcessingFrameIndex);
                
                userGameInfo.CurrentProcessingFrameIndex++;
            }
        }

        public void FirstDelivery(UserGameInfo inputUserGameInfo)
        {
            _foulService.CheckAndScoreFirstDelivery(inputUserGameInfo.DeliveryFrames, 
                inputUserGameInfo.CurrentProcessingFrameIndex);

            //slim possibility of gutter or severe error on delivery
            _allPinsMissedService.CheckAndScoreFirstDelivery(inputUserGameInfo.DeliveryFrames, 
                inputUserGameInfo.CurrentProcessingFrameIndex);

            _strikeService.CheckAndScoreFirstDelivery(inputUserGameInfo.DeliveryFrames,
                inputUserGameInfo.CurrentProcessingFrameIndex);

            _partialKnockDownPinsService.CheckAndScoreFirstDelivery(inputUserGameInfo.DeliveryFrames,
                inputUserGameInfo.CurrentProcessingFrameIndex);
        }

        public void SecondDelivery(UserGameInfo inputUserGameInfo)
        {
            _foulService.CheckAndScoreSecondDelivery(inputUserGameInfo.DeliveryFrames,
                inputUserGameInfo.CurrentProcessingFrameIndex);

            _allPinsMissedService.CheckAndScoreSecondDelivery(inputUserGameInfo.DeliveryFrames,
                inputUserGameInfo.CurrentProcessingFrameIndex);

            _spareService.ScoreSecondDeliverySpare(inputUserGameInfo.DeliveryFrames,
                inputUserGameInfo.CurrentProcessingFrameIndex);
        }

        public void FirstExtraDelivery()
        { }

        public void SecondExtraDelivery()
        { }

        private void SetupFrameDeliveryMarks(List<PlayerFrame> deliveryFrames,
            int currentFrameIndex)
        {

        }

        private void ScoreFrameTotal(List<PlayerFrame> deliveryFrames,
            int currentFrameIndex)
        {

        }
    }
}
