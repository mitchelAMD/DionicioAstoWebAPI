using PruebaUPC.Application.Common.Dtos;
using PruebaUPC.Domain;

namespace PruebaUPC.Application.Common.Mappers;

public static class ProductMapper
{
    public static ProductDto ToEntity(this Product entity, decimal? discount)
         => new(entity.Id, entity.Name, entity.Description, entity.IsActive == 1 ? "activo" : "inactivo", entity.Stock, entity.Price, discount);
}
