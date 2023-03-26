using MVCProject;
using MVCProject.Services;

var builder = WebApplication.CreateBuilder(args);

//Different Lifecycles
//builder.Services.AddSingleton<IResponseFormatter, TextResponseFormatter>();

//Transient - can perform unexpectedly when saved in constructor
//builder.Services.AddTransient<IResponseFormatter, GuidService>();

//Scoped - can perform unexpectedly when accessed directly from ServiceProvider
builder.Services.AddScoped<IResponseFormatter, GuidService>();

var app = builder.Build();

app.UseMiddleware<WeatherMiddleware>();

//Example of Directly creating and passing the service - 1
IResponseFormatter formatter = new TextResponseFormatter();
app.MapGet("middleware/function", async context =>
{
    await formatter.Format(context, "Middleware function: It is snowing in Chicago");
});

//Example of Singleton pattern - 2
app.MapGet("middleware/function", async context =>
{
    await TextResponseFormatter.Singleton.Format(context, "Middleware function: It is snowing in Chicago");
});

//Example of Typebroker pattern - 3
app.MapGet("middleware/function", async context =>
{
    await TypeBroker.Formatter.Format(context, "Middleware function: It is snowing in Chicago");
});

//Example of Dependency Injection - 4

app.MapGet("middleware/function", async (HttpContext context, IResponseFormatter formatter) =>
{
    await formatter.Format(context, "Middleware function: It is snowing in Chicago");
});


//app.MapGet("endpoint/class", WeatherEndpoint.Endpoint);

//Example of endpoint extension - 5
app.MapWeather("endpoint/class");

//app.MapGet("endpoint/function", async (HttpContext context, IResponseFormatter formatter) =>
//{
//    await formatter.Format(context,"Endpoint Function: It is sunny in Philadelphia");
//});


//Example of Test endpoint functionality for scoped - 6
app.MapGet("endpoint/function", async (HttpContext context, IResponseFormatter formatter) =>
{
    await formatter.Format(context, "Endpoint Function: It is sunny in Philadelphia\n");
    await new CustomScopedService().CustomScopedOutput(context);
});

app.Run();
