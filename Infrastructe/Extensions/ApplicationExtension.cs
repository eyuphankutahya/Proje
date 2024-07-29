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


        // default admin kısmını tekrar düzenle user oluşturma ksımında exeption fırlatıyor
        public static async void ConfigureDefaultAdminUser(this IApplicationBuilder app)
        {
            System.Console.WriteLine("fonksiyona girdi !");
            const string adminUser = "Admin";
            const string adminPassword = "Admin+123456";

            UserManager<IdentityUser> userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            RoleManager<IdentityRole> roleManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            System.Console.WriteLine("user tanımlanmadan önce!");

            // if (!await roleManager.RoleExistsAsync("ADMIN"))
            // {
            //     var roleResult = await roleManager.CreateAsync(new IdentityRole("ADMIN"));
            //     if (!roleResult.Succeeded)
            //     {
            //         throw new Exception("Failed to create ADMIN role");
            //     }
            // }  hata var diye gptt ekledi ??

            var user = await userManager.FindByNameAsync(adminUser);
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
                    System.Console.WriteLine("hata 1 numara !");
                    throw new System.Exception("User creation failed!");
                    // System.Console.WriteLine("hata 2 numara !");
                }



                System.Console.WriteLine("Admin user created successfully!");
                System.Console.WriteLine("hata 4numara !");

                // if (!await userManager.IsInRoleAsync(user, "ADMIN"))
                // {
                //     var roleResult = await userManager.AddToRoleAsync(user, "ADMIN");
                //     if (!roleResult.Succeeded)
                //     {
                //         throw new Exception("Role assignment failed: " + string.Join(", ", roleResult.Errors.Select(e => e.Description)));
                //     }     gpt yaptı hata var diyee ??

                var roleResult = await userManager.AddToRolesAsync(user,  //??
                roleManager.Roles.Select(r => r.Name).ToList());
                System.Console.WriteLine("hata 5 numara !");


                if (!roleResult.Succeeded)
                {
                    System.Console.WriteLine("hata 3 numara !");

                    throw new System.Exception("Role assignment failed!");
                }
            }
        }

    }
}
// }