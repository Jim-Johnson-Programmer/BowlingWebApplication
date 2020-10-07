using System.Reflection.PortableExecutable;
using BowlingWebApplication.Models;
using BowlingWebApplication.Models.ReferenceMessages;
using BowlingWebApplication.Models.ViewModel;
using BowlingWebApplication.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace BowlingWebApplication.Services
{
    public class DeliveryService : IDeliveryService
    {
        public string GetDeliveryStatusText(int statusCode)
        {
            UserFrameStatusInfo userFrameStatusInfo = new UserFrameStatusInfo();
            return userFrameStatusInfo.FrameStatusItem[statusCode];
        }

        public void SaveDelivery(ScoreCardViewModel scoreCardViewModel, DeliveryInputViewModel deliveryInputViewModel)
        {
            ScoreCardFrame currentFrame = scoreCardViewModel.ScoreCardRows[scoreCardViewModel.CurrentScoreCardRowIndex]
                .ScoreCardFrames[scoreCardViewModel.CurrentFrameId];

            ScoreCardFrame previousFrame = new ScoreCardFrame();
            if (scoreCardViewModel.CurrentFrameId>0)
            {
                previousFrame = scoreCardViewModel.ScoreCardRows[scoreCardViewModel.CurrentScoreCardRowIndex]
                        .ScoreCardFrames[scoreCardViewModel.CurrentFrameId - 1]; 
            }

            ScoreCardFrame twoFramesBackFrame = new ScoreCardFrame();
            if (scoreCardViewModel.CurrentFrameId > 1)
            {
                twoFramesBackFrame = scoreCardViewModel.ScoreCardRows[scoreCardViewModel.CurrentScoreCardRowIndex]
                    .ScoreCardFrames[scoreCardViewModel.CurrentFrameId - 2];
            }

            if (deliveryInputViewModel.CurrDeliveryInFrameIndex == 0)
            {
                MarkFirstDelivery(currentFrame, deliveryInputViewModel);
            }
            else if (deliveryInputViewModel.CurrDeliveryInFrameIndex == 1)
            {
                MarkSecondDelivery(currentFrame, deliveryInputViewModel);
                ScorePrevFrameForStrikesAndSpares( twoFramesBackFrame, previousFrame, currentFrame, deliveryInputViewModel);
                if (!currentFrame.IsBonusRoundAllowed)
                {
                    ScoreRegularFrames(previousFrame, currentFrame, deliveryInputViewModel);
                }
            }
            else
            {
                MarkTenthFrameBonusDeliveries(currentFrame, deliveryInputViewModel);
                ScoreTenthFrame(currentFrame, deliveryInputViewModel);
            }
        }

        private void MarkFirstDelivery(ScoreCardFrame cardFrame, DeliveryInputViewModel deliveryInputViewModel)
        {
            if (deliveryInputViewModel.SelectedDeliveryCode == (int)FrameStatusEnum.OpenFrame)
            {
                cardFrame.FirstDeliveryMark = UserDeliveryMessages.OPEN_FRAME_DELIVERY_CODE;
                cardFrame.FirstDeliveryScore = 0;
            }
            else if (deliveryInputViewModel.SelectedDeliveryCode == (int)FrameStatusEnum.Foul)
            {
                cardFrame.FirstDeliveryScore = 0;
                cardFrame.FirstDeliveryMark = UserDeliveryMessages.FOUL_DELIVERY_CODE;
            }
            else if (deliveryInputViewModel.SelectedDeliveryCode == (int)FrameStatusEnum.Split)
            {
                cardFrame.FirstDeliveryMark =
                    UserDeliveryMessages.SPLIT_DELIVERY_CODE + deliveryInputViewModel.SelectedPinsDownCount;
                cardFrame.FirstDeliveryScore = deliveryInputViewModel.SelectedPinsDownCount;
            }
            else if (deliveryInputViewModel.SelectedDeliveryCode == (int)FrameStatusEnum.Strike)
            {
                cardFrame.SecondDeliveryScore = 10;
                cardFrame.SecondDeliveryMark = UserDeliveryMessages.STRIKE_DELIVERY_CODE;
            }
            else if (deliveryInputViewModel.SelectedDeliveryCode == (int)FrameStatusEnum.StandardRoll)
            {
                cardFrame.FirstDeliveryScore = deliveryInputViewModel.SelectedPinsDownCount;
                cardFrame.FirstDeliveryMark = deliveryInputViewModel.SelectedPinsDownCount.ToString();
            }
        }

        private void MarkSecondDelivery(ScoreCardFrame scoreCardFrame, DeliveryInputViewModel deliveryInputViewModel)
        {
            if (deliveryInputViewModel.SelectedDeliveryCode == (int)FrameStatusEnum.OpenFrame)
            {
                scoreCardFrame.SecondDeliveryMark = UserDeliveryMessages.OPEN_FRAME_DELIVERY_CODE;
                scoreCardFrame.SecondDeliveryScore = 0;
            }
            else if (deliveryInputViewModel.SelectedDeliveryCode == (int)FrameStatusEnum.Foul)
            {
                scoreCardFrame.SecondDeliveryScore = 0;
                scoreCardFrame.SecondDeliveryMark = UserDeliveryMessages.FOUL_DELIVERY_CODE;
            }
            else if (deliveryInputViewModel.SelectedDeliveryCode == (int)FrameStatusEnum.Spare)
            {
                //score the next time mark as / 
                scoreCardFrame.SecondDeliveryMark = UserDeliveryMessages.SPARE_DELIVERY_CODE;
                int firstScore = scoreCardFrame.FirstDeliveryScore;
                scoreCardFrame.SecondDeliveryScore = 10 - firstScore;
            }
            else if (deliveryInputViewModel.SelectedDeliveryCode == (int)FrameStatusEnum.Split)
            {
                //simply save the score and prepend pins down with S
                scoreCardFrame.SecondDeliveryMark =
                    UserDeliveryMessages.SPLIT_DELIVERY_CODE + deliveryInputViewModel.SelectedPinsDownCount;
                scoreCardFrame.SecondDeliveryScore = deliveryInputViewModel.SelectedPinsDownCount;
            }
            else if (deliveryInputViewModel.SelectedDeliveryCode == (int)FrameStatusEnum.StandardRoll)
            {
                scoreCardFrame.SecondDeliveryScore = deliveryInputViewModel.SelectedPinsDownCount;
                scoreCardFrame.SecondDeliveryMark = deliveryInputViewModel.SelectedPinsDownCount.ToString();
            }

            if (deliveryInputViewModel.SelectedDeliveryCode == (int)FrameStatusEnum.Strike && 
                deliveryInputViewModel.SelectedDeliveryCode == (int)FrameStatusEnum.Spare && 
                deliveryInputViewModel.FrameIndex>8)
            {
                scoreCardFrame.IsBonusRoundAllowed = true;
            }
        }

        private void MarkTenthFrameBonusDeliveries(ScoreCardFrame scoreCardFrame,DeliveryInputViewModel deliveryInputViewModel)
        {
            if (deliveryInputViewModel.SelectedDeliveryCode == (int)FrameStatusEnum.Strike)
            {
                scoreCardFrame.BonusDeliveryMark = UserDeliveryMessages.STRIKE_DELIVERY_CODE;
                scoreCardFrame.BonusDeliveryScore = 0;
            }
            else if (deliveryInputViewModel.SelectedDeliveryCode == (int)FrameStatusEnum.OpenFrame)
            {
                scoreCardFrame.BonusDeliveryMark = UserDeliveryMessages.OPEN_FRAME_DELIVERY_CODE;
                scoreCardFrame.BonusDeliveryScore = 0;
            }
            else if (deliveryInputViewModel.SelectedDeliveryCode == (int)FrameStatusEnum.Foul)
            {
                scoreCardFrame.BonusDeliveryMark = UserDeliveryMessages.FOUL_DELIVERY_CODE;
                scoreCardFrame.BonusDeliveryScore = 0;
            }
            else if (deliveryInputViewModel.SelectedDeliveryCode == (int)FrameStatusEnum.Spare)
            {
                scoreCardFrame.BonusDeliveryMark = UserDeliveryMessages.SPARE_DELIVERY_CODE;
                int firstScore = scoreCardFrame.FirstDeliveryScore;
                scoreCardFrame.BonusDeliveryScore = 10 - firstScore;
            }
            else if (deliveryInputViewModel.SelectedDeliveryCode == (int)FrameStatusEnum.Split)
            {
                //simply save the score and prepend pins down with S
                scoreCardFrame.BonusDeliveryMark =
                    UserDeliveryMessages.SPLIT_DELIVERY_CODE + deliveryInputViewModel.SelectedPinsDownCount;
                scoreCardFrame.BonusDeliveryScore = deliveryInputViewModel.SelectedPinsDownCount;
            }
            else if (deliveryInputViewModel.SelectedDeliveryCode == (int)FrameStatusEnum.StandardRoll)
            {
                scoreCardFrame.BonusDeliveryMark = deliveryInputViewModel.SelectedPinsDownCount.ToString();
                scoreCardFrame.BonusDeliveryScore = deliveryInputViewModel.SelectedPinsDownCount;
            }
        }

        private void ScoreTenthFrame(ScoreCardFrame scoreCardFrame, DeliveryInputViewModel deliveryInputViewModel)
        {
            scoreCardFrame.FrameCumulativeScore = scoreCardFrame.FirstDeliveryScore +
                                                  scoreCardFrame.SecondDeliveryScore +
                                                  scoreCardFrame.BonusDeliveryScore;
        }

        private void ScoreRegularFrames(ScoreCardFrame prevScoreCardFrame, ScoreCardFrame currScoreCardFrame, DeliveryInputViewModel deliveryInputViewModel)
        {
            if (currScoreCardFrame.FrameId == 0 & 
                !currScoreCardFrame.FirstDeliveryMark.Equals(UserDeliveryMessages.STRIKE_DELIVERY_CODE) &&
                !currScoreCardFrame.SecondDeliveryMark.Equals(UserDeliveryMessages.SPARE_DELIVERY_CODE))
            {
                currScoreCardFrame.FrameCumulativeScore =
                    currScoreCardFrame.FirstDeliveryScore + currScoreCardFrame.SecondDeliveryScore;
                //return;
            }
            else if (!currScoreCardFrame.FirstDeliveryMark.Equals(UserDeliveryMessages.STRIKE_DELIVERY_CODE) &&
                    !currScoreCardFrame.SecondDeliveryMark.Equals(UserDeliveryMessages.SPARE_DELIVERY_CODE))
            {
                currScoreCardFrame.FrameCumulativeScore = prevScoreCardFrame.FrameCumulativeScore +
                                                          currScoreCardFrame.FirstDeliveryScore +
                                                          currScoreCardFrame.SecondDeliveryScore;
            }

            //if (prevScoreCardFrame.FirstDeliveryMark.Equals(UserDeliveryMessages.STRIKE_DELIVERY_CODE))
            //{
            //    prevScoreCardFrame.FrameCumulativeScore = prevScoreCardFrame.FirstDeliveryScore +
            //                                              currScoreCardFrame.FirstDeliveryScore +
            //                                              currScoreCardFrame.SecondDeliveryScore;
            //}
            //else if (deliveryInputViewModel.SelectedDeliveryCode == (int)FrameStatusEnum.Spare)
            //{
            //    prevScoreCardFrame.FrameCumulativeScore = prevScoreCardFrame.FirstDeliveryScore +
            //                                              currScoreCardFrame.FirstDeliveryScore;
            //}

        }

        private void ScorePrevFrameForStrikesAndSpares(ScoreCardFrame twoFramesBackFrame,
                                                    ScoreCardFrame prevScoreCardFrame,
                                                    ScoreCardFrame currScoreCardFrame, 
                                                    DeliveryInputViewModel deliveryInputViewModel)
        {
            if (prevScoreCardFrame.SecondDeliveryMark.Equals(UserDeliveryMessages.STRIKE_DELIVERY_CODE))
            {
                prevScoreCardFrame.FrameCumulativeScore = twoFramesBackFrame.FrameCumulativeScore
                                                          + 10 
                                                          + currScoreCardFrame.FirstDeliveryScore 
                                                          + currScoreCardFrame.SecondDeliveryScore;
            }
            else if (prevScoreCardFrame.SecondDeliveryMark.Equals(UserDeliveryMessages.SPARE_DELIVERY_CODE))
            {
                prevScoreCardFrame.FrameCumulativeScore = 10 + currScoreCardFrame.FirstDeliveryScore +
                                                            twoFramesBackFrame.FrameCumulativeScore;
            }
        }
    }
}
