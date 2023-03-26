namespace MVCProject.Services
{
    public class CustomScopedService
    {
        public Task CustomScopedOutput(HttpContext context)
        {
            IResponseFormatter? formatter = context.RequestServices.GetService<IResponseFormatter>();
            return formatter is not null ? WeatherEndpoint.Endpoint(context, formatter) : Task.CompletedTask;
        }
    }
}
