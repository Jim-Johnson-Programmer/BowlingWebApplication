using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BowlingWebApplication.Models;
using BowlingWebApplication.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BowlingWebApplication.Services
{
    public class UserService : IUserService
    {
        public void CreateUser(FullGameModel fullGameModel, BowlingUserViewModel userViewModel)
        {
            if (!fullGameModel.GamePlayers.Any(o => o.FirstName.Equals(userViewModel.FirstName) &&
                                                    o.LastName.Equals(userViewModel.LastName)))
            {
                fullGameModel.GamePlayers.Add(new UserGameInfo()
                {
                    FirstName = userViewModel.FirstName,
                    LastName = userViewModel.LastName,
                    UserId = fullGameModel.GamePlayers.Count != 0 ? fullGameModel.GamePlayers.Max(o => o.UserId) + 1 : 1,
                    DeliveryFrames = CreatePlayerFrames(),
                    CurrentStatus = "New Player"
                });
            }

        }
        private List<PlayerFrame> CreatePlayerFrames()
        {
            List<PlayerFrame> playerFrames = new List<PlayerFrame>();
            for (int ctr = 1; ctr < 11; ctr++)
            {
                playerFrames.Add(new PlayerFrame() { FrameId = ctr }); ;
            }

            return playerFrames;
        }
    }

}
