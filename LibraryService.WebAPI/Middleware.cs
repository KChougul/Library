using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LibraryService.WebAPI
{
    public class Middleware
    {
        public int counter = 0;
        private readonly RequestDelegate nextRequest;

        public Middleware(RequestDelegate next)
        {
           nextRequest = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            
          counter = counter + 1;
            context.Response.OnStarting(state=>{
                var httpContext = (HttpContext)state;
            httpContext.Response.Header.Add("requestCounter", new[]{counter});
                return Task.CompletedTask;
            },context);
            await nextRequest(context);
        }
    }
}
