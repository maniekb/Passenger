using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Passenger.Core.Domain;
using Passenger.Core.Repositories;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Exceptions;
using Passenger.Infrastructure.Extensions;

namespace Passenger.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;
        private readonly IMapper _mapper;

        public UserService()
        {     
        }

        public UserService(IUserRepository userRepository, IEncrypter encrypter, IMapper mapper)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> BrowseAsync()
        {
            var users = await _userRepository.BrowseAsync();

            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetAsync(string email)
        {
            var user = await _userRepository.GetAsync(email);

            return _mapper.Map<User, UserDto>(user);
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);
            if(user == null)
            {
                throw new ServiceException(Infrastructure.Exceptions.ErroCodes.InvalidCredentials, "Invalid credentials");
            }

            var hash = _encrypter.GetHash(password, user.Salt);

            if(user.Password == hash)
            {
                return;
            }

            throw new ServiceException(Infrastructure.Exceptions.ErroCodes.InvalidCredentials, "Invalid credentials");
        }

        public async Task RegisterAsync(Guid userId, string email, string username, string password, string role)
        {
            var user = await _userRepository.GetAsync(email);
            if(user != null)
            {
                throw new ServiceException(Infrastructure.Exceptions.ErroCodes.InvalidEmail, $"User with email: {email} arleady exists!");
            }

            var salt = _encrypter.GetSalt();
            var hash = _encrypter.GetHash(password, salt);

            user = new User(userId, email, username, hash, role, salt);
            await _userRepository.AddAsync(user);
        }
    }
}