using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Timebox.Shared.Extensions
{
    public static class HttpContextExtensions
    {
        public static Task BadRequestAsync<T>(this HttpContext context, T content)
        {
            context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(content));
        }

        public static Task BadRequestAsync(this HttpContext context, string content)
        {
            context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
            return context.Response.WriteAsync(content);
        }
        
    }
}