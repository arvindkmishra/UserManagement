using Moq;
using UserManagement.Core.Handlers;
using UserManagement.Domain.Commands;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Repositories;
using Xunit;

namespace UserManagement.Test
{
    [TestClass]
    public class DeactivateUserCommandHandlerTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly DeactivateUserHandler _handler;

        public DeactivateUserCommandHandlerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _handler = new DeactivateUserHandler();
        }

        [Fact]
        public async Task Handle_Should_DeactivateUser()
        {
            // Arrange
            var user = new User("Arvind Mishra", "arvind@gmail.com");
            _userRepositoryMock.Setup(repo => repo.GetByIdAsync(user.Id)).ReturnsAsync(user);

            var command = new DeactivateUserCommand { Id = user.Id };

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _userRepositoryMock.Verify(repo => repo.UpdateAsync(It.Is<User>(u => u.Id == user.Id && !u.IsActive)), Times.Once);
        }
    }
}
