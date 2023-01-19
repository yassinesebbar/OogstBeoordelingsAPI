using OogstBeoordelingsAPI.Models;

namespace OogstBeoordelingsAPI.IRepositories
{
    public interface IHarvestRepository
    {
        // Methods for Harvester
        Task Save(Harvest harvest);
        Task<Harvest> GetById(string Id);
        Task<Harvest> GetById(string harvestId, int harvesterId);
        Task<List<Harvest>> GetAllByGrower(int growerid, HarvestStatus status);
        Harvest GetLastInsertedCurrentYearByGrower(int growerId);
        Task UpdateOne(Harvest harvest);
        Task<Harvest> GetByAssessor(string harvestId, int assessorId);
        Task<List<Harvest>> GetAllByAssessor(int assessorId, HarvestStatus status);
        Task<List<Harvest>> GetAllHarvestByStatus(HarvestStatus status);
    }
}
