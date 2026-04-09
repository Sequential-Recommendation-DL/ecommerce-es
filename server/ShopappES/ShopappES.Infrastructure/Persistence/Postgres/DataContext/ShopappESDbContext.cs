using Microsoft.EntityFrameworkCore;
using ShopappES.Domain;

namespace ShopappES.Infrastructure.Persistence.Postgres.DataContext
{
    public class ShopappESDbContext : DbContext
    {
        private readonly string connectionString;

        public ShopappESDbContext()
        {
            connectionString = @"Server=.;Database=ecommerce_db;Trusted_Connection=True;TrustServerCertificate=True;";
        }

        public ShopappESDbContext(string connectionString)
        {
            this.connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails {get;set;}
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}
