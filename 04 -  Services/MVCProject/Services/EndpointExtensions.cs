namespace MVCProject.Services
{
    public static class EndpointExtensions
    {
        //public static void MapWeather(this IEndpointRouteBuilder app, string path)
        //{
        //    IResponseFormatter formatter = app.ServiceProvider.GetRequiredService<IResponseFormatter>();
        //    app.MapGet(path, context => WeatherEndpoint.Endpoint(context, formatter));
        //}

        //Version 2 - For scoped services
        public static void MapWeather(this IEndpointRouteBuilder app, string path)
        {
            app.MapGet(path, context =>
            {
                IResponseFormatter? formatter = context.RequestServices.GetService<IResponseFormatter>();
                return formatter is not null ? WeatherEndpoint.Endpoint(context, formatter) : Task.CompletedTask;
            });
        }
    }
}