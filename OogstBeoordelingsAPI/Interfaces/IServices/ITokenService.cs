using OogstBeoordelingsAPI.Models;

namespace OogstBeoordelingsAPI.IServices
{
    public interface ITokenService
    {
        object CreateToken(User user);
    }
}
