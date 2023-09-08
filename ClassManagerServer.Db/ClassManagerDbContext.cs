using Microsoft.EntityFrameworkCore;

namespace ClassManagerServer.Db
{
    public class ClassManagerDbContext : DbContext
    {
        public ClassManagerDbContext(DbContextOptions<ClassManagerDbContext> options)
        : base(options)
        {
        }
    }
}
