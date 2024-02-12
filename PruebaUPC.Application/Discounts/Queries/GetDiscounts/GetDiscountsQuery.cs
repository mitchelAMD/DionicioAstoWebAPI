using MediatR;
using PruebaUPC.Application.Common.Dtos;

namespace PruebaUPC.Application.Discounts.Queries.GetDiscounts;

public class GetDiscountsQuery : IRequest<List<DiscountDto>>
{
}
