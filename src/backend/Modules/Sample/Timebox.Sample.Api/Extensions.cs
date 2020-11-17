using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Timebox.Modules.Events;
using Timebox.Modules.Requests;
using Timebox.Modules.Requests.Interfaces;
using Timebox.Sample.Api.Handlers.Requests;
using Timebox.Shared.Module.Requests.Requests.Sample;

namespace Timebox.Sample.Api
{
    public static class Extensions
    {
        public static IServiceCollection AddSampleModule(this IServiceCollection services)
        {
            services.AddRequests()
                .AddRequestHandlers();
            services.AddDomainEvents()
                .AddDomainEventHandlers();
            return services;
        }

        public static IApplicationBuilder UseSampleModule(this IApplicationBuilder app)
        {
            app.UseDomainEvents();
            app.UseRequests()
                .Subscribe<GetSampleModuleName>();

            var client = app.ApplicationServices.GetRequiredService<IRequestClient>();
            var task = client.GetAsync<SampleNameDto, GetSampleModuleName>(new GetSampleModuleName());
            task.Wait();
            var name = task.Result;

            return app;
        }
    }
}
