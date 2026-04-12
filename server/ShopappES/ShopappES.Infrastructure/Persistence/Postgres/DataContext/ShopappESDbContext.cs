using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopappES.Domain.Entity;

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
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _connectionString
                    ?? throw new InvalidOperationException("DbContext is not configured with connection string");
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.Username).IsUnique();
                entity.Property(e => e.Username).HasMaxLength(100);
                entity.Property(e => e.Email).HasMaxLength(255);
                entity.Property(e => e.Password).HasMaxLength(255);
                entity.Property(e => e.FullName).HasMaxLength(255);
                entity.Property(e => e.Phone).HasMaxLength(20);
                entity.Property(e => e.Avatar).HasMaxLength(500);
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasOne(e => e.User).WithMany(u => u.Addresses).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Cascade);
                entity.Property(e => e.ReceiverName).HasMaxLength(200);
                entity.Property(e => e.ReceiverPhone).HasMaxLength(20);
                entity.Property(e => e.AddressLine).HasMaxLength(500);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasOne(e => e.ParentCategory).WithMany(c => c.SubCategories).HasForeignKey(e => e.ParentCategoryId).OnDelete(DeleteBehavior.Restrict);
                entity.Property(e => e.CategoryName).HasMaxLength(200);
                entity.Property(e => e.CategoryDescription).HasMaxLength(1000);
                entity.Property(e => e.CategoryImage).HasMaxLength(255);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(e => e.Category).WithMany(c => c.Products).HasForeignKey(e => e.CategoryId).OnDelete(DeleteBehavior.Restrict);
                entity.Property(e => e.ProductName).HasMaxLength(500);
                entity.Property(e => e.SKU).HasMaxLength(100);
                entity.Property(e => e.Images).HasMaxLength(2000);
                entity.Property(e => e.Thumbnail).HasMaxLength(500);
                entity.HasIndex(e => e.SKU).IsUnique();
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.OrderCode).IsUnique();
                entity.HasOne(e => e.User).WithMany(u => u.Orders).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.Address).WithMany().HasForeignKey(e => e.AddressId).OnDelete(DeleteBehavior.SetNull);
                entity.HasOne(e => e.Coupon).WithMany(c => c.Orders).HasForeignKey(e => e.CouponId).OnDelete(DeleteBehavior.SetNull);
                entity.Property(e => e.OrderCode).HasMaxLength(50);
                entity.Property(e => e.Note).HasMaxLength(500);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasOne(e => e.Order).WithMany(o => o.OrderDetails).HasForeignKey(e => e.OrderId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasOne(e => e.User).WithMany().HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Cascade);
                entity.HasIndex(e => e.UserId).IsUnique();
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasOne(e => e.Cart).WithMany(c => c.CartItems).HasForeignKey(e => e.CartId).OnDelete(DeleteBehavior.Cascade);
                entity.HasIndex(e => new { e.CartId, e.ProductId }).IsUnique();
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasOne(e => e.Product).WithMany(p => p.Reviews).HasForeignKey(e => e.ProductId).OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(e => e.User).WithMany(u => u.Reviews).HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Restrict);
                entity.HasOne(e => e.ParentReview).WithMany(r => r.Replies).HasForeignKey(e => e.ParentReviewId).OnDelete(DeleteBehavior.Restrict);
                entity.Property(e => e.Comment).HasMaxLength(1000);
                entity.HasIndex(e => new { e.ProductId, e.UserId });
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasOne(e => e.Order).WithOne(o => o.Payment).HasForeignKey<Payment>(e => e.OrderId).OnDelete(DeleteBehavior.Cascade);
                entity.Property(e => e.TransactionId).HasMaxLength(100);
                entity.Property(e => e.PaymentNote).HasMaxLength(500);
            });

            modelBuilder.Entity<Shipping>(entity =>
            {
                entity.HasOne(e => e.Order).WithOne(o => o.Shipping).HasForeignKey<Shipping>(e => e.OrderId).OnDelete(DeleteBehavior.Cascade);
                entity.Property(e => e.Carrier).HasMaxLength(100);
                entity.Property(e => e.TrackingNumber).HasMaxLength(100);
                entity.Property(e => e.ShippingAddress).HasMaxLength(500);
                entity.Property(e => e.Notes).HasMaxLength(1000);
            });

            modelBuilder.Entity<Coupon>(entity =>
            {
                entity.HasIndex(e => e.CouponCode).IsUnique();
                entity.Property(e => e.CouponCode).HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(500);
            });
        }
    }
}
