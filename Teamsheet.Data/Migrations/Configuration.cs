namespace Teamsheet.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Teamsheet.Data.Context.TeamsheetContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Teamsheet.Data.Context.TeamsheetContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            // Add seed users
            if (!context.Users.Any(u => u.UserName == "test@someprovider.com"))
            {

                var user = new ApplicationUser
                {
                    Name = "TestUser",
                    UserName = "test@someprovider.com",
                    Email = "test@someprovider.com"
                };

                userManager.Create(user, "Password123!");
            }

            // Add seed users with roles
            if (!context.Roles.Any(r => r.Name == "Manager"))
            {
                //Create a manager role
                roleManager.Create(new IdentityRole { Name = "Manager" });
            }

            if(!context.Roles.Any(r => r.Name == "Employee"))
            { 
                //Create a employee role
                roleManager.Create(new IdentityRole { Name = "Employee" });
            }

            //Create a user with roles of manager
            if(!context.Users.Any(u => u.UserName == "test2@someprovider.com"))
            {
                var user = new ApplicationUser
                {
                    Name = "TestUser2",
                    UserName = "test2@someprovider.com",
                    Email = "test2@someprovider.com"
                };

                userManager.Create(user, "Password123!");

                //Assign TestUser2 to Manager role
                userManager.AddToRole(user.Id, "Manager");
            }

            if(!context.Users.Any(u => u.UserName == "test3@someprovide.com"))
            {
                var user = new ApplicationUser
                {
                    Name = "TestUser3",
                    UserName = "test3@someprovide.com",
                    Email = "test3@someprovide.com"
                };

                userManager.Create(user, "Password123!");
                userManager.AddToRole(user.Id, "Employee");    
            }
        }
    }
}
