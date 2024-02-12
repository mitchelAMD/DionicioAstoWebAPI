using MediatR;

namespace PruebaUPC.Application.Products.Commands.UpdateProduct;

public record UpdateProductCommand (int Id, string Name, string? Description, bool IsActive, decimal Stock, decimal Price) : IRequest<bool>;
