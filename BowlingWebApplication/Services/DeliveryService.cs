using BowlingWebApplication.Models;
using BowlingWebApplication.Models.ReferenceMessages;
using BowlingWebApplication.Models.ViewModel;
using BowlingWebApplication.Services.Interfaces;

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

            if (deliveryInputViewModel.CurrDeliveryInFrameCount == 1 && 
                scoreCardViewModel.CurrentFrameId<9)
            {
                MarkFirstDelivery(currentFrame, deliveryInputViewModel);
            }
            else if (deliveryInputViewModel.CurrDeliveryInFrameCount == 2 &&
                     scoreCardViewModel.CurrentFrameId < 9)
            {
                MarkSecondDelivery(currentFrame, deliveryInputViewModel);
                ScoreRegularFrames(previousFrame, currentFrame, deliveryInputViewModel);
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
                ////simply save the score and prepend pins down with S
                cardFrame.FirstDeliveryMark =
                    UserDeliveryMessages.SPLIT_DELIVERY_CODE + deliveryInputViewModel.SelectedPinsDownCount;
                cardFrame.FirstDeliveryScore = deliveryInputViewModel.SelectedPinsDownCount;
            }
            else if (deliveryInputViewModel.SelectedDeliveryCode == (int)FrameStatusEnum.Strike)
            {
                //skip if first time

                //score the next time
                cardFrame.FirstDeliveryMark = UserDeliveryMessages.STRIKE_DELIVERY_CODE;
                cardFrame.FirstDeliveryScore = 10;
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
        }

        private void ScoreRegularFrames(ScoreCardFrame prevScoreCardFrame, ScoreCardFrame currScoreCardFrame, DeliveryInputViewModel deliveryInputViewModel)
        {
             if (deliveryInputViewModel.SelectedDeliveryCode == (int) FrameStatusEnum.Strike)
             {

             }
             else if (deliveryInputViewModel.SelectedDeliveryCode == (int)FrameStatusEnum.Spare)
             {

             }
             else 
             {
                if (prevScoreCardFrame.FirstDeliveryScore == 0 &&
                    prevScoreCardFrame.SecondDeliveryScore == 0)
                {
                   currScoreCardFrame.FrameCumulativeScore =
                        currScoreCardFrame.FirstDeliveryScore + currScoreCardFrame.SecondDeliveryScore;
                }
                else
                {
                    currScoreCardFrame.FrameCumulativeScore = 
                        prevScoreCardFrame.FrameCumulativeScore + currScoreCardFrame.FirstDeliveryScore + 
                        currScoreCardFrame.SecondDeliveryScore;
                }
             }
        }
    }
}
