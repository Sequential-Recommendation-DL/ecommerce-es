using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopappES.Domain;

namespace ShopappES.Infrastructure.Persistence.Postgres.DataContext
{
    public class ShopappESDbContext : DbContext
    {
        public ShopappESDbContext()
        {
        }

        public ShopappESDbContext(DbContextOptions<ShopappESDbContext> options) : base(options)
        {
        }

        public ShopappESDbContext(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        private string? _connectionString;

        public string GetConnectionString(IConfiguration configuration)
        {
            return _connectionString ?? configuration.GetConnectionString("Postgres")
                ?? throw new InvalidOperationException("Connection string 'Postgres' not found in appsettings.json");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _connectionString
                    ?? throw new InvalidOperationException("DbContext is not configured with connection string");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }
    }
}
