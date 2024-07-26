using System.Reflection;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class RepositoryContext : IdentityDbContext<IdentityUser>
    {

        public RepositoryContext()
        {

        }

        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }

        public DbSet<Giris> GirisModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            // modelBuilder.Entity<Giris>().
            //  HasData(
            //      new Giris()
            //      {
            //          Id = 1,
            //          Username = "admin",
            //          Password = "Password",
            //          Email = "admin@gmail.com"
            //      },
            //      new Giris()
            //      {
            //          Id = 2,
            //          Username = "user",
            //          Password = "userpassword",
            //          Email = "user@gmail.com"
            //      });
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
