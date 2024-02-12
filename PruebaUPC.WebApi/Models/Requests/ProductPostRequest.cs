using PruebaUPC.Application.Products.Commands.CreateProduct;

namespace PruebaUPC.WebApi.Models.Requests;

public record ProductPostRequest(string Name, string? Description, bool IsActive, decimal Stock, decimal Price, decimal Discount)
{
    public CreateProductCommand ToCreateProductCommand() => new(Name, Description, IsActive, Stock, Price);
}
