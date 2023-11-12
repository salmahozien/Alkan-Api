using flutterApi.Models;
using login.Models;
using Microsoft.AspNetCore.Identity;

namespace flutterApi.Seeds
{
    public class DefaultUsers
    {
        public static async Task SeedAdminUserAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var defaultUser = new User
            {
                FirstName = "Admin",
                LastName = "User",
                UserName = "admin@Alkan-eg.com",
                Email = "admin@Alkan-eg.com",
                EmailConfirmed = true,
                PhoneNumber = "0123456789",
                PhoneNumberConfirmed = true


            };

            var user = await userManager.GetPhoneNumberAsync(defaultUser);

            if (user == null)
            {
                var result = await userManager.CreateAsync(defaultUser, "0123456789");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(defaultUser, "Admin");
                }
            }
        }

        public static async Task SeedSuperAdminAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var defaultUser = new User
            {
                FirstName = "Super",
                LastName = "Admin",
                UserName = "admin@Yildiz-eg.com",
                Email = "admin@Yildiz-eg.com",
                EmailConfirmed = true,
                PhoneNumber = "11111",
                PhoneNumberConfirmed = true
            };

            var user = await userManager.GetPhoneNumberAsync(defaultUser);

            if (user == null)
            {
                var result = await userManager.CreateAsync(defaultUser, "11111");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(defaultUser, "SuperAdmin");
                    await userManager.AddToRoleAsync(defaultUser, "Admin");
                }
            }
        }

        public static async Task SeedUserAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var defaultUser = new User
            {
                FirstName = "User",
                LastName = "User",
                UserName = "User@User-eg.com",
                Email = "User@User-eg.com",
                EmailConfirmed = true,
                PhoneNumber = "00000",
                PhoneNumberConfirmed = true
            };
            var user = await userManager.GetPhoneNumberAsync(defaultUser);

            if (user == null)
            {
                var result = await userManager.CreateAsync(defaultUser, "00000");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(defaultUser, "User");
                }
            }
        }
    }
}
