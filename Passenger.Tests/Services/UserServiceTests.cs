using System;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.Services;
using Xunit;


namespace Passenger.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task register_async_should_invoke_add_on_repository()
        {
           var userRepositoryMock = new Mock<IUserRepository>();
           var encrypter = new Encrypter();
           var mapperMock = new Mock<IMapper>();
           
           var userService = new UserService(userRepositoryMock.Object, encrypter, mapperMock.Object);
           await userService.RegisterAsync(Guid.NewGuid(), "user@mail.com", "username", "password", "user");

           userRepositoryMock.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
        }
    }
}