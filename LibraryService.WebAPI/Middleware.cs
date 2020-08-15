using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LibraryService.WebAPI
{
    public class Middleware
    {

        public Middleware(RequestDelegate next)
        {
           
        }

        public async Task InvokeAsync(HttpContext context)
        {
          
        }
    }
}
