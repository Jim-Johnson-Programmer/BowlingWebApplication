using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using BowlingWebApplication.Models;
using BowlingWebApplication.Models.ReferenceMessages;
using BowlingWebApplication.Services.Interfaces;

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

        public void SetPlayerDeliveryInfo(int userId, int frameNum, int deliveryNum, int pinsKnockedDown, 
            string delieveryStatus, List<UserGameInfo> allGameInfos)
        {
            

            if (delieveryStatus.Equals(UserDeliveryMessages.STRIKE_DELIVERY_STATUS))
            {
                _strikeService.CheckAndScoreFirstDelivery(allGameInfos[userId].DeliveryFrames, frameNum);
            }
            else if (delieveryStatus.Equals(UserDeliveryMessages.SPARE_DELIVERY_STATUS))
            {
                
            }
            else if (delieveryStatus.Equals(UserDeliveryMessages.OPEN_DELIVERY_STATUS))
            {

            }
            else if (delieveryStatus.Equals(UserDeliveryMessages.FOUL_DELIVERY_STATUS))
            {

            }
            else if (delieveryStatus.Equals(UserDeliveryMessages.OPEN_DELIVERY_STATUS))
            {

            }
            else
            {
                //error messages
            }
        }

        //public void AllPlayersBowlNextFrame(List<UserGameInfo> allUsersGameInfo)
        //{
        //    foreach (UserGameInfo userGameInfo in allUsersGameInfo)
        //    { 
        //        FirstDelivery(userGameInfo.DeliveryFrames, userGameInfo.CurrentProcessingFrameIndex);

        //        if(!userGameInfo.DeliveryFrames[userGameInfo.CurrentProcessingFrameIndex]
        //            .IsFirstDeliveryStrike)
        //            SecondDelivery(userGameInfo.DeliveryFrames, userGameInfo.CurrentProcessingFrameIndex);

        //        userGameInfo.CurrentProcessingFrameIndex++;
        //    }
        //}

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
            _partialKnockDownPinsService.CheckAndScoreSecondDelivery(deliveryFrames, currentFrameIndex);
        }

        public void FirstExtraDelivery()
        { }

        public void SecondExtraDelivery()
        { }

        private void SetupFrameDeliveryMarks(List<PlayerFrame> deliveryFrames,
            int currentFrameIndex)
        {

        }

        private void PopulateFrameTotals(List<PlayerFrame> deliveryFrames)
        {
            for (int index = 0; index <= 10; index++)
            {
                if (deliveryFrames[index].IsFirstDeliveryStrike)
                {
                    deliveryFrames[index].CumulativeScore = 10 +
                           deliveryFrames[index+1].FirstDeliveryScore +
                           deliveryFrames[index+1].SecondDeliveryScore;
                }
                else if (deliveryFrames[index].IsSecondDeliverySpare)
                {
                    deliveryFrames[index].CumulativeScore = 10 +
                            deliveryFrames[index+1].FirstDeliveryScore;
                }
                else if (index==10)
                {
                    deliveryFrames[index].CumulativeScore =
                        deliveryFrames[index].FirstDeliveryScore +
                        deliveryFrames[index].SecondDeliveryScore +
                        deliveryFrames[index].TenthFrameThirdDeliveryScore;
                        //third delivery will be zero if not used
                }
                else
                {
                    deliveryFrames[index].CumulativeScore = 
                            deliveryFrames[index].FirstDeliveryScore +
                            deliveryFrames[index].SecondDeliveryScore;
                }
            }
        }
    }
}
