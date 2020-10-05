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
                ScoreFirstDelivery(scoreCardViewModel, deliveryInputViewModel);
            }
            else if (deliveryInputViewModel.CurrDeliveryInFrameCount == 2)
            {
                
            }
            //conditions for 10th frame calculations
            
            scoreCardViewModel.PreviousPinDownCount = deliveryInputViewModel.SelectedPinsDownCount;
            scoreCardViewModel.PreviousDeliveryType = deliveryInputViewModel.SelectedDeliveryCode;

            scoreCardViewModel.CurrentDeliveryInFrameCount++;

            //save selected info into past info
        }

        private void ScoreFirstDelivery(ScoreCardViewModel scoreCardViewModel, DeliveryInputViewModel deliveryInputViewModel)
        {
            if (deliveryInputViewModel.SelectedDeliveryCode == (int) FrameStatusEnum.OpenFrame)
            {
                //score as zero and move on
                scoreCardViewModel.ScoreCardRows[deliveryInputViewModel.FrameIndex]
                    .ScoreCardFrames[deliveryInputViewModel.CurrDeliveryInFrameIndex].FirstDeliveryMark = 
                    UserDeliveryMessages.OPEN_FRAME_DELIVERY_CODE;
                scoreCardViewModel.ScoreCardRows[deliveryInputViewModel.FrameIndex]
                    .ScoreCardFrames[deliveryInputViewModel.CurrDeliveryInFrameIndex].FirstDeliveryScore = 0;
            }
            else if (deliveryInputViewModel.SelectedDeliveryCode == (int) FrameStatusEnum.Foul)
            {
                //save the zero and mark as f
                scoreCardViewModel.ScoreCardRows[deliveryInputViewModel.FrameIndex]
                    .ScoreCardFrames[deliveryInputViewModel.CurrDeliveryInFrameIndex].FirstDeliveryScore = 0;

                scoreCardViewModel.ScoreCardRows[deliveryInputViewModel.FrameIndex]
                        .ScoreCardFrames[deliveryInputViewModel.CurrDeliveryInFrameIndex].FirstDeliveryMark =
                    UserDeliveryMessages.FOUL_DELIVERY_CODE;
            }
            else if (deliveryInputViewModel.SelectedDeliveryCode == (int) FrameStatusEnum.Split)
            {
                //simply save the score and prepend pins down with S
                scoreCardViewModel.ScoreCardRows[deliveryInputViewModel.FrameIndex]
                        .ScoreCardFrames[deliveryInputViewModel.CurrDeliveryInFrameIndex].FirstDeliveryMark =
                    UserDeliveryMessages.SPLIT_DELIVERY_CODE+deliveryInputViewModel.SelectedPinsDownCount;

                scoreCardViewModel.ScoreCardRows[deliveryInputViewModel.FrameIndex]
                        .ScoreCardFrames[deliveryInputViewModel.CurrDeliveryInFrameIndex].FirstDeliveryScore =
                                                        deliveryInputViewModel.SelectedPinsDownCount;

                int firstRoundPinsTotal = scoreCardViewModel.ScoreCardRows[deliveryInputViewModel.FrameIndex]
                    .ScoreCardFrames[deliveryInputViewModel.CurrDeliveryInFrameIndex=1].FrameCumulativeScore;

                scoreCardViewModel.ScoreCardRows[deliveryInputViewModel.FrameIndex]
                    .ScoreCardFrames[deliveryInputViewModel.CurrDeliveryInFrameIndex].FrameCumulativeScore = 
                    firstRoundPinsTotal + deliveryInputViewModel.SelectedPinsDownCount;
            }
            else if (deliveryInputViewModel.SelectedDeliveryCode == (int) FrameStatusEnum.Strike)
            {
                //skip if first time

                //score the next time
                scoreCardViewModel.ScoreCardRows[deliveryInputViewModel.FrameIndex]
                        .ScoreCardFrames[deliveryInputViewModel.CurrDeliveryInFrameIndex].FirstDeliveryMark =
                    UserDeliveryMessages.STRIKE_DELIVERY_CODE;

                scoreCardViewModel.ScoreCardRows[deliveryInputViewModel.FrameIndex]
                    .ScoreCardFrames[deliveryInputViewModel.CurrDeliveryInFrameIndex].FirstDeliveryScore = 10;
            }
        }

        private void ScoreSecondDelivery(ScoreCardViewModel scoreCardViewModel, DeliveryInputViewModel deliveryInputViewModel)
        {
            if (deliveryInputViewModel.SelectedDeliveryCode == (int)FrameStatusEnum.OpenFrame)
            {
                //score as zero and move on
                scoreCardViewModel.ScoreCardRows[deliveryInputViewModel.FrameIndex]
                    .ScoreCardFrames[deliveryInputViewModel.CurrDeliveryInFrameIndex].SecondDeliveryMark =
                    UserDeliveryMessages.OPEN_FRAME_DELIVERY_CODE;
                scoreCardViewModel.ScoreCardRows[deliveryInputViewModel.FrameIndex]
                    .ScoreCardFrames[deliveryInputViewModel.CurrDeliveryInFrameIndex].SecondDeliveryScore = 0;

                //scoreCardViewModel.ScoreCardRows[deliveryInputViewModel.FrameIndex]
                //    .ScoreCardFrames[deliveryInputViewModel.CurrDeliveryInFrameIndex - 1].FrameCumulativeScore = 0;
            }
            else if (deliveryInputViewModel.SelectedDeliveryCode == (int)FrameStatusEnum.Foul)
            {
                //save the zero and mark as f
                scoreCardViewModel.ScoreCardRows[deliveryInputViewModel.FrameIndex]
                    .ScoreCardFrames[deliveryInputViewModel.CurrDeliveryInFrameIndex - 1].FrameCumulativeScore = 0;

                scoreCardViewModel.ScoreCardRows[deliveryInputViewModel.FrameIndex]
                        .ScoreCardFrames[deliveryInputViewModel.CurrDeliveryInFrameIndex - 1].FirstDeliveryMark =
                    UserDeliveryMessages.FOUL_DELIVERY_CODE;

                //scoreCardViewModel.ScoreCardRows[deliveryInputViewModel.FrameIndex]
                //    .ScoreCardFrames[deliveryInputViewModel.CurrDeliveryInFrameIndex - 1].FrameCumulativeScore = 0;
            }
            else if (deliveryInputViewModel.SelectedDeliveryCode == (int)FrameStatusEnum.Spare)
            {
                //skip if first time

                //score the next time mark as / 
                scoreCardViewModel.ScoreCardRows[deliveryInputViewModel.FrameIndex]
                        .ScoreCardFrames[deliveryInputViewModel.CurrDeliveryInFrameIndex].FirstDeliveryMark =
                    UserDeliveryMessages.SPARE_DELIVERY_CODE;

                scoreCardViewModel.ScoreCardRows[deliveryInputViewModel.FrameIndex]
                    .ScoreCardFrames[deliveryInputViewModel.CurrDeliveryInFrameIndex].FirstDeliveryScore = 10;

                //scoreCardViewModel.ScoreCardRows[deliveryInputViewModel.FrameIndex]
                //    .ScoreCardFrames[deliveryInputViewModel.CurrDeliveryInFrameIndex - 1].FrameCumulativeScore = 0;
            }
            else if (deliveryInputViewModel.SelectedDeliveryCode == (int)FrameStatusEnum.Split)
            {
                //simply save the score and prepend pins down with S
                scoreCardViewModel.ScoreCardRows[deliveryInputViewModel.FrameIndex]
                        .ScoreCardFrames[deliveryInputViewModel.CurrDeliveryInFrameIndex].FirstDeliveryMark =
                    UserDeliveryMessages.SPLIT_DELIVERY_CODE + deliveryInputViewModel.SelectedPinsDownCount;

                scoreCardViewModel.ScoreCardRows[deliveryInputViewModel.FrameIndex]
                        .ScoreCardFrames[deliveryInputViewModel.CurrDeliveryInFrameIndex].FirstDeliveryScore =
                                                        deliveryInputViewModel.SelectedPinsDownCount;

                //scoreCardViewModel.ScoreCardRows[deliveryInputViewModel.FrameIndex]
                //    .ScoreCardFrames[deliveryInputViewModel.CurrDeliveryInFrameIndex - 1].FrameCumulativeScore = 0;
            }
        }
    }

}
