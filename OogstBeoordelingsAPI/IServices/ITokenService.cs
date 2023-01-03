using Microsoft.IdentityModel.Tokens;
using OogstBeoordelingsAPI.Services;

namespace OogstBeoordelingsAPI.IServices
{
    public interface ITokenService
    {
        object GenerateToken();
        TokenService SetClaim(string type, string value);
    }
}
