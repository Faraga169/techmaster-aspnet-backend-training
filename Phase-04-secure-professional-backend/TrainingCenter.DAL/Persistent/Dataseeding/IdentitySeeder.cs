using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TrainingCenter.DAL.Persistent.Models;

namespace TrainingCenter.DAL.Persistent.Dataseeding
{
    public class IdentitySeeder
    {
        public static async Task SeedAsync( UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            
            string[] roles =
            {
                "Admin",
                "Instructor",
                "Student"
            };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Admin
            await CreateUserAsync(
                userManager,
                "admin@techmaster.com",
                "Admin123!",
                "Admin"
            );

            // Instructor
            await CreateUserAsync(
                userManager,
                "instructor@techmaster.com",
                "Instructor123!",
                "Instructor"
            );

            // Student
            await CreateUserAsync(
                userManager,
                "student@techmaster.com",
                "Student123!",
                "Student"
            );
        }

        private static async Task CreateUserAsync(UserManager<ApplicationUser> userManager,string email,string password,string role)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user is null)
            {
                user = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow
                };

                var result = await userManager.CreateAsync(user, password);

                if (!result.Succeeded)
                {
                    var errors = string.Join(
                        ", ",
                        result.Errors.Select(e => e.Description)
                    );

                    throw new Exception(
                        $"Failed to create {role} user: {errors}");
                }
            }

            if (!await userManager.IsInRoleAsync(user, role))
            {
                await userManager.AddToRoleAsync(user, role);
            }
        }
    }
}
