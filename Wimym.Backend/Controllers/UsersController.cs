using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wimym.Backend.Data;
using Wimym.Backend.Models;

namespace Wimym.Backend.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        UserManager<ApplicationUser> _userManager;
        RoleManager<IdentityRole> _roleManager;
        UserRol _userRol;
        public List<SelectListItem> userRol;

        public UsersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _userRol = new UserRol();
            userRol = new List<SelectListItem>();
        }

        public async Task<IActionResult> Index()
        {
            var ID = "";
            var users = new List<User>();
            var appUser = await _context.ApplicationUsers.ToListAsync();

            foreach (var item in appUser)
            {
                ID = item.Id;
                userRol = await _userRol.GetRol(_userManager, _roleManager, ID);
                users.Add(new User()
                {
                    Id = item.Id,
                    UserName = item.UserName,
                    PhoneNumber = item.PhoneNumber,
                    Email = item.Email,
                    Rol = userRol[0].Text
                });
            }

            return View(users.ToList());
        }

        public async Task<List<ApplicationUser>> GetUsers(string id)
        {
            var user = new List<ApplicationUser>();
            var appUser = await _context.ApplicationUsers.SingleOrDefaultAsync(m => m.Id == id);
            user.Add(appUser);
            return user;
        }

        public async Task<string> EditUser(string id, string userName, string email, string phoneNumber, int accessFailedCount,
           string concurrencyStamp,
           bool emailConfirmed,
           bool lockoutEnabled,
           DateTimeOffset lockoutEnd,
           string normalizedUserName,
           string normalizedEmail,
           string passwordHash,
           bool phoneNumberConfirmed,
           string securityStamp,
           bool twoFactorEnabled,
           ApplicationUser applicationUser)
        {
            var resp = "";

            try
            {
                applicationUser = new ApplicationUser
                {
                    Id = id,
                    UserName = userName,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    EmailConfirmed = emailConfirmed,
                    LockoutEnabled = lockoutEnabled,
                    LockoutEnd = lockoutEnd,
                    NormalizedEmail = normalizedEmail,
                    NormalizedUserName = normalizedUserName,
                    PasswordHash = passwordHash,
                    PhoneNumberConfirmed = phoneNumberConfirmed,
                    SecurityStamp = securityStamp,
                    TwoFactorEnabled = twoFactorEnabled,
                    AccessFailedCount = accessFailedCount,
                    ConcurrencyStamp = concurrencyStamp
                };

                _context.Update(applicationUser);
                await _context.SaveChangesAsync();
                resp = "Saved";

            }
            catch (Exception ex)
            {

                resp = ex.Message;
            }
            return resp;
        }



        private bool ApplicationUserExists(string id)
        {
            return _context.ApplicationUsers.Any(e => e.Id == id);
        }
    }
}