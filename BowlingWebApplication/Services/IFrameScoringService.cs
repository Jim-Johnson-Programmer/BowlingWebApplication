using BowlingWebApplication.Models;

namespace BowlingWebApplication.Services
{
    public interface IFrameScoringService
    {
        void FirstDelivery(UserGameInfo inputUserGameInfo);
        void SecondDelivery(UserGameInfo inputUserGameInfo);
        void FirstExtraDelivery();
        void SecondExtraDelivery();
    }
}