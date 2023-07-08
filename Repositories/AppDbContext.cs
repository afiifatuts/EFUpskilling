using Microsoft.EntityFrameworkCore;
using EFUpskilling.Entities;

namespace EFUpskilling.Repositories;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.
        UseNpgsql("Host=localhost;Port=5432;Database=enigma_shop2;Username=postgres;Password=blimbeng38");
    }
}