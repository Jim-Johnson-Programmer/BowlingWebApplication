using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BowlingWebApplication.Models;
using BowlingWebApplication.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace BowlingWebApplication.Services
{
    public class UserService : IUserService
    {
        public void CreateUser(ScoreCardViewModel viewModel, BowlingUserViewModel userViewModel)
        {
            viewModel.ScoreCardRows.Add(new ScoreCardRow(){FirstName = userViewModel.FirstName, 
                LastName = userViewModel.LastName, PlayerId = viewModel.ScoreCardRows.Count + 1
            });

            if (viewModel.CurrentFrameId == 0) viewModel.CurrentFrameId = 1;

        }

        public List<SelectListItem> GetUserSelectListItems(ScoreCardViewModel viewModel)
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (var scoreCardRow in viewModel.ScoreCardRows)
            {
                selectListItems.Add(new SelectListItem(){Text = scoreCardRow.FirstName + " " + scoreCardRow.LastName, Value = scoreCardRow.PlayerId.ToString()});
            }

            return selectListItems;
        }
    }

}
