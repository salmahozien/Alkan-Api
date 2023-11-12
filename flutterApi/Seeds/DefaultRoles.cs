using Microsoft.AspNetCore.Identity;

namespace flutterApi.Seeds
{
    public class DefaultRoles
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManger)
        {
            if (!roleManger.Roles.Any())
            {
                await roleManger.CreateAsync(new IdentityRole("Admin"));
                await roleManger.CreateAsync(new IdentityRole("SuperAdmin"));
                await roleManger.CreateAsync(new IdentityRole("User"));
            }
        }
    }
}
