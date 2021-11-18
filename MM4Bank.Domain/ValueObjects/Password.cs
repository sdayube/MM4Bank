using Konscious.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MM4Bank.Domain.ValueObjects
{
    public class Password : ValueObject
    {
        public byte[] _password { get; private set; }
        public Password(string password)
        {
            if (IsValid(password))
            {
                var salt = CreateSalt();
                _password = HashPassword(password, salt);
            }
            else
            {
                throw new System.ArgumentException(nameof(password));
            }
        }

        private byte[] CreateSalt()
        {
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return buffer;
        }

        private byte[] HashPassword(string password, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));
            argon2.Salt = salt;
            argon2.DegreeOfParallelism = 8;
            argon2.Iterations = 4;
            argon2.MemorySize = 1024 * 1024;
            return argon2.GetBytes(16);
        }

        public bool VerifyHash(string password, byte[] salt, byte[] hash)
        {
            var passwordHash = HashPassword(password, salt);
            return hash.SequenceEqual(passwordHash);
        }

    }
}