using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.OData;
using Teamsheet.Data.Context;

namespace Teamsheet.WebApi.Controllers
{
    public class ActivitiesController : ODataController
    {
        private TeamsheetContext context;

        public ActivitiesController()
        {
            context = new TeamsheetContext();
        }

        public IHttpActionResult Get()
        {
            return Ok(context.Activities.ToList());
        }

    }

}