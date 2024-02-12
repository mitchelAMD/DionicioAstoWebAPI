using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaUPC.Application.Common.Dtos;
using PruebaUPC.Application.Products.Commands.CreateProduct;
using PruebaUPC.Application.Products.Commands.DeleteProduct;
using PruebaUPC.Application.Products.Commands.UpdateProduct;
using PruebaUPC.Application.Products.Queries.GetProductById;
using PruebaUPC.Application.Products.Queries.GetProducts;
using PruebaUPC.WebApi.Models.Requests;

namespace PruebaUPC.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ISender _sender;
    private readonly ILogger<ProductController> _logger;

    public ProductController(ISender sender, ILogger<ProductController> logger)
    {
        _sender = sender;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IEnumerable<ProductDto>> Get()
    {
        GetProductsQuery query = new();
        return await _sender.Send(query);
    }

    [HttpGet("{id}")]
    public async Task<ProductDto?> Get(int id)
    {
        GetProductByIdQuery query = new(id); 
        var response = await _sender.Send(query);
        if (response is null) _logger.LogError($"No se encontró el producto {id}");
        return response;
    }

    [HttpPost]
    public async Task<int> Post([FromBody] ProductPostRequest request)
    {
        CreateProductCommand _ = request.ToCreateProductCommand();
        return await _sender.Send(_);
    }

    [HttpPut]
    public async Task<bool> Put([FromQuery] int id, [FromBody] ProductPutRequest request)
    {
        UpdateProductCommand _ = request.ToUpdateProductCommand(id);
        return await _sender.Send(_);
    }

    [HttpDelete]
    public async Task<bool> Delete([FromQuery] int id)
    {
        DeleteProductCommand _ = new(id);
        return await _sender.Send(_);
    }
}
