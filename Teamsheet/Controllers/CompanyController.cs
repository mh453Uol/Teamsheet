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
    public class CompanyController : Controller
    {
        private TeamsheetContext _context;
        
        public CompanyController()
        {
            _context = new TeamsheetContext();
        }
        

        // GET: Company/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        [HttpPost]
        public ActionResult Create(CompanyForm model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var company = new Company()
            {
                Name = model.Name,
                CreatedById = User.Identity.GetUserId(),
                CreatedDate = DateTime.Now,
                ModifiedById = User.Identity.GetUserId(),
                ModifiedDate = DateTime.Now       
            };

            _context.Companies.Add(company);

            var userId = User.Identity.GetUserId();

            var user = _context.Users.Single(u => u.Id == userId);

            user.CompanyId = company.Id;

            _context.SaveChanges();

            return RedirectToAction("Index","Home");
        }

        public ActionResult CreateEmployee()
        {
            
            return View();

        }


        // GET: Company/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Company/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Company/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Company/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
