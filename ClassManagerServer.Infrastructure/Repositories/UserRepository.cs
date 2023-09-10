using ClassManagerServer.Db;
using ClassManagerServer.Domain.Enums;
using ClassManagerServer.Domain.UserAuthentication;

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

        public async Task AddUser(User user)
        {
            await _context.AddAsync(user);
        }
    }
}
