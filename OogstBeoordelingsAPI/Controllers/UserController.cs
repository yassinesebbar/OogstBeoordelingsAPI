using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OogstBeoordelingsAPI.Dtos;
using OogstBeoordelingsAPI.IServices;
using OogstBeoordelingsAPI.Models;
using System.Security.Claims;

namespace OogstBeoordelingsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        ITokenService _tokenService;
        IUserManagementService _userManagementService;


        public UserController(IUserManagementService userManagementService, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _userManagementService = userManagementService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDto credentials)
        {
            if (!_userManagementService.Login(credentials.UserName, credentials.Password))
            {
                return NotFound("User not found");
            }

            User currentUser = _userManagementService.GetUser(credentials.UserName, credentials.Password);
            
            var token = _tokenService
                .SetClaim(ClaimTypes.NameIdentifier, currentUser.Username)
                .SetClaim(ClaimTypes.PrimarySid, currentUser.Id.ToString())
                .SetClaim(ClaimTypes.Role, currentUser.UserRole.ToString())
                .GenerateToken();

            return Ok(token);
        }

       [Authorize]
       [HttpGet("GetAuthenticated")]
       public ActionResult<UserReadDto> GetMyAccount()
        {
            var Claims = (HttpContext.User.Identity as ClaimsIdentity).Claims;
            var userId = int.Parse(Claims.FirstOrDefault(c => c.Type == ClaimTypes.PrimarySid)?.Value);
            var username = Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            return Ok(new UserReadDto(_userManagementService.GetUser(userId, username)));
            //return Ok(Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value);
        }

        [AllowAnonymous]
        [HttpPost("CreateUser")]
        public ActionResult CreateUser([FromBody] CreateUserDto createUserDto)
        {
            _userManagementService.CreateUser(createUserDto);

            if (!_userManagementService.UserExist(createUserDto.Username, createUserDto.Password))
            {
                return Problem("Could not create user");
            }

            return Ok();
        }

        [HttpGet("GetUsers"), Authorize(Roles = "Administrator")]
        public ActionResult<User> GetUsers()
        {
            return Ok(_userManagementService.GetUsers());
        }
    }

}
