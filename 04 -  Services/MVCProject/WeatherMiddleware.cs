using MVCProject.Services;

namespace MVCProject
{
    //Initial Version
    //public class WeatherMiddleware
    //{
    //    private RequestDelegate next;
    //    public WeatherMiddleware(RequestDelegate nextDelegate)
    //    {
    //        next = nextDelegate;
    //    }

    //    public async Task Invoke(HttpContext context)
    //    {
    //        if (context.Request.Path == "/middleware/class")
    //            await context.Response.WriteAsync("Middleware Class: It is raining in London");
    //        else
    //            await next(context);
    //    }
    //}

    //Version using DI
    //public class WeatherMiddleware
    //{
    //    private RequestDelegate next;
    //    private IResponseFormatter formatter;
    //    public WeatherMiddleware(RequestDelegate nextDelegate, IResponseFormatter respFormatter)
    //    {
    //        next = nextDelegate;
    //        formatter = respFormatter;
    //    }

    //    public async Task Invoke(HttpContext context)
    //    {
    //        if (context.Request.Path == "/middleware/class")
    //            await formatter.Format(context,"Middleware Class: It is raining in London");
    //        else
    //            await next(context);
    //    }
    //}

    //Version using DI for transient example
    public class WeatherMiddleware
    {
        private RequestDelegate next;
        public WeatherMiddleware(RequestDelegate nextDelegate)
        {
            next = nextDelegate;
        }

        public async Task Invoke(HttpContext context, IResponseFormatter formatter)
        {
            if (context.Request.Path == "/middleware/class")
                await formatter.Format(context, "Middleware Class: It is raining in London");
            else
                await next(context);
        }
    }
}
