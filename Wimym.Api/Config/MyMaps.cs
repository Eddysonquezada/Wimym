using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wimym.Model.Domain;
using Wimym.Model.Shared;

namespace Wimym.Api.Config
{
    public class MyMaps
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<ApplicationUser, UserDto>();
                cfg.CreateMap<UserDto, ApplicationUser>();
            });
        }
    }
}
