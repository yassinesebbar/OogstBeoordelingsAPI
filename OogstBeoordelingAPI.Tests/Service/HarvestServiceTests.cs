using FakeItEasy;
using OogstBeoordelingsAPI.HarvestDtos;
using OogstBeoordelingsAPI.IRepositories;
using OogstBeoordelingsAPI.Models;
using OogstBeoordelingsAPI.Repositories;
using OogstBeoordelingsAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OogstBeoordelingsAPI.Tests.Service
{
    public class HarvestServiceTests
    {
        private readonly IHarvestRepository _harvestRepository;

        public HarvestServiceTests()
        {
            _harvestRepository = A.Fake<HarvestRepository>();
        }

        [Fact]
        public void HarvestService_CreateHarvest_ReturnID()
        {
            CreateHarvestDto harvestDto = A.Fake<CreateHarvestDto>();

            harvestDto.HarvestDate = DateTime.Now;
            harvestDto.WeightKG = 120;
            harvestDto.SubType = "Aardappelen";
            harvestDto.Type = HarvestType.Vegetable;
            Harvest harvest = harvestDto.MapToHarvest(A.Fake<User>());
            var service = new HarvestService(_harvestRepository);
            var result = service.CreateHarvest(harvest);

            Assert.NotNull(result);
        }
    }
}
