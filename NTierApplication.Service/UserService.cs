using Microsoft.Extensions.Caching.Memory;
using NTierApplication.DataAccess.Models;
using NTierApplication.Errors;
using NTierApplication.Repository;
using NTierApplication.Service.ViewModels;

namespace NTierApplication.Service;

public class UserService : IUserService
{
    private IUserRepository _repository;
    private IMemoryCache _memoryCache;

    public UserService(IUserRepository userRepository,IMemoryCache memoryCache) 
    {
        _repository = userRepository;
        _memoryCache = memoryCache;
    }

    public (bool Result, string Token) Login(UserLoginView userLoginView)
    {
        throw new NotImplementedException();
    }

    public (bool Result, string Token) Register(UserViewModel userView)
    {
        if (userView == null)
        {
            throw new ArgumentNullException(nameof(userView));
        }
        var result = _repository.GetAll().
            Where(x => x.UserEmail == userView.UserEmail).
            FirstOrDefault();
        if (result != null)
        {
            throw new ParameterInvalidException(nameof(userView));
        }
        return (true, "");

    }

  
}
