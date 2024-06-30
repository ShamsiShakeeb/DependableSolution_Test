using DAL.Ado;
using DAL.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.DAL.DependencyResolve
{
    public static class Resolver
    {
        public static IServiceCollection AdoDependency(this IServiceCollection services)
        {
            services.AddSingleton<IAdoProperties, AdoProperties>();
            services.AddSingleton<IPurchaseOrderContext, PurchaseOrderContext>();
            return services;
        }
    }
}
