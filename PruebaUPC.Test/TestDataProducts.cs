using PruebaUPC.Domain;

namespace PruebaUPC.Test;

public static class TestDataProducts
{
    public static List<Product> GetFakeProducts()
    {
        return new List<Product>()
        {
            new() { Id = 1, Name = "Beer", Stock = 10, IsActive = 1, Price = 24 },
            new() { Id = 2, Name = "Cofee", Stock = 200, IsActive = 1, Price = 5.1m },
            new() { Id = 3, Name = "Milk", Stock = 200, IsActive = 1, Price = 5.1m },
        };
    }
}
