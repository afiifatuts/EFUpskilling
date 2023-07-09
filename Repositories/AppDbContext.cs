using Microsoft.EntityFrameworkCore;
using EFUpskilling.Entities;

namespace EFUpskilling.Repositories;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<PurchaseDetail> PurchaseDetails { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.
        UseNpgsql("Host=localhost;Port=5432;Database=enigma_shop2;Username=postgres;Password=blimbeng38");
    }
}