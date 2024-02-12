using MediatR;
using PruebaUPC.Domain;
using PruebaUPC.Infraestructure.Persistence;
using PruebaUPC.Infraestructure.Repositories;

namespace PruebaUPC.Application.Products.Commands.DeleteProduct;

public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
{
    private readonly IProductRepository _productRepository;
    private readonly ApplicationDbContext _context;

    public DeleteProductHandler(IProductRepository productRepository, ApplicationDbContext context)
    {
        _productRepository = productRepository;
        _context = context;
    }

    public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        IQueryable<Product> productQuery = _productRepository.Queryable();
        Product? _ = productQuery.FirstOrDefault(x => x.Id == request.Id);
        if (_ is null) return false;
        _productRepository.Delete(_);

        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}
