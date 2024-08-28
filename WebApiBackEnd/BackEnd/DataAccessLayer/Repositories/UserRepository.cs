using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.RepositoriesInterface;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        //public Task<User> GetUserByIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<User> GetUserByEmailPass(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            return user;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task<User> GetUserByPassToken(string passwordResetToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.PasswordResetToken == passwordResetToken && u.PasswordResetTokenExpiry > DateTime.UtcNow.AddHours(7));
            return user;
        }

        public async Task<User> GetUserByVerificationTokenAsync(string token)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.VerificationEmailToken == token && u.VerificationEmailTokenExpiry > DateTime.UtcNow.AddHours(6.5));
            return user;
        }

    }
}
