using NTierApplication.DataAccess.Models;
using NTierApplication.Errors;
using NTierApplication.Repository;
using NTierApplication.Service.Helpers;
using NTierApplication.Service.Helpers.Security;
using NTierApplication.Service.ViewModels;

namespace NTierApplication.Service;

public class UserService : IUserService
{
    private IUserRepository _repository;
    private ITokenService _tokenSerivce;

    public UserService(IUserRepository userRepository, ITokenService tokenService)
    {
        _repository = userRepository;
        _tokenSerivce = tokenService;
    }

    public (bool Result, string Token) Login(UserLoginView userLoginView)
    {
        if (userLoginView == null)
        {
            throw new ArgumentNullException(nameof(userLoginView));
        }
        var userDatabase = _repository.GetAll().
          Where(x => x.UserEmail == userLoginView.UserEmail).
          FirstOrDefault();
        if (userDatabase == null)
        {
            throw new EntryNotFoundException(nameof(userDatabase));
        }

        var hasherResult = PasswordHasher.Verify(userLoginView.Password, userDatabase.Password, userDatabase.Salt);
        if (hasherResult == true)
        {
            string token = _tokenSerivce.GenerateToken(userDatabase);
            return (Result: true, Token: token);
        }
        else
        {
            throw new ParameterInvalidException(nameof(userLoginView));
        }

    }

    public (bool Result, string Token) Register(UserViewModel userView)
    {
        if (userView == null)
        {
            throw new ArgumentNullException(nameof(userView));
        }
        var userDatabase = _repository.GetAll().
            Where(x => x.UserEmail == userView.UserEmail).
            FirstOrDefault();
        if (userDatabase != null)
        {
            throw new ParameterInvalidException(nameof(userView));
        }

        var passwordHash = PasswordHasher.Hasher(userView.Password);
        User user = new User
        {
            UserName = userView.UserName,
            UserLastName = userView.UserLastName,
            UserEmail = userView.UserEmail,
            Password = passwordHash.Hash,
            Salt = passwordHash.Salt,
            CreatedAt = userView.CreatedAt,
            UpdatedAt = userView.UpdatedAt,
        };

        _repository.Insert(user);
        int result = _repository.SaveChanges();

        if (result > 0)
        {
            string token = _tokenSerivce.GenerateToken(user);
            return (Result: true, Token: token);
        }
        else
        {
            return (Result: false, Token: "");
        }
    }


}
