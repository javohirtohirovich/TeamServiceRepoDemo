using NTierApplication.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApplication.Service;

public interface IUserService
{
    public (bool Result, string Token) Register(UserViewModel userView);
    public (bool Result, string Token) Login(UserLoginView userLoginView);
}
