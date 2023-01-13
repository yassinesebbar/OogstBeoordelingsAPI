using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OogstBeoordelingsAPI.Dto.AssessorDtos;
using OogstBeoordelingsAPI.IServices;
using OogstBeoordelingsAPI.Models;

namespace OogstBeoordelingsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssessorController : ControllerBase
    {
        private readonly IUserManagementService _userManagementService;
        private readonly IHarvestService _harvestService;
        private readonly IImageService _imageService;

        public AssessorController(IUserManagementService userManagementService, IHarvestService harvestService, IImageService imageService)
        {
            _userManagementService = userManagementService;
            _harvestService = harvestService;
            _imageService = imageService;
        }

        [HttpPost("LinkToHarvest"), Authorize(Roles = "Assessor")]
        public async Task<ActionResult> LinkHarvestToAssessor(List<string> ListHarvestIds) 
        {
            User currentUser = _userManagementService.GetUser(HttpContext.User);
            Boolean HarvestLinkedSuccesfull = await _harvestService.LinkAssessorToHarvest(ListHarvestIds, currentUser);
            return Ok();
        }

        [HttpPost("SubmitReview"), Authorize(Roles = "Assessor")]
        public async Task<ActionResult> SubmitReview([FromForm] ReviewDto reviewDto)
        {
            User currentUser = _userManagementService.GetUser(HttpContext.User);
            Boolean reviewSubmitted = await _harvestService.SubmitReview(reviewDto.MapToReview(), currentUser);

            return Ok(reviewSubmitted);
        }

        [HttpGet("GetPendingHarvest"), Authorize(Roles = "Assessor")]
        public async Task<ActionResult<List<OrderedHarvestListDto>>> GetPendingHarvests()
        {
            List<Harvest> PendingHarvest = await _harvestService.GetAllPending();
            return Ok(_harvestService.OrderToHarvestListDto(PendingHarvest));
        }

        [HttpGet("GetToBeReviewedHarvest"), Authorize(Roles = "Assessor")]
        public async Task<ActionResult> GetToBeReviewdHarvests()
        {
            User currentUser = _userManagementService.GetUser(HttpContext.User);
            List<Harvest> ClosedReviews = await _harvestService.GetToBeReviewdByAssessor(currentUser);
            return Ok(_harvestService.OrderToHarvestListDto(ClosedReviews));
        }

        [HttpGet("GetClosedHarvest"), Authorize(Roles = "Assessor")]
        public async Task<ActionResult> GetClosedHarvests()
        {
            User currentUser = _userManagementService.GetUser(HttpContext.User);
            List<Harvest> ClosedReviews = await _harvestService.GetClosedByAssessor(currentUser);
            return Ok(_harvestService.OrderToHarvestListDto(ClosedReviews));
        }

    }
}
