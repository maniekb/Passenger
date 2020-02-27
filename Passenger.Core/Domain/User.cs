using System;
using System.Text.RegularExpressions;

namespace Passenger.Core.Domain
{
    public class User
    {
        private static readonly Regex NameRegex = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");
        public Guid Id { get; protected set;}
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string Role { get; protected set; }
        public string Username { get; protected set; }
        public string FullName { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        public User()
        {

        }

        public User(string email, string username, string password, string role, string salt)
        {
            Id = Guid.NewGuid();
            SetEmail(email);
            SetPassword(password);
            SetUsername(username);
            Role = role;
            Salt = salt;
            CreatedAt = UpdatedAt = DateTime.UtcNow;
        }
        
        private void SetUsername(string username)
        {
            if(!NameRegex.IsMatch(username))
            {
                throw new Exception("Username is invalid.");
            }
            if(string.IsNullOrWhiteSpace(username))
            {
                throw new Exception("Username is invalid.");
            }
            if(username == Username)
            {
                return;
            }

            Username = username.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }
        private void SetEmail(string email)
        {
            if(string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email is invalid.");
            }
            if(Email == email)
            {
                return;
            }

            Email = email.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }
        private void SetPassword(string password)
        {
            if(string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password cannot be empty.");
            }
            if(password.Length < 4 || password.Length > 100)
            {
                throw new Exception("Password must be 4-100 characters long.");
            }
            if(Password == password)
            {
                return;
            }

            Password = password;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}