using Moq;
using UserManagement.Core.Handlers;
using UserManagement.Domain.Commands;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Repositories;
using Xunit;

namespace UserManagement.Test
{
    [TestClass]
    public class UpdateUserCommandHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly UpdateUserHandler _handler;

        public UpdateUserCommandHandlerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _handler = new UpdateUserHandler();
        }

        [Fact]
        public async Task Handle_Should_UpdateUser()
        {
            // Arrange
            var user = new User("Arvind Mishra", "arvind@gmail.com");
            _userRepositoryMock.Setup(repo => repo.GetByIdAsync(user.Id)).ReturnsAsync(user);

            var command = new UpdateUserCommand { Id = user.Id, Name = "Arvind Mishra", Email = "arvind@gmail.com" };

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _userRepositoryMock.Verify(repo => repo.UpdateAsync(It.Is<User>(u => u.Id == user.Id && u.Name == command.Name && u.Email == command.Email)), Times.Once);
        }
    }
}
