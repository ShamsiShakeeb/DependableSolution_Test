using BLL.Service;
using DAL.DAL.DependencyResolve;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.BLL.DependencyResolve
{
    public static class Resolver
    {
        public static IServiceCollection ServiceDependency(this IServiceCollection services)
        {
            services.AdoDependency();
            services.AddSingleton<IOrderPurchaseService, OrderPurchaseService>();
            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<IQuantityService, QuantityService>();
            return services;
        }
    }
}
