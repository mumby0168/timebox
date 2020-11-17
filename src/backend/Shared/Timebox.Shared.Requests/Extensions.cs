using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Timebox.Modules.Requests.Interfaces;

namespace Timebox.Modules.Requests
{
    public static class Extensions
    {
        public static IServiceCollection AddRequests(this IServiceCollection services)
        {
            services.AddSingleton<IRequestRegistry, ModuleRequestRegistry>();
            services.AddSingleton<IRequestSubscriber, ModuleRequestSubscriber>();
            services.AddSingleton<IRequestClient, ModuleRequestClient>();
            services.AddSingleton<IRequestClient, ModuleRequestClient>();
            
            return services;
        }

        public static IServiceCollection AddRequestHandlers(this IServiceCollection services)
        {    
            var assembly = Assembly.GetCallingAssembly();
            services.Scan(selector => selector.FromAssemblies(assembly)
                .AddClasses(c => c.AssignableTo(typeof(IRequestHandler<>))).AsImplementedInterfaces().WithTransientLifetime());
            return services;
        }

        public static IRequestSubscriber UseRequests(this IApplicationBuilder app)
        {
            return app.ApplicationServices.GetRequiredService<IRequestSubscriber>(); 
        }

    }
}