using MediatR;
using Microsoft.AspNetCore.Mvc;
using PruebaUPC.Application.Common.Dtos;
using PruebaUPC.Application.Discounts.Queries.GetDiscountById;
using PruebaUPC.Application.Discounts.Queries.GetDiscounts;

namespace PruebaUPC.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DiscountController : ControllerBase
{
    private readonly ISender _sender;
    private readonly ILogger<DiscountController> _logger;

    public DiscountController(ISender sender, ILogger<DiscountController> logger)
    {
        _sender = sender;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IEnumerable<DiscountDto>> Get()
    {
        GetDiscountsQuery query = new();
        return await _sender.Send(query);
    }

    [HttpGet("{id}")]
    public async Task<DiscountDto?> Get(string id)
    {
        GetDiscountByIdQuery query = new(id);
        var response = await _sender.Send(query);
        if (response is null) _logger.LogError($"No se encontró el descuento: {id}");
        return response;
    }
}
