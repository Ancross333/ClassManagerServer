using ClassManagerServer.Db;
using Microsoft.EntityFrameworkCore;
using ClassManagerServer.Domain.UserAuthentication;
using ClassManagerServer.Domain.Enums;

namespace ClassManagerServer.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly ClassManagerDbContext _context;

        public UserRepository(ClassManagerDbContext context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task AddUser(User user) => await _context.AddAsync(user);

        public async Task<User?> GetUser(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

            if(user == null)
            {
                return null;
            }

            if(user.Password != password)
            {
                return new User("", "", "", "", UserType.Unauthorized);
            }

            return user;
        }
    }
}
