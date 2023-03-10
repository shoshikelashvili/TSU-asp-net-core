using Microsoft.Extensions.Options;

namespace MVCProject
{
    public class CustomMiddleware
    {
        private RequestDelegate next;

        public CustomMiddleware(RequestDelegate nextDelegate)
        {
            next = nextDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Query.ContainsKey("custom"))
            {
                await context.Response.WriteAsync("<h1>Class-based Middleware</h1> \n");
            }
            await next(context);
        }
    }

    public class CountryMiddleware
    {
        private RequestDelegate next;
        private CountryOptions options;

        public CountryMiddleware(RequestDelegate nextDelegate, IOptions<CountryOptions> opts)
        {
            next = nextDelegate;
            options = opts.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            if(context.Request.Path == "/country")
                await context.Response.WriteAsync($"<h1>Country is {options.Name} and the population is {options.Population}");
        }
    }
}