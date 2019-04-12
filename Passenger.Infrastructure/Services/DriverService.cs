using System;
using System.Threading.Tasks;
using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Repositories;

namespace Passenger.Infrastructure.Services
{
    public class DriverService : IDriverService
    {
        private readonly InMemoryDriverRepository _driverRepository;
        private readonly IMapper _mapper;

        DriverService(InMemoryDriverRepository driverRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;

            _mapper = mapper;
        }

        public async Task<DriverDto> GetAsync(Guid userId)
        {
            var driver = await _driverRepository.GetAsync(userId);

            return _mapper.Map<Driver, DriverDto>(driver);
        }
    }
}