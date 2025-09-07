using AbySalto.Junior.Models;
using Microsoft.EntityFrameworkCore;

namespace AbySalto.Junior.Infrastructure.Database
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Use fluent API configurations
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            // Seed initial data
            modelBuilder.Entity<Order>().HasData(
                 new Order
                 {
                     Id = 1,
                     CustomerName = "Ana Kolar",
                     Status = OrderStatus.Pending,
                     OrderTime = new DateTime(2025, 9, 6, 12, 0, 0),
                     PaymentMethod = OrderPaymentMethod.Cash,
                     DeliveryAddress = "Ulica 1, Zagreb",
                     ContactNumber = "0911234567",
                     Note = "Ring the doorbell",
                     Currency = OrderCurrency.EUR
                 },
                new Order
                {
                    Id = 2,
                    CustomerName = "Ivan Horvat",
                    Status = OrderStatus.Completed,
                    OrderTime = new DateTime(2025, 9, 5, 18, 30, 0),
                    PaymentMethod = OrderPaymentMethod.CreditCard,
                    DeliveryAddress = "Ulica 2, Split",
                    ContactNumber = "0987654321",
                    Note = null,
                    Currency = OrderCurrency.EUR
                }
            );
            // Example seed data for OrderItems
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem
                {
                    Id = 1,
                    ProductName = "Pizza Margherita",
                    Quantity = 2,
                    Price = 8.50m,
                    OrderId = 1
                },
                new OrderItem
                {
                    Id = 2,
                    ProductName = "Orange Juice",
                    Quantity = 1,
                    Price = 2.50m,
                    OrderId = 1
                },
                new OrderItem
                {
                    Id = 3,
                    ProductName = "Classic Burger",
                    Quantity = 1,
                    Price = 7.00m,
                    OrderId = 2
                }
            );
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
