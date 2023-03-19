using Microsoft.AspNetCore.Authentication;

namespace MVCProject
{
    public class Population
    {
        private RequestDelegate next;

        public Population()
        {
        }
        public Population(RequestDelegate nextDelegate)
        {
            next = nextDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            var parts = context.Request.Path.ToString().Split("/", StringSplitOptions.RemoveEmptyEntries);
            if(parts.Length == 2 && parts[0] == "population")
            {
                var city = parts[1];
                string population = default;

                switch(city.ToLower())
                {
                    case "london":
                        population = "8 Million";
                        break;
                    case "tbilisi":
                        population = "4 Million";
                        break;
                    case "monaco":
                        population = "40 Thousand";
                        break;
                }
                if (!string.IsNullOrWhiteSpace(population))
                {
                    await context.Response.WriteAsync($"City: {city}, Population: {population}");
                    return;
                }
            }
            if (context is not null)
                await next(context);
        }

        public static async Task Endpoint(HttpContext context)
        {
            string city = context.Request.RouteValues["city"] as string ?? "tbilisi";
            string population = default;
            switch((city ?? "").ToLower())
            {
                case "london":
                    population = "8 Million";
                    break;
                case "tbilisi":
                    population = "4 Million";
                    break;
                case "monaco":
                    population = "40 Thousand";
                    break;
            }
            if (!string.IsNullOrWhiteSpace(population))
                await context.Response.WriteAsync($"City: {city}, Population: {population}");
            else 
                context.Response.StatusCode = StatusCodes.Status404NotFound;
        }
    }

    public class Capital
    {
        private RequestDelegate next;

        public Capital()
        {
        }

        public Capital(RequestDelegate nextDelegate)
        {
            next = nextDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            var parts = context.Request.Path.ToString().Split("/", StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 2 && parts[0] == "capital")
            {
                var country = parts[1];
                string capital = default;

                switch (country.ToLower())
                {
                    case "uk":
                        capital = "London";
                        break;
                    case "georgia":
                        capital = "Tbilsi";
                        break;
                    //Example of dynamic URL generation
                    case "monaco":
                        var generator = context.RequestServices.GetService<LinkGenerator>();
                        string url = generator?.GetPathByRouteValues(context, "population", new { city = country });
                        if (!string.IsNullOrWhiteSpace(url))
                            context.Response.Redirect(url);
                        return;
                }
                if (!string.IsNullOrWhiteSpace(capital))
                {
                    await context.Response.WriteAsync($"{capital} is the capital of {country}");
                    return;
                }
            }

            if(context is not null)
                await next(context);
        }

        //Refactored version of Capital class method
        public static async Task Endpoint(HttpContext context)
        {
            string capital = default;
            string country = context.Request.RouteValues["country"] as string;
            switch((country ?? "").ToLower())
            {
                case "uk":
                    capital = "London";
                    break;
                case "georgia":
                    capital = "Tbilsi";
                    break;
                case "monaco":
                    context.Response.Redirect($"/population/{country}");
                    return;
            }

            if (!string.IsNullOrWhiteSpace(capital))
                await context.Response.WriteAsync($"{capital} is the capital of {country}");
            else
                context.Response.StatusCode = StatusCodes.Status404NotFound;
        }
    }
}
