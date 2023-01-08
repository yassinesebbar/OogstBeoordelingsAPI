using OogstBeoordelingsAPI.Dto.AssessorDtos;
using OogstBeoordelingsAPI.HarvestDtos;
using OogstBeoordelingsAPI.Models;

namespace OogstBeoordelingsAPI.IServices
{
    public interface IHarvestService
    {

        // Methods for Harvester
        public string CreateHarvest(Harvest harvest);
        Task<Harvest> GetHarvestById(string Id);
        Task<Harvest> GetHarvestById(string harvestId, int growerId);
        Task<List<Harvest>> GetAllClosedByGrower(User grower);
        Task<List<Harvest>> GetAllNotClosedByGrower(User grower);
        Task<Boolean> LinkAssessorToHarvest(List<string> ListHarvestIds, User assessor);
        Task<Boolean> SubmitReview(Review NewReview, User assessor);
        List<OrderedHarvestListDto> OrderToHarvestListDto(List<Harvest> harvestList);
        Task<List<Harvest>> GetAllPending();
        Task<List<Harvest>> GetToBeReviewdByAssessor(User assessor);
        Task<List<Harvest>> GetClosedByAssessor(User assessor);
    }
}
