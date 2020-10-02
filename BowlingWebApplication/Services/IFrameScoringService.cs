using System.Collections.Generic;
using BowlingWebApplication.Models;

namespace BowlingWebApplication.Services
{
    public interface IFrameScoringService
    {
        void AllPlayersBowlAFrame(List<UserGameInfo> allUsersGameInfo);
        void FirstDelivery(UserGameInfo inputUserGameInfo);
        void SecondDelivery(UserGameInfo inputUserGameInfo);
        void FirstExtraDelivery();
        void SecondExtraDelivery();
    }
}