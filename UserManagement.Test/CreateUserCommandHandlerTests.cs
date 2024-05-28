using FluentAssertions;
using Moq;
using UserManagement.Core.Handlers;
using UserManagement.Domain.Commands;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Repositories;
using Xunit;

namespace UserManagement.Test
{
    [TestClass]
    public class CreateUserCommandHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly CreateUserHandler  _handler;

        public CreateUserCommandHandlerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _handler = new CreateUserHandler(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_Should_CreateUser_And_ReturnUserId()
        {
            // Arrange
            var command = new CreateUserCommand { Name = "Arvind Mishra", Email = "arvind@gmail.com" };

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNullOrEmpty();
            _userRepositoryMock.Verify(repo => repo.AddAsync(It.Is<User>(u => u.Name == command.Name && u.Email == command.Email)), Times.Once);
        }
    }
}
