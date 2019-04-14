namespace Wimym.Web.Config
{
    using AutoMapper;
    using Wimym.Web.Data.Entities;
    using Wimym.Web.Dtos;

    public class MyMaps
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ApplicationUser, UserDto>();
                cfg.CreateMap<UserDto, ApplicationUser>();
            });
        }
    }
}
