using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopDemo.Data;
using WebShopDemo.Domain;

namespace WebShopDemo.Infrastucture
{
    public static class ApplicationBuilderExtension
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var services = serviceScope.ServiceProvider;

            await RoleSeeder(services);
            await SeedAdministrator(services);

            var dataCategory = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedCategories(dataCategory);

            var dataBrand = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedCategories(dataBrand);

            return app;
        }

        private static void SeedCategories(ApplicationDbContext data)
        {
            if (data.Categories.Any())
            {
                return;
            }
            data.Categories.AddRange(new[]
            {
                new Category {CategoryName="Laptop"},
                new Category {CategoryName="Computer"},
                new Category {CategoryName="Monitor"},
                new Category {CategoryName="Accessory"},
                new Category {CategoryName="TV"},
                new Category {CategoryName="Mobile phone"},
                new Category {CategoryName="Smart watch"}
            });
            data.SaveChanges();
        }

        private static void SeedBrands(ApplicationDbContext data)
        {
            if (data.Brands.Any())
            {
                return;
            }
            data.Brands.AddRange(new[]
            {
                new Brand {BrandName="Acer"},
                new Brand {BrandName="Asus"},
                new Brand {BrandName="Apple"},
                new Brand {BrandName="Dell"},
                new Brand {BrandName="HP"},
                new Brand {BrandName="Huawei"},
                new Brand {BrandName="Lenovo"},
                new Brand {BrandName="Samsung"},
            });
            data.SaveChanges();
        }

        private static async Task RoleSeeder(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roleNames = { "Administrator", "Client" };

            IdentityResult roleResult;

            foreach (var role in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);

                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }
        private static async Task SeedAdministrator(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            if (await userManager.FindByNameAsync("admin") == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "Paola";
                user.LastName = "Vasileva";
                user.PhoneNumber = "0885556549";
                user.UserName = "admin";
                user.Email = "admin@admin.com";

                var result = await userManager.CreateAsync
                (user, "Admin123456");

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }
    }
}

