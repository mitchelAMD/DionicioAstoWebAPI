using PruebaUPC.Application.Products.Commands.UpdateProduct;

namespace PruebaUPC.WebApi.Models.Requests;

public record ProductPutRequest(string Name, string? Description, bool IsActive, decimal Stock, decimal Price, decimal Discount)
{
    public UpdateProductCommand ToUpdateProductCommand(int id) => new(id, Name, Description, IsActive, Stock, Price);
}
