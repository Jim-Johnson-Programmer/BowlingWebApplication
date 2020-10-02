using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
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

        public void AllPlayersBowlNextFrame(List<UserGameInfo> allUsersGameInfo)
        {
            foreach (UserGameInfo userGameInfo in allUsersGameInfo)
            { 
                FirstDelivery(userGameInfo.DeliveryFrames, userGameInfo.CurrentProcessingFrameIndex);

                if(!userGameInfo.DeliveryFrames[userGameInfo.CurrentProcessingFrameIndex]
                    .IsFirstDeliveryStrike)
                    SecondDelivery(userGameInfo.DeliveryFrames, userGameInfo.CurrentProcessingFrameIndex);

                //ScoreFrameTotal(userGameInfo.DeliveryFrames, userGameInfo.CurrentProcessingFrameIndex);

                userGameInfo.CurrentProcessingFrameIndex++;
            }
        }

        private void FirstDelivery(List<PlayerFrame> deliveryFrames, int currentFrameIndex)
        {
            _foulService.CheckAndScoreFirstDelivery(deliveryFrames, currentFrameIndex);

            //slim possibility of gutter or severe error on delivery
            _allPinsMissedService.CheckAndScoreFirstDelivery(deliveryFrames, currentFrameIndex);

            _strikeService.CheckAndScoreFirstDelivery(deliveryFrames, currentFrameIndex);

            _partialKnockDownPinsService.CheckAndScoreFirstDelivery(deliveryFrames, currentFrameIndex);
        }

        private void SecondDelivery(List<PlayerFrame> deliveryFrames, int currentFrameIndex)
        {
            _foulService.CheckAndScoreSecondDelivery(deliveryFrames, currentFrameIndex);

            _allPinsMissedService.CheckAndScoreSecondDelivery(deliveryFrames, currentFrameIndex);

            _spareService.ScoreSecondDeliverySpare(deliveryFrames, currentFrameIndex);
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
            if (currentFrameIndex<10)
            {
                if (deliveryFrames[currentFrameIndex - 1].IsFirstDeliveryStrike)
                {
                    //10 plus next two deliveries
                    deliveryFrames[currentFrameIndex - 1].CumulativeScore = 10 +
                        deliveryFrames[currentFrameIndex - 2].CumulativeScore + 
                        deliveryFrames[currentFrameIndex].FirstDeliveryScore +
                        deliveryFrames[currentFrameIndex].SecondDeliveryScore;
                }
                else if (deliveryFrames[currentFrameIndex - 1].IsSecondDeliverySpare)
                {
                    //10 plus next delivery
                    deliveryFrames[currentFrameIndex - 1].CumulativeScore = 10 +
                       deliveryFrames[currentFrameIndex - 2].CumulativeScore +
                       deliveryFrames[currentFrameIndex].FirstDeliveryScore;
                }
                else
                {
                    //add  current deliveries 
                } 
            }
        }
    }
}
