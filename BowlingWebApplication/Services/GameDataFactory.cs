using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BowlingWebApplication.Models;

namespace BowlingWebApplication.Services
{
    public class GameDataFactory
    {
        public static FullGameInfo RegisterPlayersIntoGame()
        {
            FullGameInfo fullGameInfo = new FullGameInfo();

            UserGameInfo user1 = new UserGameInfo();
            user1.FirstName = "FirstName1";
            user1.LastName = "LastName1";
            user1.DeliveryFrames = new List<PlayerFrame>();

            PlayerFrame playerFrame1 = new PlayerFrame();
            playerFrame1.FrameId = 1;
            playerFrame1.FirstDeliveryMark = "1";
            playerFrame1.SecondDeliveryMark = "11";
            playerFrame1.CumulativeScore = 111;
            user1.DeliveryFrames.Add(playerFrame1);

            PlayerFrame playerFrame2 = new PlayerFrame();
            playerFrame2.FrameId = 2;
            playerFrame2.FirstDeliveryMark = "2";
            playerFrame2.SecondDeliveryMark = "22";
            playerFrame2.CumulativeScore = 222;
            user1.DeliveryFrames.Add(playerFrame2);

            PlayerFrame playerFrame3 = new PlayerFrame();
            playerFrame3.FrameId = 3;
            playerFrame3.FirstDeliveryMark = "3";
            playerFrame3.SecondDeliveryMark = "33";
            playerFrame3.CumulativeScore = 333;
            user1.DeliveryFrames.Add(playerFrame3);

            PlayerFrame playerFrame4 = new PlayerFrame();
            playerFrame4.FrameId = 4;
            playerFrame4.FirstDeliveryMark = "4";
            playerFrame4.SecondDeliveryMark = "44";
            playerFrame4.CumulativeScore = 444;
            user1.DeliveryFrames.Add(playerFrame4);

            PlayerFrame playerFrame5 = new PlayerFrame();
            playerFrame5.FrameId = 5;
            playerFrame5.FirstDeliveryMark = "5";
            playerFrame5.SecondDeliveryMark = "55";
            playerFrame5.CumulativeScore = 555;
            user1.DeliveryFrames.Add(playerFrame5);

            PlayerFrame playerFrame6 = new PlayerFrame();
            playerFrame6.FrameId = 6;
            playerFrame6.FirstDeliveryMark = "6";
            playerFrame6.SecondDeliveryMark = "66";
            playerFrame6.CumulativeScore = 666;
            user1.DeliveryFrames.Add(playerFrame6);

            PlayerFrame playerFrame7 = new PlayerFrame();
            playerFrame7.FrameId = 7;
            playerFrame7.FirstDeliveryMark = "7";
            playerFrame7.SecondDeliveryMark = "77";
            playerFrame7.CumulativeScore = 777;
            user1.DeliveryFrames.Add(playerFrame7);

            PlayerFrame playerFrame8 = new PlayerFrame();
            playerFrame8.FrameId = 8;
            playerFrame8.FirstDeliveryMark = "8";
            playerFrame8.SecondDeliveryMark = "88";
            playerFrame8.CumulativeScore = 888;
            user1.DeliveryFrames.Add(playerFrame8);

            PlayerFrame playerFrame9 = new PlayerFrame();
            playerFrame9.FrameId = 9;
            playerFrame9.FirstDeliveryMark = "9";
            playerFrame9.SecondDeliveryMark = "99";
            playerFrame9.CumulativeScore = 999;
            user1.DeliveryFrames.Add(playerFrame9);

            PlayerFrame playerFrame10 = new PlayerFrame();
            playerFrame10.FrameId = 10;
            playerFrame10.FirstDeliveryMark = "99";
            playerFrame10.SecondDeliveryMark = "99";
            playerFrame10.ThirdDeliveryMark = "88";
            playerFrame10.CumulativeScore = 999;
            user1.DeliveryFrames.Add(playerFrame10);

            fullGameInfo.GamePlayers.Add(user1);

            //UserGameInfo user2 = new UserGameInfo();
            //user2.FirstName = "FirstName2";
            //user2.LastName = "LastName2";
            //fullGameInfo.GamePlayers.Add(user2);

            return fullGameInfo;
        }
    }
}
