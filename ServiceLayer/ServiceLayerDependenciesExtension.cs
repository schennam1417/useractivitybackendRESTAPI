using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public static class ServiceLayerDependenciesExtension
    {
        public static void ConfigureService(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationSL, AuthenticationSL>();
            services.AddScoped<ITaskSL, TaskSL>();
        }
    }
}
