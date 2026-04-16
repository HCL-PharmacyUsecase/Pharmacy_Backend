using Microsoft.EntityFrameworkCore;
using Pharmacy.API.Models;
using System.Reflection.Emit;

namespace Pharmacy.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Medicine> Medicines { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<InventoryLog> InventoryLogs { get; set; }
    public DbSet<LoyaltyPoint> LoyaltyPoints { get; set; }
    public DbSet<HealthPackage> HealthPackages { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // User - Order (One-to-Many)
        modelBuilder.Entity<Order>()
            .HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // User - Prescription (One-to-Many)
        modelBuilder.Entity<Prescription>()
            .HasOne(p => p.User)
            .WithMany(u => u.Prescriptions)
            .HasForeignKey(p => p.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // User - LoyaltyPoint (One-to-One)
        modelBuilder.Entity<LoyaltyPoint>()
            .HasOne(lp => lp.User)
            .WithOne(u => u.LoyaltyPoint)
            .HasForeignKey<LoyaltyPoint>(lp => lp.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Category - Medicine (One-to-Many)
        modelBuilder.Entity<Medicine>()
            .HasOne(m => m.Category)
            .WithMany(c => c.Medicines)
            .HasForeignKey(m => m.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        // Order - OrderItem (One-to-Many)
        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        // Medicine - OrderItem (One-to-Many)
        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.Medicine)
            .WithMany(m => m.OrderItems)
            .HasForeignKey(oi => oi.MedicineId)
            .OnDelete(DeleteBehavior.Restrict);

        // Medicine - InventoryLog (One-to-Many)
        modelBuilder.Entity<InventoryLog>()
            .HasOne(il => il.Medicine)
            .WithMany(m => m.InventoryLogs)
            .HasForeignKey(il => il.MedicineId)
            .OnDelete(DeleteBehavior.Cascade);

        // Decimal Precision
        modelBuilder.Entity<Medicine>()
            .Property(m => m.Price)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Order>()
            .Property(o => o.TotalAmount)
            .HasPrecision(18, 2);

        modelBuilder.Entity<OrderItem>()
            .Property(oi => oi.Price)
            .HasPrecision(18, 2);

        modelBuilder.Entity<HealthPackage>()
            .Property(hp => hp.Price)
            .HasPrecision(18, 2);

        // Unique Constraints
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
    }
}