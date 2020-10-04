using System.Collections.Generic;
using BowlingWebApplication.Models.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BowlingWebApplication.Services
{
    public interface IUserService
    {
        void CreateUser(ScoreCardViewModel scoreCardViewModel, BowlingUserViewModel userViewModel);
        List<SelectListItem> GetUserSelectListItems(ScoreCardViewModel viewModel);
    }
}