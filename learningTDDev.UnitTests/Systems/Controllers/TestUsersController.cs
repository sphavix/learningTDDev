using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using learningTDDev.API.Controllers;
using learningTDDev.API.Models;
using learningTDDev.API.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace learningTDDev.UnitTests.Systems.Controllers
{
    public  class TestUsersController
    {
        [Fact]
        public async Task  Get_OnSuccess()
        {
            //Arrange
            var mockUsersService = new Mock<IUsersService>();

            mockUsersService.Setup(x => x.GetAllUsers())
                .ReturnsAsync(new List<User>());
            var userTest = new UsersController(mockUsersService.Object);

            //Act
            var result = (OkObjectResult)await userTest.Get();

            //Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Get_OnSuccessInvokesUserServiceExactlyOnce()
        {
            //Arrange 
            var mockUserService = new Mock<IUsersService>();

            mockUserService.Setup(x => x.GetAllUsers())
                .ReturnsAsync(new List<User>());

            var userTest = new UsersController(mockUserService.Object);

            //Act
            var result = await userTest.Get();

            //Assert
            mockUserService.Verify(service => service.GetAllUsers(), Times.Once());
        }

        [Fact]
        public async Task Get_OnSuccess_ReturnsListOfUsers()
        {
            //Arrange 
            var mockUserService = new Mock<IUsersService>();

            mockUserService.Setup(service => service.GetAllUsers())
                .ReturnsAsync(new List<User>());

            var userTest = new UsersController(mockUserService.Object);

            //Act
            var result = await userTest.Get();

            //Assert
            mockUserService.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<List<User>>();


        }
    }
}
