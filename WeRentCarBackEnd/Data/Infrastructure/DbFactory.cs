using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace WeRentCarBackEnd.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        ApplicationDbContext Init();
    }

    public class DbFactory : IDbFactory
    {
        private ApplicationDbContext _dbContext;
        private readonly DbContextOptions<ApplicationDbContext> _options;

        public DbFactory(IConfiguration configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            var options = optionsBuilder.Options;
            _options = options;
        }

        public ApplicationDbContext Init()
        {
            return _dbContext ?? (_dbContext = new ApplicationDbContext(_options));
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
