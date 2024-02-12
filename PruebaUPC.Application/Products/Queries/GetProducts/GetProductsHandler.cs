using MediatR;
using PruebaUPC.Application.Common.Dtos;
using PruebaUPC.Application.Common.Mappers;
using PruebaUPC.Application.Common.Services;
using PruebaUPC.Domain;
using PruebaUPC.Infraestructure.Repositories;

namespace PruebaUPC.Application.Products.Queries.GetProducts;

public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
{
    private readonly IProductRepository _productRepository;
    private readonly IDiscountService _discountService;

    public GetProductsHandler(IProductRepository productRepository, IDiscountService discountService)
    {
        _productRepository = productRepository;
        _discountService = discountService;
    }

    public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        List<Product> _ = _productRepository.Queryable().ToList();

        var tasks = _.Select(x => _discountService.GetAsync(x.Id.ToString(), cancellationToken)).ToList();
        await Task.WhenAll(tasks);

        IEnumerable<DiscountDto?> discounts = tasks.Select(x => x.Result!);

        DiscountDto? discount;
        List<ProductDto> lista = new();
        foreach (Product item in _)
        {
            discount = discounts.FirstOrDefault(x => x != null && x.Id == item.Id.ToString());
            lista.Add(item.ToEntity(discount?.Discount));
        }

        return lista;
    }
}
