using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bloggy.Models.Contexts
{
    public class AppDbContext: IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //This will pass any options passed in the constructor to the base class DbContext
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Investigation> Investigations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Setup schemd for identity framework
            base.OnModelCreating(modelBuilder);

            //Seed roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "d234f58e-7373-4ee5-98f0-c17892784b05", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN" },
                new IdentityRole() { Id = "1db56103-a3e2-4edc-afab-abde856cebe0", Name = "User", ConcurrencyStamp = "1", NormalizedName = "USER" }
            );


            //Seed admin user
            IdentityUser user = new IdentityUser()
            {
                Id = "134c1566-3f64-4ab4-b1e7-2ffe11f43e32", //https://www.guidgenerator.com/online-guid-generator.aspx
                UserName = "admin@mail.com", //Has to be the email address for the login logic to work
                NormalizedUserName = "ADMIN@MAIL.COM ",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM",
                LockoutEnabled = false,
                EmailConfirmed = true,
                PhoneNumber = ""
            };

            PasswordHasher<IdentityUser> passwordHasher = new PasswordHasher<IdentityUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "S@fePassw0rd1"); //make sure you adhere to policies (incl confirmed etc…)
            modelBuilder.Entity<IdentityUser>().HasData(user);

            //Assign existing user to the admin role
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "d234f58e-7373-4ee5-98f0-c17892784b05", UserId = "134c1566-3f64-4ab4-b1e7-2ffe11f43e32" }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    Name = "Uncategorised"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Comedy"
                },
                new Category()
                {
                    Id = 3,
                    Name = "News"
                }
            );

            modelBuilder.Entity<Report>().HasData(
                new Report()
                {
                    Id = 1,
                    Title = "AGA Today",
                    Content = "Today's AGA is characterized by a series of discussions and debates around ...",
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    ImageUrl = "/images/seed1.jpg",
                    CategoryId = 1,
                    UserId = "134c1566-3f64-4ab4-b1e7-2ffe11f43e32"
                },
                new Report()
                {
                    Id = 2,
                    Title = "Traffic is incredible",
                    Content = "Today's traffic can't be described using words. Only an image can do that ...",
                    CreatedDate = DateTime.UtcNow.AddDays(-1),
                    UpdatedDate = DateTime.UtcNow,
                    ImageUrl = "/images/seed2.jpg",
                    CategoryId = 2,
                    UserId = "134c1566-3f64-4ab4-b1e7-2ffe11f43e32"
                },
                new Report()
                {
                    Id = 3,
                    Title = "When is Spring really starting?",
                    Content = "Clouds clouds all around us. I thought spring started already, but ...",
                    CreatedDate = DateTime.UtcNow.AddDays(-2),
                    UpdatedDate = DateTime.UtcNow,
                    ImageUrl = "/images/seed3.jpg",
                    CategoryId = 3,
                    UserId = "134c1566-3f64-4ab4-b1e7-2ffe11f43e32"
                }
            );
        }


    }
}
