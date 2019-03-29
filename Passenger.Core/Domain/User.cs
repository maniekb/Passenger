using System;

namespace Passenger.Core.Domain
{
    public class User
    {
        public Guid Id { get; protected set;}
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string Username { get; protected set; }
        public string FullName { get; protected set; }
        public DateTime CreatedAt { get; protected set; }


        public User()
        {

        }

        public User(string email, string password, string username, string salt)
        {
            Id = Guid.NewGuid();
            Email = email;
            Password = password;
            Username = username;
            Salt = salt;
            CreatedAt = DateTime.UtcNow;
        }
    }
}