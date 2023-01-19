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
        public IActionResult Login([FromForm] LoginDto credentials)
        {
            if (!_userManagementService.Login(credentials.UserName, credentials.Password))
            {
                return NotFound("User not found");
            }
          
            return Ok(_tokenService.CreateToken(_userManagementService.GetUser(credentials.UserName, credentials.Password)));
        }

        [AllowAnonymous]
        [HttpPost("CreateAccount")]
        public ActionResult CreateUser([FromForm] CreateUserDto createUserDto)
        {
            if (_userManagementService.UserExist(createUserDto.Username))
            {
                return ValidationProblem("Username already exist");
            }
            _userManagementService.CreateUser(createUserDto.MapToUser());

            if (_userManagementService.UserExist(createUserDto.Username, createUserDto.Password) == false)
            {
                return Problem("Could not create user");
            }

            return Ok();
        }
    }

}
