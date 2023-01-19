using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OogstBeoordelingsAPI.Dto.HarvestDtos;
using OogstBeoordelingsAPI.HarvestDtos;
using OogstBeoordelingsAPI.IServices;
using OogstBeoordelingsAPI.Models;


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

            string harvestId = _harvestService.CreateHarvest(createHarvestDto.MapToHarvest(CurrentUser));

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


        [HttpGet("GetHarvest/{id}"), Authorize(Roles = "Grower")]
        public async Task<ActionResult<GetHarvestGrowerDto>> GetHarvest(string id)
        {
            User CurrentUser = _userManagementService.GetUser(HttpContext.User);
            Harvest harvest = await _harvestService.GetHarvestById(id, CurrentUser.Id);

            if (harvest is null)
            {
                return NotFound("Harvest not found");
            }

            return Ok(new GetHarvestGrowerDto(harvest, await _imageService.GetFile(harvest.Id)));
        }

        [HttpGet("GetAllClosedHarvest"), Authorize(Roles = "Grower")]
        public async Task<ActionResult<List<GetHarvestGrowerDto>>> GetAllClosedHarvest()
        {
            User CurrentUser = _userManagementService.GetUser(HttpContext.User);
            List<Harvest> harvestList = await _harvestService.GetAllClosedByGrower(CurrentUser);
            List<GetHarvestGrowerDto> harvestDtoList = new List<GetHarvestGrowerDto>();

            foreach (Harvest harvest in harvestList)
            {
                harvestDtoList.Add(new GetHarvestGrowerDto(harvest, null));
            }

            return Ok(harvestDtoList);
        }

        [HttpGet("GetAllActiveHarvest"), Authorize(Roles = "Grower")]
        public async Task<ActionResult<List<GetHarvestGrowerDto>>> GetAllActiveHarvest()
        {
            User CurrentUser = _userManagementService.GetUser(HttpContext.User);
            List<Harvest> harvestList = await _harvestService.GetAllNotClosedByGrower(CurrentUser);
            List<GetHarvestGrowerDto> harvestDtoList = new List<GetHarvestGrowerDto>();

            foreach (Harvest harvest in harvestList)
            {
                harvestDtoList.Add(new GetHarvestGrowerDto(harvest, null));
            }

            return Ok(harvestDtoList);
        }


    }
}
