using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Web.OData.Extensions;
using Microsoft.OData.Edm;
using System.Web.OData.Builder;
using Teamsheet.Entities;
using Teamsheet.Models;

namespace Teamsheet.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            //We set up the odata route here
            //1. Give it a name
            //2. Set up a prefix so the url would look like http://yoursite/odata/...
            //3. Set up what entity set (dbset) to allow users to interfact with.
            config.MapODataServiceRoute("ODataRoute", "odata", GetEdmModel());
        }

        private static IEdmModel GetEdmModel()
        {
            //We specify which entity set to show and create a Edm model
            var builder = new ODataConventionModelBuilder();
            builder.Namespace = "Teamsheet";
            builder.ContainerName = "TeamsheetContainer";
            //Entity set to allow interaction with
            builder.EntitySet<Activity>("Activities");
            builder.EntitySet<Company>("Companies");
            builder.EntitySet<Entry>("Entries");
            builder.EntitySet<ApplicationUser>("Users");
            builder.EntitySet<Section>("Sections");
            builder.EntitySet<Week>("Weeks");
            return builder.GetEdmModel();
        }
    }
}
