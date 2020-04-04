using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;

namespace Passenger.Infrastructure.Repositories
{
    public class InMemoryDriverRepository : IDriverRepository
    {
        private static ISet<Driver> _drivers = new HashSet<Driver>();

        public InMemoryDriverRepository()
        {
        }

        public async Task AddAsync(Driver driver)
        {
            await Task.FromResult(_drivers.Add(driver));
        }

        public async Task<Driver> GetAsync(Guid userId) 
            => await Task.FromResult(_drivers.Single( x => x.UserId == userId ));

        public async Task<IEnumerable<Driver>> BrowseAsync() 
            => await Task.FromResult(_drivers);

    }
}