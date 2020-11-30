using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Timebox.Backlog.Domain.Exceptions;
using Timebox.Shared.Extensions;
using Timebox.Shared.Kernel.Dtos;

namespace Timebox.Backlog.Api.Middleware
{
    public class BacklogModuleExceptionHandler : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (EmptyBacklogTitleException e)
            {
                await context.BadRequestAsync(new TimeboxErrorDto(e.Message, e.ErrorCode));
            }
        }
    }
}