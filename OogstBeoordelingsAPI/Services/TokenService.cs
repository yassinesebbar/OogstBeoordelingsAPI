using Microsoft.IdentityModel.Tokens;
using OogstBeoordelingsAPI.IServices;
using OogstBeoordelingsAPI.Models;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OogstBeoordelingsAPI.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        private List<Claim> ClaimsList = new List<Claim>();


        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private object GenerateToken()
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            IEnumerable<Claim> claims = ClaimsList;

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddSeconds(10),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public object CreateToken(User user)
        {
            SetClaim(ClaimTypes.NameIdentifier, user.Username);
            SetClaim(ClaimTypes.PrimarySid, user.Id.ToString());
            SetClaim(ClaimTypes.Role, user.UserRole.ToString());

             return GenerateToken();
        }

        private void SetClaim(string type, string value)
        {
            if (type != string.Empty && value != string.Empty)
            {
                ClaimsList.Add(new Claim(type, value));
            }
        }
    }
}
