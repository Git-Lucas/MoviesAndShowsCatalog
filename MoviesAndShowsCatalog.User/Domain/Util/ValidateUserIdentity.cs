using System.IdentityModel.Tokens.Jwt;

namespace MoviesAndShowsCatalog.User.Domain.Util;

public class ValidateUserIdentity : IValidateUserIdentity
{
    public void ExecuteComparingWithToken(string bearerToken, int userId)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtToken = tokenHandler.ReadJwtToken(bearerToken);

        string userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "userId")!.Value;

        if(int.Parse(userIdClaim) != userId)
        {
            throw new Exception("Unauthorized.");
        }
    }
}
