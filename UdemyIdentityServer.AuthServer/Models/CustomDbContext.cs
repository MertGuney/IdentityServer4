using Microsoft.EntityFrameworkCore;

namespace UdemyIdentityServer.AuthServer.Models
{
    public class CustomDbContext : DbContext
    {
        public CustomDbContext(DbContextOptions<CustomDbContext> options) : base(options)
        {
        }

        public DbSet<CustomUser> CustomUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomUser>().HasData(
                new CustomUser()
                {
                    Id = 1,
                    Email = "mduzel@gmail.com",
                    Username = "mduzel",
                    Password = "password",
                    City = "Ankara"
                },
                new CustomUser()
                {
                    Id = 2,
                    Email = "hcan@gmail.com",
                    Username = "hcan",
                    Password = "password",
                    City = "Istanbul"
                });
        }
    }
}
