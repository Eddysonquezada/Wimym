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

        public async Task<List<User>> GetUsers(string id)
        {
            var user = new List<User>();
            var appUser = await _context.ApplicationUsers.SingleOrDefaultAsync(m => m.Id == id);
            userRol = await _userRol.GetRol(_userManager, _roleManager, id);

            user.Add(new User()
            {
                Id = appUser.Id,
                UserName = appUser.UserName,
                PhoneNumber = appUser.PhoneNumber,
                Email = appUser.Email,
                Rol = userRol[0].Text,
                RolId = userRol[0].Value,
                AccessFailedCount = appUser.AccessFailedCount,
                ConcurrencyStamp = appUser.ConcurrencyStamp,
                EmailConfirmed = appUser.EmailConfirmed,
                LockoutEnabled = appUser.LockoutEnabled,
                LockoutEnd = appUser.LockoutEnd,
                NormalizedEmail = appUser.NormalizedEmail,
                NormalizedUserName = appUser.NormalizedUserName,
                PasswordHash = appUser.PasswordHash,
                PhoneNumberConfirmed = appUser.PhoneNumberConfirmed,
                SecurityStamp = appUser.SecurityStamp,
                TwoFactorEnabled = appUser.TwoFactorEnabled
            });

            return user;
        }

        public async Task<List<SelectListItem>> GetRols()
        {
            var rolsList = new List<SelectListItem>();
            rolsList = _userRol.Rols(_roleManager);
            return rolsList;
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
       bool twoFactorEnabled, string selectRol,
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

                var user = await _userManager.FindByIdAsync(id);
                userRol = await _userRol.GetRol(_userManager, _roleManager, id);
                if (userRol[0].Text != "No Role")
                {
                    await _userManager.RemoveFromRoleAsync(user, userRol[0].Text);
                }
                if (selectRol == "No Role")
                {
                    selectRol = "User";
                }

                var result = await _userManager.AddToRoleAsync(user, selectRol);

                resp = "Saved";

            }
            catch (Exception ex)
            {
                resp = ex.Message;
            }
            return resp;
        }

        public async Task<string> DeleteUser(string id)
        {
            var resp = "";
            try
            {
                var applicationUser = await _context.ApplicationUsers.SingleOrDefaultAsync(m => m.Id == id);
                _context.ApplicationUsers.Remove(applicationUser);
                await _context.SaveChangesAsync();
                resp = "Delete";
            }
            catch (Exception)
            {
                resp = "NoDelete";
            }
            return resp;
        }

        public async Task<string> CreateUser(string email, string phoneNumber, string passwordHash, string selectRol, ApplicationUser applicationUser)
        {
            var resp = "";
            applicationUser =
                new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    PhoneNumber = phoneNumber
                };
            var result = await _userManager.CreateAsync(applicationUser, passwordHash);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(applicationUser, selectRol);
                resp = "Save";
            }
            else
            {
                resp = "NoSave";
            }
            return resp;
        }

        private bool ApplicationUserExists(string id)
        {
            return _context.ApplicationUsers.Any(e => e.Id == id);
        }
    }
}