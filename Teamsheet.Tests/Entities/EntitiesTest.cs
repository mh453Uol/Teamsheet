using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Teamsheet.Data.Context;
using Teamsheet.Entities;
using System.Linq;
namespace Teamsheet.Tests.Entities
{
    [TestClass]
    public class EntitiesTest
    {
        public TeamsheetContext _context { get; set; }
        public EntitiesTest()
        {
            this._context = new TeamsheetContext();
        }

        [TestMethod]
        public void AddWeek()
        { 
            /*
            var week = new Week()
            {
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Days = new List<Day>()
                {
                    new Day()
                    {
                        Date = DateTime.Now,     
                        Entries = new List<Entry>()
                        {
                            new Entry
                            {
                                Duration = DateTime.Now,
                                ActivityId = 1,

                            }
                        }
                    }
                }
            };

            _context.Weeks.Add(week);
            _context.SaveChanges();
            */
        }

        [TestMethod]
        public void AddActivities()
        {
            var activites = new List<Activity>()
            {
                new Activity
                {
                    CreatedById = "a8f3a706-6ac1-411c-80b5-c4919ef9e31c",
                    ModifiedById = "a8f3a706-6ac1-411c-80b5-c4919ef9e31c",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Description = "Adminstration talks include emails, telephone calls etc.",
                    Name = "Administration"
                },
                new Activity
                {
                    CreatedById = "a8f3a706-6ac1-411c-80b5-c4919ef9e31c",
                    ModifiedById = "a8f3a706-6ac1-411c-80b5-c4919ef9e31c",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Description = "Learning and development included reading tutorials, attending pluralsight conferences.",
                    Name = "Learning and Development",
                },
                new Activity
                {
                    CreatedById = "a8f3a706-6ac1-411c-80b5-c4919ef9e31c",
                    ModifiedById = "a8f3a706-6ac1-411c-80b5-c4919ef9e31c",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Description = "CRMLive is a project for Mostyn - Warwick chemical",
                    Name = "CRMLive",
                }
            };


            var section = new Section()
            {
                Activities = activites,
                CreatedById = "a8f3a706-6ac1-411c-80b5-c4919ef9e31c",
                ModifiedById = "a8f3a706-6ac1-411c-80b5-c4919ef9e31c",
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                Description = "Test",
                Name = "Test"
            };

            _context.Sections.Add(section);
            _context.SaveChanges();
        }
    }
}
