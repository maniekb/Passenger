using System;

namespace Passenger.Infrastructure.DTO
{
    public class UserDto
    {
        public Guid Id { get; set;}
        public string Email { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }

        public UserDto(Guid id, string email, string username, string fullname)
        {
            Id = id;
            Email = email;
            Username = username;
            FullName = fullname;
        }
    }
}