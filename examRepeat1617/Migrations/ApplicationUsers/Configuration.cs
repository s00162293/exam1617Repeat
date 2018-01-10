namespace examRepeat1617.Migrations.ApplicationUsers
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<examRepeat1617.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\ApplicationUsers";
        }

        protected override void Seed(examRepeat1617.Models.ApplicationDbContext context)
        {
         
            var manager =
                 new UserManager<ApplicationUser>(
                     new UserStore<ApplicationUser>(context));

            var roleManager =
                new RoleManager<IdentityRole>(
                    new RoleStore<IdentityRole>(context));



            roleManager.Create(new IdentityRole { Name = "Lecturer" });
            roleManager.Create(new IdentityRole { Name = "StudentRole" });

            context.Users.AddOrUpdate(u => u.Email, new ApplicationUser
            {
                Email = "S12345678@mail.itsligo.ie",
                EmailConfirmed = true,
                UserName = "S12345678@mail.itsligo.ie",
                PasswordHash = new PasswordHasher().HashPassword("Ss1234567$1"),
                lecturerId= 1,
                SecurityStamp = Guid.NewGuid().ToString(),
            });

            context.Users.AddOrUpdate(u => u.Email, new ApplicationUser
            {

                Email = "S00000001@mail.itsligo.ie",
                EmailConfirmed = true,
                UserName = "S00000001@mail.itsligo.ie",
                PasswordHash = new PasswordHasher().HashPassword("SS00000001$1"),
                studentId= "s0001",
                SecurityStamp = Guid.NewGuid().ToString(),
            });
            context.SaveChanges();
            ApplicationUser lecturer = manager.FindByEmail("S12345678@mail.itsligo.ie");
            if (lecturer != null)
            {
                manager.AddToRoles(lecturer.Id, new string[] { "Lecturer" });
            }
            else
            {
                throw new Exception { Source = "Did not find Lecturer" };
            }

            ApplicationUser StudentRole = manager.FindByEmail("S00000001@mail.itsligo.ie");
            if (manager.FindByEmail("S00000001@mail.itsligo.ie") != null)
            {
                manager.AddToRoles(StudentRole.Id, new string[] { "StudentRole" });
            }

        


    }
}
}
