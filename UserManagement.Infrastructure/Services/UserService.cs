using MongoDB.Driver;
using UserManagement.Infrastructure.Interfaces;
using UserManagement.Infrastructure.Models;

namespace UserManagement.Infrastructure.Services
{
    internal class UserService : IUserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("UserDb");
            _users = database.GetCollection<User>("Users");
        }

        public async Task CreateUserAsync(User user)
        {
            await _users.InsertOneAsync(user);
        }

        public async Task UpdateUserAsync(User user)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Id, user.Id);
            await _users.ReplaceOneAsync(filter, user);
        }

        public async Task DeactivateUserAsync(User user)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Id, user.Id);
            var update = Builders<User>.Update.Set(u => u.IsActive, false);
            await _users.UpdateOneAsync(filter, update);
        }
    }
}
