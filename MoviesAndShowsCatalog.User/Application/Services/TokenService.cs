using Microsoft.IdentityModel.Tokens;
using MoviesAndShowsCatalog.User.Domain.Util;
using MoviesAndShowsCatalog.User.Domain.Util.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MoviesAndShowsCatalog.User.Application.Services;

public class TokenService(ISettings settings) : ITokenService
{
    public string GenerateToken(Domain.Users.Entities.User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(settings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new("userId", user.Id.ToString()),
                new(ClaimTypes.Name, user.Username.ToString()),
                new(ClaimTypes.Role, user.Role.ToString()),
            }),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
