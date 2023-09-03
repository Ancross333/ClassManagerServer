using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManagerServer.EventHandlers
{
    public static class EventHandlersModule
    {
        public static void RegisterDependencies(IServiceCollection services, IConfiguration configuration)
        {
            _ = services;
            _ = configuration;
        }
    }
}
