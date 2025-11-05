using Data.Interfaces.IDataImplement;
using Data.Repository;
using Entity.Infrastructure.Context;
using Entity.Models.Implements;
using System.Data.Entity;

namespace Data.Services
{
    public class UserRepository : DataGeneric<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context ;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User?> Login(string emailOrUsername, string password)
        {
            var user = await _context.User
                .Where(u => !u.IsDeleted &&
                           (u.Username == emailOrUsername || u.Email == emailOrUsername) &&
                           u.Password == password)
                .FirstOrDefaultAsync();

            return user;
        }

        public async Task<User?> GetByUsernameOrEmailAsync(string emailOrUsername)
        {
            var value = emailOrUsername.Trim().ToLower();

            return await _dbSet
                .FirstOrDefaultAsync(u =>
                    !u.IsDeleted &&
                    (u.Email.ToLower() == value || u.Username.ToLower() == value)
                );
        }


    }
}
