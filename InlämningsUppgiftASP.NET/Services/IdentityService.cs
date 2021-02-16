using InlämningsUppgiftASP.NET.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InlämningsUppgiftASP.NET.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager  )
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task AssignUserToRoleAsync(ApplicationUser User, string RoleName)
        {
            await _userManager.AddToRoleAsync(User, RoleName);
        }


        // Admin account : UserName = admin@domain.com Password = ChangeMe123!
        public async Task CreateDefaultAccountAndRolesAsync()
        {
            if (!_userManager.Users.Any())
            {
                // If no user exist make an admin account with UserName admin@domain.com
                var user = new ApplicationUser() { UserName = "admin@domain.com", Email = "admin@domain.com", FirstName = "Admin", LastName = "Account", DateOfBirth = DateTime.Now };

                // set the admin account password too ChangeMe123!
                var result = await _userManager.CreateAsync(user, "ChangeMe123!");
                if (result.Succeeded)
                {
                    // Create the basic roles Admin and User if none exist 
                    if (!_roleManager.Roles.Any())
                    {
                        await _roleManager.CreateAsync(new IdentityRole("Admin"));
                        await _roleManager.CreateAsync(new IdentityRole("User"));

                        //As Student and Teacher is needed in the assignment i will Create them at the same time as the two basic roles 

                        await _roleManager.CreateAsync(new IdentityRole("Student"));
                        await _roleManager.CreateAsync(new IdentityRole("Teacher"));

                    }

                    // set the admin account too role Admin
                    await _userManager.AddToRoleAsync(user, "Admin");

                }
            }
        }

        public async Task CreateNewRole(string RoleName)
        {
            await _roleManager.CreateAsync(new IdentityRole(RoleName));
        }

        public async Task<IdentityResult> CreateNewUserAsync(ApplicationUser User, string Password)
        {
            return await _userManager.CreateAsync(User, Password);
        }

        public IEnumerable<IdentityRole> GetAllRoles()
        {
            return _roleManager.Roles;
        }

        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return _userManager.Users;
        }
    }
}
