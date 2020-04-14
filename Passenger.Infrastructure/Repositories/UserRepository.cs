using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Passenger.Core.Repositories;
using Passenger.Core.Domain;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Passenger.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository, IMongoRepository
    {
        private readonly IMongoDatabase _database;
        private IMongoCollection<User> Users => _database.GetCollection<User>("Users");
        public UserRepository(IMongoDatabase database)
        {
            _database = database;
        }
        public async Task AddAsync(User user)
            => await Users.InsertOneAsync(user);

        public async Task<IEnumerable<User>> BrowseAsync()
            => await Users.AsQueryable().ToListAsync();

        public async Task<User> GetAsync(Guid id)
            => await Users.AsQueryable().FirstOrDefaultAsync(x => x.Id == id);

        public async Task<User> GetAsync(string email)
            => await Users.AsQueryable().FirstOrDefaultAsync(x => x.Email == email);

        public async Task RemoveAsync(Guid id)
            => await Users.DeleteOneAsync(x => x.Id == id);

        public async Task UpdateAsync(User user)
            => await Users.ReplaceOneAsync(x => x.Id == user.Id, user);
    }
}