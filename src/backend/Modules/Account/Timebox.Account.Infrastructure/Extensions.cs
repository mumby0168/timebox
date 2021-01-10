using System;
using Convey;
using Convey.Persistence.MongoDB;
using Microsoft.Extensions.DependencyInjection;
using Timebox.Account.Infrastructure.Documents;

namespace Timebox.Account.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddAccountModuleInfrastructure(this IServiceCollection services)
        {
            services.AddConvey().AddMongo().AddMongoRepository<AccountDocument, Guid>("accounts");
            return services;
        }
    }
}