using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace PruebaUPC.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StatusController: ControllerBase
{
    private readonly IMemoryCache _memoryCache;
    private readonly ILogger<StatusController> _logger;

    public StatusController(IMemoryCache memoryCache, ILogger<StatusController> logger)
    {
        _memoryCache = memoryCache;
        _logger = logger;
    }

    [HttpGet]
    public Dictionary<bool, string>? Get()
    {
        Dictionary<bool, string>? estados = new();

        if (!_memoryCache.TryGetValue("estados", out estados))
        {
            _logger.LogInformation("Se agrega los estados en memoria cache");
            estados = new()
            {
                { true, "Esta Activo" },
                { false, "No Esta Activo" },
            };

            var options = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            };

            _memoryCache.Set("estados", estados, options);
        }

        return estados;
    }

}
