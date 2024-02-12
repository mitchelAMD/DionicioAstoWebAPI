using MediatR;
using PruebaUPC.Domain;
using PruebaUPC.Infraestructure.Persistence;
using PruebaUPC.Infraestructure.Repositories;

namespace PruebaUPC.Application.Products.Commands.UpdateProduct;

public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
{
    private readonly IProductRepository _productRepository;
    private readonly ApplicationDbContext _context;

    public UpdateProductHandler(IProductRepository productRepository, ApplicationDbContext context)
    {
        _productRepository = productRepository;
        _context = context;
    }

    public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        IQueryable<Product> productQuery = _productRepository.Queryable();
        Product? _ = productQuery.FirstOrDefault(x => x.Id == request.Id);

        if (_ is null) return false;

        _.Name = request.Name;
        _.Description = request.Description;
        _.IsActive = request.IsActive ? 1 : 0;
        _.Stock = request.Stock;
        _.Price = request.Price;

        _productRepository.Update(_);
        return await _context.SaveChangesAsync(cancellationToken) > 0;
    }
}
