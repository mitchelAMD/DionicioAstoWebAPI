using MediatR;
using PruebaUPC.Domain;
using PruebaUPC.Infraestructure.Persistence;
using PruebaUPC.Infraestructure.Repositories;

namespace PruebaUPC.Application.Products.Commands.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IProductRepository _productRepository;
    private readonly ApplicationDbContext _context;

    public CreateProductHandler(IProductRepository productRepository, ApplicationDbContext context)
    {
        _productRepository = productRepository;
        _context = context;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        IQueryable<Product> productQuery = _productRepository.Queryable();
        int newId = (productQuery.Any() ? productQuery.Max(x => x.Id) : 0) + 1;

        Product _ = request.ToProduct();
        _.Id = newId;

        _productRepository.Save(_);
        await _context.SaveChangesAsync(cancellationToken);

        return newId;
    }
}
