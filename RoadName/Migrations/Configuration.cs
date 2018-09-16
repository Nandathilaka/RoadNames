namespace RoadName.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Claims;

    internal sealed class Configuration : DbMigrationsConfiguration<RoadName.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RoadName.Models.ApplicationDbContext context)
        {
            var userStrore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStrore);


            if (!context.Users.Any(t => t.UserName == "admin@gmail.com"))
            {
                var user = new ApplicationUser { UserName = "admin@gmail.com", Email = "admin@gmail.com", FirstName = "Admin", LastName = "Chamika" };
                userManager.Create(user, "passW0rd!");
                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Admin" });
                context.SaveChanges();

                userManager.AddClaim(user.Id, new Claim(ClaimTypes.GivenName, "Admin"));
                userManager.AddToRole(user.Id, "Admin");
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
