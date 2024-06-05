using Microsoft.EntityFrameworkCore;
using solution.Models;

namespace solution.Contexts;

public class DatabaseContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ShoppingCart>(entity =>
        {
            entity.HasKey(sc => new { sc.AccountId, sc.ProductId });
        });
        
        modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Admin" },
                new Role { RoleId = 2, RoleName = "User" }
        );
        
        modelBuilder.Entity<Account>().HasData(
            new Account
            {
                AccountId = 1,
                RoleId = 1,
                AccountFirstName = "John",
                AccountLastName = "Doe",
                AccountEmail = "john.doe@example.com",
                AccountPhone = "123456789"
            },
            new Account
            {
                AccountId = 2,
                RoleId = 2,
                AccountFirstName = "Jane",
                AccountLastName = "Smith",
                AccountEmail = "jane.smith@example.com",
                AccountPhone = "987654321"
            }
        );

        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, CategoryName = "Electronics" },
            new Category { CategoryId = 2, CategoryName = "Books" }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                ProductId = 1,
                ProductName = "Laptop",
                ProductWeight = 2.5,
                ProductWidth = 35.0,
                ProductHeight = 2.0,
                ProductDepth = 25.0
            },
            new Product
            {
                ProductId = 2,
                ProductName = "Book",
                ProductWeight = 0.5,
                ProductWidth = 15.0,
                ProductHeight = 2.0,
                ProductDepth = 20.0
            }
        );

        modelBuilder.Entity<ShoppingCart>().HasData(
            new ShoppingCart
            {
                AccountId = 1,
                ProductId = 1,
                ShoppingCartAmount = 1
            },
            new ShoppingCart
            {
                AccountId = 2,
                ProductId = 2,
                ShoppingCartAmount = 2
            }
        );
    }
}