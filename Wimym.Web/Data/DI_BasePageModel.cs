namespace Wimym.Back.Data
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Wimym.Web.Data;
    using Wimym.Web.Data.Entities;

    public class DI_BasePageModel : Controller
    {
        protected DataContext Context
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
        DataContext context,
        IAuthorizationService authorizationService,
        UserManager<ApplicationUser> userManager) : base()
        {
            Context = context;
            UserManager = userManager;
            AuthorizationService = authorizationService;
        }
    }
}
