using PruebaUPC.Application.Common.Dtos;

namespace PruebaUPC.Application.Common.Services;

public interface IDiscountService
{
    Task<IEnumerable<DiscountDto>?> GetAllAsync(CancellationToken cancellationToken);
    Task<DiscountDto?> GetAsync(string id, CancellationToken cancellationToken);
}
