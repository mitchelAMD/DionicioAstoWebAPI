using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using PruebaUPC.Application.Products.Commands.DeleteProduct;
using PruebaUPC.Domain;
using PruebaUPC.Infraestructure.Persistence;
using PruebaUPC.Infraestructure.Repositories;

namespace PruebaUPC.Test.Products.Commands;

[TestFixture]
public class DeleteProductTest
{
    private readonly DeleteProductHandler _deleteProductHandler;
    private readonly Mock<IProductRepository> _productoRepositoryMock = new();
    private readonly Mock<ApplicationDbContext> _applicationDbContextMock = new();

    public DeleteProductTest()
    {
        DbContextOptions<ApplicationDbContext> dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("PruebaUPC")
            .Options;
            
        _applicationDbContextMock = new(dbOptions);
        _deleteProductHandler = new(_productoRepositoryMock.Object, _applicationDbContextMock.Object);
    }

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task ShouldDeleteProduct()
    {
        //TODO: Setup
        CancellationTokenSource cancellationTokenSource = new();
        CancellationToken cancellationToken = cancellationTokenSource.Token;


        DeleteProductCommand _ = new(1);
        Product product = _.ToProduct();
        _productoRepositoryMock.Setup(x => x.Delete(It.IsAny<Product>()));

        //TODO: Act
        var result = await _deleteProductHandler.Handle(_, cancellationToken);

        //TODO: Assert
        Assert.That(result, Is.False);
    }
}
