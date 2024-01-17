using NTierApplication.Service.ViewModels;

namespace NTierApplication.Service;

public interface IUserService
{
    public bool  Register(UserRegisterModel userView);
    public (string access_token, string refresh_token,string token_type,long expires) Login(UserLoginView userLoginView);

    public ICollection<UserViewModel> GetUsers();
}
