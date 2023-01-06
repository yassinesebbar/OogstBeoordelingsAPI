using Microsoft.IdentityModel.Tokens;
using OogstBeoordelingsAPI.Models;
using OogstBeoordelingsAPI.Services;

namespace OogstBeoordelingsAPI.IServices
{
    public interface ITokenService
    {
        object CreateToken(User user);
    }
}
