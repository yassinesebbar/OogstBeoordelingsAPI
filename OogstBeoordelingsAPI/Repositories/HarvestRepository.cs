using MongoDB.Driver;
using OogstBeoordelingsAPI.IRepositories;
using OogstBeoordelingsAPI.Models;

namespace OogstBeoordelingsAPI.Repositories
{
    public class HarvestRepository : IHarvestRepository
    {
        private readonly IMongoCollection<Harvest> _harvestCollection;

        public HarvestRepository(IMongoCollection<Harvest> context)
        {
            _harvestCollection = context;
        }

        public async Task<Harvest>  GetById(string Id) => await _harvestCollection.Find(h => h.Id == Id).FirstOrDefaultAsync();
        public async Task Save(Harvest harvest) => await _harvestCollection.InsertOneAsync(harvest);
    }
}
