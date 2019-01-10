namespace Wimym.Api.Config
{
    using AutoMapper;
    using Model.Domain._Control;
    using Model.Shared._Control;

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
