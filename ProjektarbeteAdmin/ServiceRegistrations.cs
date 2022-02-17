using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektarbeteAdmin
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProjectarbeteApi, ProjectarbeteAPI>();
            Menu.MenuConfigure(services.);
            

            return services;
        }
    }
}



