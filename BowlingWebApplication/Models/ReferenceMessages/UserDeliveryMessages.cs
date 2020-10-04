using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingWebApplication.Models.ReferenceMessages
{
    public static class UserDeliveryMessages
    {
        public const string FOUL_DELIVERY_CODE = "F";
        public const string STRIKE_DELIVERY_CODE = "X";
        public const string SPARE_DELIVERY_CODE = "/";
        public const string OPEN_FRAME_DELIVERY_CODE = "_";

        public const string STRIKE_DELIVERY_STATUS = "STRIKE";
        public const string SPARE_DELIVERY_STATUS = "SPARE";
        public const string SPLIT_DELIVERY_STATUS = "SPLIT";
        public const string OPEN_DELIVERY_STATUS = "OPEN";
        public const string FOUL_DELIVERY_STATUS = "FOUL";
    }
}
