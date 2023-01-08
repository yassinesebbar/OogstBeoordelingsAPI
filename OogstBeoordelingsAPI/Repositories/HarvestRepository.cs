using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Harvest>> GetAllByGrower(int growerid, HarvestStatus status) => await _harvestCollection.Find(h => h.GrowerId == growerid && h.Status == status).ToListAsync();

        public async Task<Harvest> GetById(string Id) => await _harvestCollection.Find(h => h.Id == Id).FirstOrDefaultAsync();

        public async Task<Harvest> GetById(string harvestId, int growerId) => await _harvestCollection.Find(h => h.Id == harvestId && h.GrowerId == growerId).FirstOrDefaultAsync();

        public async Task Save(Harvest harvest) => await _harvestCollection.InsertOneAsync(harvest);
       
        public Harvest? GetLastInsertedCurrentYearByGrower(int growerId) =>  _harvestCollection.Find(h => h.GrowerId == growerId && h.YearCreated == DateTime.Now.Year).SortByDescending(e => e.CreatedAt).FirstOrDefault();

        public async Task UpdateOne(Harvest harvest) => await _harvestCollection.ReplaceOneAsync(h => h.Id == harvest.Id, harvest);

        public async Task<Harvest> GetByAssessor(string harvestId, int assessorId) => await _harvestCollection.Find(h => h.ReviewerId == assessorId && h.Id == harvestId).FirstOrDefaultAsync();

        public async Task<List<Harvest>> GetAllByAssessor(int assessorId, HarvestStatus status) => await _harvestCollection.Find(h => h.ReviewerId == assessorId && h.Status == status).ToListAsync();

        public async Task<List<Harvest>> GetAllHarvestByStatus(HarvestStatus status) => await _harvestCollection.Find(h =>  h.Status == status).ToListAsync();


    }
}
