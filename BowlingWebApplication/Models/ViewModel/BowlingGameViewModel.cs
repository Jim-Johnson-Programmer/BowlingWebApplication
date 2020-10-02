using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingWebApplication.Models.ViewModel
{
    public class BowlingGameViewModel
    {
        private FullGameInfo _fullGameInfo;
        public List<BowlingTableRow> BowlingTableRows { get; set; } 


        public BowlingGameViewModel(FullGameInfo fullGameInfo)
        {
            _fullGameInfo = fullGameInfo;
            BowlingTableRows = new List<BowlingTableRow>();
        }

        public void LoadGameData()
        {
            foreach (var gamePlayerInfo in _fullGameInfo.GamePlayers)
            {
                BowlingTableRow tableRow = new BowlingTableRow();
                tableRow.Name = gamePlayerInfo.FirstName + " " + gamePlayerInfo.LastName;
                foreach (var deliveryFrame in gamePlayerInfo.DeliveryFrames)
                {
                    tableRow.Frame1Delivery1 = deliveryFrame.FirstDeliveryMark;
                    tableRow.Frame1Delivery2 = deliveryFrame.SecondDeliveryMark;
                    tableRow.Frame1Score = deliveryFrame.CumulativeScore.ToString();
                    tableRow.Frame2Delivery1 = deliveryFrame.FirstDeliveryMark;
                    tableRow.Frame2Delivery2 = deliveryFrame.SecondDeliveryMark;
                    tableRow.Frame2Score = deliveryFrame.CumulativeScore.ToString();
                    tableRow.Frame3Delivery1 = deliveryFrame.FirstDeliveryMark;
                    tableRow.Frame3Delivery2 = deliveryFrame.SecondDeliveryMark;
                    tableRow.Frame3Score = deliveryFrame.CumulativeScore.ToString();
                    tableRow.Frame4Delivery1 = deliveryFrame.FirstDeliveryMark;
                    tableRow.Frame4Delivery2 = deliveryFrame.SecondDeliveryMark;
                    tableRow.Frame4Score = deliveryFrame.CumulativeScore.ToString();
                    tableRow.Frame4Delivery1 = deliveryFrame.FirstDeliveryMark;
                    tableRow.Frame4Delivery2 = deliveryFrame.SecondDeliveryMark;
                    tableRow.Frame1Score = deliveryFrame.CumulativeScore.ToString();
                    tableRow.Frame1Delivery1 = deliveryFrame.FirstDeliveryMark;
                    tableRow.Frame1Delivery2 = deliveryFrame.SecondDeliveryMark;
                    tableRow.Frame1Score = deliveryFrame.CumulativeScore.ToString();
                    tableRow.Frame1Delivery1 = deliveryFrame.FirstDeliveryMark;
                    tableRow.Frame1Delivery2 = deliveryFrame.SecondDeliveryMark;
                    tableRow.Frame1Score = deliveryFrame.CumulativeScore.ToString();
                    tableRow.Frame1Delivery1 = deliveryFrame.FirstDeliveryMark;
                    tableRow.Frame1Delivery2 = deliveryFrame.SecondDeliveryMark;
                    tableRow.Frame1Score = deliveryFrame.CumulativeScore.ToString();
                    tableRow.Frame1Delivery1 = deliveryFrame.FirstDeliveryMark;
                    tableRow.Frame1Delivery2 = deliveryFrame.SecondDeliveryMark;
                    tableRow.Frame1Score = deliveryFrame.CumulativeScore.ToString();
                }
            }
        }
    }

    public class BowlingTableRow
    {
        public string Name { get; set; }
        public string Frame1Delivery1 { get; set; }
        public string Frame1Delivery2 { get; set; }
        public string Frame1Score { get; set; }
        public string Frame2Delivery1 { get; set; }
        public string Frame2Delivery2 { get; set; }
        public string Frame2Score { get; set; }
        public string Frame3Delivery1 { get; set; }
        public string Frame3Delivery2 { get; set; }
        public string Frame3Score { get; set; }
        public string Frame4Delivery1 { get; set; }
        public string Frame4Delivery2 { get; set; }
        public string Frame4Score { get; set; }
        public string Frame5Delivery1 { get; set; }
        public string Frame5Delivery2 { get; set; }
        public string Frame5Score { get; set; }
        public string Frame6Delivery1 { get; set; }
        public string Frame6Delivery2 { get; set; }
        public string Frame6Score { get; set; }
        public string Frame7Delivery1 { get; set; }
        public string Frame7Delivery2 { get; set; }
        public string Frame7Score { get; set; }
        public string Frame8Delivery1 { get; set; }
        public string Frame8Delivery2 { get; set; }
        public string Frame8Score { get; set; }
        public string Frame9Delivery1 { get; set; }
        public string Frame9Delivery2 { get; set; }
        public string Frame9Score { get; set; }
        public string Frame10Delivery1 { get; set; }
        public string Frame10Delivery2 { get; set; }
        public string Frame10Delivery3 { get; set; }
        public string Frame10Score { get; set; }
    }
}
