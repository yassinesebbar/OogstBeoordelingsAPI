using OogstBeoordelingsAPI.Models;

namespace OogstBeoordelingsAPI.IServices
{
    public interface IHarvestService
    {
        Boolean CreateHarvest(Harvest harvest);
        Boolean DeleteHarvest(Harvest harvest);
        Boolean UpdateHarvest(Harvest harvest);

        Harvest GetHarvestById(int Id);

        List<Harvest> GetAll();
        List<Harvest> GetHarvestByStatus(HarvestStatus harvestStatus);
        List<Harvest> GetHarvestByHarvester(User user);
        List<Harvest> GetHarvestByReview(User user);

        Boolean AddReviewToHarvest(Harvest harvest, Review review);
        Boolean UpdateReviewFromHarvest(Review review);
        Boolean RemoveReviewFromHarvest(Harvest harvest);

        Boolean AddReviewerToHarvest(Harvest harvest, User user);
        Boolean RemoveReviewerFromHarvest(Harvest harvest, User user);
    }
}
