using BowlingWebApplication.Models.ViewModel;

namespace BowlingWebApplication.Services.Interfaces
{
    public interface IDeliveryService
    {
        string GetDeliveryStatusText(int statusCode);
        void SaveDelivery(FullGameModel fullGameModel, DeliveryInputViewModel deliveryInputViewModel);
    }
}