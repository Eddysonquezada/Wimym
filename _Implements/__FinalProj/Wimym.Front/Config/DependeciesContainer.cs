namespace Wimym.Front.Config
{
    using Common;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependeciesContainer
    {
        public static void AddMyDependencies(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            #region Current User
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ICurrentUserFactory, CurrentUserFactory>();
            #endregion

            
        }
    }
}
