using PruebaUPC.Domain;
using PruebaUPC.Infraestructure.Persistence;

namespace PruebaUPC.Infraestructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IQueryable<Product> Queryable() => _context.Product.AsQueryable();

    public void Save(Product entity) => _context.Product.Add(entity);

    public void Update(Product entity) => _context.Product.Update(entity);

    public void Delete(Product entity) => _context.Product.Remove(entity);
}
