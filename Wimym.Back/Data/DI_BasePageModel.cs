using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wimym.Back.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Back.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class DI_BasePageModel : Controller
    {
        protected ApplicationDbContext Context
        {
            get;
        }
        protected IAuthorizationService AuthorizationService
        {
            get;
        }
        protected UserManager<ApplicationUser> UserManager
        {
            get;
        }

        public DI_BasePageModel(
        ApplicationDbContext context,
        IAuthorizationService authorizationService,
        UserManager<ApplicationUser> userManager) : base()
        {
            Context = context;
            UserManager = userManager;
            AuthorizationService = authorizationService;
        }
    }
}
