namespace Wimym.Back.Data
{
    using Back.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Wimym.Backend.Models;

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
