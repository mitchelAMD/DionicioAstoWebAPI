using MediatR;
using PruebaUPC.Domain;

namespace PruebaUPC.Application.Products.Commands.DeleteProduct;

public record DeleteProductCommand(int Id) : IRequest<bool>
{
    public Product ToProduct() => new() { Id = Id };
}
