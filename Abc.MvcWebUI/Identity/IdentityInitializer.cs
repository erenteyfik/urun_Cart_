using Abc.MvcWebUI.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.Identity
{
    //database yoksa oluştursun sadece
    public class IdentityInitializer : CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            // Rolleri
            if (!context.Roles.Any(i => i.Name == "admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "admin", Description = "admin rolü" };
                manager.Create(role);
            }

            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "user", Description = "user rolü" }; ;
                manager.Create(role);
            }


            // User
            if (!context.Users.Any(i => i.Name == "teyfikeren"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "teyfik", Surname = "eren", UserName = "teyfikeren", Email = "teyfikeren@gmail.com" };

                manager.Create(user, "1234567");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
                //bir kullanıcı hem user hem admin
            }

            if (!context.Users.Any(i => i.Name == "mahmuteren"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "Mahmut", Surname = "eren", UserName = "mahmuteren", Email = "mahmuteren@gmail.com" };

                manager.Create(user, "1234567");
                manager.AddToRole(user.Id, "user");
                //sadece usesr
            }



            base.Seed(context);
        }
    }
}