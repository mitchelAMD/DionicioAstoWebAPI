using MediatR;
using PruebaUPC.Application.Common.Dtos;

namespace PruebaUPC.Application.Discounts.Queries.GetDiscountById;

public record GetDiscountByIdQuery (string Id) : IRequest<DiscountDto?>;
