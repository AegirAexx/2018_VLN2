using BookCave.Models.ViewModels;

namespace BookCave.Services
{
    public interface IUserServices
    {
         void ProcessUser(RegisterViewModel model);
         void ProcessLogin(LoginViewModel user);
    }
    
}