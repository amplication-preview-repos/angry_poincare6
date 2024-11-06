using Puma.APIs;

namespace Puma;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IPurchaseOrdersService, PurchaseOrdersService>();
        services.AddScoped<IPurchaseRequestsService, PurchaseRequestsService>();
        services.AddScoped<ITendersService, TendersService>();
        services.AddScoped<IVendorsService, VendorsService>();
    }
}
