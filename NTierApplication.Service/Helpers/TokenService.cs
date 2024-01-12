using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NTierApplication.DataAccess.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NTierApplication.Service.Helpers;
public class TokenService : ITokenService
{
    private IConfiguration _config;

    public TokenService(IConfiguration configuration)
    {
        _config = configuration.GetSection("Jwt");
    }
    public string GenerateToken(User user)
    {
        var IdentityClaims = new Claim[]
        {
            new Claim("Id",user.UserId.ToString()),
            new Claim("Name",user.UserName.ToString()),
            new Claim("Surname",user.UserLastName.ToString()),
            new Claim(ClaimTypes.Email,user.UserEmail.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecurityKey"]!));
        var keyCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        int expiresHours = int.Parse(_config["Lifetime"]);
        var token = new JwtSecurityToken(
            issuer: _config["Issuer"],
            audience: _config["Audience"],
            claims:IdentityClaims,
            expires:TimeHelper.GetDateTime().AddHours(expiresHours),
            signingCredentials:keyCredentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
