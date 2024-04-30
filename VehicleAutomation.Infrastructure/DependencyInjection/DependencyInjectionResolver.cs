using Microsoft.Extensions.DependencyInjection;
using VehicleAutomation.Data.Repository;
using VehicleAutomation.Domain.IRepository;
using VehicleAutomation.Domain.IService;
using VehicleAutomation.Infrastructure.Services;

namespace VehicleAutomation.Infrastructure.DependencyInjection
{
    public static class DependencyInjectionResolver
    {
        public static IServiceCollection AppServices(this IServiceCollection services)
        {
            // repositories
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            // services
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IInventoryService, InventoryService>();

            return services;
        }
    }
}
