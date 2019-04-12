using System;
using System.Threading.Tasks;
using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.DTO;

namespace Passenger.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService()
        {
            
        }

        public UserService(IUserRepository userRepository, IMapper Mapper)
        {
            _userRepository = userRepository;
            _mapper = Mapper;
        }
        public async Task<UserDto> GetAsync(string email)
        {
            var user = await _userRepository.GetAsync(email);

            return _mapper.Map<User, UserDto>(user);
        }

        public async Task RegisterAsync(string email, string username, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if(user != null)
            {
                throw new Exception($"User with email: {email} arleady exists!");
            }

            var salt = Guid.NewGuid().ToString("N");
            user = new User(email, username, password, salt);
            await _userRepository.AddAsync(user);
        }
    }
}