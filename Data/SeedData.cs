using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebApp1.Models;

namespace WebApp1.Data
{
    public class SeedData
    {
        public static async Task Initialize(ApplicationDbContext context,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)
        {

            context.Database.EnsureCreated();

            string adminRole = "Admin";
            string userRole = "User";
            string password4all = "P@$$w0rd";

            if (await roleManager.FindByNameAsync(adminRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }

            if (await roleManager.FindByNameAsync(userRole) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(userRole));
            }

            if (await userManager.FindByNameAsync("aa@aa.aa") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "aa@aa.aa",
                    Email = "aa@aa.aa",
                    UntilDate = new DateTime(2050, 12, 25)
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password4all);
                    await userManager.AddToRoleAsync(user, adminRole);
                }
            }

            if (await userManager.FindByNameAsync("mm@mm.mm") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "mm@mm.mm",
                    Email = "mm@mm.mm",
                    UntilDate = new DateTime(2023, 12, 25)
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password4all);
                    await userManager.AddToRoleAsync(user, userRole);
                }
            }
        }
    }
}