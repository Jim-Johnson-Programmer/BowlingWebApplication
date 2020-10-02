using System.Collections.Generic;
using BowlingWebApplication.Models;

namespace BowlingWebApplication.Services
{
    public interface IFrameScoringService
    {
        void AllPlayersBowlNextFrame(List<UserGameInfo> allUsersGameInfo);
    }
}