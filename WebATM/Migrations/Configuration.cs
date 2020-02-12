namespace WebATM.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebATM.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebATM.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WebATM.Models.ApplicationDbContext";
        }

        /// <summary>
        /// Voegt admin toe aan 
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(WebATM.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!context.Users.Any(t => t.UserName == "admin@mvcatm.com")) 
            {
                ApplicationUser user = new ApplicationUser { Email = "admin@live.nl", UserName = "admin@live.nl" };
                userManager.Create(user, "passw0rd");

                CheckingAccount service = new CheckingAccount()
                {
                    Voornaam = user.UserName,
                    Achternaam = user.UserName,
                    ApplicationUserId = user.Id,
                    TelefoonNummer = "00000",
                    Balans = 1000,
                };

                context.Roles.AddOrUpdate(r => r.Name, new IdentityRole { Name = "Admin" });
                context.SaveChanges();

                userManager.AddToRole(user.Id, "Admin");
            }

        }
    }
}
