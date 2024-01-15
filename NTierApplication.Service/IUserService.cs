using NTierApplication.Service.ViewModels;

namespace NTierApplication.Service;

public interface IUserService
{
    public (bool Result, string Token) Register(UserRegisterModel userView);
    public (bool Result, string Token) Login(UserLoginView userLoginView);

    public ICollection<UserViewModel> GetUsers();
}
