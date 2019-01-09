using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Wimym.DatabaseContext;
using Wimym.Model.Shared;

namespace Wimym.Services
{
    public interface IUserService
    {
        Task<UserDto> Get(string id);
        Task<bool> PartialUpdate(string id, UserPartialDto model);
    }

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(
            ApplicationDbContext context
        )
        {
            _context = context;
        }

        public async Task<UserDto> Get(string id)
        {
            var result = new UserDto();

            try
            {
                var user = await _context.Users.SingleAsync(x => x.Id == id);
                result = Mapper.Map<UserDto>(user);
            }
            catch (Exception e)
            {
                // Error logging
            }

            return result;
        }

        public async Task<bool> PartialUpdate(string id, UserPartialDto model)
        {
            var result = false;

            try
            {
                var user = await _context.Users.SingleAsync(x => x.Id == id);

                if (model.Name != null)
                    user.Name = model.Name;

                if (model.Lastname != null)
                    user.LastName = model.Lastname;

                //if (model.AboutUs != null)
                //    user.ab = model.AboutUs;

                if (model.Image != null)
                    user.Image = model.Image;

                _context.Update(user);
                await _context.SaveChangesAsync();

                result = true;
            }
            catch (Exception e)
            {
                // Error logging
            }

            return result;
        }
    }
}
