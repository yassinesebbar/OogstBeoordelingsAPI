using OogstBeoordelingsAPI.Models;

namespace OogstBeoordelingsAPI.IRepositories
{
    public interface IHarvestRepository
    {
        // Methods for Harvester
        Task Save(Harvest harvest);
        Task<Harvest> GetById(string Id);

        /*   List<Harvest> GetAllByUser(User user, HarvestStatus status);
           List<Harvest> GetAllByUser(User user);
           Boolean Update(Harvest harvest);

           // General method
           Harvest GetById(int Id);
           List<Harvest> GetAllByStatus(HarvestStatus status);
           Boolean Delete(Harvest harvest);*/
    }
}
