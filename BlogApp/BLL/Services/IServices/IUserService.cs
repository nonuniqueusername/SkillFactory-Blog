using Microsoft.AspNetCore.Identity;
using BlogApp.BLL.ViewModels.Users;
using BlogApp.DAL.Models;

namespace BlogApp.BLL.Services.IServices
{
    public interface IUserService
    {
        Task<IdentityResult> Register(UserRegisterViewModel model);

        Task<IdentityResult> CreateUser(UserCreateViewModel model);

        Task<SignInResult> Login(UserLoginViewModel model);

        Task<IdentityResult> EditAccount(UserEditViewModel model);

        Task<UserEditViewModel> EditAccount(Guid id);

        Task RemoveAccount(Guid id);

        Task<List<User>> GetAccounts();

        Task<User> GetAccount(Guid id);

        Task LogoutAccount();
    }
}
