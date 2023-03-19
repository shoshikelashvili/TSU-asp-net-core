using MVCProject;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RouteOptions>(opts =>
{
    opts.ConstraintMap.Add("countryName", typeof(CustomRoutingConstraint));
});

var app = builder.Build();

//Example of URL Routing with middlewares - 1
app.UseMiddleware<Population>();
app.UseMiddleware<Capital>();

//Example of Built in Routing - 2
app.UseRouting();

//Example of getting endpoint data after endpoint selectioon - 19
//app.Use(async (context, next) =>
//{
//    Endpoint endp = context.GetEndpoint();
//    if (endp is not null)
//        await context.Response.WriteAsync($"{endp.DisplayName} endpoint has been selected\n");
//    else
//        await context.Response.WriteAsync($"No endpoint has been selected\n");
//    await next();
//});

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("routing", async context =>
    {
        await context.Response.WriteAsync("Request was routed");
    });

    //Example of Routing in combination with middlewares - 3
    endpoints.MapGet("capital/uk", new Capital().Invoke);

});


//Example of directly using the mapping method, without the need to preconfigure other middlewares - 4
//When defining routes directly, requests are always forwarded in the pipeline, so no terminal middleware should follow 
app.MapGet("capital/uk", new Capital().Invoke);


//Example of Segment variables - 5
app.MapGet("{first}/{second}/{third}", async context =>
{
    await context.Response.WriteAsync($"Request was routed with segment variables\n");
    foreach (var entry in context.Request.RouteValues)
        await context.Response.WriteAsync($"{entry.Key} : {entry.Value}\n");
});


//Example of routing scoring system - 6
app.MapGet("one/two/three", async context =>
{
    await context.Response.WriteAsync($"Request was routed with static values\n");
    foreach (var entry in context.Request.RouteValues)
        await context.Response.WriteAsync($"{entry.Key} : {entry.Value}\n");
});

//Example of refactored middleware routing - 7
app.MapGet("capital/{country}", Capital.Endpoint);

//Example of routing with Name metadata - 8
app.MapGet("population/{city}", Population.Endpoint).WithMetadata(new RouteNameMetadata("population"));

//Example of dynamic name routing in action - 9
app.MapGet("size/{city}", Population.Endpoint).WithMetadata(new RouteNameMetadata("population"));

//Example of routing pitfalls - 10
//example/redgreen
//example/redredgreen
app.MapGet("example/red{color}", async context => { await context.Response.WriteAsync("Buggy route was matched!"); });

//Example of default values - 11
app.MapGet("capital/{country=Georgia}", Capital.Endpoint);

//Example of optional value - 12
app.MapGet("size/{city?}", Population.Endpoint).WithMetadata(new RouteNameMetadata("population"));

//Example of catchall variable - 13
app.MapGet("{first}/{second}/{*catchall}", async context =>
{
    await context.Response.WriteAsync($"Request was routed with catchall values\n");
    foreach (var entry in context.Request.RouteValues)
        await context.Response.WriteAsync($"{entry.Key} : {entry.Value}\n");
});

//Example of constrained route - 14
app.MapGet("{first:int}/{second:bool}", async context =>
{
    await context.Response.WriteAsync($"Request was routed with constrained values\n");
    foreach (var entry in context.Request.RouteValues)
        await context.Response.WriteAsync($"{entry.Key} : {entry.Value}\n");
});

//Example of combined constraints - 15
app.MapGet("{first:alpha:length(3)}/{second:bool}", async context =>
{
    await context.Response.WriteAsync($"Request was routed with combined constrained values\n");
    foreach (var entry in context.Request.RouteValues)
        await context.Response.WriteAsync($"{entry.Key} : {entry.Value}\n");
});

//Example of a fallback route - 16
app.MapFallback(async context =>
{
    await context.Response.WriteAsync("Routed to fallback endpoint");
});

//Example of custom constraint - 17
app.MapGet("capital/{country:countryName}", Capital.Endpoint);


//Example of ambiguous endpoints - 18
app.MapGet("{number:int}", async context =>
{
    await context.Response.WriteAsync("Routed to int endpoint");
}).Add(b => ((RouteEndpointBuilder)b).Order = 1);

app.MapGet("{number:double}", async context =>
{
    await context.Response.WriteAsync("Routed to double endpoint");
}).Add(b => ((RouteEndpointBuilder)b).Order = 2); ;

app.Run();