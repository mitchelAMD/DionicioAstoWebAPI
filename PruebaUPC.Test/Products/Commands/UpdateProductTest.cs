using Microsoft.EntityFrameworkCore;
using Moq;
using PruebaUPC.Application.Products.Commands.UpdateProduct;
using PruebaUPC.Domain;
using PruebaUPC.Infraestructure.Persistence;
using PruebaUPC.Infraestructure.Repositories;

namespace PruebaUPC.Test.Products.Commands;

[TestFixture]
public class UpdateProductTest
{
    private readonly UpdateProductHandler _updateProductHandler;
    private readonly Mock<IProductRepository> _productoRepositoryMock = new();
    private readonly Mock<ApplicationDbContext> _applicationDbContextMock = new();

    public UpdateProductTest()
    {
        DbContextOptions<ApplicationDbContext> dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("PruebaUPC")
            .Options;

        _applicationDbContextMock = new(MockBehavior.Strict, dbOptions);
        _updateProductHandler = new(_productoRepositoryMock.Object, _applicationDbContextMock.Object);
    }

    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public async Task ShouldUpdateProduct()
    {
        //TODO: Setup
        CancellationTokenSource cancellationTokenSource = new();
        CancellationToken cancellationToken = cancellationTokenSource.Token;

        //_applicationDbContextMock.Setup(x => x.Product).Returns(FakeDbSet(TestDataProducts.GetFakeProducts()));

        UpdateProductCommand _ = new(1, "Prueba", "Producto de Prueba", true, 40, 150);
        Product product = new()
        {
            Id = _.Id,
            Name = _.Name,
            Description = _.Description,
            IsActive = _.IsActive ? 1 : 0,
            Stock = _.Stock,
            Price = _.Price,
        };

        _productoRepositoryMock.Setup(x => x.Update(It.IsAny<Product>()));

        //TODO: Act
        var result = await _updateProductHandler.Handle(_, cancellationToken);

        //TODO: Assert
        Assert.That(result, Is.False);
    }

    private static DbSet<T> FakeDbSet<T>(List<T> elementos) where T : class
    {
        var mockSet = new Mock<DbSet<T>>();

        mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(elementos.AsQueryable().Provider);
        mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(elementos.AsQueryable().Expression);
        mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(elementos.AsQueryable().ElementType);
        mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(elementos.GetEnumerator());

        return mockSet.Object;
    }
}
