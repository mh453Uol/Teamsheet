using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Teamsheet.Data.Context;
using Teamsheet.Entities;

namespace Teamsheet.Controllers
{
    public class HomeController : Controller
    {
        private TeamsheetContext context;

        public HomeController()
        {
            this.context = new TeamsheetContext();
        }
        public ActionResult Index()
        {
            context.Sections.Where(s => s.Id == 1);
            return View();
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