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

        public User(Guid userId, string email, string username, string password, string role, string salt)
        {
            Id = userId;
            SetEmail(email);
            SetPassword(password);
            SetUsername(username);
            SetRole(role);
            Salt = salt;
            CreatedAt = UpdatedAt = DateTime.UtcNow;
        }

        private void SetRole(string role)
        {
            if(Role == role)
                return;

            if(!(role.Equals("user") || role.Equals("admin")))
            {
                throw new DomainException(ErroCodes.InvalidRole, "Role must be 'user' or 'admin'");
            }

            Role = role;
        }

        private void SetUsername(string username)
        {
            if(!NameRegex.IsMatch(username))
            {
                throw new DomainException(ErroCodes.InvalidUsername, "Username is invalid.");
            }
            if(string.IsNullOrWhiteSpace(username))
            {
                throw new DomainException(ErroCodes.InvalidUsername, "Username can not be empty.");
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
                throw new DomainException(ErroCodes.InvalidEmail, "Email is invalid.");
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
                throw new DomainException(ErroCodes.InvalidPassword, "Password cannot be empty.");
            }
            if(password.Length < 4 || password.Length > 100)
            {
                throw new DomainException(ErroCodes.InvalidPassword, "Password must be 4-100 characters long.");
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