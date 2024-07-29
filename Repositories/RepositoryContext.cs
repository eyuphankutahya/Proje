using System.Reflection;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class RepositoryContext : IdentityDbContext<IdentityUser>
    {

        // public RepositoryContext()
        // {
        //??
        // }

        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
        public DbSet<Giris> GirisModel { get; set; }
        // ?? gerek yok gibi

        public DbSet<IdentityUser> IdentityUser { get; set; }

        public DbSet<IdentityRole> IdentityRole { get; set; }


    }
}
