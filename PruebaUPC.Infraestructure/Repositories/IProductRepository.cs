using PruebaUPC.Domain;

namespace PruebaUPC.Infraestructure.Repositories;

public interface IProductRepository
{
    IQueryable<Product> Queryable();

    void Save(Product entity);
    void Update(Product entity);
    void Delete(Product entity);
}
