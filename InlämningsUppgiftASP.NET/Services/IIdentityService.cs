using InlämningsUppgiftASP.NET.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InlämningsUppgiftASP.NET.Services
{
    public interface IIdentityService
    {
        Task CreateDefaultAccountAndRolesAsync();

        Task<IdentityResult> CreateNewUserAsync(ApplicationUser User, string Password);
        Task CreateNewRole(String RoleName);
        Task AssignUserToRoleAsync(ApplicationUser User, String RoleName);

        IEnumerable<ApplicationUser> GetAllUsers();
        IEnumerable<IdentityRole> GetAllRoles();

        // Task<IEnumerable<UserViewModel>> GetAllUsersWithRolesAsync();
    }
}
