using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Passenger.Infrastructure.Extensions;

namespace Passenger.Infrastructure.Services
{
    public class Encrypter : IEncrypter
    {
        private static readonly int DerivedBytesIterationsCount = 10000;
        private static readonly int SaltSize = 40;
        public string GetHash(string value, string salt)
        {
            if(value.Empty())
            {
                throw new ArgumentException("Can not generate hash from empty value", nameof(value));
            }

            if(salt.Empty())
            {
                throw new ArgumentException("Can not use an empty salt from hashing value", nameof(value));
            }

            var pbkdf2 = new Rfc2898DeriveBytes(value, GetBytes(salt), DerivedBytesIterationsCount);

            return Convert.ToBase64String(pbkdf2.GetBytes(SaltSize));
        }

        public string GetSalt(string value)
        {
            if(value.Empty())
            {
                throw new ArgumentException("Can not generate salt from empty value", nameof(value));
            }

            var random = new Random();
            var saltBytes = new byte[SaltSize];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }
    }
}