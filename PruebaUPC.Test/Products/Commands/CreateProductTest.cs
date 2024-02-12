using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using PruebaUPC.Application.Products.Commands.CreateProduct;
using PruebaUPC.Domain;
using PruebaUPC.Infraestructure.Persistence;
using PruebaUPC.Infraestructure.Repositories;
using System.Xml.Linq;

namespace PruebaUPC.Test.Products.Commands;

[TestFixture]
public class CreateProductTest
{
    private readonly CreateProductHandler _createProductHandler;
    private readonly Mock<IProductRepository> _productoRepositoryMock = new();
    private readonly Mock<ApplicationDbContext> _applicationDbContextMock = new();

    public CreateProductTest()
    {
        DbContextOptions<ApplicationDbContext> dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("PruebaUPC")
            .Options;
        _applicationDbContextMock = new(dbOptions);
        _createProductHandler = new(_productoRepositoryMock.Object, _applicationDbContextMock.Object);
    }

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task ShouldCreateProduct()
    {
        //TODO: Setup
        CancellationTokenSource cancellationTokenSource = new();
        CancellationToken cancellationToken = cancellationTokenSource.Token;

        CreateProductCommand _ = new("Prueba", "Producto de Prueba", true, 20, 150);
        Product product = _.ToProduct();
        _productoRepositoryMock.Setup(x => x.Save(It.IsAny<Product>()));

        //TODO: Act
        var result = await _createProductHandler.Handle(_, cancellationToken);

        //TODO: Assert
        Assert.Greater(result, 0);
    }
}
