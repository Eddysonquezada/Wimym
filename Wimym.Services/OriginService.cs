using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wimym.DatabaseContext;
using Wimym.Model.Domain._Control;
using Wimym.Model.Shared._Control;
using Wimym.Model.Shared.Helper;

namespace Wimym.Services
{
    public interface IOriginService
    {
        Task<bool> CreateAsync(OriginDto model);
        Task<IEnumerable<OriginList>> GetAllAsync(ApiFilter filter);
    }

    public class OriginService : IOriginService
    {
        private readonly ApplicationDbContext _context;

        public OriginService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(OriginDto model)
        {
            var result = false;

            try
            {
                _context.Origins.Add(new Origin
                {
                    Code = model.Code,
                    Name = model.Name,
                    Description = model.Description,
                    Simbol=model.Simbol
                });

                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                // Error logging
            }

            return result;
        }

        public async Task<IEnumerable<OriginList>> GetAllAsync(ApiFilter filter)
        {
            var result = new List<OriginList>();

            try
            {
                var _filter = new OriginListFilter();

                if (!string.IsNullOrEmpty(filter.Filter))
                {
                    _filter = JsonConvert.DeserializeObject<OriginListFilter>(filter.Filter);
                }
                var query = (
                    from u in _context.Origins
                    select new OriginList
                    {
                        Code = u.Code,
                        Name = u.Name,
                        Description = u.Description,
                        Simbol = u.Simbol
                    }).Take(filter.Take);
                //var query = (
                //    from c in _context.Origin
                //   // from u in _context.Users.Where(x => x.Id == c.UserId)
                //    select new OriginList
                //    {
                //        Code = c.Code,
                //        Name = c.Name,
                //        Description = c.Description,
                //        Simbol = c.Simbol
                //    }
                //).Take(filter.Take);
                //var origin =    _context.Origins.whe
                // Los parámetros del filtro todos deberían ser opcionales
                 query = query.Where(x => _filter.Code == null || x.Code == _filter.Code);

                result = await query.ToListAsync();
            }
            catch (Exception e)
            {
                // Error logging
            }

            return result;
        }
    }
}
