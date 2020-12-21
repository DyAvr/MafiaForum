using System.Threading.Tasks;
using MafiaForum.Models;
using Microsoft.AspNetCore.Identity;

namespace MafiaForum
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@gmail.com";
            string password = "123456";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("mister") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("mister"));
            }
            if (await roleManager.FindByNameAsync("madam") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("madam"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
