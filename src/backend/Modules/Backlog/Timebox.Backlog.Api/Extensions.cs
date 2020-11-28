using System;
using System.Reflection;
using Convey;
using Convey.Persistence.MongoDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Timebox.Backlog.Application.Interfaces.Repositories;
using Timebox.Backlog.Application.Interfaces.Services;
using Timebox.Backlog.Application.Services;
using Timebox.Backlog.Domain.Aggregates;
using Timebox.Backlog.Infastructure.Documents;
using Timebox.Backlog.Infastructure.Repository;
using Timebox.Backlog.Infastructure.Services;

namespace Timebox.Backlog.Api
{
    public static class Extensions
    {
        public static IServiceCollection AddBacklogModule(this IServiceCollection services)
        {
            services.AddControllers()
                .AddApplicationPart(Assembly.GetExecutingAssembly()).AddControllersAsServices();
            services
                .AddConvey()
                .AddMongo()
                .AddMongoRepository<BacklogDocument, Guid>("backlogs");
            services.AddSingleton<IBacklogService, BacklogService>();
            services.AddTransient<IBacklogRepository, MongoBacklogRepository>();
            services.AddTransient<IBacklogAggregate, BacklogAggregate>();
            services.AddSingleton<IUserService, UserService>();
            return services;
        }

        public static IApplicationBuilder UseBacklogModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
