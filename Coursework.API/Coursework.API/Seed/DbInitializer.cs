using Core.Models.Origin;
using Microsoft.AspNetCore.Identity;

namespace Coursework.API.Seed
{
    public static class DbInitializer
    {
        public static void SeedUsers(UserManager<User> userManager)
        {
            const string adminEmail = "a@a.a",
                testUserEmail = "t@t.t";
            if (userManager.FindByEmailAsync(adminEmail).Result == null)
            {
                User user = new User
                {
                    UserName = adminEmail,
                    Email = adminEmail
                };

                IdentityResult result = userManager.CreateAsync(user, "123456").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }

            if (userManager.FindByEmailAsync(testUserEmail).Result == null)
            {
                User user = new User
                {
                    UserName = testUserEmail,
                    Email = testUserEmail
                };

                IdentityResult result = userManager.CreateAsync(user, "123456").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                }
            }
        }
    }
}
