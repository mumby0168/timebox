using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Timebox.Backlog.Api
{
    public static class Extensions
    {
        public static IServiceCollection AddBacklogModule(this IServiceCollection services)
        {
            return services;
        }

        public static IApplicationBuilder UseBacklogModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
