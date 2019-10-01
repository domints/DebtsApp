using System;
using System.Linq;
using System.Threading.Tasks;
using DebtsApp.Web.Database;
using DebtsApp.Web.Database.Models;
using DebtsApp.Web.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DebtsApp.Web.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DebtContext cx;

        public UserRepository(DebtContext cx)
        {
            this.cx = cx;
        }

        public async Task<User> AddUser(string login, string password, string name)
        {
            var user = await cx.Users.Where(u => u.Email == login).FirstOrDefaultAsync().ConfigureAwait(false);
            if(user != null)
                return null;

            CreatePasswordHash(password, out string hash, out string salt);
            var newUser = new User
            {
                Email = login,
                Password = hash,
                Seed = salt,
                Name = name
            };
            cx.Users.Add(newUser);
            await cx.SaveChangesAsync().ConfigureAwait(false);
            return newUser;
        }

        public async Task<User> VerifyPassword(string login, string password)
        {
            var user = await cx.Users.Where(u => u.Email == login).FirstOrDefaultAsync().ConfigureAwait(false);
            if(user == null)
                return null;

            return VerifyPasswordHash(password, user.Password, user.Seed) ? user : null;
        }

        private static void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt)
        {
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", nameof(password));

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = Convert.ToBase64String(hmac.Key);
                passwordHash = Convert.ToBase64String(hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password)));
            }
        }

        private static bool VerifyPasswordHash(string password, string storedHash, string storedSalt)
        {
            Console.WriteLine(password);
            Console.WriteLine(storedHash);
            Console.WriteLine(storedSalt);
            var bStoredHash = Convert.FromBase64String(storedHash);
            var bStoredSalt = Convert.FromBase64String(storedSalt);
            if (password == null) throw new ArgumentNullException(nameof(password));
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", nameof(password));
            if (bStoredHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (bStoredSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(bStoredSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != bStoredHash[i]) return false;
                }
            }

            return true;
        }
    }
}