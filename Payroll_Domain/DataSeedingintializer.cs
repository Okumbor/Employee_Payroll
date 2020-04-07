using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Payroll_Domain
{
    public static class DataSeedingintializer
    {
        public static async Task IdentityRoleandUserSeeding(UserManager<IdentityUser> userManager,
                                                            RoleManager<IdentityRole> roleManager)
        {
            string[] roles = {"Admin", "Manager", "Staff"};
            foreach (var role in roles)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);
                if (!roleExist )
                {
                    IdentityResult result = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            if (userManager.FindByEmailAsync("sharkcity400@gmail.com").Result==null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "sharkcity400@gmail.com",
                    Email = "sharkcity400@gmail.com",
                };
                IdentityResult identityResult = userManager.CreateAsync(user, "Password1").Result;
                if (identityResult.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

            if (userManager.FindByEmailAsync("John.Gray@gmail.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "John.Gray@gmail.com",
                    Email = "John.Gray@gmail.com",
                };
                IdentityResult identityResult = userManager.CreateAsync(user, "Password1").Result;
                if (identityResult.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Manager").Wait();
                }
            }

            if (userManager.FindByEmailAsync("Sunday.Fidelis@gmail.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "Sunday.Fidelis@gmail.com",
                    Email = "Sunday.Fidelis@gmail.com",
                };
                IdentityResult identityResult = userManager.CreateAsync(user, "Password1").Result;
                if (identityResult.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Staff").Wait();
                }
            }

            if (userManager.FindByEmailAsync("Collins.Fidelis@gmail.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "Collins.Fidelis@gmail.com",
                    Email = "Collins.Fidelis@gmail.com",
                };
                IdentityResult identityResult = userManager.CreateAsync(user, "Password1").Result;
                
            }
        }
    }
}
