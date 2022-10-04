using Xunit;
using CloudCustomers.API.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using CloudCustomers.API.Services;
using CloudCustomers.API.Models;
using System.Collections.Generic;
using CloudCustomers.UnitTests.Fixtures;

namespace CloudCustomers.UnitTests.Systems.Controllers;
/****NOTES***
 sut stands for system under test

FluentAssertions alllows for Methods shown below
like: Should() and Be()

An OkObjectResult returns a staus code 200 if everything succeedes 
 */



public class TestUsersController
{
    [Fact]
    public async Task GetOnSuccess_ReturnsStatusCode200()
    {

        //Arrage
        var mockUserService = new Mock<IUserService>();
        mockUserService
            .Setup(service => service.GetAllUsers())
             .ReturnsAsync(UserFixture.GetTestUsers());

        var sut = new UsersController(mockUserService.Object);

        //Act
        var result = (OkObjectResult)await sut.Get();

        //ASsert
        result.StatusCode.Should().Be(200);

    }

    [Fact]
    public async Task GetOnSuccess_InvokesUserService_ExactalyOnce()
    {
        //Arrange
        var mockUserService = new Mock<IUserService>();
        mockUserService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());

        var sut = new UsersController(mockUserService.Object);

        //Act
        var result = await sut.Get();

        //Assert
        mockUserService.Verify
            (service => service.GetAllUsers(),
            Times.Once());

    }

    [Fact]
    public async Task GetOnSucess_ReturnsListOfUSers()
    {
        //Arrange
        var mockUserService = new Mock<IUserService>();

        mockUserService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(UserFixture.GetTestUsers());


        var sut = new UsersController(mockUserService.Object);
        //Act
        var result = await sut.Get();

        //Assert
        result.Should().BeOfType<OkObjectResult>();
        var objectResult = (OkObjectResult)result;
        objectResult.Value.Should().BeOfType<List<User>>();
    }

    [Fact]
    public async Task GetOnNoUsersFound_Return404()
    {
        //Arrange
        var mockUserService = new Mock<IUserService>();

        mockUserService
            .Setup(service => service.GetAllUsers())
            .ReturnsAsync(new List<User>());

        var sut = new UsersController(mockUserService.Object);
        //Act
        var result = await sut.Get();

        //Assert
        result.Should().BeOfType<NotFoundResult>();
        var objectResult = (NotFoundResult)result;
        objectResult.StatusCode.Should().Be(404);

    }



}