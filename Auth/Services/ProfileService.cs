using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Wimym.Model.Domain;

namespace Auth.Services
{
    public class ProfileService : IProfileService
    {
        protected UserManager<ApplicationUser> _userManager;
        public ProfileService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var user = _userManager.GetUserAsync(context.Subject).Result;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Uri, user.SeoUrl),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim("ImageProfile", user.Image ?? "")
            };

            context.IssuedClaims.AddRange(claims);
            return Task.FromResult(0);
        }

        public Task IsActiveAsync(IsActiveContext context)
        {
            //in case you want to implement a logic for banner users
           // context.IsActive = !user.isbanned;
            var user = _userManager.GetUserAsync(context.Subject).Result;
            context.IsActive = true;
            return Task.FromResult(0);
        }
    }
}
