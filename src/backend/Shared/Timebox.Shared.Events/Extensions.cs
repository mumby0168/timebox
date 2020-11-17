using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Timebox.Modules.Events.Interfaces;
using Timebox.Shared.Modules;

namespace Timebox.Modules.Events
{
    public static class Extensions
    {
        public static IServiceCollection AddDomainEvents(this IServiceCollection services)
        {
            services.AddSingleton<IModuleEventRegistry, ModuleEventRegistry>();
            services.AddSingleton<IEventSubscriber, ModuleEventSubscriber>();
            services.AddSingleton<IEventPublisher, ModuleEventPublisher>();
            services.AddSingleton<IModuleOwnerKeyService, ModuleOwnerKeyService>();

            return services;
        }

        public static IServiceCollection AddDomainEventHandlers(this IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();
            services.Scan(selector => selector.FromAssemblies(assembly)
                .AddClasses(c => c.AssignableTo(typeof(IDomainEventHandler<>))).AsImplementedInterfaces().WithTransientLifetime());
            return services;
        }


        public static IApplicationBuilder UseDomainEvents(this IApplicationBuilder app, Action<IEventSubscriber> configure = null)
        {
            configure?.Invoke(app.ApplicationServices.GetRequiredService<IEventSubscriber>());
            return app;
        }
    }
}