using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Teamsheet.Data.Context;
using Teamsheet.Entities;
using Teamsheet.Models;

namespace Teamsheet.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private TeamsheetContext context;

        public HomeController()
        {
            this.context = new TeamsheetContext();
        }
        public ActionResult Index()
        {

            var userId = User.Identity.GetUserId();

            var model = new ProfileViewModel();

            // Looking at the User table. checking userid and company id.
            model.isRegisteredToCompany = context.Users.Any(u => u.Id == userId && u.CompanyId != null);

            model.isManager = context.Companies.Any(c => c.CreatedById == userId);


            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}