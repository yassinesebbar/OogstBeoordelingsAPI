using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OogstBeoordelingsAPI.Data;
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
        private readonly ITokenService _tokenService;
        private readonly IUserManagementService _userManagementService;


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
          
            return Ok(_tokenService.CreateToken(_userManagementService.GetUser(credentials.UserName, credentials.Password)));
        }

      /* [Authorize]
       [HttpGet("GetAuthenticated")]
       public ActionResult<ReadUserDto> GetMyAccount()
        {
            return Ok(new ReadUserDto(_userManagementService.GetUser(HttpContext.User)));
        }*/

        [AllowAnonymous]
        [HttpPost("CreateAccount")]
        public ActionResult CreateUser([FromBody] CreateUserDto createUserDto)
        {
            _userManagementService.CreateUser(createUserDto);

            if (!_userManagementService.UserExist(createUserDto.Username, createUserDto.Password))
            {
                return Problem("Could not create user");
            }

            return Ok();
        }

        /*[HttpGet("GetUsers"), Authorize(Roles = "Administrator")]
        public ActionResult<User> GetUsers()
        {
            return Ok(_userManagementService.GetUsers());
        }*/
    }

}
