using OogstBeoordelingsAPI.HarvestDtos;
using OogstBeoordelingsAPI.IRepositories;
using OogstBeoordelingsAPI.IServices;
using OogstBeoordelingsAPI.Models;

namespace OogstBeoordelingsAPI.Services
{
    public class HarvestService : IHarvestService
    {

    private readonly IHarvestRepository _harvestRepository;

        public HarvestService(IHarvestRepository harvestRepository)
        {
            _harvestRepository = harvestRepository;
        }

        public string CreateHarvest(CreateHarvestDto harvestDto, User grower)
        {

            Harvest harvest = new Harvest() {
                GrowerId = grower.Id, 
                GrowerName = grower.FirstName, 
                HarvestDate = harvestDto.HarvestDate, 
                Type = harvestDto.Type, 
                SubType = harvestDto.SubType, 
                WeightKG = harvestDto.WeightKG};

            _harvestRepository.Save(harvest);

            return harvest.Id;
        }

        public async Task<Harvest> GetHarvestById(string Id)
        {
            return await _harvestRepository.GetById(Id);;
        }
    }
}
