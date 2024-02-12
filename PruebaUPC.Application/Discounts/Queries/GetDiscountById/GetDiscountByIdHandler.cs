using MediatR;
using PruebaUPC.Application.Common.Dtos;
using PruebaUPC.Application.Common.Services;
using System.Text.Json;

namespace PruebaUPC.Application.Discounts.Queries.GetDiscountById;

public class GetDiscountByIdHandler : IRequestHandler<GetDiscountByIdQuery, DiscountDto?>
{
    private readonly IDiscountService _discountService;

    public GetDiscountByIdHandler(IDiscountService discountService)
    {
        _discountService = discountService;
    }

    public async Task<DiscountDto?> Handle(GetDiscountByIdQuery request, CancellationToken cancellationToken)
    {
        return await _discountService.GetAsync(request.Id, cancellationToken);
    }
}
