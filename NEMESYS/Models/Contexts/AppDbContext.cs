using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NEMESYS.Models.Interfaces;

namespace NEMESYS.Models.Contexts
{
    public class AppDbContext: IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //This will pass any options passed in the constructor to the base class DbContext
        }

        public DbSet<CampusCategory> CampusCategories { get; set; }

        public DbSet<Status> Statuses { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Investigation> Investigations { get; set; } 


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Setup schemd for identity framework
            base.OnModelCreating(modelBuilder);

            //Seed roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "d234f58e-7373-4ee5-98f0-c17892784b05", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN" },
                new IdentityRole() { Id = "1db56103-a3e2-4edc-afab-abde856cebe0", Name = "Reporter", ConcurrencyStamp = "1", NormalizedName = "REPORTER" },
                new IdentityRole() { Id = "90b7db83-4a71-4ef1-b3ae-07b481310175", Name = "Investigator", ConcurrencyStamp = "1", NormalizedName = "INVESTIGATOR" }

            );


            //Seed admin userAdmin
            ApplicationUser userAdmin = new ApplicationUser()
            {
                Id = "134c1566-3f64-4ab4-b1e7-2ffe11f43e32", //https://www.guidgenerator.com/online-guid-generator.aspx
                CustomUsername = "test",
                UserName = "admin@mail.com", //Has to be the email address for the login logic to work
                NormalizedUserName = "ADMIN@MAIL.COM",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM",
                LockoutEnabled = false,
                EmailConfirmed = true,
                PhoneNumber = ""
            };

            //Seed Investigator user
            ApplicationUser userInvestigator = new ApplicationUser()
            {
                Id = "357f9cab-c811-47c9-980b-6e500ef98cd8", //https://www.guidgenerator.com/online-guid-generator.aspx
                CustomUsername = "testInvestigator",
                UserName = "investigator@mail.com", //Has to be the email address for the login logic to work
                NormalizedUserName = "INVESTIGATOR@MAIL.COM",
                Email = "investigator@mail.com",
                NormalizedEmail = "INVESTIGATOR@MAIL.COM",
                LockoutEnabled = false,
                EmailConfirmed = true,
                PhoneNumber = ""
            };

            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            userAdmin.PasswordHash = passwordHasher.HashPassword(userAdmin, "S@fePassw0rd1"); //make sure you adhere to policies (incl confirmed etc…)
            userInvestigator.PasswordHash = passwordHasher.HashPassword(userInvestigator, "S@fePassw0rd1");
            modelBuilder.Entity<ApplicationUser>().HasData(userAdmin,userInvestigator);

            //Assign existing userAdmin to the admin role and investigator to investigator role.
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "d234f58e-7373-4ee5-98f0-c17892784b05", UserId = "134c1566-3f64-4ab4-b1e7-2ffe11f43e32" },
                new IdentityUserRole<string>() { RoleId = "90b7db83-4a71-4ef1-b3ae-07b481310175", UserId = "357f9cab-c811-47c9-980b-6e500ef98cd8" }
            );

            modelBuilder.Entity<CampusCategory>().HasData(
                new CampusCategory() 
                {
                    Id = 1,
                    Name = "Msida Campus"
                },
                new CampusCategory()
                {
                    Id = 2,
                    Name = "Valletta Campus"
                },
                new CampusCategory()
                {
                    Id = 3,
                    Name = "Marsaxlokk Campus"
                },
                new CampusCategory()
                {
                    Id = 4,
                    Name = "Gozo Campus"
                }
            );
            modelBuilder.Entity<Status>().HasData(
              new Status()
              {
                  Id = 1,
                  Name = "Being Investigated"
              },
              new Status()
              {
                  Id = 2,
                  Name = "No Action Required"
              },
              new Status()
              {
                  Id = 3,
                  Name = "Closed"
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
                    CampusCategoryId = 1,
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
                    CampusCategoryId = 2,
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
                    CampusCategoryId = 3,
                    UserId = "134c1566-3f64-4ab4-b1e7-2ffe11f43e32"
                }
            );
        }


    }
}
