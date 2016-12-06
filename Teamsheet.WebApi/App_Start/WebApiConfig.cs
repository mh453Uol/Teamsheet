﻿using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using Teamsheet.Entities;

namespace Teamsheet.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            /*
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            */

            config.MapODataServiceRoute("ODataRoute", "odata", GetEdmModel());
            config.EnsureInitialized();
    }
        private static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.Namespace = "Teamsheet";
            builder.ContainerName = "TeamsheetContainer";
            //Add more entity sets here if you want to use them in your api controllers.
            builder.EntitySet<Activity>("Activities");
            builder.EntitySet<Company>("Companies");

            return builder.GetEdmModel();
        }
    }
}
