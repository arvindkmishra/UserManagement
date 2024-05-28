using UserManagement.Infrastructure.Models;

namespace UserManagement.Infrastructure.Interfaces
{
    public interface IUserService
    {
        Task CreateUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeactivateUserAsync(User user);
    }
}
