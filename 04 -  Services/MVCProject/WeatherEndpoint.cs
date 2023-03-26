using MVCProject.Services;

namespace MVCProject
{
    //Version 1
    //public class WeatherEndpoint
    //{
    //    public static async Task Endpoint(HttpContext context)
    //    {
    //        await context.Response.WriteAsync("Endpoint Class: It is cloudy in Milan");
    //    }
    //}

    //Version 2 Using DI
    //Drawback of this being that we'd have to get the formatter manually every time
    //public class WeatherEndpoint
    //{
    //    public static async Task Endpoint(HttpContext context)
    //    {
    //        IResponseFormatter formatter = context.RequestServices.GetRequiredService<IResponseFormatter>();
    //        await formatter.Format(context, "Endpoint Class: It is cloudy in Milan");
    //    }
    //}

    //Version 3 Adapter Function
    public static class WeatherEndpoint
    {
        public static async Task Endpoint(HttpContext context, IResponseFormatter formatter)
        {
            await formatter.Format(context, "Endpoint Class: It is cloudy in Milan");
        }
    }
}