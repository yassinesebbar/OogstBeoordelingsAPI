using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OogstBeoordelingsAPI.Dto.HarvestDtos;
using OogstBeoordelingsAPI.HarvestDtos;
using OogstBeoordelingsAPI.IServices;
using OogstBeoordelingsAPI.Models;
using System.Security.Claims;

namespace OogstBeoordelingsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GrowerController : ControllerBase
    {
        private readonly IUserManagementService _userManagementService;
        private readonly IHarvestService _harvestService;
        private readonly IImageService _imageService;

        public GrowerController(IUserManagementService userManagementService, IHarvestService harvestService, IImageService imageService)
        {
            _userManagementService = userManagementService;
            _harvestService = harvestService;
            _imageService = imageService;
        }

        [HttpPost("CreateHarvest"), Authorize(Roles = "Grower")]
        public IActionResult CreateHarvest([FromForm] CreateHarvestDto createHarvestDto)
        {
            User CurrentUser = _userManagementService.GetUser(HttpContext.User);

            if (CurrentUser == null)
            {
                return Problem("User not found!");
            }

            string harvestId = _harvestService.CreateHarvest(createHarvestDto, CurrentUser);

            if (harvestId == string.Empty)
            {
                return Problem("Harvest could not be saved!");
            }

            if(!_imageService.StoreImage(createHarvestDto.File, harvestId))
            {
                return Problem("Harvest is created but image could not be saved");
            }

            return Ok();
        }


        [HttpPost("GetHarvest/{id}"), Authorize(Roles = "Grower")]
        public async Task<ActionResult<Harvest>> GetHarvest(string id)
        {
            Harvest Harvest = await _harvestService.GetHarvestById(id);

            if (Harvest is null)
            {
                return NotFound("Harvest not found");
            }

            return Ok(Harvest);
        }


    }
}
