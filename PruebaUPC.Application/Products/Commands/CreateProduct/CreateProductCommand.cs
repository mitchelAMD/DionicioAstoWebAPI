using MediatR;
using PruebaUPC.Domain;

namespace PruebaUPC.Application.Products.Commands.CreateProduct;

public record CreateProductCommand(string Name, string? Description, bool IsActive, decimal Stock, decimal Price) : IRequest<int>
{

    public Product ToProduct() => new()
    {
        Name = Name,
        Description = Description,
        IsActive = IsActive ? 1 : 0,
        Stock = Stock,
        Price = Price
    };
}
