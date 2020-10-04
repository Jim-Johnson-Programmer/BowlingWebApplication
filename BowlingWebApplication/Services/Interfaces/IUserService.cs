using BowlingWebApplication.Models.ViewModel;

namespace BowlingWebApplication.Services
{
    public interface IUserService
    {
        void CreateUser(FullGameModel fullGameModel, BowlingUserViewModel userViewModel);
    }
}