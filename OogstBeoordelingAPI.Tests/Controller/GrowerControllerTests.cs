using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OogstBeoordelingsAPI.Controllers;
using OogstBeoordelingsAPI.Dto.HarvestDtos;
using OogstBeoordelingsAPI.HarvestDtos;
using OogstBeoordelingsAPI.IRepositories;
using OogstBeoordelingsAPI.IServices;
using OogstBeoordelingsAPI.Models;
using OogstBeoordelingsAPI.Repositories;
using OogstBeoordelingsAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OogstBeoordelingsAPI.Tests.Controller
{
    public class GrowerControllerTests
    {
        private readonly IUserManagementService _userManagementService;
        private readonly IHarvestService _harvestService;
        private readonly IImageService _imageService;

        public GrowerControllerTests()
        {
            _userManagementService = A.Fake<UserManagementService>();
            _harvestService = A.Fake<HarvestService>();
            _imageService = A.Fake<ImageService>();
        }


        [Fact]
        public void GrowerController_GetAllActiveHarvest_ReturnOk()
        {

            var controller = new GrowerController(_userManagementService, _harvestService, _imageService);
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            //Act
            var result = controller.GetAllActiveHarvest();
            var OkResult = result as Task<ActionResult<List<GetHarvestGrowerDto>>>;
            //Assert
            Assert.Equal(result, OkResult);
        }

    }
}
