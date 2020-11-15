using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Timebox.Shared.DomainEvents;
using Timebox.Shared.DomainEvents.Interfaces;

namespace Timebox.Api
{
    [ModuleOwner("Test")]
    public class SampleMessage : IDomainEvent
    {
        public string Message { get; set; }
    }

    public class SampleMessageHandler : IDomainEventHandler<SampleMessage>
    {
        public Task HandleAsync(SampleMessage domainEvent)
        {
            if (domainEvent is null)
            {
                throw new InvalidCastException();
            }

            return Task.CompletedTask;
        }
    }
    
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IDomainEventHandler<SampleMessage>, SampleMessageHandler>();
            services.AddMessageBroker();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMessageBroker(subscriber => subscriber.Subscribe<SampleMessage>());

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });

            var broker = app.ApplicationServices.GetRequiredService<IMessageBroker>();
            broker.PublishDomainEventAsync(new Timebox.Shared.SampleMessage {Message = "Hello World"}).Wait();
        }
    }
}
