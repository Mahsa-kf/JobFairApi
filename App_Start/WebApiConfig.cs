using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JobFairApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services


            // Enable Cross-Orgin
            EnableCorsAttribute cros = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cros);

            // Return Json instead of XML
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            //Solve cycles refrance issue 
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

            // Format All DateTimes to yyyy-MM-dd  
            var dateFormatter = new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd" };
            config.Formatters.JsonFormatter.SerializerSettings.Converters.Add(dateFormatter);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
