using Microsoft.Extensions.Configuration;
using NTierApplication.DataAccess.Models;
using NTierApplication.Errors;
using NTierApplication.Repository;
using NTierApplication.Service.Helpers;
using NTierApplication.Service.Helpers.Security;
using NTierApplication.Service.ViewModels;
using System.Data;

namespace NTierApplication.Service;

public class UserService : IUserService
{
    private IUserRepository _repository;
    private ITokenService _tokenSerivce;
    private readonly IConfiguration _config;

    public UserService(IUserRepository userRepository, ITokenService tokenService,IConfiguration configuration)
    {
        _repository = userRepository;
        _tokenSerivce = tokenService;
        _config = configuration.GetSection("Jwt");
    }

    public ICollection<UserViewModel> GetUsers()
    {
        return _repository.GetAll().Select(x => new UserViewModel
        {
           UserId=x.UserId,
           UserName=x.UserName,
           UserLastName=x.UserLastName,
           UserEmail=x.UserEmail,
           CreatedAt=x.CreatedAt,
           UpdatedAt=x.UpdatedAt,
        }).ToList();
    }

    public (string access_token, string refresh_token, string token_type, long expires) Login(UserLoginView userLoginView)
    {
        if (userLoginView == null)
        {
            throw new ArgumentNullException(nameof(userLoginView));
        }
        var userDatabase = _repository.GetAll().
          Where(x => x.UserEmail == userLoginView.UserName).
          FirstOrDefault();
        if (userDatabase == null)
        {
            throw new EntryNotFoundException(nameof(userDatabase));
        }

        var hasherResult = PasswordHasher.Verify(userLoginView.Password, userDatabase.Password, userDatabase.Salt);
        if (hasherResult == true)
        {
            string token = _tokenSerivce.GenerateToken(userDatabase);
            long expires_time = long.Parse(_config["Lifetime"])*3600;
            return (access_token: token,refresh_token:null,token_type:"Bearer",expires:expires_time);
        }
        else
        {
            throw new ParameterInvalidException(nameof(userLoginView));
        }

    }

    public bool  Register(UserRegisterModel userView)
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
            throw new DuplicateNameException(nameof(userView));
        }

        var passwordHash = PasswordHasher.Hasher(userView.Password);
        User user = new User
        {
            UserName = userView.UserName,
            UserLastName = userView.UserLastName,
            UserEmail = userView.UserEmail,
            Password = passwordHash.Hash,
            Salt = passwordHash.Salt,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime(),
        };

        _repository.Insert(user);
        int result = _repository.SaveChanges();

        if (result > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
