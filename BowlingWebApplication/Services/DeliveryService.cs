using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BowlingWebApplication.Models;
using BowlingWebApplication.Models.ReferenceMessages;
using BowlingWebApplication.Models.ViewModel;
using BowlingWebApplication.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BowlingWebApplication.Services
{
    public class DeliveryService : IDeliveryService
    {

        public DeliveryService()
        {
            
        }

        public string GetDeliveryStatusText(int statusCode)
        {
            UserFrameStatusInfo userFrameStatusInfo = new UserFrameStatusInfo();
            return userFrameStatusInfo.FrameStatusItem[statusCode];
        }

        public void SaveDelivery(ScoreCardViewModel scoreCardViewModel, DeliveryInputViewModel deliveryInputViewModel)
        {
            if (deliveryInputViewModel.CurrDeliveryInFrameCount == 1)
            {
                MarkFirstDelivery(scoreCardViewModel, deliveryInputViewModel);
            }
            else if (deliveryInputViewModel.CurrDeliveryInFrameCount == 2)
            {
                MarkSecondDelivery(scoreCardViewModel, deliveryInputViewModel);
            }
            else
            {
                ScoreRegularFrames(scoreCardViewModel, deliveryInputViewModel);
            }
            //conditions for 10th frame calculations

            scoreCardViewModel.PreviousPinDownCount = deliveryInputViewModel.SelectedPinsDownCount;
            scoreCardViewModel.PreviousDeliveryType = deliveryInputViewModel.SelectedDeliveryCode;

            //save selected info into past info
            if (scoreCardViewModel.CurrentFrameId < 10 &&
                deliveryInputViewModel.CurrDeliveryInFrameCount==2)
            {
                scoreCardViewModel.PreviousPinDownCount = 0;
                scoreCardViewModel.PreviousDeliveryType = 0;
                scoreCardViewModel.CurrentFrameId++;
            }

            scoreCardViewModel.CurrentDeliveryInFrameCount = deliveryInputViewModel.CurrDeliveryInFrameCount == 2 
                ? 0 : deliveryInputViewModel.CurrDeliveryInFrameCount;
        }

        private void MarkFirstDelivery(ScoreCardViewModel scoreCardViewModel, DeliveryInputViewModel deliveryInputViewModel)
        {
            if (deliveryInputViewModel.SelectedDeliveryCode == (int) FrameStatusEnum.OpenFrame)
            {
                //score as zero and move on
                scoreCardViewModel.ScoreCardRows[scoreCardViewModel.CurrentScoreCardRowIndex]
                    .ScoreCardFrames[scoreCardViewModel.CurrentFrameId].FirstDeliveryMark = 
                    UserDeliveryMessages.OPEN_FRAME_DELIVERY_CODE;
                scoreCardViewModel.ScoreCardRows[scoreCardViewModel.CurrentScoreCardRowIndex]
                    .ScoreCardFrames[scoreCardViewModel.CurrentFrameId].FirstDeliveryScore = 0;
            }
            else if (deliveryInputViewModel.SelectedDeliveryCode == (int) FrameStatusEnum.Foul)
            {
                //save the zero and mark as f
                scoreCardViewModel.ScoreCardRows[scoreCardViewModel.CurrentScoreCardRowIndex]
                    .ScoreCardFrames[scoreCardViewModel.CurrentFrameId].FirstDeliveryScore = 0;

                scoreCardViewModel.ScoreCardRows[scoreCardViewModel.CurrentScoreCardRowIndex]
                        .ScoreCardFrames[scoreCardViewModel.CurrentFrameId].FirstDeliveryMark =
                    UserDeliveryMessages.FOUL_DELIVERY_CODE;
            }
            else if (deliveryInputViewModel.SelectedDeliveryCode == (int) FrameStatusEnum.Split)
            {
                //simply save the score and prepend pins down with S
                scoreCardViewModel.ScoreCardRows[scoreCardViewModel.CurrentScoreCardRowIndex]
                        .ScoreCardFrames[scoreCardViewModel.CurrentFrameId].FirstDeliveryMark =
                    UserDeliveryMessages.SPLIT_DELIVERY_CODE+deliveryInputViewModel.SelectedPinsDownCount;

                scoreCardViewModel.ScoreCardRows[scoreCardViewModel.CurrentScoreCardRowIndex]
                        .ScoreCardFrames[scoreCardViewModel.CurrentFrameId].FirstDeliveryScore =
                                                        deliveryInputViewModel.SelectedPinsDownCount;

                //int firstRoundPinsTotal = scoreCardViewModel.ScoreCardRows[deliveryInputViewModel.FrameIndex]
                //    .ScoreCardFrames[deliveryInputViewModel.CurrDeliveryInFrameIndex].FrameCumulativeScore;

                //scoreCardViewModel.ScoreCardRows[deliveryInputViewModel.FrameIndex]
                //    .ScoreCardFrames[deliveryInputViewModel.CurrDeliveryInFrameIndex].FrameCumulativeScore = 
                //    firstRoundPinsTotal + deliveryInputViewModel.SelectedPinsDownCount;
            }
            else if (deliveryInputViewModel.SelectedDeliveryCode == (int) FrameStatusEnum.Strike)
            {
                //skip if first time

                //score the next time
                scoreCardViewModel.ScoreCardRows[scoreCardViewModel.CurrentScoreCardRowIndex]
                        .ScoreCardFrames[scoreCardViewModel.CurrentFrameId].FirstDeliveryMark =
                    UserDeliveryMessages.STRIKE_DELIVERY_CODE;

                scoreCardViewModel.ScoreCardRows[scoreCardViewModel.CurrentScoreCardRowIndex]
                    .ScoreCardFrames[scoreCardViewModel.CurrentFrameId].FirstDeliveryScore = 10;
            }
        }

        private void MarkSecondDelivery(ScoreCardViewModel scoreCardViewModel, DeliveryInputViewModel deliveryInputViewModel)
        {
            if (deliveryInputViewModel.SelectedDeliveryCode == (int)FrameStatusEnum.OpenFrame)
            {
                scoreCardViewModel.ScoreCardRows[scoreCardViewModel.CurrentScoreCardRowIndex]
                    .ScoreCardFrames[scoreCardViewModel.CurrentFrameId].SecondDeliveryMark =
                    UserDeliveryMessages.OPEN_FRAME_DELIVERY_CODE;
                scoreCardViewModel.ScoreCardRows[scoreCardViewModel.CurrentScoreCardRowIndex]
                    .ScoreCardFrames[scoreCardViewModel.CurrentFrameId].SecondDeliveryScore = 0;
            }
            else if (deliveryInputViewModel.SelectedDeliveryCode == (int)FrameStatusEnum.Foul)
            {
                //save the zero and mark as f
                scoreCardViewModel.ScoreCardRows[scoreCardViewModel.CurrentScoreCardRowIndex]
                    .ScoreCardFrames[scoreCardViewModel.CurrentFrameId].SecondDeliveryScore = 0;

                scoreCardViewModel.ScoreCardRows[scoreCardViewModel.CurrentScoreCardRowIndex]
                        .ScoreCardFrames[scoreCardViewModel.CurrentFrameId].SecondDeliveryMark =
                    UserDeliveryMessages.FOUL_DELIVERY_CODE;
            }
            else if (deliveryInputViewModel.SelectedDeliveryCode == (int)FrameStatusEnum.Spare)
            {
                //score the next time mark as / 
                scoreCardViewModel.ScoreCardRows[scoreCardViewModel.CurrentScoreCardRowIndex]
                        .ScoreCardFrames[scoreCardViewModel.CurrentFrameId].SecondDeliveryMark=
                    UserDeliveryMessages.SPARE_DELIVERY_CODE;

                int firstScore = scoreCardViewModel.ScoreCardRows[scoreCardViewModel.CurrentScoreCardRowIndex]
                                .ScoreCardFrames[scoreCardViewModel.CurrentFrameId].FirstDeliveryScore;

                scoreCardViewModel.ScoreCardRows[scoreCardViewModel.CurrentScoreCardRowIndex]
                    .ScoreCardFrames[scoreCardViewModel.CurrentFrameId].SecondDeliveryScore = 10 - firstScore;
            }
            else if (deliveryInputViewModel.SelectedDeliveryCode == (int)FrameStatusEnum.Split)
            {
                //simply save the score and prepend pins down with S
                scoreCardViewModel.ScoreCardRows[scoreCardViewModel.CurrentScoreCardRowIndex]
                        .ScoreCardFrames[scoreCardViewModel.CurrentFrameId].SecondDeliveryMark =
                    UserDeliveryMessages.SPLIT_DELIVERY_CODE + deliveryInputViewModel.SelectedPinsDownCount;

                scoreCardViewModel.ScoreCardRows[scoreCardViewModel.CurrentScoreCardRowIndex]
                        .ScoreCardFrames[scoreCardViewModel.CurrentFrameId].SecondDeliveryScore =
                                                        deliveryInputViewModel.SelectedPinsDownCount;
            }
        }

        private void ScoreRegularFrames(ScoreCardViewModel scoreCardViewModel, DeliveryInputViewModel deliveryInputViewModel)
        {
                //score as zero and move on
                scoreCardViewModel.ScoreCardRows[scoreCardViewModel.CurrentScoreCardRowIndex]
                        .ScoreCardFrames[scoreCardViewModel.CurrentFrameId].FrameCumulativeScore
                    =
                    scoreCardViewModel.ScoreCardRows[scoreCardViewModel.CurrentScoreCardRowIndex]
                        .ScoreCardFrames[scoreCardViewModel.CurrentFrameId - 1].FrameCumulativeScore
                    +
                    scoreCardViewModel.ScoreCardRows[scoreCardViewModel.CurrentScoreCardRowIndex]
                        .ScoreCardFrames[scoreCardViewModel.CurrentFrameId].FirstDeliveryScore
                    +
                    scoreCardViewModel.ScoreCardRows[scoreCardViewModel.CurrentScoreCardRowIndex]
                        .ScoreCardFrames[scoreCardViewModel.CurrentFrameId].SecondDeliveryScore;
        }
    }
}
