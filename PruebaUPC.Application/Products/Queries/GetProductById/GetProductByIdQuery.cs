using MediatR;
using PruebaUPC.Application.Common.Dtos;

namespace PruebaUPC.Application.Products.Queries.GetProductById;

public record GetProductByIdQuery(int Id) : IRequest<ProductDto?>;
