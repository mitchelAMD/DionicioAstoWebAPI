using MediatR;
using PruebaUPC.Application.Common.Dtos;

namespace PruebaUPC.Application.Products.Queries.GetProducts;

public class GetProductsQuery : IRequest<List<ProductDto>>
{
}
