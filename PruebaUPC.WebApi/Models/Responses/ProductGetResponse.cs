namespace PruebaUPC.WebApi.Models.Responses;

public record ProductGetResponse(int Id, string Name, string? Description, bool IsActive, decimal Stock, decimal Price, decimal Discount)
{
}
