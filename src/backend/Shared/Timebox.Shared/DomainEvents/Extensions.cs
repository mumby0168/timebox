using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Timebox.Shared.DomainEvents.Interfaces;

namespace Timebox.Shared.DomainEvents
{
    public static class Extensions
    {
        public static IServiceCollection AddMessageBroker(this IServiceCollection services)
        {
            services.AddSingleton<IModuleMessageRepository, ModuleMessageRepository>();
            services.AddSingleton<IMessageSubscriber, ModuleMessageSubscriber>();
            services.AddSingleton<IMessageBroker, ModuleMessageBroker>();
            services.AddSingleton<IMessageKeyService, MessageKeyService>();

            return services;
        }
        
        

        public static IApplicationBuilder UseMessageBroker(this IApplicationBuilder app, Action<IMessageSubscriber> configure = null)
        {
            configure?.Invoke(app.ApplicationServices.GetRequiredService<IMessageSubscriber>());
            return app;
        }
    }
}