using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Proje.Infrastructure.Extensions
{

    public static class ApplicationExtension
    {
        public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
        {
            RepositoryContext context = app.ApplicationServices
            .CreateScope().ServiceProvider.GetRequiredService<RepositoryContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }

        public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
        {
            System.Console.WriteLine("fonksiyona girdi !");
            const string adminUser = "admin";
            const string adminPassword = "adminpassword";

            UserManager<IdentityUser> userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            RoleManager<IdentityRole> roleManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            System.Console.WriteLine("user tanımlanmadan önce!");

            IdentityUser user = await userManager.FindByNameAsync(adminUser);
            if (user is null)
            {
                System.Console.WriteLine("user null !");

                System.Console.WriteLine("Admin user not found. Creating admin user...");
                user = new IdentityUser()
                {

                    Email = "eyuphan@example.com",
                    PhoneNumber = "1234567890",
                    UserName = "adminUser",
                };
                var result = await userManager.CreateAsync(user, adminPassword);
                System.Console.WriteLine("succed öncesi !");

                if (!result.Succeeded)
                {
                    System.Console.WriteLine("hata 1 numara !");//burada kalıyor
                    throw new System.Exception("User creation failed!");
                }
                System.Console.WriteLine("Admin user created successfully!");

                var roleResult = await userManager.AddToRolesAsync(user,
                roleManager.Roles.Select(r => r.Name).ToList()
                );
                if (!roleResult.Succeeded)
                {
                    System.Console.WriteLine("hata 2 numara !");

                    throw new System.Exception("Role assignment failed!");
                }
            }
        }


    }
}