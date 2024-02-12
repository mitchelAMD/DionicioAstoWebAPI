namespace PruebaUPC.Application.Common.Dtos;

public record ProductDto(int Id, string Name, string? Description, string Status, decimal Stock, decimal Price, decimal? Discount)
{
    public decimal TotalPrice => Stock * (Discount.HasValue ? Price * (1 - Discount.Value / 100) : Price);
}
