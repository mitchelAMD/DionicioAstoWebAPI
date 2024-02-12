using Moq;
using PruebaUPC.Application.Common.Dtos;
using PruebaUPC.Application.Common.Services;
using PruebaUPC.Application.Products.Queries.GetProducts;
using PruebaUPC.Domain;
using PruebaUPC.Infraestructure.Repositories;

namespace PruebaUPC.Test.Products.Queries;

[TestFixture]
public class GetProductsTest
{
    private readonly GetProductsHandler _getProductsHandler;
    private readonly Mock<IProductRepository> _productoRepositoryMock = new();
    private readonly Mock<IDiscountService> _discountServiceMock = new();

    public GetProductsTest()
    {
        _discountServiceMock = new();
        _getProductsHandler = new(_productoRepositoryMock.Object, _discountServiceMock.Object);
    }

    [Test]
    public async Task ShouldGetProducts()
    {
        //TODO: Setup
        CancellationTokenSource cancellationTokenSource = new();
        CancellationToken cancellationToken = cancellationTokenSource.Token;

        DiscountDto? discount = new("1", 10);

        _discountServiceMock.Setup(x => x.GetAsync(It.IsAny<string>(), cancellationToken)).Returns(Task.FromResult(discount)!);

        _productoRepositoryMock.Setup(x => x.Queryable()).Returns(new List<Product>
        {
            new () { Id = 1, Name = "Beer", Stock = 10, IsActive = 1, Price = 24 },
            new () { Id = 2, Name = "Cofee", Stock = 200, IsActive = 1, Price = 5.1m  },
            new () { Id = 3, Name = "Milk", Stock = 400, IsActive = 1, Price = 2.5m  },
        }.AsQueryable());

        //TODO: Act
        GetProductsQuery _ = new();
        var result = await _getProductsHandler.Handle(_, cancellationToken);

        //TODO: Assert
        Assert.That(result, Has.Count.GreaterThanOrEqualTo(0));
    }
}
