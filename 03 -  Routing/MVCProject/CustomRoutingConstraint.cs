﻿namespace MVCProject
{
    public class CustomRoutingConstraint : IRouteConstraint
    {
        private static string[] countries = { "uk", "georgia", "monaco" };

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            string segmentValue = values[routeKey] as string ?? "";
            return Array.IndexOf(countries, segmentValue.ToLower()) > -1;
        }
    }
}
