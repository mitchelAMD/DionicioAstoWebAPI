using PruebaUPC.Domain.Base;

namespace PruebaUPC.Domain;

public class Product : Entity
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }

    public int IsActive { get; set; }
    
    public decimal Stock { get; set; }
    public decimal Price { get; set; }
}
