using AutoMapper;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using JiraProgressTracker.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace JiraProgressTracker
{
    public static class WebApiConfig
    {
        

        public static void Register(HttpConfiguration config)
        {
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;

            Mapper.Initialize(c => c.AddProfile<MappingProfile>());

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
