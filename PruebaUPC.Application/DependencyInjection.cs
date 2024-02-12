using Microsoft.Extensions.DependencyInjection;
using PruebaUPC.Application.Common.Services;
using PruebaUPC.Infraestructure;
using System.Reflection;

namespace PruebaUPC.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(conf => conf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddInfraestructureServices();

        services.AddHttpClient("DiscountHttp", client =>
        {
            client.BaseAddress = new Uri("https://65c65ca1e5b94dfca2e16db0.mockapi.io/");
        });

        services.AddScoped<IDiscountService, DiscountService>();

        return services;
    }
}
