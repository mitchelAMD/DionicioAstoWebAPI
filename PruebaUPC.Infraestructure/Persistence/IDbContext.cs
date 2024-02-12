using Microsoft.EntityFrameworkCore;
using PruebaUPC.Domain;

namespace PruebaUPC.Infraestructure.Persistence;

public interface IDbContext
{
    DbSet<Product> Product { get; set; }
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
