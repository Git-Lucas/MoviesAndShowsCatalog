using System.IdentityModel.Tokens.Jwt;

namespace MoviesAndShowsCatalog.User.Application.Authentication;

public static class BearerTokenUtils
{
    public static void ValidateUserIdentity(string bearerToken, int userId)
    {
        int userIdClaim = GetUserIdByToken(bearerToken);

        if (userIdClaim != userId)
        {
            throw new UnauthorizedAccessException("Unauthorized.");
        }
    }

    public static int GetUserIdByToken(string bearerToken)
    {
        JwtSecurityTokenHandler tokenHandler = new();
        JwtSecurityToken jwtToken = tokenHandler.ReadJwtToken(bearerToken);

        string userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "userId")!.Value;
        int userId = int.Parse(userIdClaim);

        return userId;
    }
}
