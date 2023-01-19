using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OogstBeoordelingsAPI.IServices;
using OogstBeoordelingsAPI.Models;

namespace OogstBeoordelingsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUserManagementService _userManagementService;
        private readonly IHarvestService _harvestService;
        private readonly IImageService _imageService;

        public AdminController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        [HttpGet("RemoveAllUsers"), Authorize(Roles = "Administrator")]
        public IActionResult RemoveAllUsers()
        {
            User CurrentUser = _userManagementService.GetUser(HttpContext.User);

            if (CurrentUser != null)
            {
                _userManagementService.DeleteAllUsers(CurrentUser);
            }

            return Ok();
        }

        }
    }
