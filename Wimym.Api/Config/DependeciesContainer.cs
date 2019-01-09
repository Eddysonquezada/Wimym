using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wimym.Common;
using Wimym.Services;

namespace Wimym.Api.Config
{
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
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<ILikeService, LikeService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IReportService, ReportService>();
            #endregion 
        }
    }
}
