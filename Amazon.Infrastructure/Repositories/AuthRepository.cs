using Amazon.Core.Entities.Identity;
using Amazon.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Infrastructure.Repositories
{
    public class AuthRepository :IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;

    public AuthRepository(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ApplicationUser> FindByEmailAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }

    public async Task<IdentityResult> CreateAsync(ApplicationUser user, string password)
    {
        return await _userManager.CreateAsync(user, password);
    }
}
}
