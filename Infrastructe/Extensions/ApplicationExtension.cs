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
            const string adminUser = "Admin";
            const string adminPassword = "Admin+123456";

            UserManager<IdentityUser> userManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
            RoleManager<IdentityRole> roleManager = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            
            IdentityUser user = await userManager.FindByNameAsync(adminUser);
            if (user is null)
            {
                user = new IdentityUser()
                {
                    Email = "eyuphan@example.com",
                    PhoneNumber = "1234567890",
                    UserName = adminUser
                };

                var result = await userManager.CreateAsync(user, adminPassword);
                if (!result.Succeeded)
                {
                    throw new System.Exception("User creation failed!");
                }

             var roleResult = await userManager.AddToRolesAsync(user,  //??
             roleManager.Roles.Select(r => r.Name).ToList());


                if (!roleResult.Succeeded)
                {
                    throw new System.Exception("Role assignment failed!");
                }
            }
        }

    }

 }