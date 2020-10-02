using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BowlingWebApplication.Models.ViewModel
{
    public class BowlingGameViewModel
    {
        private UserGameInfo _GameInformation;

        public BowlingGameViewModel()
        {
            _GameInformation = new UserGameInfo();
        }
    }
}
