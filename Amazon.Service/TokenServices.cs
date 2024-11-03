﻿using Amazon.Core.Contract.Services;
using Amazon.Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Service
{
    public class TokenServices : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> CreateTokenAsync(ApplicationUser user, UserManager<ApplicationUser> userManager)
        {

            //1. Header
            //2. Payload
            //2.1 Private Claims (ده user الخاصه بال )
            var AuthClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.GivenName , user.DisplayName),
                new Claim(ClaimTypes.Email,user.Email),
            };

            var UserRoles = await userManager.GetRolesAsync(user);

            foreach (var Role in UserRoles)
            {
                AuthClaims.Add(new Claim(ClaimTypes.Role, Role));
            }

            //3. Signature 
            //3.1 Key
            var AuthKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var Token = new JwtSecurityToken(
               issuer: _configuration["JWT:ValidIssuer"],
               audience: _configuration["JWT:ValidAudience"],
               expires: DateTime.Now.AddDays(double.Parse(_configuration["JWT:DurationInDays"])),
               claims: AuthClaims,
               signingCredentials: new SigningCredentials(AuthKey, SecurityAlgorithms.HmacSha256Signature)
               );
            return new JwtSecurityTokenHandler().WriteToken(Token);
        }
    }
}
