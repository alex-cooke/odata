using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Extensions;
using Microsoft.OData;
using Microsoft.OData.Edm;
using System.Web.OData.Builder;
using model;

namespace api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.MapODataServiceRoute("ODataRoute", "odata", GetEdmMode());

            config.EnsureInitialized();
        }

        private static IEdmModel GetEdmMode() {

            var builder = new ODataConventionModelBuilder();
            builder.Namespace = "App";
            builder.ContainerName = "AppContainer";

            builder.EntitySet<Person>("Person");
            builder.EntitySet<Experience>("Experience");

            return builder.GetEdmModel();
        }
    }
}
