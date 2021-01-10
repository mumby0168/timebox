using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Timebox.Account.Application.Interfaces.Repositories;
using Timebox.Account.Application.Interfaces.Services;
using Timebox.Account.Application.Services;
using Timebox.Account.Infrastructure;
using Timebox.Account.Infrastructure.Repositories;

namespace Timebox.Account.Api
{
    public static class Extensions
    {
        public static IServiceCollection AddAccountModule(this IServiceCollection services)
        {
            services.AddAccountModuleInfrastructure();
            
            services.AddSingleton<IPasswordService, PBKDF2PasswordService>();
            services.AddSingleton<IEmailService, EmailService>();
            services.AddSingleton<IPhoneService, PhoneService>();
            services.AddSingleton<IAccountService, AccountService>();
            services.AddSingleton<IAccountRepository, AccountRepository>();
            
            return services;
        }
        
        public static IApplicationBuilder UseAccountModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}