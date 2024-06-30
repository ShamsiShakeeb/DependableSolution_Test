using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Excel;

namespace Utility.Utility.DependencyResolve
{
    public static class Resolver
    {
        public static IServiceCollection UtilityResolver(this IServiceCollection services)
        {
            services.AddSingleton<IExcelServiceUtility, ExcelServiceUtility>();
            return services;
        }
    }
}
