using System;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;
using PostN.WebApi.Controllers;
using PostN.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PostN.DataAccess;
using PostN.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Entity = PostN.DataAccess.Entities;
using System.Collections.Generic;
using User = PostN.Domain.User;
namespace Tests
{
    public class UserControllerTest
    {
        private readonly DbContextOptions<CMKWDTP2Context> options;
        public UserControllerTest()
        {
            options = new DbContextOptionsBuilder<CMKWDTP2Context>().UseSqlite("Filename=Test0.db").Options;
        }
        [Fact]
        public async void GetAllUsersAsync_ShouldReturnAllUsers()
        {
            var logger = new Mock<ILogger<UserController>>();
            var mockUserRepo = new Mock<IUserRepo>();
            using (var testcontext = new CMKWDTP2Context(options))
            {
                IUserRepo _repo = new UserRepo(testcontext);
                var testUser = _repo.GetUsers();
                mockUserRepo.Setup(repo => repo.GetUsers()).Returns(testUser);
                var controller = new UserController((ILogger<UserController>)logger.Object, (IUserRepo)mockUserRepo.Object);
                var result = await controller.GetUsers();
                var jsonResult = (ObjectResult)result.Result;
                Assert.Equal(testUser.Result, (IEnumerable<User>)jsonResult.Value);
            }
        }
    }
}