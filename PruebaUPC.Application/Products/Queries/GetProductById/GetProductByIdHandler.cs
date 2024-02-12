using MediatR;
using PruebaUPC.Application.Common.Dtos;
using PruebaUPC.Application.Common.Mappers;
using PruebaUPC.Application.Common.Services;
using PruebaUPC.Domain;
using PruebaUPC.Infraestructure.Repositories;

namespace PruebaUPC.Application.Products.Queries.GetProductById;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
{
    private readonly IProductRepository _productRepository;
    private readonly IDiscountService _discountService;

    public GetProductByIdHandler(IProductRepository productRepository, IDiscountService discountService)
    {
        _productRepository = productRepository;
        _discountService = discountService;
    }

    public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        Product? _ = _productRepository.Queryable().SingleOrDefault(x => x.Id == request.Id);
        if (_ is null) return null;

        DiscountDto? discount = await _discountService.GetAsync(request.Id.ToString(), cancellationToken);
        
        return _?.ToEntity(discount?.Discount);
    }
}
