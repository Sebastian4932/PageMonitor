using Microsoft.Extensions.DependencyInjection;
using PageMonitor.Aplication.Interfaces;
using PageMonitor.Aplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageMonitor.Aplication
{
    public static class DefaultDIConfiguration
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICurrentAccountProvider, CurrentAccountProvider>();
            return services;
        }
    }
}
