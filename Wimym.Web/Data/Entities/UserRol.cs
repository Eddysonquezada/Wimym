namespace Wimym.Web.Data.Entities
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserRol
    {
        public List<SelectListItem> userRols;

        public UserRol()
        {
            userRols = new List<SelectListItem>();
        }

        public async Task<List<SelectListItem>> GetRol(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            string iD)
        {
            userRols = new List<SelectListItem>();
            string rol;
            var user = await userManager.FindByIdAsync(iD);
            var rols = await userManager.GetRolesAsync(user);

            if (rols.Count == 0)
            {
                userRols.Add(new SelectListItem()
                {
                    Value = "null",
                    Text = "No Rols"
                });
            }
            else
            {
                rol = Convert.ToString(rols[0]);
                var rolId = roleManager.Roles.Where(m => m.Name == rol);

                foreach (var item in rolId)
                {
                    userRols.Add(new SelectListItem()
                    {
                        Value = item.Id,
                        Text = item.Name
                    });

                }
            }

            return userRols;

        }

        public List<SelectListItem> Rols(RoleManager<IdentityRole> roleManager)
        {
            var rols = roleManager.Roles.ToList();
            foreach (var item in rols)
            {
                userRols.Add(
                    new SelectListItem()
                    {
                        Value = item.Id,
                        Text = item.Name
                    });
            }
            return userRols;
        }

    }
}
