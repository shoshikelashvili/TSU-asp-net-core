using Microsoft.Extensions.Options;
using MVCProject;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<CountryOptions>(options =>
{
    options.Name = "Georgia";
    options.Population = "~4Mil";
});

var app = builder.Build();

//Example of Custom middleware using Lambda expression - 1
app.Use(async (context, next) =>
{
    if (context.Request.Query.ContainsKey("custom"))
        await context.Response.WriteAsync("<h1>Lambda-based Middleware</h1> \n");

    await next();
});

//Example of Custom middleware using Classes - 2
app.UseMiddleware<MVCProject.CustomMiddleware>();


//Example of Custom middleware Return path - 3
app.Use(async (context, next) =>
{
    await next();
    if (context.Request.Query.ContainsKey("custom"))
        await context.Response.WriteAsync("<h1>Middleware output during return path</h1> \n");
});


//Example of a Pipeline Branch - 5
app.Map("/branch", branch =>
{
    branch.UseMiddleware<MVCProject.CustomMiddleware>();

    branch.Use(async (HttpContext context, Func<Task> next) =>
    {
        await context.Response.WriteAsync("<h1>Branch Middleware</h1>\n");
        await next();
    });
});

//Example of a Pipeline Branch that can return to main branch - 7
app.UseWhen(context => context.Request.Path.ToString().Contains("/branch2"), branch =>
{
    branch.Use(async (HttpContext context, Func<Task> next) =>
    {
        await context.Response.WriteAsync("<h1>Branch Middleware that doesn't terminate</h1>\n");
        await next();
    });
});

//Example of Custom middleware short circuiting - 4
app.Use(async (context, next) =>
{
    if (context.Request.Query.ContainsKey("custom"))
        await context.Response.WriteAsync("<h1>Middleware short-circuiting</h1> \n");
    else
        await next();
});


//Example of a Pipeline Branch with a predicate - 6
//app.MapWhen(context => context.Request.Query.ContainsKey("predicateKey"), branch =>
//{
//    //...
//});

//Example of Middleware configured with a service
app.UseMiddleware<CountryMiddleware>();

//Example of a Terminal middleware - 8
app.Run(async context =>
{
    if (context.Request.Query.ContainsKey("terminal"))
        await context.Response.WriteAsync("<h1>Example of a terminal middleware</h1> \n");
});

app.Run();