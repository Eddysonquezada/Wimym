namespace Wimym.Web.Config
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Wimym.Web.Interfaces;
    using Wimym.Web.Helpers;
    using Wimym.Web.Services;
    using Wimym.Web.Data.Repositories.Contracts;
    using Wimym.Web.Data.Repositories.Implementations;

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

            #region My services
            services.AddScoped<IUserService, UserService>();
            // services.AddTransient<SeedDb>();
            services.AddScoped<IReaction, ReactionRepository>();
            services.AddScoped<IUserHelper, UserHelper>();
            services.AddScoped<IMailHelper, MailHelper>();
            services.AddTransient<IEmailSender, EmailSender>();
            //services.AddScoped<IPhotoService, PhotoService>();
            //services.AddScoped<ILikeService, LikeService>();
            //services.AddScoped<ICommentService, CommentService>();
            //services.AddScoped<Services.IReportService, ReportService>();
            #endregion 
        }
    }
}
