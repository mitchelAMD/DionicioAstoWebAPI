using MediatR;
using PruebaUPC.Application.Common.Dtos;
using PruebaUPC.Application.Common.Services;

namespace PruebaUPC.Application.Discounts.Queries.GetDiscounts;

public class GetDiscountsHandler : IRequestHandler<GetDiscountsQuery, List<DiscountDto>>
{
    private readonly IDiscountService _discountService;

    public GetDiscountsHandler(IDiscountService discountService)
    {
        _discountService = discountService;
    }

    public async Task<List<DiscountDto>> Handle(GetDiscountsQuery request, CancellationToken cancellationToken)
    {
        return (await _discountService.GetAllAsync(cancellationToken))!.ToList();
    }
}
