using OogstBeoordelingsAPI.HarvestDtos;
using OogstBeoordelingsAPI.Models;

namespace OogstBeoordelingsAPI.IServices
{
    public interface IHarvestService
    {

        // Methods for Harvester
        public string CreateHarvest(CreateHarvestDto harvest, User grower);
        Task<Harvest> GetHarvestById(string Id);

        /*        List<Harvest> GetAllHarvestByHarvester(User user);
                List<Harvest> GetAllClosedHarvestByHarvester(User user);
                Harvest GetHarvestById(int Id);

                //Methods for Reviewer
                List<Harvest> GetAllHarvestByReviewer(User user);
                List<Harvest> GetAllClosedHarvestByReviewer(User user);
                Boolean AddReviewerToHarvest(int harvestId, User user);
                Boolean AddReviewToHarvest(int harvestId, Review review);

                // general methods
                List<Harvest> GetAllHarvestByStatus(HarvestStatus status);
                Boolean DeleteHarvest(Harvest harvest);
                Boolean UpdateHarvest(Harvest harvest);
                Boolean UpdateReviewFromHarvest(Review review);
                Boolean RemoveReviewFromHarvest(Harvest harvest);
                Boolean RemoveReviewerFromHarvest(Harvest harvest, User user);*/
    }
}
