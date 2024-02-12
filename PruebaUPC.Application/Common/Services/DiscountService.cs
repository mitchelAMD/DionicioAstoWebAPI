using PruebaUPC.Application.Common.Dtos;
using System.Net.Http.Json;
using System.Text.Json;

namespace PruebaUPC.Application.Common.Services;

public class DiscountService : IDiscountService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public DiscountService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("DiscountHttp");
        _jsonSerializerOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
    }

    public Task<IEnumerable<DiscountDto>?> GetAllAsync(CancellationToken cancellationToken) => _httpClient.GetFromJsonAsync<IEnumerable<DiscountDto>>("api/v1/Product", _jsonSerializerOptions, cancellationToken);

    public Task<DiscountDto?> GetAsync(string id, CancellationToken cancellationToken) => _httpClient.GetFromJsonAsync<DiscountDto>($"api/v1/Product/{id}", _jsonSerializerOptions, cancellationToken);
}
