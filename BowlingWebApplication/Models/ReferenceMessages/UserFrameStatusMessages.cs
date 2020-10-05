using System.Collections.Generic;

namespace BowlingWebApplication.Models.ReferenceMessages
{
    public class UserFrameStatusMessages
    {
        public const string SINGLE_STRIKE_DELIVERY_STATUS = "STRIKE FRAME";
        public const string DOUBLE_STRIKE_STATUS = "TWO STRIKES IN A ROW! A DOUBLE!";
        public const string TRIPLE_STRIKE_STATUS = "THREE STRIKES IN A ROW! A TURKEY!";
        public const string QUAD_STRIKE_STATUS = "FOUR STRIKES IN A ROW! A FOUR BAGGER!";
        public const string SPARE_DELIVERY_STATUS = "SPARE FRAME";
        public const string OPEN_FRAME_DELIVERY_STATUS = "OPEN FRAME";
        public const string SPLIT_FRAME_DELIVERY_STATUS = "SPLIT FRAME";
        public const string FOUL_DELIVERY_STATUS = "FOUL ON FIRST DELIVERY IN FRAME";
    }

    public class UserFrameStatusInfo
    {
        public UserFrameStatusInfo()
        {
            FrameStatusItem.Add(0, "No Previous Delivery");
            FrameStatusItem.Add((int)FrameStatusEnum.OpenFrame, "Open Frame");
            FrameStatusItem.Add((int)FrameStatusEnum.Foul, "Foul");
            FrameStatusItem.Add((int)FrameStatusEnum.Spare, "Spare");
            FrameStatusItem.Add((int)FrameStatusEnum.Split, "Split");
            FrameStatusItem.Add((int)FrameStatusEnum.Strike, "Strike");
            FrameStatusItem.Add((int)FrameStatusEnum.StandardRoll, "Standard Roll");
        }

        public Dictionary<int, string> FrameStatusItem { get; set; } = new Dictionary<int, string>();
    }

}