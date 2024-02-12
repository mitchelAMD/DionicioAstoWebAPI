using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PruebaUPC.Infraestructure.Persistence;
using PruebaUPC.Infraestructure.Repositories;

namespace PruebaUPC.Infraestructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructureServices(this IServiceCollection services)
    {
        services.AddScoped<IProductRepository, ProductRepository>();

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.UseSqlite("Data Source=.\\Database\\products.db");
        });

        return services;
    }
}
