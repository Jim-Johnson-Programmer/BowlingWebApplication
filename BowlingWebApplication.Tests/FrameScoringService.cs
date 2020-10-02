using System;
using System.Collections.Generic;
using BowlingWebApplication.Models;
using BowlingWebApplication.Services;
using Xunit;

namespace BowlingWebApplication.Tests
{
    public class FrameScoringService
    {
        /*Frame scoring service*/
        //test strikes for frames 1-8
        //test strikes for frames 9 and 10

        //test spares for frames 1-8
        //test spares for frames 9 and 10

        //test scoring for frames 1-9
        //test scoring for 10th frame

        public FullGameInfo GenerateData()
        {
            FullGameInfo fullGameInfo = new FullGameInfo();
            fullGameInfo.GamePlayers = new List<UserGameInfo>();
            UserGameInfo player1 = new UserGameInfo();
            fullGameInfo.GamePlayers.Add(player1);

            return fullGameInfo;
        }

        public IFrameScoringService CreateService()
        {
            IAllPinsMissedService allPinsMissedService = new Services.AllPinsMissedService();
            IFoulScoringService foulScoringService = new Services.FoulScoringService();
            IStrikeScoringService strikeScoringService = new Services.StrikeScoringService();
            ISpareScoringService spareScoringService = new Services.SpareScoringService();
            IPartialKnockDownPinsService partialKnockDownPinsService = new Services.PartialKnockDownPinsService();
            IFrameScoringService frameScoringService = new Services.FrameScoringService(foulScoringService,
                strikeScoringService,
                spareScoringService,
                allPinsMissedService,
                partialKnockDownPinsService);

            return frameScoringService;
        }

        public void GenerateStrikeFrame()
        {

        }

        [Fact]
        public void Strike_Frame1()
        {
            IFrameScoringService frameScoringService = CreateService();
            FullGameInfo fullGameInfo = GenerateData();
            fullGameInfo.GamePlayers[0].DeliveryFrames

        }
    }
}
