using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_953504_Kozlovski.Entities;

namespace WEB_953504_Kozlovski.Data
{
    public class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            // create a database if it has not been created yet
            context.Database.EnsureCreated();
            // checking for roles
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                // create admin role
                await roleManager.CreateAsync(roleAdmin);
            }
            // checking the availability of users
            if (!context.Users.Any())
            {
                // create user user@mail.ru
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");
                // create user admin@mail.ru
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                // assign role admin
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }

            // checking for the presence of groups of objects
            if (!context.Brands.Any())
            {
                context.Brands.AddRange(
                new List<Brand>
                {
                    new Brand { BrandName = "Apple" },
                    new Brand { BrandName = "ASUS" },
                    new Brand { BrandName = "Lenovo" },
                    new Brand { BrandName = "Xiaomi" },
                    new Brand { BrandName = "HP" },
                    new Brand { BrandName = "Dell" }
                });
                await context.SaveChangesAsync();
            }
            // check for the presence of objects
            if (!context.Notebooks.Any())
            {
                context.Notebooks.AddRange(
                new List<Notebook>
                {
                    new Notebook { NotebookName = "Apple MacBook Pro", Description = "Normal notebook",
                    Price = 2000, BrandId = 1, Image = "MacBookPro.jpg" },
                    new Notebook { NotebookName = "ASUS ZenBook", Description = "The best notebook",
                    Price = 2500, BrandId = 2, Image = "ZenBook.jpg" },
                    new Notebook { NotebookName = "Lenovo ThinkPad", Description = "Good notebook for work",
                    Price = 1000, BrandId = 3, Image = "ThinkPad.jpg" },
                    new Notebook { NotebookName = "Lenovo IdeaPad", Description = "Good notebook for regular user",
                     Price = 700, BrandId = 3, Image = "IdeaPad.jpg" },
                    new Notebook { NotebookName = "Xiaomi RedmiBook Pro", Description = "Good notebook",
                     Price = 2500, BrandId = 4, Image = "RedmiBookPro.jpg" },
                    new Notebook { NotebookName = "Xiaomi Mi Notebook Pro", Description = "Fast notebook",
                     Price = 3000, BrandId = 4, Image = "MiNotebookPro.jpg" },
                    new Notebook { NotebookName = "HP Pavilion", Description = "Unknown notebook",
                     Price = 900, BrandId = 5, Image = "Pavilion.jpg" }
                });
                await context.SaveChangesAsync();
            }
        }
    }
}
