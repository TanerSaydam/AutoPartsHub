using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context;

public sealed class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer("Data Source=TUGAY\\SQLEXPRESS;Initial Catalog=AutoPartsHubDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=admin;Database=AutoPartDb;");
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ProductWarehouse> ProductWarehouses { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<ProductCategory>()
            .HasKey(key => new { key.CategoryId, key.ProductId }); //composite key

        modelBuilder
            .Entity<ProductWarehouse>()
            .HasKey(key => new { key.ProductId, key.WarehouseId });

        modelBuilder
            .Entity<UserRole>()
            .HasKey(key => new { key.RoleId, key.UserId });

        modelBuilder
            .Entity<Product>()
            .Property(p => p.Price)
            .HasColumnType("money");

        modelBuilder
            .Entity<ShoppingCart>()
            .Property(p => p.Price)
            .HasColumnType("money");

        modelBuilder
           .Entity<Order>()
           .Property(p => p.Price)
           .HasColumnType("money");

        List<Category> categories = new()
        {
            new Category()
            {
                Id = 1,
                MainCategoryId = null,
                Name = "Otomobil"
            },
            new Category()
            {
                Id = 2,
                MainCategoryId = null,
                Name = "Arazi"
            },
            new Category()
            {
                Id = 3,
                MainCategoryId = null,
                Name = "SUV"
            },
            new Category()
            {
                Id = 4,
                MainCategoryId = null,
                Name = "Pickup"
            }
        };

        modelBuilder
            .Entity<Category>()
            .HasData(categories);

        List<Category> subCategories = new()
        {
            new Category()
            {
                Id = 5,
                MainCategoryId = 1,
                Name = "Aion"
            },
            new Category()
            {
                Id = 6,
                MainCategoryId = 1,
                Name = "Alfa Romeo"
            },
            new Category()
            {
                Id = 7,
                MainCategoryId = 1,
                Name = "Anadol"
            },
            new Category()
            {
                Id = 8,
                MainCategoryId = 1,
                Name = "Arora"
            },
            new Category()
            {
                Id = 9,
                MainCategoryId = 2,
                Name = "Acura"
            },
        };

        modelBuilder
            .Entity<Category>()
            .HasData(subCategories);
    }
}