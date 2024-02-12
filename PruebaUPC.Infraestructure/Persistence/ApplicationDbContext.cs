using Microsoft.EntityFrameworkCore;
using PruebaUPC.Domain;
using System.Reflection;

namespace PruebaUPC.Infraestructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Product { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
