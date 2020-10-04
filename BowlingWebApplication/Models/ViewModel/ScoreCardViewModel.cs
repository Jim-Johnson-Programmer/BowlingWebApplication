using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingWebApplication.Models.ViewModel
{
    public class ScoreCardViewModel
    {
        public int CurrentFrameId { get; set; }
        public int CurrentDeliveryId { get; set; }
        public int CurrentPlayerId { get; set; }
        public int PreviousDeliveryType { get; set; }
        public int CurrentDeliveryType { get; set; }
   
        public List<ScoreCardRow> ScoreCardRows { get; set; } = new List<ScoreCardRow>();
    }

    public class ScoreCardRow
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PlayerId { get; set; }
        public List<ScoreCardFrame> ScoreCardFrames { get; set; }
    }

    public class ScoreCardFrame
    {
        public string FirstDeliveryMark { get; set; }
        public string SecondDeliveryMark { get; set; }
        public int FrameCumulativeScore { get; set; }
        public int FrameId { get; set; }
        public List<DeliveryItem> DeliveryItems { get; set; }= new List<DeliveryItem>(10);
    }

    public class DeliveryItem
    {
        public int PinsDown { get; set; }
        public int DeliveryTypeCode { get; set; }
        public string DeliveryTypeText { get; set; }
    }

}
