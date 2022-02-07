using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisCom.Aplicacao.Configuration
{
    public static class AppConfig
    { 
        public static IServiceCollection AddAppConfig(this IServiceCollection services)
        {
            return services;
        }
    }
}
