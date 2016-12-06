using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.OData;
using Teamsheet.Data.Context;
using Teamsheet.Entities;
using Teamsheet.Web.Models;

namespace Teamsheet.WebApi.Controllers
{
    public class CompaniesController : ODataController
    {
        private TeamsheetContext context;

        public CompaniesController()
        {
            context = new TeamsheetContext();
        }
        public IHttpActionResult Get()
        {
            return Ok("WORKING");
        }

        public IHttpActionResult Post(Company company)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok();
        }


    }
}