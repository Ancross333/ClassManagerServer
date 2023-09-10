using ClassManagerServer.Domain.UserAuthentication;
using Microsoft.EntityFrameworkCore;

namespace ClassManagerServer.Db
{
    public class ClassManagerDbContext : DbContext
    {
        public ClassManagerDbContext(DbContextOptions<ClassManagerDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.UserId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
    }

}
