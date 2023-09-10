using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace ClassManagerServer.Db
{
    public class ClassManagerDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ClassManagerDbContext>
    {
        public ClassManagerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ClassManagerDbContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=password");

            return new ClassManagerDbContext(optionsBuilder.Options);
        }
    }
}
