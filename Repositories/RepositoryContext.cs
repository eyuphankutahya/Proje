using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class RepositoryContext : DbContext
    {

        public RepositoryContext()
        {

        }

        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options) { }

        public DbSet<Giris> GirisModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Giris>().
            HasData(
                new Giris()
                {
                    Id = 1,
                    Username = "admin",
                    Password = "Password",
                    Email = "admin@gmail.com"
                },
                new Giris()
                {
                    Id = 2,
                    Username = "user",
                    Password = "userpassword",
                    Email = "user@gmail.com"
                });
        }

    }


}