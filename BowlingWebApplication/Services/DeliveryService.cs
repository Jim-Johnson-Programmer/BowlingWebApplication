using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public void SaveDelivery(FullGameModel fullGameModel, DeliveryInputViewModel deliveryInputViewModel)
        {
            //if(fullGameModel.)
            //{ }
            //else if (deliveryInputViewModel.DeliveryCount==1)
            //{
                
            //}
        }
    }

}
